using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Wifi;

namespace MIDTesters.Wifi
{
    [TestClass]
    [TestCategory("Wifi")]
    public class TestMid0805 : DefaultMidTests<Mid0805>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0805Revision1()
        {
            string package = "00200805            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0805), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0805ByteRevision1()
        {
            string package = "00200805            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0805), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }

    [TestClass]
    [TestCategory("Wifi")]
    public class TestMid0806 : DefaultMidTests<Mid0806>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0806Revision1()
        {
            string package = "00260806            01-080";
            var mid = _midInterpreter.Parse<Mid0806>(package);

            Assert.AreEqual("-080", mid.ReceptionQuality);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0806ByteRevision1()
        {
            string package = "00260806            01-080";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0806>(bytes);

            Assert.AreEqual("-080", mid.ReceptionQuality);
            AssertEqualPackages(bytes, mid, true);
        }
    }

    [TestClass]
    [TestCategory("Wifi")]
    public class TestMid0807 : DefaultMidTests<Mid0807>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0807Revision1()
        {
            string package = "00220807            10";
            var mid = _midInterpreter.Parse<Mid0807>(package);

            Assert.AreEqual(10, mid.ChangeLevel);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0807ByteRevision1()
        {
            string package = "00220807            10";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0807>(bytes);

            Assert.AreEqual(10, mid.ChangeLevel);
            AssertEqualPackages(bytes, mid, true);
        }
    }

    [TestClass]
    [TestCategory("Wifi")]
    public class TestMid0808 : DefaultMidTests<Mid0808>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0808Revision1()
        {
            string package = "00260808            01-080";
            var mid = _midInterpreter.Parse<Mid0808>(package);

            Assert.AreEqual("-080", mid.ReceptionQuality);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0808ByteRevision1()
        {
            string package = "00260808            01-080";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0808>(bytes);

            Assert.AreEqual("-080", mid.ReceptionQuality);
            AssertEqualPackages(bytes, mid, true);
        }
    }

    [TestClass]
    [TestCategory("Wifi")]
    public class TestMid0809 : DefaultMidTests<Mid0809>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0809Revision1()
        {
            string package = "00200809            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0809), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0809ByteRevision1()
        {
            string package = "00200809            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0809), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
