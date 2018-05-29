using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;

namespace MIDTesters.Communication
{
    [TestClass]
    public class TestMid0005 : MidTester
    {
        [TestMethod]
        public void Mid0005Revision1()
        {
            string pack = @"00240005            0018";
            var mid = _midInterpreter.Parse<MID_0005>(pack);

            Assert.AreEqual(typeof(MID_0005), mid.GetType());
            Assert.IsNotNull(mid.MidAccepted);
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
