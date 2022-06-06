using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0038 : DefaultMidTests<Mid0038>
    {
        [TestMethod]
        public void Mid0038Revision1()
        {
            string package = "00220038001         01";
            var mid = _midInterpreter.Parse<Mid0038>(package);

            Assert.IsNotNull(mid.JobId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0038ByteRevision1()
        {
            string package = "00220038001         01";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0038>(bytes);

            Assert.IsNotNull(mid.JobId);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        public void Mid0038Revision2()
        {
            string package = "00240038002         0001";
            var mid = _midInterpreter.Parse<Mid0038>(package);

            Assert.IsNotNull(mid.JobId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0038ByteRevision2()
        {
            string package = "00240038002         0001";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0038>(bytes);

            Assert.IsNotNull(mid.JobId);
            AssertEqualPackages(bytes, mid);
        }
    }
}
