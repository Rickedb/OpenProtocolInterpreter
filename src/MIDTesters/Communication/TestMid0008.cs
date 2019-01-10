using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;

namespace MIDTesters.Communication
{
    [TestClass]
    public class TestMid0008 : MidTester
    {
        [TestMethod]
        public void Mid0008Revision1()
        {
            string pack = @"00430008            002200214lengthequals14";
            var mid = _midInterpreter.Parse<Mid0008>(pack);

            Assert.AreEqual(typeof(Mid0008), mid.GetType());
            Assert.IsNotNull(mid.SubscriptionMid);
            Assert.IsNotNull(mid.WantedRevision);
            Assert.IsNotNull(mid.ExtraDataLength);
            Assert.IsNotNull(mid.ExtraData);
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
