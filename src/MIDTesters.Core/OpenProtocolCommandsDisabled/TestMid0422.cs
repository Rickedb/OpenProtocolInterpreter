using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.OpenProtocolCommandsDisabled;

namespace MIDTesters.OpenProtocolCommandsDisabled
{
    [TestClass]
    public class TestMid0422 : DefaultMidTests<Mid0422>
    {
        [TestMethod]
        public void Mid0422Revision1()
        {
            string package = "00200422            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0422), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0422ByteRevision1()
        {
            string package = "00200422            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0422), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
