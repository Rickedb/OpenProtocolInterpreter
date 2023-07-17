using OpenProtocolInterpreter.Alarm;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Emulator.Drivers;
using OpenProtocolInterpreter.Job;
using OpenProtocolInterpreter.Job.Advanced;
using OpenProtocolInterpreter.Tightening;
using OpenProtocolInterpreter.Vin;

namespace OpenProtocolInterpreter.Emulator.AutomaticControllers
{
    internal class AutomaticDriver : AtlasCopcoControllerDriver
    {
        private readonly ControllerConfiguration _configuration;
        private readonly Random _random;
        private readonly System.Threading.Timer _timer;
        private readonly List<int> _jobIdList = new() { 1, 2, 3 };
        private readonly List<Mid0061> _tighteningsPerformed;
        private string CurrentVinNumber;
        private int OkTighteningSentInJob;
        private int CurrentJobId;

        public AutomaticDriver(ControllerConfiguration configuration)
            : base(configuration.ControllerName)
        {
            _configuration = configuration;
            OkTighteningSentInJob = 0;
            _tighteningsPerformed = new List<Mid0061>();
            _random = new Random();
            _timer = new System.Threading.Timer(new TimerCallback(OnTimer), null, Timeout.Infinite, Timeout.Infinite);
            AddOrUpdateReply(new Dictionary<int, Func<Mid, Mid>>()
            {
                { Mid0030.MID, mid => new Mid0031() { JobIds = _jobIdList }  },
                { Mid0034.MID, mid => PositiveAcknowledge(mid) },
                { Mid0038.MID, mid => OnJobSelected((Mid0038)mid) },
                { Mid0050.MID, mid => OnVinDownloadRequest((Mid0050)mid) },
                { Mid0051.MID, mid => PositiveAcknowledge(mid) },
                { Mid0060.MID, mid => PositiveAcknowledge(mid) },
                { Mid0064.MID, mid => OnOldTighteningRequest((Mid0064)mid) },
                { Mid0070.MID, mid => PositiveAcknowledge(mid) },
                { Mid0127.MID, mid => OnJobAbort((Mid0127)mid) }
            });
        }

        public Task StartAsync()
        {
            return StartAsync(_configuration.Port);
        }

        private async void OnTimer(object? obj)
        {
            try
            {

                var angleStatus = (TighteningValueStatus)(_configuration.TighteningStrategy == Strategy.Random ? _random.Next(0, 2) : 1);
                var torqueStatus = (TighteningValueStatus)(_configuration.TighteningStrategy == Strategy.Random ? _random.Next(0, 2) : 1);
                var tighteningStatus = angleStatus == TighteningValueStatus.Ok && torqueStatus == TighteningValueStatus.Ok;

                if (tighteningStatus || OkTighteningSentInJob == 0)
                {
                    OkTighteningSentInJob++;
                }
                var mid61 = new Mid0061(1)
                {
                    CellId = 1,
                    ChannelId = 1,
                    TorqueControllerName = _configuration.ControllerName,
                    VinNumber = CurrentVinNumber,
                    JobId = CurrentJobId,
                    ParameterSetId = 1,
                    BatchSize = 5,
                    BatchCounter = OkTighteningSentInJob,
                    TighteningStatus = tighteningStatus,
                    TorqueStatus = torqueStatus,
                    AngleStatus = angleStatus,
                    TorqueMinLimit = 100,
                    TorqueMaxLimit = 300,
                    TorqueFinalTarget = 200,
                    Torque = GenerateFakeTorqueAngleValue(torqueStatus, 100, 300),
                    AngleMinLimit = 60,
                    AngleMaxLimit = 360,
                    AngleFinalTarget = 220,
                    Angle = GenerateFakeTorqueAngleValue(angleStatus, 60, 360),
                    Timestamp = DateTime.Now,
                    LastChangeInParameterSet = DateTime.Today,
                    BatchStatus = OkTighteningSentInJob >= 5 ? BatchStatus.Ok : BatchStatus.Running,
                    TighteningId = _tighteningsPerformed.Count + 1
                };
                _tighteningsPerformed.Add(mid61);
                foreach (var client in ConnectedClients)
                {
                    await SendAsync(client, mid61);
                }

                var mid35 = new Mid0035()
                {
                    JobId = CurrentJobId,
                    VinNumber = CurrentVinNumber,
                    JobBatchMode = JobBatchMode.OnlyOkTightenings,
                    JobBatchSize = 5,
                    JobBatchCounter = OkTighteningSentInJob,
                    TimeStamp = DateTime.Now
                };

                if (OkTighteningSentInJob >= 5)
                {
                    OkTighteningSentInJob = 0;
                    CurrentJobId = 0;
                    mid35.JobStatus = JobStatus.Ok;
                    _timer.Change(Timeout.Infinite, Timeout.Infinite);
                }
                else
                {
                    mid35.JobStatus = JobStatus.NotCompleted;
                    var delay = _random.Next(_configuration.MinTighteningDelay, _configuration.MaxTighteningDelay);
                    _timer.Change(delay, Timeout.Infinite);
                }

                foreach (var client in ConnectedClients)
                {
                    await SendAsync(client, mid35);
                }
            }
            catch
            {

            }
        }

        private Mid OnJobSelected(Mid0038 mid)
        {
            CurrentJobId = mid.JobId;
            OkTighteningSentInJob = 0;
            var delay = _random.Next(_configuration.MinTighteningDelay, _configuration.MaxTighteningDelay);
            _timer.Change(delay, Timeout.Infinite);
            return PositiveAcknowledge(mid);
        }

        private Mid OnVinDownloadRequest(Mid0050 mid)
        {
            CurrentVinNumber = mid.VinNumber;
            return PositiveAcknowledge(mid);
        }

        private Mid OnOldTighteningRequest(Mid0064 mid)
        {
            if (_tighteningsPerformed.Count < mid.TighteningId || _tighteningsPerformed.Count == 0)
            {
                return new Mid0004()
                {
                    FailedMid = mid.Header.Mid,
                    ErrorCode = Error.TighteningIdRequestNotFound
                };
            }

            var id = (mid.TighteningId > 0 ? (int)mid.TighteningId : _tighteningsPerformed.Count) - 1;
            var tightening = _tighteningsPerformed[id];
            var oldTightening = new Mid0065(1)
            {
                TighteningId = tightening.TighteningId,
                VinNumber = tightening.VinNumber,
                ParameterSetId = tightening.ParameterSetId,
                BatchCounter = tightening.BatchCounter,
                TighteningStatus = tightening.TighteningStatus,
                TorqueStatus = tightening.TorqueStatus,
                AngleStatus = tightening.AngleStatus,
                Torque = tightening.Torque,
                Angle = tightening.Angle,
                Timestamp = tightening.Timestamp,
                BatchStatus = tightening.BatchStatus
            };
            return oldTightening;
        }

        private Mid OnJobAbort(Mid0127 mid)
        {
            CurrentJobId = 0;
            OkTighteningSentInJob = 0;
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            return PositiveAcknowledge(mid);
        }

        private int GenerateFakeTorqueAngleValue(TighteningValueStatus status, int min, int max)
        {
            return status switch
            {
                TighteningValueStatus.Low => _random.Next(0, min),
                TighteningValueStatus.High => _random.Next(max, max + 200),
                _ => _random.Next(min, max),
            };
        }
    }
}
