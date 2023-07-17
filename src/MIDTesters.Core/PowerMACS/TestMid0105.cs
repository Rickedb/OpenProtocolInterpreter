using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PowerMACS;

namespace MIDTesters.PowerMACS
{
    [TestClass]
    [TestCategory("PowerMACS")]
    public class TestMid0105 : DefaultMidTests<Mid0105>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0105Revision1()
        {
            string pack = @"002001050011        ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0105), mid.GetType());
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0105ByteRevision1()
        {
            string package = @"002001050011        ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0105), mid.GetType());
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0105Revision2()
        {
            string pack = @"003001050021        4294967295";
            var mid = _midInterpreter.Parse<Mid0105>(pack);

            Assert.IsNotNull(mid.DataNumberSystem);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0105ByteRevision2()
        {
            string package = @"003001050021        4294967295";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0105>(bytes);

            Assert.IsNotNull(mid.DataNumberSystem);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ASCII")]
        public void Mid0105Revision3()
        {
            string pack = @"003101050031        42949672951";
            var mid = _midInterpreter.Parse<Mid0105>(pack);

            Assert.IsNotNull(mid.DataNumberSystem);
            Assert.IsNotNull(mid.SendOnlyNewData);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ByteArray")]
        public void Mid0105ByteRevision3()
        {
            string package = @"003101050031        42949672951";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0105>(bytes);

            Assert.IsNotNull(mid.DataNumberSystem);
            Assert.IsNotNull(mid.SendOnlyNewData);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ASCII")]
        public void Mid0105Revision4()
        {
            string pack = @"003101050041        32949672951";
            var mid = _midInterpreter.Parse<Mid0105>(pack);

            Assert.IsNotNull(mid.DataNumberSystem);
            Assert.IsNotNull(mid.SendOnlyNewData);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ByteArray")]
        public void Mid0105ByteRevision4()
        {
            string package = @"003101050041        32949672951";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0105>(bytes);

            Assert.IsNotNull(mid.DataNumberSystem);
            Assert.IsNotNull(mid.SendOnlyNewData);
            AssertEqualPackages(bytes, mid);
        }
    }
}
