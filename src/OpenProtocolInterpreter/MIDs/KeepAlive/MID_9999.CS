using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.KeepAlive
{
    /// <summary>
    /// MID: Keep alive message
    /// Description: 
    ///   The integrator sends a keep alive to the controller. The controller should only mirror and return the 
    ///   received keep alive to the integrator.
    ///   The controller has a communication timeout equal to 15s.This means that if no message has been 
    ///   exchanged between the integrator and the controller for the last 15s, then the controller considers 
    ///   the connection lost and closes it.
    ///   In order to keep the communication alive the integrator must send a keep alive to the controller with a
    ///   time interval lower than 15s.
    ///   Note: An inactivity timeout is suggested to integrator i.e. if no message has been exchanged (sent or 
    ///   received) during the last 10s, send a keep alive.
    ///  
    /// Message sent by: Integrator
    /// Answer: The same message mirrored by the controller.
    /// </summary>
    public class MID_9999 : MID
    {
        private const int length = 20;
        private const int mid = 9999;
        private const int revision = 1;

        public MID_9999() : base(length, mid, revision) { }

        public override MID processPackage(string package)
        {
            if (this.isCorrectType(package))
                return base.processPackage(package);

            throw new NotImplementedException("O MID <" + mid + "> não está implementado!");
        }
    }
}
