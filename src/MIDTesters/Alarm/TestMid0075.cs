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
            var mid = _midInterpreter.Parse<Mid0075>(pack);

            Assert.AreEqual(typeof(Mid0075), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
