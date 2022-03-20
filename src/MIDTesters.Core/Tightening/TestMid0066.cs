using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tightening;

namespace MIDTesters.Tightening
{
    [TestClass]
    public class TestMid0066 : MidTester
    {
        [TestMethod]
        public void Mid0066Revision1()
        {
            string package = "00220066001         14";
            var mid = _midInterpreter.Parse<Mid0066>(package);

            Assert.AreEqual(typeof(Mid0066), mid.GetType());
            Assert.IsNotNull(mid.NumberOfOfflineResults);
            Assert.AreEqual(14, mid.NumberOfOfflineResults);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0066ByteRevision1()
        {
            string package = "00220066001         14";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0066>(bytes);

            Assert.AreEqual(typeof(Mid0066), mid.GetType());
            Assert.IsNotNull(mid.NumberOfOfflineResults);
            Assert.AreEqual(14, mid.NumberOfOfflineResults);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
