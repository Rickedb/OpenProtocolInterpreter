using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.ParameterSet;

using OpenProtocolInterpreter;
using System.Collections.Generic;
namespace MIDTesters.ParameterSet
{
    [TestClass]
    [TestCategory("ParameterSet")]
    public class TestMid2505 : DefaultMidTests<Mid2505>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid2505Revision1()
        {
            string package = "00822505001         01000201000003010000000005010030190500000002022-08-12:13:33:22";
            var mid = _midInterpreter.Parse<Mid2505>(package);

            Assert.AreEqual(10, mid.ParameterSetId);
            Assert.AreEqual(2, mid.NumberOfParameterDataFields);
            Assert.AreEqual(2, mid.VariableDataFields.Count);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid2505ByteRevision1()
        {
            string package = "00462505001         01000101000003010000000005";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid2505>(bytes);

            Assert.AreEqual(10, mid.ParameterSetId);
            AssertEqualPackages(bytes, mid);
        }

        // [TestMethod]
        // [TestCategory("Revision 1"), TestCategory("ASCII")]
        // public void Mid2505ExtraDataRevision1()
        // {
        //     string package = "00910006001         25050016201000201000003010000000005010030190500000002022-08-12:13:33:22";
        //     var mid = _midInterpreter.Parse<Mid0006>(package);

        //     var extraDataMid = _midInterpreter.ParseExtra<Mid2505>(mid);
        //     Assert.AreEqual(10, extraDataMid.ParameterSetId);
        //     Assert.AreEqual(2, extraDataMid.NumberOfParameterDataFields);
        //     Assert.AreEqual(2, extraDataMid.VariableDataFields.Count);
        //     AssertEqualPackages(package, mid);
        // }

        // [TestMethod]
        // [TestCategory("Revision 1"), TestCategory("ByteArray")]
        // public void Mid2505ExtraDataByteRevision1()
        // {
        //     string package = "00350006001         250500106010000";
        //     byte[] bytes = GetAsciiBytes(package);
        //     var mid = _midInterpreter.Parse<Mid0006>(package);

        //     var extraDataMid = _midInterpreter.ParseExtra<Mid2505>(mid);
        //     Assert.AreEqual(10, extraDataMid.ParameterSetId);
        //     AssertEqualPackages(bytes, mid);
        // }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid2505PackRevision1()
        {
            string package = "00822505001         01000201000003010000000005010030190500000002022-08-12:13:33:22";

            AssertBuildAndParse(package, new Mid2505(1)
            {
                ParameterSetId = 10,
                NumberOfParameterDataFields = 2,
                VariableDataFields = new List<VariableDataField>()
                {
                    new VariableDataField() { ParameterId = 1000, Length = 3, DataType = DataTypeDefinition.UnsignedInteger, Unit = DataUnitType.NoUnit, StepNumber = 0, DataValue = "005" },
                    new VariableDataField() { ParameterId = 1003, Length = 19, DataType = DataTypeDefinition.Timestamp, Unit = DataUnitType.NoUnit, StepNumber = 0, DataValue = "2022-08-12:13:33:22" }
                }
            });
        }
    }
}
