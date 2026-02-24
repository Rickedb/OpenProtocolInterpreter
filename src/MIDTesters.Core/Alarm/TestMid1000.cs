using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

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

            Assert.IsNotNull(mid.AlarmCode);
            Assert.IsNotNull(mid.Time);
            Assert.IsNotNull(mid.AlarmDataFields);
            Assert.AreEqual(2, mid.NumberOfDataFields);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid1000ByteRevision1()
        {
            string pack = "00911000001         ABCDE2017-12-01:20:12:4500201700009040000000ALARMTEXT017010010100000001";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid1000>(bytes);

            Assert.IsNotNull(mid.AlarmCode);
            Assert.IsNotNull(mid.Time);
            Assert.IsNotNull(mid.AlarmDataFields);
            Assert.AreEqual(2, mid.NumberOfDataFields);
            AssertEqualPackages(bytes, mid);
        }
    }
}
