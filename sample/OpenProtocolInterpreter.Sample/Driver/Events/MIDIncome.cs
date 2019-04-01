using OpenProtocolInterpreter;
using System;

namespace OpenProtocolInterpreter.Sample.Driver.Events
{
    public class MIDIncome : EventArgs
    {
        public Mid Mid { get; set; }
    }
}