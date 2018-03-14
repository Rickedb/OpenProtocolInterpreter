using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MIDs;
using OpenProtocolInterpreter.MIDs.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDTesters.Communication
{
    [TestClass]
    public class Mid0002Packs
    {
        [TestMethod]
        public void Mid02Revision1()
        {
            MIDIdentifier identifier = new MIDIdentifier();

            string mid02 = @"00570002001         010001020103Airbag1                  ";
            var myMid02 = identifier.IdentifyMid<MID_0002>(mid02);
            var package2 = myMid02.BuildPackage();

            Assert.IsNotNull(myMid02.CellID);
            Assert.IsNotNull(myMid02.ChannelID);
            Assert.IsNotNull(myMid02.ControllerName);
            Assert.AreEqual(mid02, package2);
        }

        [TestMethod]
        public void Mid02Revision2()
        {
            MIDIdentifier identifier = new MIDIdentifier();

            string mid02 = @"00570002002         010001020103Airbag1                  04ACT";
            var myMid02 = identifier.IdentifyMid<MID_0002>(mid02);
            var package2 = myMid02.BuildPackage();

            Assert.IsNotNull(myMid02.SupplierCode);
            Assert.AreEqual(mid02, package2);
        }

        [TestMethod]
        public void Mid02Revision3()
        {
            MIDIdentifier identifier = new MIDIdentifier();

            string mid02 = @"00570002003         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   ";
            var myMid02 = identifier.IdentifyMid<MID_0002>(mid02);
            var package2 = myMid02.BuildPackage();

            Assert.IsNotNull(myMid02.OpenProtocolVersion);
            Assert.IsNotNull(myMid02.ControllerSoftwareVersion);
            Assert.IsNotNull(myMid02.ToolSoftwareVersion);
            Assert.AreEqual(mid02, package2);
        }

        [TestMethod]
        public void Mid02Revision4()
        {
            MIDIdentifier identifier = new MIDIdentifier();

            string mid02 = @"00570002004         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   08RBUType                 09Serial    ";
            var myMid02 = identifier.IdentifyMid<MID_0002>(mid02);
            var package2 = myMid02.BuildPackage();

            Assert.IsNotNull(myMid02.RBUType);
            Assert.IsNotNull(myMid02.ControllerSerialNumber);
            Assert.AreEqual(mid02, package2);
        }

        [TestMethod]
        public void Mid02Revision5()
        {
            MIDIdentifier identifier = new MIDIdentifier();

            string mid02 = @"00570002005         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   08RBUType                 09Serial    1000211002";
            var myMid02 = identifier.IdentifyMid<MID_0002>(mid02);
            var package2 = myMid02.BuildPackage();

            Assert.IsNotNull(myMid02.SystemType);
            Assert.IsNotNull(myMid02.SystemSubType);
            Assert.AreEqual(mid02, package2);
        }

        [TestMethod]
        public void Mid02Revision6()
        {
            MIDIdentifier identifier = new MIDIdentifier();

            string mid02 = @"00570002006         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   08RBUType                 09Serial    1000211002120131";
            var myMid02 = identifier.IdentifyMid<MID_0002>(mid02);
            var package2 = myMid02.BuildPackage();

            Assert.IsNotNull(myMid02.SequenceNumberSupport);
            Assert.IsNotNull(myMid02.LinkingHandlingSupport);
            Assert.AreEqual(mid02, package2);
        }
    }
}
