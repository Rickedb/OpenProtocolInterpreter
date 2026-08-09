using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

using OpenProtocolInterpreter;
namespace MIDTesters.ParameterSet
{
    [TestClass]
    [TestCategory("ParameterSet")]
    public class TestMid0019 : DefaultMidTests<Mid0019>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0019Revision1()
        {
            string package = "00250019            77750";
            var mid = _midInterpreter.Parse<Mid0019>(package);

            Assert.AreEqual(777, mid.ParameterSetId);
            Assert.AreEqual(50, mid.BatchSize);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0019ByteRevision1()
        {
            string package = "00250019            77750";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0019>(bytes);

            Assert.AreEqual(777, mid.ParameterSetId);
            Assert.AreEqual(50, mid.BatchSize);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0019Revision2()
        {
            string package = "00270019002         7770050";
            var mid = _midInterpreter.Parse<Mid0019>(package);

            Assert.AreEqual(777, mid.ParameterSetId);
            Assert.AreEqual(50, mid.BatchSize);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0019ByteRevision2()
        {
            string package = "00270019002         7770050";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0019>(bytes);

            Assert.AreEqual(777, mid.ParameterSetId);
            Assert.AreEqual(50, mid.BatchSize);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0019PackRevision1()
        {
            string package = "00250019            77750";

            AssertBuildAndParse(package, new Mid0019()
            {
                ParameterSetId = 777,
                BatchSize = 50
            }, true);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("Pack")]
        public void Mid0019PackRevision2()
        {
            string package = "00270019002         7770050";

            AssertBuildAndParse(package, new Mid0019(new Header() { Mid = Mid0019.MID, Revision = 2 })
            {
                ParameterSetId = 777,
                BatchSize = 50
            });
        }
    }
}
