using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultiSpindle;

namespace MIDTesters.MultiSpindle
{
    [TestClass]
    [TestCategory("MultiSpindle")]
    public class TestMid0100 : DefaultMidTests<Mid0100>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0100Revision1()
        {
            string pack = @"00200100001         ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0100), mid.GetType());
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0100ByteRevision1()
        {
            string package = @"00200100001         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0100), mid.GetType());
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0100Revision2()
        {
            string pack = @"00300100002         0123456789";
            var mid = _midInterpreter.Parse<Mid0100>(pack);

            Assert.AreEqual(typeof(Mid0100), mid.GetType());
            Assert.AreEqual(123456789L, mid.DataNumberSystem);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0100ByteRevision2()
        {
            string package = @"00300100002         0123456789";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0100>(bytes);

            Assert.AreEqual(typeof(Mid0100), mid.GetType());
            Assert.AreEqual(123456789L, mid.DataNumberSystem);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ASCII")]
        public void Mid0100Revision3()
        {
            string pack = @"00310100003         01234567891";
            var mid = _midInterpreter.Parse<Mid0100>(pack);

            Assert.AreEqual(typeof(Mid0100), mid.GetType());
            Assert.AreEqual(123456789L, mid.DataNumberSystem);
            Assert.IsTrue(mid.SendOnlyNewData);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ByteArray")]
        public void Mid0100ByteRevision3()
        {
            string package = @"00310100003         01234567891";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0100>(bytes);

            Assert.AreEqual(typeof(Mid0100), mid.GetType());
            Assert.AreEqual(123456789L, mid.DataNumberSystem);
            Assert.IsTrue(mid.SendOnlyNewData);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0100PackRevision1()
        {
            string pack = @"00200100001         ";

            AssertBuildAndParse(pack, new Mid0100(1));
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("Pack")]
        public void Mid0100PackRevision2()
        {
            string pack = @"00300100002         0123456789";

            AssertBuildAndParse(pack, new Mid0100(2)
            {
                DataNumberSystem = 123456789L
            });
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("Pack")]
        public void Mid0100PackRevision3()
        {
            string pack = @"00310100003         01234567891";

            AssertBuildAndParse(pack, new Mid0100(3)
            {
                DataNumberSystem = 123456789L,
                SendOnlyNewData = true
            });
        }
    }
}
