using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    [TestCategory("ParameterSet")]
    public class TestMid0014 : DefaultMidTests<Mid0014>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0014Revision1()
        {
            string package = "00200014            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0014), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0014ByteRevision1()
        {
            string package = "00200014            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0014), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
