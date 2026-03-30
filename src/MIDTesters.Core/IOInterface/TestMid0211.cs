using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    [TestCategory("IOInterface")]
    public class TestMid0211 : DefaultMidTests<Mid0211>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0211Revision1()
        {
            string package = "00280211   1        10101011";
            var mid = _midInterpreter.Parse<Mid0211>(package);

            Assert.IsTrue(mid.Header.NoAckFlag);
            Assert.IsTrue(mid.StatusDigInOne);
            Assert.IsFalse(mid.StatusDigInTwo);
            Assert.IsTrue(mid.StatusDigInThree);
            Assert.IsFalse(mid.StatusDigInFour);
            Assert.IsTrue(mid.StatusDigInFive);
            Assert.IsFalse(mid.StatusDigInSix);
            Assert.IsTrue(mid.StatusDigInSeven);
            Assert.IsTrue(mid.StatusDigInEight);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0211ByteRevision1()
        {
            string package = "00280211   1        10101011";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0211>(bytes);

            Assert.IsTrue(mid.Header.NoAckFlag);
            Assert.IsTrue(mid.StatusDigInOne);
            Assert.IsFalse(mid.StatusDigInTwo);
            Assert.IsTrue(mid.StatusDigInThree);
            Assert.IsFalse(mid.StatusDigInFour);
            Assert.IsTrue(mid.StatusDigInFive);
            Assert.IsFalse(mid.StatusDigInSix);
            Assert.IsTrue(mid.StatusDigInSeven);
            Assert.IsTrue(mid.StatusDigInEight);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
