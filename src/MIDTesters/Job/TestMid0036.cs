using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0036 : MidTester
    {
        [TestMethod]
        public void Mid0036AllRevisions()
        {
            string package = "00200036001         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0036), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
