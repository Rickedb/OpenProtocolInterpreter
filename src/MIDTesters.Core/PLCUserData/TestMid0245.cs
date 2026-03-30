using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PLCUserData;

namespace MIDTesters.PLCUserData
{
    [TestClass]
    [TestCategory("PLCUserData")]
    public class TestMid0245 : DefaultMidTests<Mid0245>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0245Revision1()
        {
            string package = "00460245            022My identifier less than";
            var mid = _midInterpreter.Parse<Mid0245>(package);

            Assert.AreEqual(22, mid.Offset);
            Assert.AreEqual("My identifier less than", mid.UserData);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0245ByteRevision1()
        {
            string package = "00460245            022My identifier less than";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0245>(bytes);

            Assert.AreEqual(22, mid.Offset);
            Assert.AreEqual("My identifier less than", mid.UserData);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        public void Mid0245ShouldTruncateUserData()
        {
            string userData = "the phrase the quick brown fox jumps over the lazy dog should test all the letter keys in your keyboard ";
            userData += userData; //double it to get 208 characters

            var mid0245 = new Mid0245(2) { Offset = 0, UserData = userData };
            Assert.AreEqual(0, mid0245.Offset);
            Assert.AreEqual(208, mid0245.UserData.Length);
            Assert.IsTrue(mid0245.Pack().Length == 223);
        }
    }
}
