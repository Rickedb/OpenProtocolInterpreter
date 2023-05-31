using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.UserInterface;

namespace MIDTesters.UserInterface
{
    [TestClass]
    [TestCategory("UserInterface")]
    public class TestMid0111 : DefaultMidTests<Mid0111>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0111Revision1()
        {
            string package = "01370111001         01200502103Header Text              04Line 2 Text              05Line 3 Text              06Line 4 Text              ";
            var mid = _midInterpreter.Parse<Mid0111>(package);

            Assert.IsNotNull(mid.TextDuration);
            Assert.IsNotNull(mid.RemovalCondition);
            Assert.IsNotNull(mid.Line1);
            Assert.IsNotNull(mid.Line2);
            Assert.IsNotNull(mid.Line3);
            Assert.IsNotNull(mid.Line4);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0111ByteRevision1()
        {
            string package = "01370111001         01200502103Header Text              04Line 2 Text              05Line 3 Text              06Line 4 Text              ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0111>(bytes);

            Assert.IsNotNull(mid.TextDuration);
            Assert.IsNotNull(mid.RemovalCondition);
            Assert.IsNotNull(mid.Line1);
            Assert.IsNotNull(mid.Line2);
            Assert.IsNotNull(mid.Line3);
            Assert.IsNotNull(mid.Line4);
            AssertEqualPackages(bytes, mid);
        }
    }
}
