using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PowerMACS;

namespace MIDTesters.PowerMACS
{
    public class TestMid0108 : MidTester
    {
        [TestMethod]
        public void Mid0108AllRevisions()
        {
            string package = "00200108002         1";
            var mid = _midInterpreter.Parse<MID_0108>(package);

            Assert.AreEqual(typeof(MID_0108), mid.GetType());
            Assert.IsNotNull(mid.BoltData);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
