using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Emulator.Drivers;
using OpenProtocolInterpreter.Emulator.Drivers.Events;
using OpenProtocolInterpreter.Job;
using OpenProtocolInterpreter.Tightening;
using OpenProtocolInterpreter.Vin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.Emulator.AutomaticControllers
{
    internal class AutomaticDriver
    {
        private readonly ControllerConfiguration _configuration;
        private readonly AtlasCopcoControllerDriver _driver;
        private readonly Random _random;
        private readonly System.Threading.Timer _timer;
        private int TighteningsSent;

        public AutomaticDriver(ControllerConfiguration configuration)
        {
            _configuration = configuration;
            _driver = new AtlasCopcoControllerDriver(_configuration.ControllerName);
            TighteningsSent = 0;
            _timer = new System.Threading.Timer(new TimerCallback(OnTimer), null, Timeout.Infinite, Timeout.Infinite);
        }

        public void Start()
        {
            _driver.StartAsync(_configuration.Port);
            _driver.MessageReceived += OnMessageReceived;
            var delay = _random.Next(_configuration.MinTighteningDelay, _configuration.MaxTighteningDelay);
            _timer.Change(, Timeout.Infinite);
        }

        private async void OnMessageReceived(object sender, MidMessageEvent e)
        {
            switch (e.Mid)
            {
                case Mid0050 mid0050:
                    await _driver.SendAsync(e.ClientIpPort, new Mid0052(mid0050.VinNumber));
                    break;
                case Mid0038 mid0038:
                    await _driver.SendAsync(e.ClientIpPort, new Mid0005(mid0038.HeaderData.Mid));
                    var delay = _random.Next(_configuration.MinTighteningDelay, _configuration.MaxTighteningDelay);
                    _timer.Change(delay, Timeout.Infinite);
                    break;
            }
        }
        private async void OnTimer(object? obj)
        {
            var mid61 = new Mid0061();
            foreach(var client in _driver.ConnectedClients)
            {
                await _driver.SendAsync(client, mid61);
            }

            TighteningsSent++;
            var delay = _random.Next(_configuration.MinTighteningDelay, _configuration.MaxTighteningDelay);
            _timer.Change(delay, Timeout.Infinite);
        }
    }
}
