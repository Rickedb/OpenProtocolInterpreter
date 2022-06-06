using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationToolLocationSystem;

namespace MIDTesters.ApplicationToolLocationSystem
{
    [TestClass]
    public class TestMid0264 : DefaultMidTests<Mid0264>
    {
        [TestMethod]
        public void Mid0264Revision1()
        {
            string package = "00200264            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0264), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0264ByteRevision1()
        {
            string package = "00200264            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0264), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
