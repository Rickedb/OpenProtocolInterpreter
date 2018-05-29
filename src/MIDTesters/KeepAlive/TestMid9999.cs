using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.KeepAlive;

namespace MIDTesters.KeepAlive
{
    [TestClass]
    public class TestMid9999 : MidTester
    {
        [TestMethod]
        public void Mid9999Revision1()
        {
            string package = "00209999            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_9999), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
