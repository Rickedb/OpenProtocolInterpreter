using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    [TestCategory("Tool")]
    public class TestMid0043 : DefaultMidTests<Mid0043>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0043Revision1()
        {
            string package = "00200043            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0043), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0043ByteRevision1()
        {
            string package = "00200043            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0043), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0043Revision2()
        {
            string package = "00260043002         010042";
            var mid = _midInterpreter.Parse<Mid0043>(package);

            Assert.IsNotNull(mid.ToolNumber);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0043ByteRevision2()
        {
            string package = "00260043002         010032";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0043>(bytes);

            Assert.IsNotNull(mid.ToolNumber);
            AssertEqualPackages(bytes, mid);
        }
    }
}
