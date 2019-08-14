using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Vin;
using System.Linq;

namespace MIDTesters.Vin
{
    [TestClass]
    public class TestMid0050 : MidTester
    {
        [TestMethod]
        public void Mid0050Revision1()
        {
            string package = "00350050001         VehicleIdNumber";
            var mid = _midInterpreter.Parse<Mid0050>(package);

            Assert.AreEqual(typeof(Mid0050), mid.GetType());
            Assert.IsNotNull(mid.VinNumber);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0050ByteRevision1()
        {
            string package = "00350050001         VehicleIdNumber";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0050>(bytes);

            Assert.AreEqual(typeof(Mid0050), mid.GetType());
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
