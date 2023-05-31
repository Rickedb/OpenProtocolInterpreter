using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationSelector;

namespace MIDTesters.ApplicationSelector
{
    [TestClass]
    [TestCategory("ApplicationSelector")]
    public class TestMid0252 : DefaultMidTests<Mid0252>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0252Revision1()
        {
            string package = "00200252            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0252), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0252ByteRevision1()
        {
            string package = "00200252            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0252), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
