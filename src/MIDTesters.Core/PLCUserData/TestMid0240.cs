using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PLCUserData;

namespace MIDTesters.PLCUserData
{
    [TestClass]
    public class TestMid0240 : DefaultMidTests<Mid0240>
    {
        [TestMethod]
        public void Mid0240Revision1()
        {
            string package = "00470240            My identifier less than 200";
            var mid = _midInterpreter.Parse<Mid0240>(package);

            Assert.IsNotNull(mid.UserData);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0240ByteRevision1()
        {
            string package = "00470240            My identifier less than 200";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0240>(bytes);
            
            Assert.IsNotNull(mid.UserData);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        public void Mid0240ShouldTrucanteUserData()
        {
            string userData = "the phrase the quick brown fox jumps over the lazy dog should test all the letter keys in your keyboard ";
            userData += userData; //double it to get 208 characters

            var mid0240 = new Mid0240(userData);
            Assert.IsNotNull(mid0240.UserData);
            Assert.AreEqual(userData.Substring(0, 200), mid0240.UserData);
            Assert.IsTrue(mid0240.Pack().Length == 220);
        }
    }
}
