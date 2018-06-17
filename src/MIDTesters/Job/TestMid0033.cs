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
            var mid = _midInterpreter.Parse<Mid0033>(package);

            Assert.AreEqual(typeof(Mid0033), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.JobName);
            Assert.IsNotNull(mid.ForcedOrder);
            Assert.IsNotNull(mid.MaxTimeForFirstTightening);
            Assert.IsNotNull(mid.MaxTimeToCompleteJob);
            Assert.IsNotNull(mid.JobBatchMode);
            Assert.IsNotNull(mid.LockAtJobDone);
            Assert.IsNotNull(mid.UseLineControl);
            Assert.IsNotNull(mid.RepeatJob);
            Assert.IsNotNull(mid.ToolLoosening);
            Assert.IsNotNull(mid.Reserved);
            Assert.IsNotNull(mid.NumberOfParameterSets);
            Assert.IsNotNull(mid.ParameterSetList);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
