using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Vin;

namespace MIDTesters.Vin
{
    [TestClass]
    public class TestMid0050 : DefaultMidTests<Mid0050>
    {
        [TestMethod]
        public void Mid0050Revision1()
        {
            string package = "00350050001         VehicleIdNumber";
            var mid = _midInterpreter.Parse<Mid0050>(package);

            Assert.IsNotNull(mid.VinNumber);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0050ByteRevision1()
        {
            string package = "00350050001         VehicleIdNumber";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0050>(bytes);

            Assert.IsNotNull(mid.VinNumber);
            AssertEqualPackages(bytes, mid);
        }
    }
}
