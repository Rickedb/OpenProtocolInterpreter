using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    public class TestMid0127 : MidTester
    {
        [TestMethod]
        public void Revision1()
        {
            string package = "00200127001         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0127), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
