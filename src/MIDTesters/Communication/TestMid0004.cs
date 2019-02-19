using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;
using System.Linq;

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

        [TestMethod]
        public void Mid0004ByteRevision1()
        {
            string pack = @"00260004            001802";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0004>(bytes);

            Assert.AreEqual(typeof(Mid0004), mid.GetType());
            Assert.IsNotNull(mid.FailedMid);
            Assert.IsNotNull(mid.ErrorCode);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
