using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Result;
using System.Collections.Generic;

namespace MIDTesters.Result
{
    [TestClass]
    [TestCategory("Result")]
    public class TestMid1202 : DefaultMidTests<Mid1202>
    {
        private const string Revision1Package = "01221202001         0020010000000153001000301000003010000000005010030190500000002022-08-12:13:33:2201001006040000001TORQUE";
        private const string Revision2Package = "01581202002         002001000000015300101b6d1a1e-4b3f-4b1a-9c2d-7f5e8a9b0c1d00301000003010000000005010030190500000002022-08-12:13:33:2201001006040000001TORQUE";
        private const string NodeGuid = "1b6d1a1e-4b3f-4b1a-9c2d-7f5e8a9b0c1d";

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid1202Revision1()
        {
            var mid = _midInterpreter.Parse<Mid1202>(Revision1Package);

            AssertParsedMid1202(mid, revision: 1);
            AssertEqualPackages(Revision1Package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid1202ByteRevision1()
        {
            byte[] bytes = GetAsciiBytes(Revision1Package);
            var mid = _midInterpreter.Parse<Mid1202>(bytes);

            AssertParsedMid1202(mid, revision: 1);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid1202Revision2()
        {
            var mid = _midInterpreter.Parse<Mid1202>(Revision2Package);

            AssertParsedMid1202(mid, revision: 2);
            AssertEqualPackages(Revision2Package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid1202ByteRevision2()
        {
            byte[] bytes = GetAsciiBytes(Revision2Package);
            var mid = _midInterpreter.Parse<Mid1202>(bytes);

            AssertParsedMid1202(mid, revision: 2);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid1202PackRevision1()
        {
            AssertBuildAndParse(Revision1Package, BuildMid1202(1));
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("Pack")]
        public void Mid1202PackRevision2()
        {
            var mid = BuildMid1202(2);
            mid.NodeGuid = NodeGuid;

            AssertBuildAndParse(Revision2Package, mid);
        }

        private static Mid1202 BuildMid1202(int revision)
        {
            return new Mid1202(new Header() { Mid = Mid1202.MID, Revision = revision })
            {
                TotalNumberOfMessages = 2,
                MessageNumber = 1,
                ResultDataIdentifier = 153,
                ObjectId = 10,
                VariableDataFields = BuildVariableDataFields()
            };
        }

        private static List<VariableDataField> BuildVariableDataFields()
        {
            return new List<VariableDataField>()
            {
                new VariableDataField() { ParameterId = 1000, Length = 3, DataType = DataTypeDefinition.UnsignedInteger, Unit = DataUnitType.NoUnit, StepNumber = 0, DataValue = "005" },
                new VariableDataField() { ParameterId = 1003, Length = 19, DataType = DataTypeDefinition.Timestamp, Unit = DataUnitType.NoUnit, StepNumber = 0, DataValue = "2022-08-12:13:33:22" },
                new VariableDataField() { ParameterId = 1001, Length = 6, DataType = DataTypeDefinition.String, Unit = DataUnitType.NoUnit, StepNumber = 1, DataValue = "TORQUE" }
            };
        }

        private static void AssertParsedMid1202(Mid1202 mid, int revision)
        {
            Assert.AreEqual(2, mid.TotalNumberOfMessages);
            Assert.AreEqual(1, mid.MessageNumber);
            Assert.AreEqual(153, mid.ResultDataIdentifier);
            Assert.AreEqual(10, mid.ObjectId);

            if (revision > 1)
            {
                Assert.AreEqual(NodeGuid, mid.NodeGuid);
            }

            Assert.AreEqual(3, mid.NumberOfDataFields);
            Assert.AreEqual(3, mid.VariableDataFields.Count);

            var unsignedInteger = mid.VariableDataFields[0];
            Assert.AreEqual(1000, unsignedInteger.ParameterId);
            Assert.AreEqual(3, unsignedInteger.Length);
            Assert.AreEqual(DataTypeDefinition.UnsignedInteger, unsignedInteger.DataType);
            Assert.AreEqual(DataUnitType.NoUnit, unsignedInteger.Unit);
            Assert.AreEqual(0, unsignedInteger.StepNumber);
            Assert.AreEqual("005", unsignedInteger.DataValue);

            var timestamp = mid.VariableDataFields[1];
            Assert.AreEqual(1003, timestamp.ParameterId);
            Assert.AreEqual(19, timestamp.Length);
            Assert.AreEqual(DataTypeDefinition.Timestamp, timestamp.DataType);
            Assert.AreEqual(0, timestamp.StepNumber);
            Assert.AreEqual("2022-08-12:13:33:22", timestamp.DataValue);

            var text = mid.VariableDataFields[2];
            Assert.AreEqual(1001, text.ParameterId);
            Assert.AreEqual(6, text.Length);
            Assert.AreEqual(DataTypeDefinition.String, text.DataType);
            Assert.AreEqual(1, text.StepNumber);
            Assert.AreEqual("TORQUE", text.DataValue);
        }
    }
}
