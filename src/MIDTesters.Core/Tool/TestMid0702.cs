using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Tool;

using OpenProtocolInterpreter;
using System.Collections.Generic;
namespace MIDTesters.Tool
{
    [TestClass]
    [TestCategory("Tool")]
    public class TestMid0702 : DefaultMidTests<Mid0702>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0702Revision1()
        {
            string package = "01000702001         00301200012040000000QST50-150CTT01202012040000000SERIALNUMBER0120300201000000011";
            var mid = _midInterpreter.Parse<Mid0702>(package);

            Assert.AreEqual(3, mid.ToolDataUpload.Count);
            Assert.AreEqual(3, mid.NumberOfToolPIDs);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0702ByteRevision1()
        {
            string package = "01000702001         00301200012040000000QST50-150CTT01202012040000000SERIALNUMBER0120300201000000011";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0702>(bytes);

            Assert.AreEqual(3, mid.ToolDataUpload.Count);
            Assert.AreEqual(3, mid.NumberOfToolPIDs);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0702ExtraDataRequestRevision1()
        {
            string package = "00350006001         070200106010003";
            var mid = _midInterpreter.Parse<Mid0006>(package);

            var extraData = _midInterpreter.ParseExtraData<Mid0702ExtraData>(mid);
            Assert.AreEqual(Mid0006.MID, mid.Header.Mid);
            Assert.AreEqual(Mid0702.MID, mid.RequestedMid);
            Assert.AreEqual(1, mid.WantedRevision);
            Assert.AreEqual(6, mid.ExtraDataLength);
            Assert.AreEqual(3, extraData.ToolNumber);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0702ExtraDataRequestByteRevision1()
        {
            string package = "00350006001         070200106010003";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0006>(bytes);

            var extraData = _midInterpreter.ParseExtraData<Mid0702ExtraData>(mid);

            Assert.AreEqual(Mid0702.MID, mid.RequestedMid);
            Assert.AreEqual(1, mid.WantedRevision);
            Assert.AreEqual(6, mid.ExtraDataLength);
            Assert.AreEqual(3, extraData.ToolNumber);
            AssertEqualPackages(bytes, mid);
        }


        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0702PackRevision1()
        {
            string package = "01000702001         00301200012040000000QST50-150CTT01202012040000000SERIALNUMBER0120300201000000011";

            AssertBuildAndParse(package, new Mid0702()
            {
                NumberOfToolPIDs = 3,
                ToolDataUpload = new List<VariableDataField>()
                {
                    new VariableDataField()
                    {
                        ParameterId = 1200,
                        Length = 12,
                        DataType = DataTypeDefinition.String,
                        Unit = DataUnitType.NoUnit,
                        StepNumber = 0,
                        DataValue = "QST50-150CTT"
                    },
                    new VariableDataField()
                    {
                        ParameterId = 1202,
                        Length = 12,
                        DataType = DataTypeDefinition.String,
                        Unit = DataUnitType.NoUnit,
                        StepNumber = 0,
                        DataValue = "SERIALNUMBER"
                    },
                    new VariableDataField()
                    {
                        ParameterId = 1203,
                        Length = 2,
                        DataType = DataTypeDefinition.UnsignedInteger,
                        Unit = DataUnitType.NoUnit,
                        StepNumber = 0,
                        DataValue = "11"
                    }
                }
            });
        }
    }
}
