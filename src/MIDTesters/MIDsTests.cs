using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MIDs;
using OpenProtocolInterpreter.MIDs.Reply;
using OpenProtocolInterpreter.MIDs.KeepAlive;
using OpenProtocolInterpreter.MIDs.Job;
using OpenProtocolInterpreter.MIDs.Job.Advanced;

namespace MIDTesters
{
    [TestClass]
    public class MIDsTests
    {
        [TestMethod]
        public void TestMIDIdentifier()
        {
            this.TestReplyMessages();
            this.TestKeepAliveMessages();
        }

        [TestMethod]
        public void TestReplyMessages()
        {
            MIDIdentifier identifier = new MIDIdentifier();

            string mid04 = @"00260004001         001802";
            var myMid04 = identifier.IdentifyMid<MID_0004>(mid04);
            var package4 = myMid04.buildPackage();

            if (mid04 != package4)
                throw new Exception("Failed to build mid 0004 package");

            string mid05 = @"00240005001         0018";
            var myMid05 = identifier.IdentifyMid<MID_0005>(mid05);
            var package5 = myMid05.buildPackage();

            if (mid05 != package5)
                throw new Exception("Failed to build mid 0005 package");
        }

        [TestMethod]
        public void TestKeepAliveMessages()
        {
            MIDIdentifier identifier = new MIDIdentifier();

            string mid9999 = @"00209999001         ";
            var myMid9999 = identifier.IdentifyMid<MID_9999>(mid9999);
            var package = myMid9999.buildPackage();

            if (mid9999 != package)
                throw new Exception("Failed to build mid 9999 package");
        }

        [TestMethod]
        public void TestJobMessages()
        {
            MIDIdentifier identifier = new MIDIdentifier();

            string mid34 = @"00200034001         ";
            var myMid34 = identifier.IdentifyMid<MID_0034>(mid34);
            var package34 = myMid34.buildPackage();

            if (mid34 != package34)
                throw new Exception("Failed to build mid 34 package");

            string mid35 = @"00630035001         0101020030040008050003062001-12-01:20:12:45";
            var myMid35 = identifier.IdentifyMid<MID_0035>(mid35);
            var package35 = myMid35.buildPackage();

            if (mid35 != package35)
                throw new Exception("Failed to build mid 35 package");

            string mid36 = @"00200036001         ";
            var myMid36 = identifier.IdentifyMid<MID_0036>(mid36);
            var package36 = myMid36.buildPackage();

            if (mid36 != package36)
                throw new Exception("Failed to build mid 36 package");

            string mid37 = @"00200037001         ";
            var myMid37 = identifier.IdentifyMid<MID_0037>(mid37);
            var package37 = myMid37.buildPackage();

            if (mid37 != package37)
                throw new Exception("Failed to build mid 37 package");

            string mid38 = @"00200038001         01";
            var myMid38 = identifier.IdentifyMid<MID_0038>(mid38);
            var package38 = myMid38.buildPackage();

            if (mid38 != package38)
                throw new Exception("Failed to build mid 38 package");
        }

        [TestMethod]
        public void TestAdvancedJobMessages()
        {
            MIDIdentifier identifier = new MIDIdentifier();

            string mid127 = @"00200127001         ";
            var myMid127 = identifier.IdentifyMid<MID_0127>(mid127);
            var package = myMid127.buildPackage();

            if (mid127 != package)
                throw new Exception("Failed to build mid 127 package");
        }
    }
}
