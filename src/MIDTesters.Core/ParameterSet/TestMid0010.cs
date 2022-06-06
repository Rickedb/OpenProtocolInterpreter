using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0010 : DefaultMidTests<Mid0010>
    {
        [TestMethod]
        public void Mid0010AllRevisions()
        {
            string package = "00200010002         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0010), mid.GetType());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0010ByteAllRevisions()
        {
            string package = "00200010002         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0010), mid.GetType());
            AssertEqualPackages(bytes, mid);
        }
    }
}
