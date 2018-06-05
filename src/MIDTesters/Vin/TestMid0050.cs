using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Vin;

namespace MIDTesters.Vin
{
    [TestClass]
    public class TestMid0050 : MidTester
    {
        [TestMethod]
        public void Mid0050Revision1()
        {
            string package = "00350050001         VehicleIdNumber";
            var mid = _midInterpreter.Parse<MID_0050>(package);

            Assert.AreEqual(typeof(MID_0050), mid.GetType());
            Assert.IsNotNull(mid.VinNumber);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
