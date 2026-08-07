using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    [TestCategory("IOInterface")]
    public class TestMid0214 : DefaultMidTests<Mid0214>
    {
        [TestMethod]
        [TestCategory("ASCII")]
        public void Mid0214AllRevisions()
        {
            string package = "00220214002         10";
            var mid = _midInterpreter.Parse<Mid0214>(package);

            Assert.AreEqual(10, mid.DeviceNumber);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("ByteArray")]
        public void Mid0214ByteAllRevisions()
        {
            string package = "00220214002         10";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0214>(bytes);

            Assert.AreEqual(10, mid.DeviceNumber);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Pack")]
        public void Mid0214PackAllRevisions()
        {
            string package = "00220214002         10";

            AssertBuildAndParse(package, new Mid0214(2)
            {
                DeviceNumber = 10
            });
        }
    }
}
