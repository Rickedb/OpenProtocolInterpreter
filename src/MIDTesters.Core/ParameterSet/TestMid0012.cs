using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0012 : DefaultMidTests<Mid0012>
    {
        [TestMethod]
        public void Mid0012Revision1()
        {
            string pack = @"00230012            002";
            var mid = _midInterpreter.Parse<Mid0012>(pack);

            Assert.IsNotNull(mid.ParameterSetId);
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        public void Mid0012ByteRevision1()
        {
            string package = "00230012            002";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0012>(bytes);

            Assert.IsNotNull(mid.ParameterSetId);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        public void Mid0012Revision2()
        {
            string pack = @"00230012002         002";
            var mid = _midInterpreter.Parse<Mid0012>(pack);

            Assert.IsNotNull(mid.ParameterSetId);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        public void Mid0012ByteRevision2()
        {
            string package = @"00230012002         002";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0012>(bytes);

            Assert.IsNotNull(mid.ParameterSetId);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        public void Mid0012Revision3()
        {
            string pack = @"00310012003         00212345678";
            var mid = _midInterpreter.Parse<Mid0012>(pack);

            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.ParameterSetFileVersion);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
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
        public void Mid0012Revision4()
        {
            string pack = @"00310012004         00212345678";
            var mid = _midInterpreter.Parse<Mid0012>(pack);

            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.ParameterSetFileVersion);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
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
