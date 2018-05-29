using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0037 : MidTester
    {
        [TestMethod]
        public void Mid0037AllRevisions()
        {
            string package = "00200037001         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0037), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
