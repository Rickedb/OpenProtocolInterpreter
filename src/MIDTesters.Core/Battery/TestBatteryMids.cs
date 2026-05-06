using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Battery;

namespace MIDTesters.Battery
{
    [TestClass]
    [TestCategory("Battery")]
    public class TestMid0800 : DefaultMidTests<Mid0800>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0800Revision1()
        {
            string package = "00200800            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0800), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0800ByteRevision1()
        {
            string package = "00200800            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0800), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }

    [TestClass]
    [TestCategory("Battery")]
    public class TestMid0801 : DefaultMidTests<Mid0801>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0801Revision1()
        {
            string package = "00280801            01030023";
            var mid = _midInterpreter.Parse<Mid0801>(package);

            Assert.AreEqual(30, mid.Capacity);
            Assert.AreEqual(3, mid.State);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0801ByteRevision1()
        {
            string package = "00280801            01030023";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0801>(bytes);

            Assert.AreEqual(30, mid.Capacity);
            Assert.AreEqual(3, mid.State);
            AssertEqualPackages(bytes, mid, true);
        }
    }

    [TestClass]
    [TestCategory("Battery")]
    public class TestMid0802 : DefaultMidTests<Mid0802>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0802Revision1()
        {
            string package = "00220802            25";
            var mid = _midInterpreter.Parse<Mid0802>(package);

            Assert.AreEqual(25, mid.ChangeLevel);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0802ByteRevision1()
        {
            string package = "00220802            25";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0802>(bytes);

            Assert.AreEqual(25, mid.ChangeLevel);
            AssertEqualPackages(bytes, mid, true);
        }
    }

    [TestClass]
    [TestCategory("Battery")]
    public class TestMid0803 : DefaultMidTests<Mid0803>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0803Revision1()
        {
            string package = "00280803            01030023";
            var mid = _midInterpreter.Parse<Mid0803>(package);

            Assert.AreEqual(30, mid.Capacity);
            Assert.AreEqual(3, mid.State);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0803ByteRevision1()
        {
            string package = "00280803            01030023";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0803>(bytes);

            Assert.AreEqual(30, mid.Capacity);
            Assert.AreEqual(3, mid.State);
            AssertEqualPackages(bytes, mid, true);
        }
    }

    [TestClass]
    [TestCategory("Battery")]
    public class TestMid0804 : DefaultMidTests<Mid0804>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0804Revision1()
        {
            string package = "00200804            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0804), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0804ByteRevision1()
        {
            string package = "00200804            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0804), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
