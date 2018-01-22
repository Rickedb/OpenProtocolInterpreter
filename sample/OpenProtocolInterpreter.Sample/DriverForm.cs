using OpenProtocolInterpreter.MIDs;
using OpenProtocolInterpreter.Sample.Driver;
using OpenProtocolInterpreter.Sample.Driver.Events;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenProtocolInterpreter.Sample.Driver.Helpers;
using OpenProtocolInterpreter.MIDs.KeepAlive;
using System.Drawing;
using OpenProtocolInterpreter.MIDs.Tightening;
using OpenProtocolInterpreter.MIDs.Communication;
using OpenProtocolInterpreter.MIDs.Job;

namespace OpenProtocolInterpreter.Sample
{
    public partial class DriverForm : Form
    {
        private Timer keepAliveTimer;
        private OpenProtocolDriver driver;

        public DriverForm()
        {
            InitializeComponent();
            this.keepAliveTimer = new Timer();
            this.keepAliveTimer.Tick += KeepAliveTimer_Tick;
            this.keepAliveTimer.Interval = 1000;
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            //Added list of mids i want to use in my interpreter, every another will be desconsidered
            this.driver = new OpenProtocolDriver(new List<MID>()
            {
                new MIDs.Communication.MID_0002(),
                new MIDs.Communication.MID_0005(),
                new MIDs.Communication.MID_0004(),
                new MIDs.Communication.MID_0003(),

                new MIDs.ParameterSet.MID_0011(),
                new MIDs.ParameterSet.MID_0013(),

                new MIDs.Job.MID_0035(),
                new MIDs.Job.MID_0031(),

                new MIDs.Alarm.MID_0071(),
                new MIDs.Alarm.MID_0074(),
                new MIDs.Alarm.MID_0076(),

                new MIDs.VIN.MID_0052(),

                new MIDs.Tightening.MID_0061(),
                new MIDs.Tightening.MID_0065(),

                new MIDs.Time.MID_0081(),

                new MID_9999()
            });

            if (this.driver.BeginCommunication(new Ethernet.SimpleTcpClient().Connect(this.textIp.Text, 4545)))
            {
                this.keepAliveTimer.Start();
                this.connectionStatus.Text = "Connected!";
                this.connectionStatus.BackColor = Color.Green;
            }
            else
            {
                this.driver = null;
                this.connectionStatus.Text = "Disconnected!";
                this.connectionStatus.BackColor = Color.Red;
            }
        }

        private void KeepAliveTimer_Tick(object sender, EventArgs e)
        {
            if (this.driver.keepAlive.ElapsedMilliseconds > 10000) //10 sec
            {
                Console.WriteLine($"Sending Keep Alive...");
                var pack = this.driver.sendAndWaitForResponse(new MID_9999().buildPackage(), TimeSpan.FromSeconds(10));
                if (pack != null && pack.HeaderData.Mid == MID_9999.MID)
                {
                    lastMessageArrived.Text = MID_9999.MID.ToString();
                    Console.WriteLine($"Keep Alive Received");
                }
                else
                    Console.WriteLine($"Keep Alive Not Received");
            }
        }

        /// <summary>
        /// Job info subscribe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJobInfoSubscribe_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"Sending Job Info Subscribe...");
            var pack = this.driver.sendAndWaitForResponse(new MID_0034().buildPackage(), TimeSpan.FromSeconds(10));

            if (pack != null)
            {
                if (pack.HeaderData.Mid == MID_0004.MID)
                {
                    var mid04 = pack as MID_0004;
                    Console.WriteLine($@"Error while subscribing (MID 0004):
                                         Error Code: <{mid04.ErrorCode}>
                                         Failed MID: <{mid04.FailedMid}>");
                }
                else
                    Console.WriteLine($"Job Info Subscribe accepted!");
            }

            this.driver.AddUpdateOnReceivedCommand(typeof(MID_0035), this.onJobInfoReceived);
        }

        /// <summary>
        /// Tightening subscribe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTighteningSubscribe_Click(object sender, EventArgs e)
        {
            
            Console.WriteLine($"Sending Tightening Subscribe...");
            var pack = this.driver.sendAndWaitForResponse(new MID_0060().buildPackage(), TimeSpan.FromSeconds(10));

            if(pack != null)
            {
                if(pack.HeaderData.Mid == MID_0004.MID)
                {
                    var mid04 = pack as MID_0004;
                    Console.WriteLine($@"Error while subscribing (MID 0004):
                                         Error Code: <{mid04.ErrorCode}>
                                         Failed MID: <{mid04.FailedMid}>");
                }
                else
                    Console.WriteLine($"Tightening Subscribe accepted!");
            }
            
            //register command
            this.driver.AddUpdateOnReceivedCommand(typeof(MID_0061), this.onTighteningReceived);
        }

        /// <summary>
        /// Async method from controller, MID 0035 (Job Info)
        /// </summary>
        /// <param name="e"></param>
        private void onJobInfoReceived(MIDIncome e)
        {
            this.driver.sendMessage(e.Mid.BuildAckPackage());
            
            var jobInfo = e.Mid as MID_0035;
            lastMessageArrived.Text = MID_0035.MID.ToString();
            Console.WriteLine($@"JOB INFO RECEIVED (MID 0035): 
                                 Job ID: <{jobInfo.JobID}>
                                 Job Status: <{(int)jobInfo.JobStatus}> ({jobInfo.JobStatus.ToString()})
                                 Job Batch Mode: <{(int)jobInfo.JobBatchMode}> ({jobInfo.JobBatchMode.ToString()})
                                 Job Batch Size: <{jobInfo.JobBatchSize}>
                                 Job Batch Counter: <{jobInfo.JobBatchCounter}>
                                 TimeStamp: <{jobInfo.TimeStamp.ToString("yyyy-MM-dd:HH:mm:ss")}>");
        }

        /// <summary>
        /// Async method from controller, MID 0061 (Last Tightening)
        /// Basically, on every tightening this method will be called!
        /// </summary>
        /// <param name="e"></param>
        private void onTighteningReceived(MIDIncome e)
        {
            this.driver.sendMessage(e.Mid.BuildAckPackage());

            var tighteningMid = e.Mid as MID_0061;
            lastMessageArrived.Text = MID_0061.MID.ToString();
            Console.WriteLine($@"TIGHTENING RECEIVED (MID 0061): 
                                 Cell ID: <{tighteningMid.CellID}>
                                 Channel ID: <{tighteningMid.ChannelID}>
                                 Torque Controller Name: <{tighteningMid.TorqueControllerName}>
                                 VIN Number: <{tighteningMid.VINNumber}>
                                 Job ID: <{tighteningMid.JobID}>
                                 Parameter Set ID: <{tighteningMid.ParameterSetID}>
                                 Batch Size: <{tighteningMid.BatchSize}>
                                 Batch Counter: <{tighteningMid.BatchCounter}>
                                 Tightening Status: <{tighteningMid.TighteningStatus}>
                                 Torque Status: <{(int)tighteningMid.TorqueStatus}> ({tighteningMid.TorqueStatus.ToString()})
                                 Angle Status: <{(int)tighteningMid.AngleStatus}> ({tighteningMid.AngleStatus.ToString()})
                                 Torque Min Limit: <{tighteningMid.TorqueMinLimit}>
                                 Torque Max Limit: <{tighteningMid.TorqueMaxLimit}>
                                 Torque Final Target: <{tighteningMid.TorqueFinalTarget}>
                                 Torque: <{tighteningMid.Torque}>
                                 Angle Min Limit: <{tighteningMid.AngleMinLimit}>
                                 Angle Max Limit: <{tighteningMid.AngleMaxLimit}>
                                 Final Angle Target: <{tighteningMid.AngleFinalTarget}>
                                 Angle: <{tighteningMid.Angle}>
                                 TimeStamp: <{tighteningMid.TimeStamp.ToString("yyyy-MM-dd:HH:mm:ss")}>
                                 Last Change In Parameter Set: <{tighteningMid.LastChangeInParameterSet.ToString("yyyy-MM-dd:HH:mm:ss")}>
                                 Batch Status: <{(int)tighteningMid.BatchStatus}> ({tighteningMid.BatchStatus.ToString()})
                                 TighteningID: <{tighteningMid.TighteningID}>");
        }

    }
}
