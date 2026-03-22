using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;
using System;

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
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid1000ByteRevision1()
        {
            string pack = "00911000001         ABCDE2017-12-01:20:12:4500201700009040000000ALARMTEXT017010010100000001";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid1000>(bytes);

            Assert.AreEqual("ABCDE", mid.AlarmCode);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.Time);
            Assert.AreEqual(2, mid.NumberOfDataFields);
            Assert.AreEqual(2, mid.AlarmDataFields.Count);
            AssertEqualPackages(bytes, mid);
        }
    }
}
