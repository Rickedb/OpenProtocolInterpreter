using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;

namespace MIDTesters.Communication
{
    [TestClass]
    [TestCategory("Communication")]
    public class TestMid0005 : DefaultMidTests<Mid0005>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0005Revision1()
        {
            string pack = @"00240005            0018";
            var mid = _midInterpreter.Parse<Mid0005>(pack);

            Assert.AreEqual(18, mid.MidAccepted);
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0005ByteRevision1()
        {
            string pack = @"00240005            0018";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0005>(bytes);

            Assert.AreEqual(18, mid.MidAccepted);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0005PackRevision1()
        {
            string pack = @"00240005            0018";

            AssertBuildAndParse(pack, new Mid0005(1)
            {
                MidAccepted = 18
            }, true);
        }
    }
}
