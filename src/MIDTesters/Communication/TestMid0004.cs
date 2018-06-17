using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;

namespace MIDTesters.Communication
{
    [TestClass]
    public class TestMid0004 : MidTester
    {
        [TestMethod]
        public void Mid0004Revision1()
        {
            string pack = @"00260004            001802";
            var mid = _midInterpreter.Parse<Mid0004>(pack);


            Assert.AreEqual(typeof(Mid0004), mid.GetType());
            Assert.IsNotNull(mid.FailedMid);
            Assert.IsNotNull(mid.ErrorCode);
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
