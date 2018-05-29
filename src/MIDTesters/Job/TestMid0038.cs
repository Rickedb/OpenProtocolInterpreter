using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0038 : MidTester
    {
        [TestMethod]
        public void Mid0038Revision1()
        {
            string package = "00220038001         01";
            var mid = _midInterpreter.Parse<MID_0038>(package);

            Assert.AreEqual(typeof(MID_0038), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
