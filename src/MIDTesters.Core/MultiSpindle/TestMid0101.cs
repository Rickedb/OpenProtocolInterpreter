using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultiSpindle;

namespace MIDTesters.MultiSpindle
{
    [TestClass]
    public class TestMid0101 : MidTester
    {
        [TestMethod]
        public void Mid0101Revisions1To3()
        {
            var pack = "01920101001         010102BM3GA02111900601         030304003050001060001071080006800900092010000800110000012000151300000142019-11-14:14:08:05152019-11-25:11:22:41160091317118010111000809100000";
            var mid = _midInterpreter.Parse<Mid0101>(pack);

            Assert.AreEqual(typeof(Mid0101), mid.GetType());
            Assert.IsNotNull(mid.NumberOfSpindlesOrPresses);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.BatchStatus);
            Assert.IsNotNull(mid.TorqueOrForceMinLimit);
            Assert.IsNotNull(mid.TorqueOrForceMaxLimit);
            Assert.IsNotNull(mid.TorqueOrForceFinalTarget);
            Assert.IsNotNull(mid.AngleOrStrokeMinLimit);
            Assert.IsNotNull(mid.AngleOrStrokeMaxLimit);
            Assert.IsNotNull(mid.FinalAngleOrStrokeTarget);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsNotNull(mid.TimeStamp);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.SyncOverallStatus);
            Assert.IsNotNull(mid.SpindlesOrPressesStatus);
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
