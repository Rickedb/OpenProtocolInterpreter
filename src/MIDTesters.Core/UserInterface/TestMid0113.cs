using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.UserInterface;

namespace MIDTesters.UserInterface
{
    [TestClass]
    public class TestMid0113 : DefaultMidTests<Mid0113>
    {
        [TestMethod]
        public void Mid0113Revision1()
        {
            string package = "00200113            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0113), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0113ByteAllRevisions()
        {
            string package = "00200113            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0113), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
