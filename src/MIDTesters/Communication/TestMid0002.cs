using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDTesters.Communication
{
    [TestClass]
    public class TestMid0002 : MidTester
    {
        [TestMethod]
        public void Mid0002Revision1()
        {
            string pack = @"00570002001         010001020103Airbag1                  ";
            var mid = _midInterpreter.Parse<MID_0002>(pack);

            Assert.AreEqual(typeof(MID_0002), mid.GetType());
            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.ControllerName);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0002Revision2()
        {
            string pack = @"00620002002         010001020103Airbag1                  04ACT";
            var mid = _midInterpreter.Parse<MID_0002>(pack);

            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.ControllerName);
            Assert.IsNotNull(mid.SupplierCode);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0002Revision3()
        {
            string pack = @"01250002003         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   ";
            var mid = _midInterpreter.Parse<MID_0002>(pack);

            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.ControllerName);
            Assert.IsNotNull(mid.SupplierCode);
            Assert.IsNotNull(mid.OpenProtocolVersion);
            Assert.IsNotNull(mid.ControllerSoftwareVersion);
            Assert.IsNotNull(mid.ToolSoftwareVersion);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0002Revision4()
        {
            string pack = @"01630002004         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   08RBUType                 09Serial    ";
            var mid = _midInterpreter.Parse<MID_0002>(pack);

            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.ControllerName);
            Assert.IsNotNull(mid.SupplierCode);
            Assert.IsNotNull(mid.OpenProtocolVersion);
            Assert.IsNotNull(mid.ControllerSoftwareVersion);
            Assert.IsNotNull(mid.ToolSoftwareVersion);
            Assert.IsNotNull(mid.RBUType);
            Assert.IsNotNull(mid.ControllerSerialNumber);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0002Revision5()
        {
            string pack = @"01730002005         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   08RBUType                 09Serial    1000211002";
            var mid = _midInterpreter.Parse<MID_0002>(pack);

            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.ControllerName);
            Assert.IsNotNull(mid.SupplierCode);
            Assert.IsNotNull(mid.OpenProtocolVersion);
            Assert.IsNotNull(mid.ControllerSoftwareVersion);
            Assert.IsNotNull(mid.ToolSoftwareVersion);
            Assert.IsNotNull(mid.RBUType);
            Assert.IsNotNull(mid.ControllerSerialNumber);
            Assert.IsNotNull(mid.SystemType);
            Assert.IsNotNull(mid.SystemSubType);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0002Revision6()
        {
            string pack = @"01790002006         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   08RBUType                 09Serial    1000211002120131";
            var mid = _midInterpreter.Parse<MID_0002>(pack);

            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.ControllerName);
            Assert.IsNotNull(mid.SupplierCode);
            Assert.IsNotNull(mid.OpenProtocolVersion);
            Assert.IsNotNull(mid.ControllerSoftwareVersion);
            Assert.IsNotNull(mid.ToolSoftwareVersion);
            Assert.IsNotNull(mid.RBUType);
            Assert.IsNotNull(mid.ControllerSerialNumber);
            Assert.IsNotNull(mid.SystemType);
            Assert.IsNotNull(mid.SystemSubType);
            Assert.IsNotNull(mid.SequenceNumberSupport);
            Assert.IsNotNull(mid.LinkingHandlingSupport);
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
