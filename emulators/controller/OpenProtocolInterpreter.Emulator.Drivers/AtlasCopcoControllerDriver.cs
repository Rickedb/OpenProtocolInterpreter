using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Emulator.Drivers.Events;
using OpenProtocolInterpreter.KeepAlive;
using SimpleTcp;

namespace OpenProtocolInterpreter.Emulator.Drivers
{
    public class AtlasCopcoControllerDriver
    {
        private readonly string _controllerName;
        private readonly MidInterpreter _midInterpreter;
        private readonly IList<string> _connectedClients;
        private readonly IDictionary<int, Func<Mid, Mid>> _replies;
        private SimpleTcpServer Server;

        public event EventHandler<string> ClientConnected;
        public event EventHandler<string> ClientDisconnected;
        public event EventHandler<string> LogHandler;
        public event EventHandler<MidMessageEvent> MessageReceived;

        public IEnumerable<string> ConnectedClients { get => _connectedClients; }

        public AtlasCopcoControllerDriver(string controllerName)
        {
            _controllerName = controllerName;
            _connectedClients = new List<string>();
            _midInterpreter = new MidInterpreter().UseAllMessages(InterpreterMode.Controller);
            _replies = new Dictionary<int, Func<Mid, Mid>>()
            {
                { Mid0001.MID, mid => OnCommunicationStart((Mid0001)mid) },
                { Mid9999.MID, mid => new Mid9999() }
            };
        }

        public virtual Task StartAsync(int port)
        {
            Server = new SimpleTcpServer("127.0.0.1", port);
            Server.Settings.IdleClientTimeoutMs = 15000;
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

        public void AddOrUpdateAutoReply(int mid, Func<Mid, Mid> func)
        {
            if(_replies.ContainsKey(mid))
            {
                _replies.Remove(mid); 
            }

            _replies.Add(mid, func);
        }

        public void AddOrUpdateReply(Dictionary<int, Func<Mid, Mid>> dictionary)
        {
            foreach(var item in dictionary)
            {
                AddOrUpdateAutoReply(item.Key, item.Value);
            }
        }

        protected virtual Mid OnCommunicationStart(Mid0001 mid)
        {
            return new Mid0002()
            {
                CellId = 1,
                ChannelId = 1,
                ControllerName = _controllerName
            };
        }

        protected virtual Mid OnCommunicationStop(Mid0003 mid)
        {
            return new Mid0005() { MidAccepted = mid.Header.Mid };
        }

        protected virtual Mid PositiveAcknowledge(Mid mid) => new Mid0005() { MidAccepted = mid.Header.Mid };
        protected virtual Mid NegativeAcknowledge(Mid mid) => new Mid0004()
        {
            FailedMid = mid.Header.Mid,
            ErrorCode = Error.CommandFailed
        };

        private void OnClientConnected(object sender, ConnectionEventArgs e)
        {
            _connectedClients.Add(e.IpPort);
            LogHandler?.Invoke(this, $"Client connected from IP and Port {e.IpPort}");
            ClientConnected?.Invoke(this, e.IpPort);
        }

        private void OnClientDisconnected(object sender, ConnectionEventArgs e)
        {
            _connectedClients.Remove(e.IpPort);
            LogHandler?.Invoke(this, $"Client ({e.IpPort}) disconnected. Reason: {e.Reason}");
            ClientDisconnected?.Invoke(this, e.IpPort);
        }

        private void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            var mid = _midInterpreter.Parse(e.Data);
            if(_replies.TryGetValue(mid.Header.Mid, out var responseCreator))
            {
                var responseMid = responseCreator(mid);
                var bytes = responseMid.PackBytes();
                Server.Send(e.IpPort, bytes);
            }
            MessageReceived?.Invoke(this, new MidMessageEvent
            {
                Driver = this,
                ClientIpPort = e.IpPort,
                Mid = mid
            });
        }
    }
}
