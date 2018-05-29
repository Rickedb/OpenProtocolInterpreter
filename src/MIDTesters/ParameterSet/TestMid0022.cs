using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0022 : MidTester
    {
        [TestMethod]
        public void Mid0022Revision1()
        {
            string package = "00210022   1        1";
            var mid = _midInterpreter.Parse<MID_0022>(package);

            Assert.AreEqual(typeof(MID_0022), mid.GetType());
            Assert.IsNotNull(mid.HeaderData.NoAckFlag);
            Assert.IsNotNull(mid.RelayStatus);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
