using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;
using System.Linq;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0022 : MidTester
    {
        [TestMethod]
        public void Mid0022Revision1()
        {
            string package = "00210022   1        1";
            var mid = _midInterpreter.Parse<Mid0022>(package);

            Assert.AreEqual(typeof(Mid0022), mid.GetType());
            Assert.IsNotNull(mid.Header.NoAckFlag);
            Assert.IsNotNull(mid.RelayStatus);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0022ByteRevision1()
        {
            string package = "00210022   1        1";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0022>(bytes);

            Assert.AreEqual(typeof(Mid0022), mid.GetType());
            Assert.IsNotNull(mid.Header.NoAckFlag);
            Assert.IsNotNull(mid.RelayStatus);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
