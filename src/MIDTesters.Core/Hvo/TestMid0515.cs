using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Hvo;

namespace MIDTesters.Hvo
{
    [TestClass]
    [TestCategory("Hvo")]
    public class TestMid0515 : DefaultMidTests<Mid0515>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0515Revision1()
        {
            string package = "00320515001         011022033044";
            var mid = _midInterpreter.Parse<Mid0515>(package);

            Assert.AreEqual(1, mid.Lamp1);
            Assert.AreEqual(2, mid.Lamp2);
            Assert.AreEqual(3, mid.Lamp3);
            Assert.AreEqual(4, mid.Lamp4);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0515ByteRevision1()
        {
            string package = "00320515001         011022033044";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0515>(bytes);

            Assert.AreEqual(1, mid.Lamp1);
            Assert.AreEqual(2, mid.Lamp2);
            Assert.AreEqual(3, mid.Lamp3);
            Assert.AreEqual(4, mid.Lamp4);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0515Revision2()
        {
            string package = "00300515002         0100102003";
            var mid = _midInterpreter.Parse<Mid0515>(package);

            Assert.AreEqual(1, mid.LightNumber);
            Assert.AreEqual(3, mid.LightStatus);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0515ByteRevision2()
        {
            string package = "00300515002         0100102003";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0515>(bytes);

            Assert.AreEqual(1, mid.LightNumber);
            Assert.AreEqual(3, mid.LightStatus);
            AssertEqualPackages(bytes, mid);
        }
    }
}
