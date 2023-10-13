using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultiSpindle;

namespace MIDTesters.MultiSpindle
{
    [TestClass]
    [TestCategory("MultiSpindle")]
    public class TestMid0101 : DefaultMidTests<Mid0101>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Revision 2"), TestCategory("Revision 3"), TestCategory("ASCII")]
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
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Revision 2"), TestCategory("Revision 3"), TestCategory("ByteArray")]
        public void Mid0101ByteRevisions1To3()
        {
            string package = "01920101001         010102BM3GA02111900601         030304003050001060001071080006800900092010000800110000012000151300000142019-11-14:14:08:05152019-11-25:11:22:41160091317118010111000809100000";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0101>(bytes);

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
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ASCII")]
        public void Mid0101Revision4()
        {
            var pack = "01970101004         010102BM3GA02111900601         030304003050001060001071080006800900092010000800110000012000151300000142019-11-14:14:08:05152019-11-25:11:22:4116009131711801011100080910000019002";
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
            Assert.IsNotNull(mid.SystemSubType);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ByteArray")]
        public void Mid0101ByteRevision4()
        {
            var package = "01970101004         010102BM3GA02111900601         030304003050001060001071080006800900092010000800110000012000151300000142019-11-14:14:08:05152019-11-25:11:22:4116009131711801011100080910000019002";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0101>(bytes);

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
            Assert.IsNotNull(mid.SystemSubType);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("ASCII")]
        public void Mid0101Revision5()
        {
            var pack = "02040101005         010102BM3GA02111900601         030304003050001060001071080006800900092010000800110000012000151300000142019-11-14:14:08:05152019-11-25:11:22:41160091317118010111000809100000190022000021";
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
            Assert.IsNotNull(mid.SystemSubType);
            Assert.IsNotNull(mid.JobSequenceNumber);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("ByteArray")]
        public void Mid0101ByteRevision5()
        {
            var package = "02040101005         010102BM3GA02111900601         030304003050001060001071080006800900092010000800110000012000151300000142019-11-14:14:08:05152019-11-25:11:22:41160091317118010111000809100000190022000021";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0101>(bytes);

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
            Assert.IsNotNull(mid.SystemSubType);
            Assert.IsNotNull(mid.JobSequenceNumber);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 6"), TestCategory("ASCII")]
        public void Mid0101Revision6()
        {
            var pack = "02040101006         010102BM3GA02111900601         030304003050001060001071080006800900092010000800110000012-00151300000142019-11-14:14:08:05152019-11-25:11:22:41160091317118010111000809100000190022000021";
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
            Assert.IsTrue(mid.AngleOrStrokeMaxLimit < 0);
            Assert.IsNotNull(mid.FinalAngleOrStrokeTarget);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsNotNull(mid.TimeStamp);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.SyncOverallStatus);
            Assert.IsNotNull(mid.SpindlesOrPressesStatus);
            Assert.IsNotNull(mid.SystemSubType);
            Assert.IsNotNull(mid.JobSequenceNumber);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 6"), TestCategory("ByteArray")]
        public void Mid0101ByteRevision6()
        {
            var package = "02040101006         010102BM3GA02111900601         030304003050001060001071080006800900092010000800110000012-00151300000142019-11-14:14:08:05152019-11-25:11:22:41160091317118010111000809100000190022000021";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0101>(bytes);

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
            Assert.IsTrue(mid.AngleOrStrokeMaxLimit < 0);
            Assert.IsNotNull(mid.FinalAngleOrStrokeTarget);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsNotNull(mid.TimeStamp);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.SyncOverallStatus);
            Assert.IsNotNull(mid.SpindlesOrPressesStatus);
            Assert.IsNotNull(mid.SystemSubType);
            Assert.IsNotNull(mid.JobSequenceNumber);
            AssertEqualPackages(bytes, mid);
        }
    }
}
