using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter;

namespace MIDTesters.Communication
{
    [TestClass]
    [TestCategory("Communication")]
    public class TestMid0002 : DefaultMidTests<Mid0002>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0002Revision1()
        {
            string pack = @"00570002001         010001020103Airbag1                  ";
            var mid = _midInterpreter.Parse<Mid0002>(pack);

            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("Airbag1", mid.ControllerName.TrimEnd());
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0002ByteRevision1()
        {
            string pack = @"00570002001         010001020103Airbag1                  ";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0002>(bytes);

            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("Airbag1", mid.ControllerName.TrimEnd());
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0002Revision2()
        {
            string pack = @"00620002002         010001020103Airbag1                  04ACT";
            var mid = _midInterpreter.Parse<Mid0002>(pack);

            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("Airbag1", mid.ControllerName.TrimEnd());
            Assert.AreEqual("ACT", mid.SupplierCode);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0002ByteRevision2()
        {
            string pack = @"00620002002         010001020103Airbag1                  04ACT";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0002>(bytes);

            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("Airbag1", mid.ControllerName.TrimEnd());
            Assert.AreEqual("ACT", mid.SupplierCode);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ASCII")]
        public void Mid0002Revision3()
        {
            string pack = @"01250002003         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   ";
            var mid = _midInterpreter.Parse<Mid0002>(pack);

            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("Airbag1", mid.ControllerName.TrimEnd());
            Assert.AreEqual("ACT", mid.SupplierCode);
            Assert.AreEqual("OpenProtocolVersion", mid.OpenProtocolVersion);
            Assert.AreEqual("Version 19.0.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual("Version 01.0.0.0", mid.ToolSoftwareVersion.TrimEnd());
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ByteArray")]
        public void Mid0002ByteRevision3()
        {
            string pack = @"01250002003         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   ";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0002>(bytes);

            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("Airbag1", mid.ControllerName.TrimEnd());
            Assert.AreEqual("ACT", mid.SupplierCode);
            Assert.AreEqual("OpenProtocolVersion", mid.OpenProtocolVersion);
            Assert.AreEqual("Version 19.0.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual("Version 01.0.0.0", mid.ToolSoftwareVersion.TrimEnd());
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ASCII")]
        public void Mid0002Revision4()
        {
            string pack = @"01630002004         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   08RBUType                 09Serial    ";
            var mid = _midInterpreter.Parse<Mid0002>(pack);

            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("Airbag1", mid.ControllerName.TrimEnd());
            Assert.AreEqual("ACT", mid.SupplierCode);
            Assert.AreEqual("OpenProtocolVersion", mid.OpenProtocolVersion);
            Assert.AreEqual("Version 19.0.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual("Version 01.0.0.0", mid.ToolSoftwareVersion.TrimEnd());
            Assert.AreEqual("RBUType", mid.RBUType.TrimEnd());
            Assert.AreEqual("Serial", mid.ControllerSerialNumber.TrimEnd());
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ByteArray")]
        public void Mid0002ByteRevision4()
        {
            string pack = @"01630002004         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   08RBUType                 09Serial    ";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0002>(bytes);

            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("Airbag1", mid.ControllerName.TrimEnd());
            Assert.AreEqual("ACT", mid.SupplierCode);
            Assert.AreEqual("OpenProtocolVersion", mid.OpenProtocolVersion);
            Assert.AreEqual("Version 19.0.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual("Version 01.0.0.0", mid.ToolSoftwareVersion.TrimEnd());
            Assert.AreEqual("RBUType", mid.RBUType.TrimEnd());
            Assert.AreEqual("Serial", mid.ControllerSerialNumber.TrimEnd());
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("ASCII")]
        public void Mid0002Revision5()
        {
            string pack = @"01730002005         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   08RBUType                 09Serial    1000211002";
            var mid = _midInterpreter.Parse<Mid0002>(pack);

            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("Airbag1", mid.ControllerName.TrimEnd());
            Assert.AreEqual("ACT", mid.SupplierCode);
            Assert.AreEqual("OpenProtocolVersion", mid.OpenProtocolVersion);
            Assert.AreEqual("Version 19.0.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual("Version 01.0.0.0", mid.ToolSoftwareVersion.TrimEnd());
            Assert.AreEqual("RBUType", mid.RBUType.TrimEnd());
            Assert.AreEqual("Serial", mid.ControllerSerialNumber.TrimEnd());
            Assert.AreEqual(SystemType.PowerMacs4000, mid.SystemType);
            Assert.AreEqual(SystemSubType.SystemRunningPresses, mid.SystemSubType);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("ByteArray")]
        public void Mid0002ByteRevision5()
        {
            string pack = @"01730002005         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   08RBUType                 09Serial    1000211002";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0002>(bytes);

            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("Airbag1", mid.ControllerName.TrimEnd());
            Assert.AreEqual("ACT", mid.SupplierCode);
            Assert.AreEqual("OpenProtocolVersion", mid.OpenProtocolVersion);
            Assert.AreEqual("Version 19.0.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual("Version 01.0.0.0", mid.ToolSoftwareVersion.TrimEnd());
            Assert.AreEqual("RBUType", mid.RBUType.TrimEnd());
            Assert.AreEqual("Serial", mid.ControllerSerialNumber.TrimEnd());
            Assert.AreEqual(SystemType.PowerMacs4000, mid.SystemType);
            Assert.AreEqual(SystemSubType.SystemRunningPresses, mid.SystemSubType);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 6"), TestCategory("ASCII")]
        public void Mid0002Revision6()
        {
            string pack = @"02210002006         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   08RBUType                 09Serial    100021100212013114429496729515Station Or Cell Name     16A";
            var mid = _midInterpreter.Parse<Mid0002>(pack);

            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("Airbag1", mid.ControllerName.TrimEnd());
            Assert.AreEqual("ACT", mid.SupplierCode);
            Assert.AreEqual("OpenProtocolVersion", mid.OpenProtocolVersion);
            Assert.AreEqual("Version 19.0.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual("Version 01.0.0.0", mid.ToolSoftwareVersion.TrimEnd());
            Assert.AreEqual("RBUType", mid.RBUType.TrimEnd());
            Assert.AreEqual("Serial", mid.ControllerSerialNumber.TrimEnd());
            Assert.AreEqual(SystemType.PowerMacs4000, mid.SystemType);
            Assert.AreEqual(SystemSubType.SystemRunningPresses, mid.SystemSubType);
            Assert.IsFalse(mid.SequenceNumberSupport);
            Assert.IsTrue(mid.LinkingHandlingSupport);
            Assert.AreEqual(4294967295L, mid.StationCellId);
            Assert.AreEqual("Station Or Cell Name", mid.StationCellName.TrimEnd());
            Assert.AreEqual("A", mid.ClientId);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 6"), TestCategory("ByteArray")]
        public void Mid0002ByteRevision6()
        {
            string pack = @"02210002006         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   08RBUType                 09Serial    100021100212013114429496729515Station Or Cell Name     16A";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0002>(bytes);

            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("Airbag1", mid.ControllerName.TrimEnd());
            Assert.AreEqual("ACT", mid.SupplierCode);
            Assert.AreEqual("OpenProtocolVersion", mid.OpenProtocolVersion);
            Assert.AreEqual("Version 19.0.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual("Version 01.0.0.0", mid.ToolSoftwareVersion.TrimEnd());
            Assert.AreEqual("RBUType", mid.RBUType.TrimEnd());
            Assert.AreEqual("Serial", mid.ControllerSerialNumber.TrimEnd());
            Assert.AreEqual(SystemType.PowerMacs4000, mid.SystemType);
            Assert.AreEqual(SystemSubType.SystemRunningPresses, mid.SystemSubType);
            Assert.IsFalse(mid.SequenceNumberSupport);
            Assert.IsTrue(mid.LinkingHandlingSupport);
            Assert.AreEqual(4294967295L, mid.StationCellId);
            Assert.AreEqual("Station Or Cell Name", mid.StationCellName.TrimEnd());
            Assert.AreEqual("A", mid.ClientId);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 7"), TestCategory("ASCII")]
        public void Mid0002Revision7()
        {
            string pack = @"02240002007         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   08RBUType                 09Serial    100021100212013114429496729515Station Or Cell Name     16A171";
            var mid = _midInterpreter.Parse<Mid0002>(pack);

            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("Airbag1", mid.ControllerName.TrimEnd());
            Assert.AreEqual("ACT", mid.SupplierCode);
            Assert.AreEqual("OpenProtocolVersion", mid.OpenProtocolVersion);
            Assert.AreEqual("Version 19.0.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual("Version 01.0.0.0", mid.ToolSoftwareVersion.TrimEnd());
            Assert.AreEqual("RBUType", mid.RBUType.TrimEnd());
            Assert.AreEqual("Serial", mid.ControllerSerialNumber.TrimEnd());
            Assert.AreEqual(SystemType.PowerMacs4000, mid.SystemType);
            Assert.AreEqual(SystemSubType.SystemRunningPresses, mid.SystemSubType);
            Assert.IsFalse(mid.SequenceNumberSupport);
            Assert.IsTrue(mid.LinkingHandlingSupport);
            Assert.AreEqual(4294967295L, mid.StationCellId);
            Assert.AreEqual("Station Or Cell Name", mid.StationCellName.TrimEnd());
            Assert.AreEqual("A", mid.ClientId);
            Assert.IsTrue(mid.OptionalKeepAlive);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 7"), TestCategory("ByteArray")]
        public void Mid0002ByteRevision7()
        {
            string pack = @"02240002007         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   08RBUType                 09Serial    100021100212013114429496729515Station Or Cell Name     16A171";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0002>(bytes);

            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("Airbag1", mid.ControllerName.TrimEnd());
            Assert.AreEqual("ACT", mid.SupplierCode);
            Assert.AreEqual("OpenProtocolVersion", mid.OpenProtocolVersion);
            Assert.AreEqual("Version 19.0.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual("Version 01.0.0.0", mid.ToolSoftwareVersion.TrimEnd());
            Assert.AreEqual("RBUType", mid.RBUType.TrimEnd());
            Assert.AreEqual("Serial", mid.ControllerSerialNumber.TrimEnd());
            Assert.AreEqual(SystemType.PowerMacs4000, mid.SystemType);
            Assert.AreEqual(SystemSubType.SystemRunningPresses, mid.SystemSubType);
            Assert.IsFalse(mid.SequenceNumberSupport);
            Assert.IsTrue(mid.LinkingHandlingSupport);
            Assert.AreEqual(4294967295L, mid.StationCellId);
            Assert.AreEqual("Station Or Cell Name", mid.StationCellName.TrimEnd());
            Assert.AreEqual("A", mid.ClientId);
            Assert.IsTrue(mid.OptionalKeepAlive);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0002PackRevision1()
        {
            string pack = @"00570002001         010001020103Airbag1                  ";

            AssertBuildAndParse(pack, new Mid0002(1)
            {
                CellId = 1,
                ChannelId = 1,
                ControllerName = "Airbag1"
            });
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("Pack")]
        public void Mid0002PackRevision2()
        {
            string pack = @"00620002002         010001020103Airbag1                  04ACT";

            AssertBuildAndParse(pack, new Mid0002(2)
            {
                CellId = 1,
                ChannelId = 1,
                ControllerName = "Airbag1",
                SupplierCode = "ACT"
            });
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("Pack")]
        public void Mid0002PackRevision3()
        {
            string pack = @"01250002003         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   ";

            AssertBuildAndParse(pack, new Mid0002(3)
            {
                CellId = 1,
                ChannelId = 1,
                ControllerName = "Airbag1",
                SupplierCode = "ACT",
                OpenProtocolVersion = "OpenProtocolVersion",
                ControllerSoftwareVersion = "Version 19.0.0.0",
                ToolSoftwareVersion = "Version 01.0.0.0"
            });
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("Pack")]
        public void Mid0002PackRevision4()
        {
            string pack = @"01630002004         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   08RBUType                 09Serial    ";

            AssertBuildAndParse(pack, new Mid0002(4)
            {
                CellId = 1,
                ChannelId = 1,
                ControllerName = "Airbag1",
                SupplierCode = "ACT",
                OpenProtocolVersion = "OpenProtocolVersion",
                ControllerSoftwareVersion = "Version 19.0.0.0",
                ToolSoftwareVersion = "Version 01.0.0.0",
                RBUType = "RBUType",
                ControllerSerialNumber = "Serial"
            });
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("Pack")]
        public void Mid0002PackRevision5()
        {
            string pack = @"01730002005         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   08RBUType                 09Serial    1000211002";

            AssertBuildAndParse(pack, new Mid0002(5)
            {
                CellId = 1,
                ChannelId = 1,
                ControllerName = "Airbag1",
                SupplierCode = "ACT",
                OpenProtocolVersion = "OpenProtocolVersion",
                ControllerSoftwareVersion = "Version 19.0.0.0",
                ToolSoftwareVersion = "Version 01.0.0.0",
                RBUType = "RBUType",
                ControllerSerialNumber = "Serial",
                SystemType = SystemType.PowerMacs4000,
                SystemSubType = SystemSubType.SystemRunningPresses
            });
        }

        [TestMethod]
        [TestCategory("Revision 6"), TestCategory("Pack")]
        public void Mid0002PackRevision6()
        {
            string pack = @"02210002006         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   08RBUType                 09Serial    100021100212013114429496729515Station Or Cell Name     16A";

            AssertBuildAndParse(pack, new Mid0002(6)
            {
                CellId = 1,
                ChannelId = 1,
                ControllerName = "Airbag1",
                SupplierCode = "ACT",
                OpenProtocolVersion = "OpenProtocolVersion",
                ControllerSoftwareVersion = "Version 19.0.0.0",
                ToolSoftwareVersion = "Version 01.0.0.0",
                RBUType = "RBUType",
                ControllerSerialNumber = "Serial",
                SystemType = SystemType.PowerMacs4000,
                SystemSubType = SystemSubType.SystemRunningPresses,
                SequenceNumberSupport = false,
                LinkingHandlingSupport = true,
                StationCellId = 4294967295L,
                StationCellName = "Station Or Cell Name",
                ClientId = "A"
            });
        }

        [TestMethod]
        [TestCategory("Revision 7"), TestCategory("Pack")]
        public void Mid0002PackRevision7()
        {
            string pack = @"02240002007         010001020103Airbag1                  04ACT05OpenProtocolVersion06Version 19.0.0.0   07Version 01.0.0.0   08RBUType                 09Serial    100021100212013114429496729515Station Or Cell Name     16A171";

            AssertBuildAndParse(pack, new Mid0002(7)
            {
                CellId = 1,
                ChannelId = 1,
                ControllerName = "Airbag1",
                SupplierCode = "ACT",
                OpenProtocolVersion = "OpenProtocolVersion",
                ControllerSoftwareVersion = "Version 19.0.0.0",
                ToolSoftwareVersion = "Version 01.0.0.0",
                RBUType = "RBUType",
                ControllerSerialNumber = "Serial",
                SystemType = SystemType.PowerMacs4000,
                SystemSubType = SystemSubType.SystemRunningPresses,
                SequenceNumberSupport = false,
                LinkingHandlingSupport = true,
                StationCellId = 4294967295L,
                StationCellName = "Station Or Cell Name",
                ClientId = "A",
                OptionalKeepAlive = true
            });
        }
    }
}
