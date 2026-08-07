using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.LinkCommunication;

namespace MIDTesters.LinkCommunication
{
    [TestClass]
    [TestCategory("LinkCommunication")]
    public class TestMid9997 : DefaultMidTests<Mid9997>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid9997Revision1()
        {
            string package = "00249997001         0061";
            var mid = _midInterpreter.Parse<Mid9997>(package);

            Assert.AreEqual(61, mid.MidNumber);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid9997ByteRevision1()
        {
            string package = "00249997001         0065";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid9997>(bytes);

            Assert.AreEqual(65, mid.MidNumber);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid9997PackRevision1()
        {
            string package = "00249997001         0061";

            AssertBuildAndParse(package, new Mid9997()
            {
                MidNumber = 61
            });
        }
    }
}
