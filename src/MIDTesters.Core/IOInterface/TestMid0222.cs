using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0222 : DefaultMidTests<Mid0222>
    {
        [TestMethod]
        public void Mid0222Revision1()
        {
            string package = "00200222            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0222), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0222ByteRevision1()
        {
            string package = "00200222            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0222), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
