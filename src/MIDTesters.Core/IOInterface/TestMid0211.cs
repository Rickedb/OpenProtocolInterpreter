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
            Assert.IsNotNull(mid.StatusDigInOne);
            Assert.IsNotNull(mid.StatusDigInTwo);
            Assert.IsNotNull(mid.StatusDigInThree);
            Assert.IsNotNull(mid.StatusDigInFour);
            Assert.IsNotNull(mid.StatusDigInFive);
            Assert.IsNotNull(mid.StatusDigInSix);
            Assert.IsNotNull(mid.StatusDigInSeven);
            Assert.IsNotNull(mid.StatusDigInEight);
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
            Assert.IsNotNull(mid.StatusDigInOne);
            Assert.IsNotNull(mid.StatusDigInTwo);
            Assert.IsNotNull(mid.StatusDigInThree);
            Assert.IsNotNull(mid.StatusDigInFour);
            Assert.IsNotNull(mid.StatusDigInFive);
            Assert.IsNotNull(mid.StatusDigInSix);
            Assert.IsNotNull(mid.StatusDigInSeven);
            Assert.IsNotNull(mid.StatusDigInEight);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
