using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationToolLocationSystem;

namespace MIDTesters.ApplicationToolLocationSystem
{
    [TestClass]
    public class TestMid0263 : DefaultMidTests<Mid0263>
    {
        [TestMethod]
        public void Mid0263Revision1()
        {
            string package = "00200263            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0263), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0263ByteRevision1()
        {
            string package = "00200263            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0263), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
