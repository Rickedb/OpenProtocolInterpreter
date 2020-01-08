namespace OpenProtocolInterpreter.Ethernet.Integrator
{
    public class CommunicationOptions
    {
        public string IpOrHostname { get; set; }
        public int Port { get; set; }
        public int Revision { get; set; }
        public bool AutoAcknowledge { get; set; }

        public CommunicationOptions()
        {
            Port = 4545;
            Revision = 5;
            AutoAcknowledge = true;
        }
    }
}
