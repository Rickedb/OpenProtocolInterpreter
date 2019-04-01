using OpenProtocolInterpreter.MIDs;
using OpenProtocolInterpreter.MIDs.Communication;
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
        private readonly MIDIdentifier midIdentifier;
        private SimpleTcpClient simpleTcpClient;
        public Stopwatch keepAlive;
        public Dictionary<Type, ReceivedCommandActionDelegate> OnReceivedMID;
        public bool Connected { get; set; }

        public delegate void ReceivedCommandActionDelegate(MIDIncome e);

        /// <summary>
        /// Using all MIDs
        /// </summary>
        public OpenProtocolDriver()
        {
            this.OnReceivedMID = new Dictionary<Type, ReceivedCommandActionDelegate>();
            this.midIdentifier = new MIDIdentifier();
        }

        /// <summary>
        /// Custom MIDs that will be used on OpenProtocol lib (Filtering my used mids)
        /// </summary>
        public OpenProtocolDriver(IEnumerable<MID> usedMids)
        {
            this.OnReceivedMID = new Dictionary<Type, ReceivedCommandActionDelegate>();
            this.midIdentifier = new MIDIdentifier(usedMids);
        }

        public bool BeginCommunication(SimpleTcpClient client)
        {
            this.simpleTcpClient = client;
            this.simpleTcpClient.DataReceived += this.onPackageReceived;
            this.simpleTcpClient.DelimiterDataReceived += this.onPackageReceived;
            return this.startCommunication();
        }

        /// <summary>
        /// Add or update a command for a specific Mid type
        /// </summary>
        /// <param name="midType"></param>
        /// <param name="deleg"></param>
        public void AddUpdateOnReceivedCommand(Type midType, ReceivedCommandActionDelegate deleg)
        {
            if (this.OnReceivedMID.ContainsKey(midType))
                this.OnReceivedMID[midType] = deleg;
            else
                this.OnReceivedMID.Add(midType, deleg);
        }

        /// <summary>
        /// Send an Async message to controller without waiting for response
        /// </summary>
        /// <param name="message">Message to be sent</param>
        public void sendMessage(string message)
        {
            try
            {
                System.Threading.Thread.Sleep(500); //Just to not send so many packages at once
                Console.WriteLine($"Sending message: {message}");

                this.simpleTcpClient.WriteLine(message);
                this.communicationAlive();
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
        public MID sendAndWaitForResponse(string message, TimeSpan timeout)
        {
            try
            {
                System.Threading.Thread.Sleep(500);
                MID midResponse = null;

                Console.WriteLine($"Sending message: {message}");
                Message response = this.simpleTcpClient.WriteLineAndGetReply(message, timeout);

                Console.WriteLine((response != null) ? $"Response: {response.MessageString}" : "TIMEOUT!");

                if (response != null)
                {
                    this.communicationAlive();
                    midResponse = this.midIdentifier.IdentifyMid(response.MessageString);
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
        protected virtual void onPackageReceived(object sender, Message message)
        {
            try
            {
                Console.WriteLine($"Message arrived: {message.MessageString}");

                var mid = this.midIdentifier.IdentifyMid(message.MessageString);
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
        protected virtual bool startCommunication()
        {
            try
            {
                var message = this.sendAndWaitForResponse(new MID_0001(1).buildPackage(), TimeSpan.FromSeconds(10));
                if (message != null)
                    switch (message.HeaderData.Mid)
                    {
                        case MID_0002.MID:
                            this.OnCommunicationStartAccepted(message as MID_0002);
                            break;
                        case MID_0004.MID:
                            this.OnCommunicationStartError(message as MID_0004);
                            break;
                    }
                return true;
            }
            catch (Exception ex)
            {
                this.Connected = false;
                Console.WriteLine($"Exception: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// When controller accept comunication start accordingly with OpenProtocol telegrams (MID 0002)
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCommunicationStartAccepted(MID_0002 mid)
        {
            this.Connected = true;
            Console.WriteLine($"Communication Start Accepted (MID 0002)");
        }

        protected virtual void OnCommunicationStartError(MID_0004 mid)
        {
            this.Connected = false;
            if (mid.ErrorCode == MID_0004.Errors.CLIENT_ALREADY_CONNECTED)
                Console.WriteLine("Client is already connected!!");
            else if (mid.ErrorCode == MID_0004.Errors.MID_REVISION_UNSUPPORTED)
                Console.WriteLine(MID_0004.Errors.MID_REVISION_UNSUPPORTED.ToString());
        }

        private void communicationAlive()
        {
            this.keepAlive = Stopwatch.StartNew();
        }
    }
}
