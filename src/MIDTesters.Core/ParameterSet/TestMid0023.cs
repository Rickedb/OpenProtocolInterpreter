using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    [TestCategory("ParameterSet")]
    public class TestMid0023 : DefaultMidTests<Mid0023>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0023Revision1()
        {
            string package = "00200023            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0023), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0023ByteRevision1()
        {
            string package = "00200023            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0023), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
