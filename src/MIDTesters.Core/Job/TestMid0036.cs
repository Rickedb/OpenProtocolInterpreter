using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0036 : DefaultMidTests<Mid0036>
    {
        [TestMethod]
        public void Mid0036AllRevisions()
        {
            string package = "00200036001         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0036), mid.GetType());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0036ByteAllRevisions()
        {
            string package = "00200036001         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0036), mid.GetType());
            AssertEqualPackages(bytes, mid);
        }
    }
}
