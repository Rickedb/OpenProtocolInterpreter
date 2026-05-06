using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.RexrothJob;

namespace MIDTesters.RexrothJob
{
    [TestClass]
    [TestCategory("RexrothJob")]
    public class TestMid0555 : DefaultMidTests<Mid0555>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0555Revision1()
        {
            string package = "00280555            01001025";
            var mid = _midInterpreter.Parse<Mid0555>(package);

            Assert.AreEqual(1, mid.JobResultNumber);
            Assert.AreEqual(5, mid.JobResultValue);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0555ByteRevision1()
        {
            string package = "00280555            01001025";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0555>(bytes);

            Assert.AreEqual(1, mid.JobResultNumber);
            Assert.AreEqual(5, mid.JobResultValue);
            AssertEqualPackages(bytes, mid, true);
        }
    }

    [TestClass]
    [TestCategory("RexrothJob")]
    public class TestMid0570 : DefaultMidTests<Mid0570>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0570Revision1()
        {
            string package = "00230570            011";
            var mid = _midInterpreter.Parse<Mid0570>(package);

            Assert.IsTrue(mid.JobStatus);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0570ByteRevision1()
        {
            string package = "00230570            011";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0570>(bytes);

            Assert.IsTrue(mid.JobStatus);
            AssertEqualPackages(bytes, mid, true);
        }
    }

    [TestClass]
    [TestCategory("RexrothJob")]
    public class TestMid0571 : DefaultMidTests<Mid0571>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0571Revision1()
        {
            string package = "00230571            011";
            var mid = _midInterpreter.Parse<Mid0571>(package);

            Assert.IsTrue(mid.JobStart);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0571ByteRevision1()
        {
            string package = "00230571            011";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0571>(bytes);

            Assert.IsTrue(mid.JobStart);
            AssertEqualPackages(bytes, mid, true);
        }
    }

    [TestClass]
    [TestCategory("RexrothJob")]
    public class TestMid0573 : DefaultMidTests<Mid0573>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0573Revision1()
        {
            string package = "00230573            001";
            var mid = _midInterpreter.Parse<Mid0573>(package);

            Assert.AreEqual(1, mid.JobNumber);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0573ByteRevision1()
        {
            string package = "00230573            001";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0573>(bytes);

            Assert.AreEqual(1, mid.JobNumber);
            AssertEqualPackages(bytes, mid, true);
        }
    }

    [TestClass]
    [TestCategory("RexrothJob")]
    public class TestMid0574 : DefaultMidTests<Mid0574>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0574Revision1()
        {
            string package = "00240574            0101";
            var mid = _midInterpreter.Parse<Mid0574>(package);

            Assert.AreEqual(1, mid.ActionCode);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0574ByteRevision1()
        {
            string package = "00240574            0101";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0574>(bytes);

            Assert.AreEqual(1, mid.ActionCode);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
