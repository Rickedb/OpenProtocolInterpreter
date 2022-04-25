using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0214 : DefaultMidTests<Mid0214>
    {
        [TestMethod]
        public void Mid0214AllRevisions()
        {
            string package = "00220214002         10";
            var mid = _midInterpreter.Parse<Mid0214>(package);

            Assert.IsNotNull(mid.DeviceNumber);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0214ByteAllRevisions()
        {
            string package = "00220214002         10";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0214>(bytes);

            Assert.IsNotNull(mid.DeviceNumber);
            AssertEqualPackages(bytes, mid);
        }
    }
}
