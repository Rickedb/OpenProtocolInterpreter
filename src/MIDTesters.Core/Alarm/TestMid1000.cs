using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Alarm;
using System;

using System.Collections.Generic;
namespace MIDTesters.Alarm
{
    [TestClass]
    [TestCategory("Alarm")]
    public class TestMid1000 : DefaultMidTests<Mid1000>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid1000Revision1()
        {
            string pack = "00911000001         ABCDE2017-12-01:20:12:4500201700009040000000ALARMTEXT017010010100000001";
            var mid = _midInterpreter.Parse<Mid1000>(pack);

            Assert.AreEqual("ABCDE", mid.AlarmCode);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.Time);
            Assert.AreEqual(2, mid.NumberOfDataFields);
            Assert.AreEqual(2, mid.AlarmDataFields.Count);

            var alarmText = mid.AlarmDataFields[0];
            Assert.AreEqual(1700, alarmText.ParameterId);
            Assert.AreEqual(9, alarmText.Length);
            Assert.AreEqual(DataTypeDefinition.String, alarmText.DataType);
            Assert.AreEqual(DataUnitType.NoUnit, alarmText.Unit);
            Assert.AreEqual(0, alarmText.StepNumber);
            Assert.AreEqual("ALARMTEXT", alarmText.DataValue);

            var alarmFlag = mid.AlarmDataFields[1];
            Assert.AreEqual(1701, alarmFlag.ParameterId);
            Assert.AreEqual(1, alarmFlag.Length);
            Assert.AreEqual(DataTypeDefinition.UnsignedInteger, alarmFlag.DataType);
            Assert.AreEqual(DataUnitType.NoUnit, alarmFlag.Unit);
            Assert.AreEqual(0, alarmFlag.StepNumber);
            Assert.AreEqual("1", alarmFlag.DataValue);

            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid1000ByteRevision1()
        {
            string pack = "00911000001         ABCDE2017-12-01:20:12:4500201700009040000000TEXTALARM017010010100000002";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid1000>(bytes);

            Assert.AreEqual("ABCDE", mid.AlarmCode);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.Time);
            Assert.AreEqual(2, mid.NumberOfDataFields);
            Assert.AreEqual(2, mid.AlarmDataFields.Count);

            var alarmText = mid.AlarmDataFields[0];
            Assert.AreEqual(1700, alarmText.ParameterId);
            Assert.AreEqual(9, alarmText.Length);
            Assert.AreEqual(DataTypeDefinition.String, alarmText.DataType);
            Assert.AreEqual(DataUnitType.NoUnit, alarmText.Unit);
            Assert.AreEqual(0, alarmText.StepNumber);
            Assert.AreEqual("TEXTALARM", alarmText.DataValue);

            var alarmFlag = mid.AlarmDataFields[1];
            Assert.AreEqual(1701, alarmFlag.ParameterId);
            Assert.AreEqual(1, alarmFlag.Length);
            Assert.AreEqual(DataTypeDefinition.UnsignedInteger, alarmFlag.DataType);
            Assert.AreEqual(DataUnitType.NoUnit, alarmFlag.Unit);
            Assert.AreEqual(0, alarmFlag.StepNumber);
            Assert.AreEqual("2", alarmFlag.DataValue);

            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid1000PackRevision1()
        {
            string pack = "00911000001         ABCDE2017-12-01:20:12:4500201700009040000000ALARMTEXT017010010100000001";

            AssertBuildAndParse(pack, new Mid1000(1)
            {
                AlarmCode = "ABCDE",
                Time = new DateTime(2017, 12, 1, 20, 12, 45),
                NumberOfDataFields = 2,
                AlarmDataFields = new List<VariableDataField>()
                {
                    new VariableDataField() { ParameterId = 1700, Length = 9, DataType = DataTypeDefinition.String, Unit = DataUnitType.NoUnit, StepNumber = 0, DataValue = "ALARMTEXT" },
                    new VariableDataField() { ParameterId = 1701, Length = 1, DataType = DataTypeDefinition.UnsignedInteger, Unit = DataUnitType.NoUnit, StepNumber = 0, DataValue = "1" }
                }
            });
        }
    }
}
