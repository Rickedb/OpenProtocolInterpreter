using OpenProtocolInterpreter.Emulator.Controller.Drivers;
using OpenProtocolInterpreter.Job;
using OpenProtocolInterpreter.Tightening;
using OpenProtocolInterpreter.Vin;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OpenProtocolInterpreter.Emulator.Controller
{
    public partial class DriverForm : Form
    {
        private readonly AtlasCopcoControllerDriver _driver;

        private string ClientIpPort;

        public DriverForm()
        {
            InitializeComponent();
            _driver = new AtlasCopcoControllerDriver();
            _driver.LogHandler += OnLog;
            _driver.ClientConnected += OnClientConnected;
            _driver.ClientDisconnected += OnClientDisconnected;

            TorqueStatusComboBox.DataSource = new List<TighteningValueStatus>()
            {
                TighteningValueStatus.LOW,
                TighteningValueStatus.OK,
                TighteningValueStatus.HIGH
            };
            AngleStatusComboBox.DataSource = new List<TighteningValueStatus>()
            {
                TighteningValueStatus.LOW,
                TighteningValueStatus.OK,
                TighteningValueStatus.HIGH
            };
            BatchStatusComboBox.DataSource = new List<BatchStatus>()
            {
                BatchStatus.NOK,
                BatchStatus.OK,
                BatchStatus.NOT_USED,
                BatchStatus.RUNNING
            };
            JobStatusComboBox.DataSource = new List<JobStatus>() { JobStatus.NOT_COMPLETED, JobStatus.OK, JobStatus.NOK };
            JobBatchModeComboBox.DataSource = new List<JobBatchMode>() { JobBatchMode.ONLY_OK_TIGHTENINGS, JobBatchMode.OK_AND_NOK_TIGHTENINGS };
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
            await _driver.StartAsync();
        }

        private void OnLog(object sender, string e)
        {
            Console.WriteLine(e);
        }

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
                BatchStatus = BatchStatus.OK,
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
            await _driver.SendAsync(ClientIpPort, mid);
        }

        private async void SendVinNumberButton_Click(object sender, EventArgs e)
        {
            var mid = new Mid0052(IdentifierPart1TextBox.Text);
            await _driver.SendAsync(ClientIpPort, mid);
        }

        private async void SendJobInfoButton_Click(object sender, EventArgs e)
        {
            var mid = new Mid0035(
                JobIdTextBox.GetTextAsInt(),
                (JobStatus)JobStatusComboBox.SelectedValue,
                (JobBatchMode)JobBatchModeComboBox.SelectedValue,
                JobBatchSizeTextBox.GetTextAsInt(),
                JobBatchCounterTextBox.GetTextAsInt(),
                DateTime.Now,
                1);
            await _driver.SendAsync(ClientIpPort, mid);
        }
    }
}
