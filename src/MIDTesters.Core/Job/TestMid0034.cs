using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0034 : DefaultMidTests<Mid0034>
    {
        [TestMethod]
        public void Mid0034AllRevisions()
        {
            string package = "00200034001         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0034), mid.GetType());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0034ByteAllRevisions()
        {
            string package = "00200034001         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0034), mid.GetType());
            AssertEqualPackages(bytes, mid);
        }
    }
}
