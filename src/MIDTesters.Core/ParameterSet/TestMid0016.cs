using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    [TestCategory("ParameterSet")]
    public class TestMid0016 : DefaultMidTests<Mid0016>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0016Revision1()
        {
            string package = "00200016            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0016), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0016ByteRevision1()
        {
            string package = "00200016            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0016), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
