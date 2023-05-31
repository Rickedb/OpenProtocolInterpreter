using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    [TestCategory("ParameterSet")]
    public class TestMid0024 : DefaultMidTests<Mid0024>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0024Revision1()
        {
            string package = "00200024            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0024), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0024ByteRevision1()
        {
            string package = "00200024            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0024), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
