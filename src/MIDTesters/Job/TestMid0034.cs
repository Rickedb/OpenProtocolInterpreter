using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0034 : MidTester
    {
        [TestMethod]
        public void Mid0034AllRevisions()
        {
            string package = "00200034001         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0034), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
