using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Job;
using OpenProtocolInterpreter.KeepAlive;
using OpenProtocolInterpreter.Sample.Driver;
using OpenProtocolInterpreter.Sample.Driver.Commands;
using OpenProtocolInterpreter.Sample.Driver.Events;
using OpenProtocolInterpreter.Sample.Driver.Helpers;
using OpenProtocolInterpreter.Tightening;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenProtocolInterpreter.Sample
{
    public partial class DriverForm : Form
    {
        private readonly Timer _keepAliveTimer;
        private OpenProtocolDriver driver;

        public DriverForm()
        {
            InitializeComponent();
            _keepAliveTimer = new Timer();
            _keepAliveTimer.Tick += KeepAliveTimer_Tick;
            _keepAliveTimer.Interval = 1000;
        }

        private void BtnConnection_Click(object sender, EventArgs e)
        {
            //Added list of mids i want to use in my interpreter, every another will be desconsidered
            driver = new OpenProtocolDriver(new Type[]
            {
                typeof(Mid0002),
                typeof(Mid0005),
                typeof(Mid0004),
                typeof(Mid0003),
                
                typeof(ParameterSet.Mid0011),
                typeof(ParameterSet.Mid0013),
                
                typeof(Mid0035),
                typeof(Mid0031),
                
                typeof(Alarm.Mid0071),
                typeof(Alarm.Mid0074),
                typeof(Alarm.Mid0076),
                
                typeof(Vin.Mid0052),
                
                typeof(Mid0061),
                typeof(Mid0065),
                
                typeof(Time.Mid0081),
                
                typeof(Mid9999)
            });

            var client = new Ethernet.SimpleTcpClient().Connect(textIp.Text, (int)numericPort.Value);
            if (driver.BeginCommunication(client))
            {
                _keepAliveTimer.Start();
                connectionStatus.Text = "Connected!";
                connectionStatus.BackColor = Color.Green;
            }
            else
            {
                driver = null;
                connectionStatus.Text = "Disconnected!";
                connectionStatus.BackColor = Color.Red;
            }
        }

        private void KeepAliveTimer_Tick(object sender, EventArgs e)
        {
            if (driver.KeepAlive.ElapsedMilliseconds > 10000) //10 sec
            {
                Console.WriteLine($"Sending Keep Alive...");
                var pack = driver.SendAndWaitForResponse(new Mid9999().Pack(), TimeSpan.FromSeconds(10));
                if (pack != null && pack.Header.Mid == Mid9999.MID)
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
        private void BtnJobInfoSubscribe_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"Sending Job Info Subscribe...");
            var pack = driver.SendAndWaitForResponse(new Mid0034().Pack(), TimeSpan.FromSeconds(10));

            if (pack != null)
            {
                if (pack.Header.Mid == Mid0004.MID)
                {
                    var mid04 = pack as Mid0004;
                    Console.WriteLine($@"Error while subscribing (MID 0004):
                                         Error Code: <{mid04.ErrorCode}>
                                         Failed MID: <{mid04.FailedMid}>");
                }
                else
                    Console.WriteLine($"Job Info Subscribe accepted!");
            }

            driver.AddUpdateOnReceivedCommand(typeof(Mid0035), OnJobInfoReceived);
        }

        /// <summary>
        /// Tightening subscribe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTighteningSubscribe_Click(object sender, EventArgs e)
        {

            Console.WriteLine($"Sending Tightening Subscribe...");
            var pack = driver.SendAndWaitForResponse(new Mid0060().Pack(), TimeSpan.FromSeconds(10));

            if (pack != null)
            {
                if (pack.Header.Mid == Mid0004.MID)
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
            driver.AddUpdateOnReceivedCommand(typeof(Mid0061), OnTighteningReceived);
        }


        private void BtnSendJob_Click(object sender, EventArgs e)
        {
            new SendJobCommand(driver).Execute((int)numericJob.Value);
        }

        /// <summary>
        /// Async method from controller, MID 0035 (Job Info)
        /// </summary>
        /// <param name="e"></param>
        private void OnJobInfoReceived(MIDIncome e)
        {
            driver.SendMessage(e.Mid.BuildAckPackage());

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
        private void OnTighteningReceived(MIDIncome e)
        {
            driver.SendMessage(e.Mid.BuildAckPackage());

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
                                 Batch Status: <{(int)tighteningMid.BatchStatus}> ({tighteningMid.BatchStatus})
                                 TighteningID: <{tighteningMid.TighteningId}>");
        }

        private void BtnSendProduct_Click(object sender, EventArgs e)
        {
            new DownloadProductCommand(driver).Execute(txtProduct.Text);
        }

        private void BtnAbortJob_Click(object sender, EventArgs e)
        {
            new AbortJobCommand(driver).Execute();
        }
    }
}