using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.OpenProtocolCommandsDisabled;

namespace MIDTesters.OpenProtocolCommandsDisabled
{
    [TestClass]
    [TestCategory("OpenProtocolCommandsDisabled")]
    public class TestMid0423 : DefaultMidTests<Mid0423>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0423Revision1()
        {
            string package = "00200423            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0423), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0423ByteRevision1()
        {
            string package = "00200423            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0423), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
