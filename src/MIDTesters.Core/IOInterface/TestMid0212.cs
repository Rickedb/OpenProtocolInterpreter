using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0212 : DefaultMidTests<Mid0212>
    {
        [TestMethod]
        public void Mid0212Revision1()
        {
            string package = "00200212            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0212), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0212ByteRevision1()
        {
            string package = "00200212            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0212), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
