using OpenProtocolInterpreter.Alarm;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Emulator.Controller.Events;
using OpenProtocolInterpreter.Job;
using OpenProtocolInterpreter.KeepAlive;
using OpenProtocolInterpreter.ParameterSet;
using OpenProtocolInterpreter.Tightening;
using OpenProtocolInterpreter.Vin;
using SimpleTcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.Emulator.Controller.Drivers
{
    public class AtlasCopcoControllerDriver
    {
        private readonly MidInterpreter _midInterpreter;
        private readonly IList<string> _connectedClients;
        private readonly IDictionary<int, Func<Mid, Mid>> _autoReplies;
        private readonly Dictionary<int, Action<string, Mid>> _handlers;
        private SimpleTcpServer Server;

        public event EventHandler<string> ClientConnected;
        public event EventHandler<string> ClientDisconnected;
        public event EventHandler<string> LogHandler;
        public event EventHandler<MidMessageEvent> MessageReceived;

        public IEnumerable<string> ConnectedClients { get => _connectedClients; }

        public AtlasCopcoControllerDriver()
        {
            _connectedClients = new List<string>();
            _midInterpreter = new MidInterpreter().UseAllMessages(InterpreterMode.Controller);
            _autoReplies = new Dictionary<int, Func<Mid, Mid>>()
            {
                { Mid0001.MID, mid => OnCommunicationStart((Mid0001)mid) },
                { Mid0034.MID,mid => PositiveAcknowledge(mid) },
                { Mid0038.MID,mid => PositiveAcknowledge(mid) },
                { Mid0050.MID, mid => PositiveAcknowledge(mid) },
                { Mid0051.MID, mid => PositiveAcknowledge(mid) },
                { Mid0060.MID, mid => PositiveAcknowledge(mid) },
                { Mid0070.MID, mid => PositiveAcknowledge(mid) },
                { Mid9999.MID, mid => new Mid9999() }
            };
        }

        public Task StartAsync(int port)
        {
            Server = new SimpleTcpServer("0.0.0.0", port);
            Server.Settings.IdleClientTimeoutMs = 10000;
            Server.Events.ClientConnected += OnClientConnected;
            Server.Events.ClientDisconnected += OnClientDisconnected;
            Server.Events.DataReceived += OnDataReceived;
            return Server.StartAsync();
        }

        public async Task SendAsync(string ipPort, Mid mid)
        {
            var data = mid.PackBytes();
            await Server.SendAsync(ipPort, data);
        }

        protected virtual Mid OnCommunicationStart(Mid0001 mid)
        {
            return new Mid0002()
            {
                CellId = 1,
                ChannelId = 1,
                ControllerName = "New Controller"
            };
        }

        protected virtual Mid PositiveAcknowledge(Mid mid) => new Mid0005() { MidAccepted = mid.Header.Mid };
        protected virtual Mid NegativeAcknowledge(Mid mid) => new Mid0004() { ErrorCode = Error.CommandFailed, FailedMid = mid.Header.Mid };

        private void OnClientConnected(object sender, ClientConnectedEventArgs e)
        {
            _connectedClients.Add(e.IpPort);
            LogHandler?.Invoke(this, $"Client connected from IP and Port {e.IpPort}");
            ClientConnected?.Invoke(this, e.IpPort);
        }

        private void OnClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            _connectedClients.Remove(e.IpPort);
            LogHandler?.Invoke(this, $"Client ({e.IpPort}) disconnected. Reason: {e.Reason}");
            ClientDisconnected?.Invoke(this, e.IpPort);
        }

        private void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            var mid = _midInterpreter.Parse(e.Data);
            if (_autoReplies.TryGetValue(mid.Header.Mid, out var responseCreator))
            {
                var responseMid = responseCreator(mid);
                var bytes = responseMid.PackBytesWithNul();
                Server.Send(e.IpPort, bytes);
            }
            MessageReceived?.Invoke(this, new MidMessageEvent
            {
                ClientIpPort = e.IpPort,
                Mid = mid
            });
        }
    }
}
