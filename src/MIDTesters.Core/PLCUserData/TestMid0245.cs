using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PLCUserData;

namespace MIDTesters.PLCUserData
{
    [TestClass]
    public class TestMid0245 : DefaultMidTests<Mid0245>
    {
        [TestMethod]
        public void Mid0245Revision1()
        {
            string package = "00460245            022My identifier less than";
            var mid = _midInterpreter.Parse<Mid0245>(package);

            Assert.IsNotNull(mid.Offset);
            Assert.IsNotNull(mid.UserData);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0245ByteRevision1()
        {
            string package = "00460245            022My identifier less than";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0245>(bytes);

            Assert.IsNotNull(mid.Offset);
            Assert.IsNotNull(mid.UserData);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        public void Mid0245UserDataShouldPadMinimum()
        {
            var mid0245 = new Mid0245();
            Assert.IsTrue(mid0245.Pack().Length == 25);
        }

        [TestMethod]
        public void Mid0245ShouldTrucanteUserData()
        {
            string userData = "the phrase the quick brown fox jumps over the lazy dog should test all the letter keys in your keyboard ";
            userData += userData; //double it to get 208 characters

            var mid0245 = new Mid0245(2, userData);
            Assert.IsNotNull(mid0245.UserData);
            Assert.AreEqual(userData.Substring(0, 200), mid0245.UserData);
            Assert.IsTrue(mid0245.Pack().Length == 223);
        }
    }
}
