using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    [TestCategory("ParameterSet")]
    public class TestMid0012 : DefaultMidTests<Mid0012>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0012Revision1()
        {
            string pack = @"00230012            002";
            var mid = _midInterpreter.Parse<Mid0012>(pack);

            Assert.IsNotNull(mid.ParameterSetId);
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0012ByteRevision1()
        {
            string package = "00230012            002";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0012>(bytes);

            Assert.IsNotNull(mid.ParameterSetId);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0012Revision2()
        {
            string pack = @"00230012002         002";
            var mid = _midInterpreter.Parse<Mid0012>(pack);

            Assert.IsNotNull(mid.ParameterSetId);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0012ByteRevision2()
        {
            string package = @"00230012002         002";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0012>(bytes);

            Assert.IsNotNull(mid.ParameterSetId);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ASCII")]
        public void Mid0012Revision3()
        {
            string pack = @"00310012003         00212345678";
            var mid = _midInterpreter.Parse<Mid0012>(pack);

            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.ParameterSetFileVersion);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ByteArray")]
        public void Mid0012ByteRevision3()
        {
            string package = "00310012003         00212345678";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0012>(bytes);

            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.ParameterSetFileVersion);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ASCII")]
        public void Mid0012Revision4()
        {
            string pack = @"00310012004         00212345678";
            var mid = _midInterpreter.Parse<Mid0012>(pack);

            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.ParameterSetFileVersion);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ByteArray")]
        public void Mid0012ByteRevision4()
        {
            string package = @"00310012004         00212345678";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0012>(bytes);

            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.ParameterSetFileVersion);
            AssertEqualPackages(bytes, mid);
        }
    }
}
