using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    public class TestMid0075 : MidTester
    {
        [TestMethod]
        public void Mid0075AllRevisions()
        {
            string pack = @"00200075001         ";
            var mid = _midInterpreter.Parse<MID_0075>(pack);

            Assert.AreEqual(typeof(MID_0075), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
