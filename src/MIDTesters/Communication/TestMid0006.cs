using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;

namespace MIDTesters.Communication
{
    [TestClass]
    public class TestMid0006 : MidTester
    {
        [TestMethod]
        public void Mid0006Revision1()
        {
            string pack = @"00430006            001800214lengthequals14";
            var mid = _midInterpreter.Parse<Mid0006>(pack);

            Assert.AreEqual(typeof(Mid0006), mid.GetType());
            Assert.IsNotNull(mid.RequestedMid);
            Assert.IsNotNull(mid.WantedRevision);
            Assert.IsNotNull(mid.ExtraDataLength);
            Assert.IsNotNull(mid.ExtraData);
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
