using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    [TestCategory("ParameterSet")]
    public class TestMid0017 : DefaultMidTests<Mid0017>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0017Revision1()
        {
            string package = "00200017            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0017), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0017ByteRevision1()
        {
            string package = "00200017            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0017), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
