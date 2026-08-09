using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

using System.Collections.Generic;
using OpenProtocolInterpreter;
namespace MIDTesters.Tool
{
    [TestClass]
    [TestCategory("Tool")]
    public class TestMid0703 : DefaultMidTests<Mid0703>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0703Revision1()
        {
            string package = "01050703001         0100400301200012040000000QST50-150CTT01202012040000000SERIALNUMBER0120300201000000011";
            var mid = _midInterpreter.Parse<Mid0703>(package);

            Assert.AreEqual(3, mid.CalibrationParameters.Count);
            Assert.AreEqual(3, mid.NumberOfCalibrationParameters);
            Assert.AreEqual(40, mid.ToolNumber);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0703ByteRevision1()
        {
            string package = "01050703001         0100400301200012040000000QST50-150CTT01202012040000000SERIALNUMBER0120300201000000011";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0703>(bytes);

            Assert.AreEqual(3, mid.CalibrationParameters.Count);
            Assert.AreEqual(3, mid.NumberOfCalibrationParameters);
            Assert.AreEqual(40, mid.ToolNumber);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0703PackRevision1()
        {
            string package = "01050703001         0100400301200012040000000QST50-150CTT01202012040000000SERIALNUMBER0120300201000000011";

            AssertBuildAndParse(package, new Mid0703()
            {
                ToolNumber = 40,
                NumberOfCalibrationParameters = 3,
                CalibrationParameters = new List<VariableDataField>()
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
