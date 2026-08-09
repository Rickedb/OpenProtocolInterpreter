using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Result;

namespace MIDTesters.Result
{
    [TestClass]
    [TestCategory("Result")]
    public class TestMid1203 : DefaultMidTests<Mid1203>
    {
        private const string Revision1Package = "00201203001         ";

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid1203Revision1()
        {
            var mid = _midInterpreter.Parse<Mid1203>(Revision1Package);

            Assert.AreEqual(typeof(Mid1203), mid.GetType());
            Assert.AreEqual(Mid1203.MID, mid.Header.Mid);
            AssertEqualPackages(Revision1Package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid1203ByteRevision1()
        {
            byte[] bytes = GetAsciiBytes(Revision1Package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid1203), mid.GetType());
            Assert.AreEqual(Mid1203.MID, mid.Header.Mid);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid1203PackRevision1()
        {
            AssertBuildAndParse(Revision1Package, new Mid1203());
        }
    }
}
