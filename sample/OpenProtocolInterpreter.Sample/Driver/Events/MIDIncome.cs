using OpenProtocolInterpreter.MIDs;
using System;

namespace OpenProtocolInterpreter.Sample.Driver.Events
{
    public class MIDIncome : EventArgs
    {
        public MID Mid { get; set; }
    }
}
