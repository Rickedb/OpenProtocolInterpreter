using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    [TestCategory("Job")]
    public class TestMid0032 : DefaultMidTests<Mid0032>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0032Revision1()
        {
            string package = "00220032001         04";
            var mid = _midInterpreter.Parse<Mid0032>(package);

            Assert.AreEqual(4, mid.JobId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0032ByteRevision1()
        {
            string package = "00220032001         04";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0032>(bytes);

            Assert.AreEqual(4, mid.JobId);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0032Revision2()
        {
            string package = "00240032002         0002";
            var mid = _midInterpreter.Parse<Mid0032>(package);

            Assert.AreEqual(2, mid.JobId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0032ByteRevision2()
        {
            string package = "00240032002         0002";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0032>(bytes);

            Assert.AreEqual(2, mid.JobId);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ASCII")]
        public void Mid0032Revision3()
        {
            string package = "00240032003         0003";
            var mid = _midInterpreter.Parse<Mid0032>(package);

            Assert.AreEqual(3, mid.JobId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ByteArray")]
        public void Mid0032ByteRevision3()
        {
            string package = "00240032003         0003";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0032>(bytes);

            Assert.AreEqual(3, mid.JobId);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ASCII")]
        public void Mid0032Revision4()
        {
            string package = "00240032004         0003";
            var mid = _midInterpreter.Parse<Mid0032>(package);

            Assert.AreEqual(3, mid.JobId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ByteArray")]
        public void Mid0032ByteRevision4()
        {
            string package = "00240032004         0003";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0032>(bytes);

            Assert.AreEqual(3, mid.JobId);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0032PackRevision1()
        {
            string package = "00220032001         04";

            AssertBuildAndParse(package, new Mid0032(1)
            {
                JobId = 4
            });
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("Pack")]
        public void Mid0032PackRevision2()
        {
            string package = "00240032002         0002";

            AssertBuildAndParse(package, new Mid0032(2)
            {
                JobId = 2
            });
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("Pack")]
        public void Mid0032PackRevision3()
        {
            string package = "00240032003         0003";

            AssertBuildAndParse(package, new Mid0032(3)
            {
                JobId = 3
            });
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("Pack")]
        public void Mid0032PackRevision4()
        {
            string package = "00240032004         0003";

            AssertBuildAndParse(package, new Mid0032(4)
            {
                JobId = 3
            });
        }
    }
}
