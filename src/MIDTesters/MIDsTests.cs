using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MIDs;
using OpenProtocolInterpreter.MIDs.Reply;

namespace MIDTesters
{
    [TestClass]
    public class MIDsTests
    {
        [TestMethod]
        public void TestMIDIdentifier()
        {
            this.TestReplyMessages();
        }

        private bool TestReplyMessages()
        {
            string mid05 = "00240005            0018NUL";
            MIDIdentifier identifier = new MIDIdentifier();

            var myMid05 = identifier.IdentifyMid<MID_0005>(mid05);

            return true;
        }
    }
}
