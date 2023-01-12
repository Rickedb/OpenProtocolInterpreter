using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Threading;

namespace OpenProtocolInterpreter.Sample.Ethernet
{
    public class SimpleTcpClient : IDisposable
    {
        public SimpleTcpClient()
        {
            StringEncoder = System.Text.Encoding.ASCII;
            ReadLoopIntervalMs = 10;
            Delimiter = 0x00; // NUL
        }

        private readonly object _messageSendLock = new object();
        private readonly object _queueStopLock = new object();
        private bool waitingForResponse = false;
        private Thread _rxThread = null;
        private List<byte> _queuedMsg = new List<byte>();
        private bool _queueStop;
        private event EventHandler<Message> ReplyEvent;

        public byte Delimiter { get; set; }
        public System.Text.Encoding StringEncoder { get; set; }
        private TcpClient _client = null;

        public event EventHandler<Message> DelimiterDataReceived;
        public event EventHandler<Message> DataReceived;

        internal bool QueueStop
        {
            get
            {
                lock (_queueStopLock)
                    return _queueStop;
            }
            set
            {
                lock (_queueStopLock)
                    _queueStop = value;
            }
        }
        internal int ReadLoopIntervalMs { get; set; }
        public bool AutoTrimStrings { get; set; }

        public SimpleTcpClient Connect(string hostNameOrIpAddress, int port)
        {
            if (string.IsNullOrEmpty(hostNameOrIpAddress))
            {
                throw new ArgumentNullException("hostNameOrIpAddress");
            }

            _client = new TcpClient();
            _client.Connect(hostNameOrIpAddress, port);

            StartRxThread();

            return this;
        }

        private void StartRxThread()
        {
            if (_rxThread != null) { return; }

            _rxThread = new Thread(ListenerLoop);
            _rxThread.IsBackground = true;
            _rxThread.Start();
        }

        public SimpleTcpClient Disconnect()
        {
            if (_client == null) { return this; }
            _client.Close();
            _client = null;
            return this;
        }

        public TcpClient Client { get { return _client; } }

        private void ListenerLoop(object state)
        {
            while (!QueueStop)
            {
                try
                {
                    RunLoopStep();
                }
                catch
                {

                }

                Thread.Sleep(ReadLoopIntervalMs);
            }

            _rxThread = null;
        }

        private void RunLoopStep()
        {
            if (_client == null) { return; }
            if (_client.Connected == false) { return; }

            var delimiter = this.Delimiter;
            var c = _client;

            int bytesAvailable = c.Available;
            if (bytesAvailable == 0)
            {
                Thread.Sleep(10);
                return;
            }

            List<byte> bytesReceived = new List<byte>();

            while (c.Available > 0 && c.Connected)
            {
                byte[] nextByte = new byte[1];
                c.Client.Receive(nextByte, 0, 1, SocketFlags.None);
                if (nextByte[0] == delimiter)
                {
                    byte[] msg = _queuedMsg.ToArray();
                    _queuedMsg.Clear();
                    NotifyDelimiterMessageRx(c, msg);
                }
                else
                {
                    _queuedMsg.AddRange(nextByte);
                }
            }

            bytesReceived.AddRange(_queuedMsg);
            if (bytesReceived.Count > 0)
            {
                NotifyEndTransmissionRx(c, bytesReceived.ToArray());
            }
        }

        private void NotifyDelimiterMessageRx(System.Net.Sockets.TcpClient client, byte[] msg)
        {
            Message m = new Message(msg, client, StringEncoder, Delimiter, AutoTrimStrings);

            if (this.ReplyEvent != null)
            {
                this.ReplyEvent(this, m);
                return;
            }

            DelimiterDataReceived(this, m);
        }

        private void NotifyEndTransmissionRx(System.Net.Sockets.TcpClient client, byte[] msg)
        {
            Message m = new Message(msg, client, StringEncoder, Delimiter, AutoTrimStrings);

            if (this.ReplyEvent != null)
            {
                this.ReplyEvent(this, m);
                return;
            }

            DataReceived(this, m);
        }

        public void Write(byte[] data)
        {
            if (_client == null) { throw new NullReferenceException("Cannot send data to a null TcpClient (check to see if Connect was called)"); }

            lock (_messageSendLock)
                _client.GetStream().Write(data, 0, data.Length);
        }

        public void Write(string data)
        {
            if (data == null) { return; }
            var byteData = StringEncoder.GetBytes(data).ToList();
            byteData.Add(Delimiter);
            Write(byteData.ToArray());
        }

        public void WriteLine(string data)
        {
            if (string.IsNullOrEmpty(data)) { return; }

            while (this.waitingForResponse)
                Thread.Sleep(10);
            if (data.LastOrDefault() != Delimiter)
            {
                Write(data);
            }
            else
            {
                Write(data);
            }
        }

        public Message WriteLineAndGetReply(string data, TimeSpan timeout)
        {
            lock (_messageSendLock)
            {
                while (this.waitingForResponse)
                    Thread.Sleep(10);

                if (timeout == null)
                    timeout = TimeSpan.FromSeconds(10);
                Message mReply = null;

                EventHandler<Message> ev = (s, e) => { mReply = e; };
                this.ReplyEvent += ev;

                WriteLine(data);
                waitingForResponse = true;

                Stopwatch sw = new Stopwatch();
                sw.Start();

                while (mReply == null && sw.Elapsed < timeout)
                    Thread.Sleep(10);

                this.ReplyEvent -= ev;
                this.ReplyEvent = null;
                waitingForResponse = false;
                return mReply;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).

                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                QueueStop = true;
                if (_client != null)
                {
                    try
                    {
                        _client.Close();
                    }
                    catch { }
                    _client = null;
                }

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SimpleTcpClient() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
