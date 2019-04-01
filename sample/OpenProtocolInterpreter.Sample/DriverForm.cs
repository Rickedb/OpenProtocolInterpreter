using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Sample.Driver;
using OpenProtocolInterpreter.Sample.Driver.Events;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenProtocolInterpreter.Sample.Driver.Helpers;
using OpenProtocolInterpreter.KeepAlive;
using System.Drawing;
using OpenProtocolInterpreter.Tightening;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Job;
using OpenProtocolInterpreter.Sample.Driver.Commands;

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
            this.driver = new OpenProtocolDriver(new List<Mid>()
            {
                new Communication.Mid0002(),
                new Communication.Mid0005(),
                new Communication.Mid0004(),
                new Communication.Mid0003(),

                new ParameterSet.Mid0011(),
                new ParameterSet.Mid0013(),

                new Job.Mid0035(),
                new Job.Mid0031(),

                new Alarm.Mid0071(),
                new Alarm.Mid0074(),
                new Alarm.Mid0076(),

                new Vin.Mid0052(),

                new Tightening.Mid0061(),
                new Tightening.Mid0065(),

                new Time.Mid0081(),

                new Mid9999()
            });

            if (this.driver.BeginCommunication(new Ethernet.SimpleTcpClient().Connect(this.textIp.Text, (int)this.numericPort.Value)))
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
                var pack = this.driver.sendAndWaitForResponse(new Mid9999().Pack(), TimeSpan.FromSeconds(10));
                if (pack != null && pack.HeaderData.Mid == Mid9999.MID)
                {
                    lastMessageArrived.Text = Mid9999.MID.ToString();
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
            var pack = this.driver.sendAndWaitForResponse(new Mid0034().Pack(), TimeSpan.FromSeconds(10));

            if (pack != null)
            {
                if (pack.HeaderData.Mid == Mid0004.MID)
                {
                    var mid04 = pack as Mid0004;
                    Console.WriteLine($@"Error while subscribing (MID 0004):
                                         Error Code: <{mid04.ErrorCode}>
                                         Failed MID: <{mid04.FailedMid}>");
                }
                else
                    Console.WriteLine($"Job Info Subscribe accepted!");
            }

            this.driver.AddUpdateOnReceivedCommand(typeof(Mid0035), this.onJobInfoReceived);
        }

        /// <summary>
        /// Tightening subscribe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTighteningSubscribe_Click(object sender, EventArgs e)
        {
            
            Console.WriteLine($"Sending Tightening Subscribe...");
            var pack = this.driver.sendAndWaitForResponse(new Mid0060().Pack(), TimeSpan.FromSeconds(10));

            if(pack != null)
            {
                if(pack.HeaderData.Mid == Mid0004.MID)
                {
                    var mid04 = pack as Mid0004;
                    Console.WriteLine($@"Error while subscribing (MID 0004):
                                         Error Code: <{mid04.ErrorCode}>
                                         Failed MID: <{mid04.FailedMid}>");
                }
                else
                    Console.WriteLine($"Tightening Subscribe accepted!");
            }
            
            //register command
            this.driver.AddUpdateOnReceivedCommand(typeof(Mid0061), this.onTighteningReceived);
        }


        private void btnSendJob_Click(object sender, EventArgs e)
        {
            new SendJobCommand(this.driver).Execute((int)this.numericJob.Value);
        }

        /// <summary>
        /// Async method from controller, MID 0035 (Job Info)
        /// </summary>
        /// <param name="e"></param>
        private void onJobInfoReceived(MIDIncome e)
        {
            this.driver.sendMessage(e.Mid.BuildAckPackage());
            
            var jobInfo = e.Mid as Mid0035;
            lastMessageArrived.Text = Mid0035.MID.ToString();
            Console.WriteLine($@"JOB INFO RECEIVED (MID 0035): 
                                 Job ID: <{jobInfo.JobId}>
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

            var tighteningMid = e.Mid as Mid0061;
            lastMessageArrived.Text = Mid0061.MID.ToString();
            Console.WriteLine($@"TIGHTENING RECEIVED (MID 0061): 
                                 Cell ID: <{tighteningMid.CellId}>
                                 Channel ID: <{tighteningMid.ChannelId}>
                                 Torque Controller Name: <{tighteningMid.TorqueControllerName}>
                                 VIN Number: <{tighteningMid.VinNumber}>
                                 Job ID: <{tighteningMid.JobId}>
                                 Parameter Set ID: <{tighteningMid.ParameterSetId}>
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
                                 TimeStamp: <{tighteningMid.Timestamp.ToString("yyyy-MM-dd:HH:mm:ss")}>
                                 Last Change In Parameter Set: <{tighteningMid.LastChangeInParameterSet.ToString("yyyy-MM-dd:HH:mm:ss")}>
                                 Batch Status: <{(int)tighteningMid.BatchStatus}> ({tighteningMid.BatchStatus.ToString()})
                                 TighteningID: <{tighteningMid.TighteningId}>");
        }

        private void btnSendProduct_Click(object sender, EventArgs e)
        {
            new DownloadProductCommand(this.driver).Execute(this.txtProduct.Text);
        }

        private void btnAbortJob_Click(object sender, EventArgs e)
        {
            new AbortJobCommand(this.driver).Execute();
        }
    }
}
