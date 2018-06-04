using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0033 : MidTester
    {
        [TestMethod]
        public void Mid0033Revision1()
        {
            string package = "01150033001         010402My Job 4                 031045000057000406107108109110211112021315:011:1:02;11:015:1:02;";
            var mid = _midInterpreter.Parse<MID_0033>(package);

            Assert.AreEqual(typeof(MID_0033), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
