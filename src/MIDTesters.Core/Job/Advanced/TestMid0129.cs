using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    [TestCategory("Job"), TestCategory("Advanced Job")]
    public class TestMid0129 : DefaultMidTests<Mid0129>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0129Revision1()
        {
            string package = "00200129            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0129), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0129ByteRevision1()
        {
            string package = "00200129            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0129), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0129Revision2()
        {
            string package = "00290129002         010302123";
            var mid = _midInterpreter.Parse<Mid0129>(package);

            Assert.AreEqual(3, mid.ChannelId);
            Assert.AreEqual(123, mid.ParameterSetId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0129ByteRevision2()
        {
            string package = "00290129002         010302123";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0129>(bytes);

            Assert.AreEqual(3, mid.ChannelId);
            Assert.AreEqual(123, mid.ParameterSetId);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0129PackRevision1()
        {
            string package = "00200129            ";

            AssertBuildAndParse(package, new Mid0129(1), true);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("Pack")]
        public void Mid0129PackRevision2()
        {
            string package = "00290129002         010302123";

            AssertBuildAndParse(package, new Mid0129(2)
            {
                ChannelId = 3,
                ParameterSetId = 123
            });
        }
    }
}
