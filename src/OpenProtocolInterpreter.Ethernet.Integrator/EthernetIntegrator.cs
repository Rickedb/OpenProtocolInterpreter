using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Ethernet.Integrator;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter
{
    public class EthernetIntegrator : IDisposable
    {
        private readonly Dictionary<Type, MidReceivedDelegate> _listeners;
        private readonly CommunicationOptions _options;
        private readonly SimpleTcpClient _client;
        private readonly MidInterpreter _interpreter;

        public delegate void MidReceivedDelegate(IMid mid);

        public bool Connected { get => _client.Client.Connected; }
        public bool Ready { get; private set; }

        public EthernetIntegrator(CommunicationOptions options)
        {
            _interpreter = new MidInterpreter().UseAllMessages(InterpreterMode.Controller);
            _listeners = new Dictionary<Type, MidReceivedDelegate>();
            _client = new SimpleTcpClient();
            _client.DataReceived += OnPackageReceived;
            _client.DelimiterDataReceived += OnPackageReceived;
            _options = options;
        }

        public EthernetIntegrator Connect()
        {
            _client.Connect(_options);
            return this;
        }

        public void Disconnect() => DisconnectAsync().Wait(1000);

        public Task DisconnectAsync() => SendAsync(new Mid0003());

        public void Dispose()
        {
            _client.DataReceived -= OnPackageReceived;
            _client.DelimiterDataReceived -= OnPackageReceived;
            _client.Dispose();
            _listeners.Clear();
        }

        public void ListenTo<TMid>(MidReceivedDelegate action) where TMid : IMid, IController
        {
            var type = typeof(TMid);
            if (_listeners.ContainsKey(type))
            {
                _listeners.Remove(type);
            }

            _listeners.Add(type, action);
        }

        public void Send(IMid mid) => SendAsync(mid).Wait(1000);

        public Task SendAsync(IMid mid)
        {
            if(!typeof(IIntegrator).IsAssignableFrom(mid.GetType()))
            {
                throw new ArgumentException("Mid should be an integrator mid and implement IIntegrator");
            }

            var bytes = mid.PackBytes();
            return _client.WriteAsync(bytes);
        }

        protected virtual void CommunicationAlive()
        {

        }

        protected virtual void OnPackageReceived(object sender, Message message)
        {
            CommunicationAlive();

            var mid = _interpreter.Parse(message.Data);
            if(mid.HeaderData.Mid == Mid0005.MID)
            {
                var mid05 = mid as Mid0005;
                switch (mid05.MidAccepted)
                {
                    case Mid0001.MID:
                        OnStartCommunicationAccepted();
                        break;
                    case Mid0003.MID:
                        OnStopCommunicationAccepted();
                        break;
                }
            }

            if(_listeners.TryGetValue(mid.GetType(), out MidReceivedDelegate action))
            {
                action(mid);
            }
        }

        protected virtual void OnStartCommunicationAccepted()
        {
            Ready = true;
        }

        protected virtual void OnStopCommunicationAccepted()
        {
            _client.Disconnect();
        }
    }
}
