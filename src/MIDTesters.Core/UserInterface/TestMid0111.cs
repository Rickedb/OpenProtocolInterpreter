using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.UserInterface;
using OpenProtocolInterpreter;

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

            Assert.AreEqual(2005, mid.TextDuration);
            Assert.AreEqual(RemovalCondition.Acknowledge, mid.RemovalCondition);
            Assert.AreEqual("Header Text", mid.Line1.TrimEnd());
            Assert.AreEqual("Line 2 Text", mid.Line2.TrimEnd());
            Assert.AreEqual("Line 3 Text", mid.Line3.TrimEnd());
            Assert.AreEqual("Line 4 Text", mid.Line4.TrimEnd());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0111ByteRevision1()
        {
            string package = "01370111001         01200502103Header Text              04Line 2 Text              05Line 3 Text              06Line 4 Text              ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0111>(bytes);

            Assert.AreEqual(2005, mid.TextDuration);
            Assert.AreEqual(RemovalCondition.Acknowledge, mid.RemovalCondition);
            Assert.AreEqual("Header Text", mid.Line1.TrimEnd());
            Assert.AreEqual("Line 2 Text", mid.Line2.TrimEnd());
            Assert.AreEqual("Line 3 Text", mid.Line3.TrimEnd());
            Assert.AreEqual("Line 4 Text", mid.Line4.TrimEnd());
            AssertEqualPackages(bytes, mid);
        }
    }
}
