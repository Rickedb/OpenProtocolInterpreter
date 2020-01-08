using OpenProtocolInterpreter.Ethernet.Integrator;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter
{
    public class EthernetIntegrator
    {
        private readonly Dictionary<Type, MidReceivedDelegate> _listeners;
        private readonly CommunicationOptions _options;
        private readonly SimpleTcpClient _client;
        private readonly MidInterpreter _interpreter;

        public delegate void MidReceivedDelegate(IMid mid);

        public EthernetIntegrator(CommunicationOptions options)
        {
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

        public void Disconnect()
        {

        }

        public void Send(IMid mid)
        {
            var bytes = mid.PackBytes();
            _client.Write(bytes);
        }

        public void ListenTo<TMid>(MidReceivedDelegate action) where TMid : IMid
        {
            var type = typeof(TMid);
            if (_listeners.ContainsKey(type))
            {
                _listeners.Remove(type);
            }

            _listeners.Add(type, action);
        }

        private void CommunicationAlive()
        {

        }

        private void OnPackageReceived(object sender, Message message)
        {
            CommunicationAlive();
            var mid = _interpreter.Parse(message.Data);
            if(_listeners.TryGetValue(mid.GetType(), out MidReceivedDelegate action))
            {
                action(mid);
            }
        }
    }
}
