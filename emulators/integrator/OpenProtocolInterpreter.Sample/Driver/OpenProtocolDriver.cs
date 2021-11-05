using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Sample.Driver.Events;
using OpenProtocolInterpreter.Sample.Ethernet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace OpenProtocolInterpreter.Sample.Driver
{
    public class OpenProtocolDriver
    {
        private readonly MidInterpreter _midInterpreter;
        private SimpleTcpClient simpleTcpClient;
        public Stopwatch KeepAlive { get; set; }
        public Dictionary<Type, ReceivedCommandActionDelegate> OnReceivedMID { get; private set; }

        public bool Connected { get; set; }

        public delegate void ReceivedCommandActionDelegate(MIDIncome e);

        /// <summary>
        /// Using all MIDs
        /// </summary>
        public OpenProtocolDriver()
        {
            OnReceivedMID = new Dictionary<Type, ReceivedCommandActionDelegate>();
            _midInterpreter = new MidInterpreter().UseAllMessages();
        }

        /// <summary>
        /// Custom MIDs that will be used on OpenProtocol lib (Filtering my used mids)
        /// </summary>
        public OpenProtocolDriver(IEnumerable<Type> usedMids)
        {
            OnReceivedMID = new Dictionary<Type, ReceivedCommandActionDelegate>();
            _midInterpreter = new MidInterpreter().UseAllMessages(usedMids);
        }

        public bool BeginCommunication(SimpleTcpClient client)
        {
            simpleTcpClient = client;
            simpleTcpClient.DataReceived += OnPackageReceived;
            simpleTcpClient.DelimiterDataReceived += OnPackageReceived;
            return StartCommunication();
        }

        /// <summary>
        /// Add or update a command for a specific Mid type
        /// </summary>
        /// <param name="midType"></param>
        /// <param name="deleg"></param>
        public void AddUpdateOnReceivedCommand(Type midType, ReceivedCommandActionDelegate deleg)
        {
            if (OnReceivedMID.ContainsKey(midType))
                OnReceivedMID[midType] = deleg;
            else
                OnReceivedMID.Add(midType, deleg);
        }

        /// <summary>
        /// Send an Async message to controller without waiting for response
        /// </summary>
        /// <param name="message">Message to be sent</param>
        public void SendMessage(string message)
        {
            try
            {
                System.Threading.Thread.Sleep(500); //Just to not send so many packages at once
                Console.WriteLine($"Sending message: {message}");

                this.simpleTcpClient.WriteLine(message);
                this.KeepConnectionAlive();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        /// <summary>
        /// Send a message and wait until controller replies
        /// </summary>
        /// <param name="message">Message to be sent</param>
        /// <param name="timeout">Max time to wait</param>
        /// <returns>Controller's message</returns>
        public Mid SendAndWaitForResponse(string message, TimeSpan timeout)
        {
            try
            {
                System.Threading.Thread.Sleep(500);
                Mid midResponse = null;

                Console.WriteLine($"Sending message: {message}");
                Message response = this.simpleTcpClient.WriteLineAndGetReply(message, timeout);

                Console.WriteLine((response != null) ? $"Response: {response.MessageString}" : "TIMEOUT!");

                if (response != null)
                {
                    KeepConnectionAlive();
                    midResponse = _midInterpreter.Parse(response.MessageString);
                }

                return midResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// When a message is received in TCP Client socket
        /// This is the core of the thing! When a MID arrived, it identifies and call de right registered command!
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="message">Message received</param>
        protected virtual void OnPackageReceived(object sender, Message message)
        {
            try
            {
                Console.WriteLine($"Message arrived: {message.MessageString}");

                var mid = this._midInterpreter.Parse(message.MessageString);
                var action = this.OnReceivedMID.FirstOrDefault(x => x.Key == mid.GetType());

                if (action.Equals(default(KeyValuePair<Type, ReceivedCommandActionDelegate>)))
                {
                    Console.WriteLine($"NO ACTION WAS REGISTERED TO MID: {mid.GetType()}");
                    return;
                }

                action.Value(new MIDIncome() { Mid = mid });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        /// <summary>
        /// Start TCP/IP connection and initiates an OpenProtocol conversation with controller, send start communication to controller (MID 0001)
        /// </summary>
        protected virtual bool StartCommunication()
        {
            try
            {
                var message = SendAndWaitForResponse(new Mid0001(1).Pack(), TimeSpan.FromSeconds(10));
                if (message != null)
                    switch (message.HeaderData.Mid)
                    {
                        case Mid0002.MID:
                            OnCommunicationStartAccepted(message as Mid0002);
                            break;
                        case Mid0004.MID:
                            OnCommunicationStartError(message as Mid0004);
                            break;
                    }
            }
            catch (Exception ex)
            {
                Connected = false;
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return Connected;
        }

        /// <summary>
        /// When controller accept comunication start accordingly with OpenProtocol telegrams (MID 0002)
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCommunicationStartAccepted(Mid0002 mid)
        {
            Connected = true;
            Console.WriteLine($"Communication Start Accepted (MID 0002)");
        }

        protected virtual void OnCommunicationStartError(Mid0004 mid)
        {
            Connected = false;
            if (mid.ErrorCode == Error.CLIENT_ALREADY_CONNECTED)
                Console.WriteLine("Client is already connected!!");
            else if (mid.ErrorCode == Error.MID_REVISION_UNSUPPORTED)
                Console.WriteLine(Error.MID_REVISION_UNSUPPORTED.ToString());
        }

        private void KeepConnectionAlive()
        {
            KeepAlive = Stopwatch.StartNew();
        }
    }
}