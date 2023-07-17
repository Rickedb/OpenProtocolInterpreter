using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Emulator.Controller.Drivers;
using OpenProtocolInterpreter.Emulator.Controller.Events;
using OpenProtocolInterpreter.Emulator.Controller.Models;
using OpenProtocolInterpreter.Job;
using OpenProtocolInterpreter.ParameterSet;
using OpenProtocolInterpreter.Tightening;
using OpenProtocolInterpreter.Vin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace OpenProtocolInterpreter.Emulator.Controller
{
    public partial class DriverForm : Form
    {
        private readonly AtlasCopcoControllerDriver _driver;

        private string ClientIpPort;
        private List<FakeParameterSet> _parameterSets;
        private List<FakeJob> _jobs;

        public DriverForm()
        {
            InitializeComponent();
            _parameterSets = new List<FakeParameterSet>()
            {
                FakeParameterSet.Random(1),
                FakeParameterSet.Random(2),
                FakeParameterSet.Random(3)
            };
            _jobs = new List<FakeJob>()
            { 
                FakeJob.Random(1, _parameterSets),
                FakeJob.Random(2, _parameterSets),
                FakeJob.Random(3, _parameterSets)
            };
            _driver = new AtlasCopcoControllerDriver();
            _driver.MessageReceived += OnMessageReceived;
            _driver.LogHandler += OnLog;
            _driver.ClientConnected += OnClientConnected;
            _driver.ClientDisconnected += OnClientDisconnected;

            TorqueStatusComboBox.DataSource = new List<TighteningValueStatus>()
            {
                TighteningValueStatus.Low,
                TighteningValueStatus.Ok,
                TighteningValueStatus.High
            };
            AngleStatusComboBox.DataSource = new List<TighteningValueStatus>()
            {
                TighteningValueStatus.Low,
                TighteningValueStatus.Ok,
                TighteningValueStatus.High
            };
            BatchStatusComboBox.DataSource = new List<BatchStatus>()
            {
                BatchStatus.Nok,
                BatchStatus.Ok,
                BatchStatus.NotUsed,
                BatchStatus.Running
            };
            JobStatusComboBox.DataSource = new List<JobStatus>() { JobStatus.NotCompleted, JobStatus.Ok, JobStatus.Nok };
            JobBatchModeComboBox.DataSource = new List<JobBatchMode>() { JobBatchMode.OnlyOkTightenings, JobBatchMode.OkAndNokTightenings };
        }

        private async void OnMessageReceived(object sender, MidMessageEvent e)
        {
            switch (e.Mid)
            {
                case Mid0001 mid0001:
                    Invoke(new Action(() =>
                    {
                        ConnectedStatusLabel.Text = "Connected";
                        ConnectedStatusLabel.BackColor = Color.Green;
                    }));
                    break;
                //PSET
                case Mid0010 mid0010:
                    await _driver.SendAsync(e.ClientIpPort, new Mid0011()
                    {
                        ParameterSets = _parameterSets.Select(x => x.Id).ToList()
                    });
                    break;
                case Mid0012 mid0012:
                    var pset = _parameterSets.FirstOrDefault(x => x.Id == mid0012.ParameterSetId);
                    if(pset == null)
                    {
                        await _driver.SendAsync(e.ClientIpPort, new Mid0004() 
                        { 
                            ErrorCode = Error.ParameterSetIdNotPresent, 
                            FailedMid = mid0012.Header.Mid 
                        });
                        break;
                    }

                    await _driver.SendAsync(e.ClientIpPort, pset.ToMid0013());
                    break;
                //JOB
                case Mid0030 mid0030:
                    await _driver.SendAsync(e.ClientIpPort, new Mid0031()
                    {
                        JobIds = _jobs.Select(x=> x.Id).ToList()
                    });
                    break;
                case Mid0032 mid0032:
                    var job = _jobs.FirstOrDefault(x => x.Id == mid0032.JobId);
                    if (job == null)
                    {
                        await _driver.SendAsync(e.ClientIpPort, new Mid0004()
                        {
                            ErrorCode = Error.JobIdNotPresent,
                            FailedMid = mid0032.Header.Mid
                        });
                        break;
                    }

                    await _driver.SendAsync(e.ClientIpPort, job.ToMid0032());
                    break;
                case Mid0064 mid0064:
                    await _driver.SendAsync(e.ClientIpPort, new Mid0004()
                    {
                        FailedMid = mid0064.Header.Mid,
                        ErrorCode = Error.TighteningIdRequestNotFound
                    });
                    break;
                case Mid0050 mid0050:
                    Invoke(new Action(() =>
                    {
                        VinNumberTextBox.Text = mid0050.VinNumber;
                    }));
                    await _driver.SendAsync(e.ClientIpPort, new Mid0052() { VinNumber = mid0050.VinNumber });
                    break;
                case Mid0038 mid0038:
                    Invoke(new Action(() =>
                    {
                        JobIdTextBox.Text = Job_JobIdTextBox.Text = mid0038.JobId.ToString();
                    }));
                    break;
            }
        }

        private void OnClientConnected(object sender, string e)
        {
            ClientIpPort = e;
        }

        private void OnClientDisconnected(object sender, string e)
        {

        }

        private async void StartStopServerButton_Click(object sender, EventArgs e)
        {
            ServerPortNumeric.ReadOnly = true;
            await _driver.StartAsync((int)ServerPortNumeric.Value);
        }

        private void OnLog(object sender, string e)
        {
            Console.WriteLine(e);
        }

        //private Mid OnOldTighteningRequest(Mid0064 mid)
        //{

        //    if (_tighteningsPerformed.Count < mid.TighteningId || _tighteningsPerformed.Count == 0)
        //    {
        //        return new Mid0004()
        //        {
        //            FailedMid = mid.Header.Mid,
        //            ErrorCode = Error.TighteningIdRequestNotFound
        //        };
        //    }

        //    var id = (mid.TighteningId > 0 ? (int)mid.TighteningId : _tighteningsPerformed.Count) - 1;
        //    var tightening = _tighteningsPerformed[id];
        //    var oldTightening = new Mid0065(1)
        //    {
        //        TighteningId = tightening.TighteningId,
        //        VinNumber = tightening.VinNumber,
        //        ParameterSetId = tightening.ParameterSetId,
        //        BatchCounter = tightening.BatchCounter,
        //        TighteningStatus = tightening.TighteningStatus,
        //        TorqueStatus = tightening.TorqueStatus,
        //        AngleStatus = tightening.AngleStatus,
        //        Torque = tightening.Torque,
        //        Angle = tightening.Angle,
        //        Timestamp = tightening.Timestamp,
        //        BatchStatus = tightening.BatchStatus
        //    };
        //    return oldTightening;
        //}

        private async void SendTighteningButton_Click(object sender, EventArgs e)
        {
            var mid = new Mid0061(1)
            {
                CellId = CellIdTextBox.GetTextAsInt(),
                ChannelId = ChannelIdTextBox.GetTextAsInt(),
                Angle = AngleTextBox.GetTextAsInt(),
                AngleFinalTarget = FinalAngleTargetTextBox.GetTextAsInt(),
                AngleMinLimit = AngleMinTextBox.GetTextAsInt(),
                AngleMaxLimit = AngleMaxTextBox.GetTextAsInt(),
                BatchSize = BatchSizeTextBox.GetTextAsInt(),
                BatchCounter = BatchCounterTextBox.GetTextAsInt(),
                AngleStatus = (TighteningValueStatus)AngleStatusComboBox.SelectedValue,
                BatchStatus = BatchStatus.Ok,
                VinNumber = VinNumberTextBox.Text,
                ParameterSetId = ParameterSetIdTextBox.GetTextAsInt(),
                JobId = JobIdTextBox.GetTextAsInt(),
                TighteningStatus = true,
                TorqueStatus = (TighteningValueStatus)TorqueStatusComboBox.SelectedValue,
                Torque = 200,
                TorqueMinLimit = TorqueMinLimitTextBox.GetTextAsInt(),
                TorqueMaxLimit = TorqueMaxLimitTextBox.GetTextAsInt(),
                TorqueFinalTarget = TorqueFinalTargetTextBox.GetTextAsInt(),
                TorqueControllerName = TorqueControllerNameTextBox.Text,
                Timestamp = DateTime.Now,
                TighteningId = TighteningIdTextBox.GetTextAsInt(),
                LastChangeInParameterSet = LastChangeInParameterDateTimePicker.Value
            };

            TighteningIdTextBox.Text = (mid.TighteningId + 1).ToString();
            await _driver.SendAsync(ClientIpPort, mid);
        }

        private async void SendVinNumberButton_Click(object sender, EventArgs e)
        {
            var mid = new Mid0052() { VinNumber = IdentifierPart1TextBox.Text };
            await _driver.SendAsync(ClientIpPort, mid);
        }

        private async void SendJobInfoButton_Click(object sender, EventArgs e)
        {
            var mid = new Mid0035()
            {
                JobId = JobIdTextBox.GetTextAsInt(),
                JobStatus = (JobStatus)JobStatusComboBox.SelectedValue,
                JobBatchMode = (JobBatchMode)JobBatchModeComboBox.SelectedValue,
                JobBatchSize = JobBatchSizeTextBox.GetTextAsInt(),
                JobBatchCounter = JobBatchCounterTextBox.GetTextAsInt(),
                TimeStamp = DateTime.Now,
            };
            await _driver.SendAsync(ClientIpPort, mid);
        }
    }
}
