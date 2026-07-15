using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
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
            var pack = "02100101001         010202BM3GA02111900601         030304003050001060001071080006800900092010000800110000012000151300000142019-11-14:14:08:05152019-11-25:11:22:41160091317118010111000809100000020111000809100000";
            var mid = _midInterpreter.Parse<Mid0101>(pack);

            Assert.AreEqual(typeof(Mid0101), mid.GetType());
            Assert.AreEqual(2, mid.NumberOfSpindlesOrPresses);
            Assert.AreEqual("BM3GA02111900601", mid.VinNumber.TrimEnd());
            Assert.AreEqual(3, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(1, mid.BatchSize);
            Assert.AreEqual(1, mid.BatchCounter);
            Assert.AreEqual(BatchStatus.Ok, mid.BatchStatus);
            Assert.AreEqual(6.80m, mid.TorqueOrForceMinLimit);
            Assert.AreEqual(9.20m, mid.TorqueOrForceMaxLimit);
            Assert.AreEqual(8.00m, mid.TorqueOrForceFinalTarget);
            Assert.AreEqual(0.00m, mid.AngleOrStrokeMinLimit);
            Assert.AreEqual(0.15m, mid.AngleOrStrokeMaxLimit);
            Assert.AreEqual(0.00m, mid.FinalAngleOrStrokeTarget);
            Assert.AreEqual(new DateTime(2019, 11, 14, 14, 8, 5), mid.LastChangeInParameterSet);
            Assert.AreEqual(new DateTime(2019, 11, 25, 11, 22, 41), mid.TimeStamp);
            Assert.AreEqual(913, mid.SyncTighteningId);
            Assert.IsTrue(mid.SyncOverallStatus);
            Assert.AreEqual(2, mid.SpindlesOrPressesStatus.Count);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Revision 2"), TestCategory("Revision 3"), TestCategory("ByteArray")]
        public void Mid0101ByteRevisions1To3()
        {
            string package = "02100101001         010202BM3GA02111900601         030304003050001060001071080006800900092010000800110000012000151300000142019-11-14:14:08:05152019-11-25:11:22:41160091317118010111000809100000020111000809100000";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0101>(bytes);

            Assert.AreEqual(typeof(Mid0101), mid.GetType());
            Assert.AreEqual(2, mid.NumberOfSpindlesOrPresses);
            Assert.AreEqual("BM3GA02111900601", mid.VinNumber.TrimEnd());
            Assert.AreEqual(3, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(1, mid.BatchSize);
            Assert.AreEqual(1, mid.BatchCounter);
            Assert.AreEqual(BatchStatus.Ok, mid.BatchStatus);
            Assert.AreEqual(6.80m, mid.TorqueOrForceMinLimit);
            Assert.AreEqual(9.20m, mid.TorqueOrForceMaxLimit);
            Assert.AreEqual(8.00m, mid.TorqueOrForceFinalTarget);
            Assert.AreEqual(0.00m, mid.AngleOrStrokeMinLimit);
            Assert.AreEqual(0.15m, mid.AngleOrStrokeMaxLimit);
            Assert.AreEqual(0.00m, mid.FinalAngleOrStrokeTarget);
            Assert.AreEqual(new DateTime(2019, 11, 14, 14, 8, 5), mid.LastChangeInParameterSet);
            Assert.AreEqual(new DateTime(2019, 11, 25, 11, 22, 41), mid.TimeStamp);
            Assert.AreEqual(913, mid.SyncTighteningId);
            Assert.IsTrue(mid.SyncOverallStatus);
            Assert.AreEqual(2, mid.SpindlesOrPressesStatus.Count);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ASCII")]
        public void Mid0101Revision4()
        {
            var pack = "02150101004         010202BM3GA02111900601         030304003050001060001071080006800900092010000800110000012000151300000142019-11-14:14:08:05152019-11-25:11:22:4116009131711801011100080910000002011100080910000019002";
            var mid = _midInterpreter.Parse<Mid0101>(pack);

            Assert.AreEqual(typeof(Mid0101), mid.GetType());
            Assert.AreEqual(2, mid.NumberOfSpindlesOrPresses);
            Assert.AreEqual("BM3GA02111900601", mid.VinNumber.TrimEnd());
            Assert.AreEqual(3, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(1, mid.BatchSize);
            Assert.AreEqual(1, mid.BatchCounter);
            Assert.AreEqual(BatchStatus.Ok, mid.BatchStatus);
            Assert.AreEqual(6.80m, mid.TorqueOrForceMinLimit);
            Assert.AreEqual(9.20m, mid.TorqueOrForceMaxLimit);
            Assert.AreEqual(8.00m, mid.TorqueOrForceFinalTarget);
            Assert.AreEqual(0.00m, mid.AngleOrStrokeMinLimit);
            Assert.AreEqual(0.15m, mid.AngleOrStrokeMaxLimit);
            Assert.AreEqual(0.00m, mid.FinalAngleOrStrokeTarget);
            Assert.AreEqual(new DateTime(2019, 11, 14, 14, 8, 5), mid.LastChangeInParameterSet);
            Assert.AreEqual(new DateTime(2019, 11, 25, 11, 22, 41), mid.TimeStamp);
            Assert.AreEqual(913, mid.SyncTighteningId);
            Assert.IsTrue(mid.SyncOverallStatus);
            Assert.AreEqual(2, mid.SpindlesOrPressesStatus.Count);
            Assert.AreEqual(SystemSubType.SystemRunningPresses, mid.SystemSubType);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ByteArray")]
        public void Mid0101ByteRevision4()
        {
            var package = "02150101004         010202BM3GA02111900601         030304003050001060001071080006800900092010000800110000012000151300000142019-11-14:14:08:05152019-11-25:11:22:4116009131711801011100080910000002011100080910000019002";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0101>(bytes);

            Assert.AreEqual(typeof(Mid0101), mid.GetType());
            Assert.AreEqual(2, mid.NumberOfSpindlesOrPresses);
            Assert.AreEqual("BM3GA02111900601", mid.VinNumber.TrimEnd());
            Assert.AreEqual(3, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(1, mid.BatchSize);
            Assert.AreEqual(1, mid.BatchCounter);
            Assert.AreEqual(BatchStatus.Ok, mid.BatchStatus);
            Assert.AreEqual(6.80m, mid.TorqueOrForceMinLimit);
            Assert.AreEqual(9.20m, mid.TorqueOrForceMaxLimit);
            Assert.AreEqual(8.00m, mid.TorqueOrForceFinalTarget);
            Assert.AreEqual(0.00m, mid.AngleOrStrokeMinLimit);
            Assert.AreEqual(0.15m, mid.AngleOrStrokeMaxLimit);
            Assert.AreEqual(0.00m, mid.FinalAngleOrStrokeTarget);
            Assert.AreEqual(new DateTime(2019, 11, 14, 14, 8, 5), mid.LastChangeInParameterSet);
            Assert.AreEqual(new DateTime(2019, 11, 25, 11, 22, 41), mid.TimeStamp);
            Assert.AreEqual(913, mid.SyncTighteningId);
            Assert.IsTrue(mid.SyncOverallStatus);
            Assert.AreEqual(2, mid.SpindlesOrPressesStatus.Count);
            Assert.AreEqual(SystemSubType.SystemRunningPresses, mid.SystemSubType);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("ASCII")]
        public void Mid0101Revision5()
        {
            var pack = "02220101005         010202BM3GA02111900601         030304003050001060001071080006800900092010000800110000012000151300000142019-11-14:14:08:05152019-11-25:11:22:41160091317118010111000809100000020111000809100000190022000021";
            var mid = _midInterpreter.Parse<Mid0101>(pack);

            Assert.AreEqual(typeof(Mid0101), mid.GetType());
            Assert.AreEqual(2, mid.NumberOfSpindlesOrPresses);
            Assert.AreEqual("BM3GA02111900601", mid.VinNumber.TrimEnd());
            Assert.AreEqual(3, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(1, mid.BatchSize);
            Assert.AreEqual(1, mid.BatchCounter);
            Assert.AreEqual(BatchStatus.Ok, mid.BatchStatus);
            Assert.AreEqual(6.80m, mid.TorqueOrForceMinLimit);
            Assert.AreEqual(9.20m, mid.TorqueOrForceMaxLimit);
            Assert.AreEqual(8.00m, mid.TorqueOrForceFinalTarget);
            Assert.AreEqual(0.00m, mid.AngleOrStrokeMinLimit);
            Assert.AreEqual(0.15m, mid.AngleOrStrokeMaxLimit);
            Assert.AreEqual(0.00m, mid.FinalAngleOrStrokeTarget);
            Assert.AreEqual(new DateTime(2019, 11, 14, 14, 8, 5), mid.LastChangeInParameterSet);
            Assert.AreEqual(new DateTime(2019, 11, 25, 11, 22, 41), mid.TimeStamp);
            Assert.AreEqual(913, mid.SyncTighteningId);
            Assert.IsTrue(mid.SyncOverallStatus);
            Assert.AreEqual(2, mid.SpindlesOrPressesStatus.Count);
            Assert.AreEqual(SystemSubType.SystemRunningPresses, mid.SystemSubType);
            Assert.AreEqual(21, mid.JobSequenceNumber);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("ByteArray")]
        public void Mid0101ByteRevision5()
        {
            var package = "02220101005         010202BM3GA02111900601         030304003050001060001071080006800900092010000800110000012000151300000142019-11-14:14:08:05152019-11-25:11:22:41160091317118010111000809100000020111000809100000190022000021";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0101>(bytes);

            Assert.AreEqual(typeof(Mid0101), mid.GetType());
            Assert.AreEqual(2, mid.NumberOfSpindlesOrPresses);
            Assert.AreEqual("BM3GA02111900601", mid.VinNumber.TrimEnd());
            Assert.AreEqual(3, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(1, mid.BatchSize);
            Assert.AreEqual(1, mid.BatchCounter);
            Assert.AreEqual(BatchStatus.Ok, mid.BatchStatus);
            Assert.AreEqual(6.80m, mid.TorqueOrForceMinLimit);
            Assert.AreEqual(9.20m, mid.TorqueOrForceMaxLimit);
            Assert.AreEqual(8.00m, mid.TorqueOrForceFinalTarget);
            Assert.AreEqual(0.00m, mid.AngleOrStrokeMinLimit);
            Assert.AreEqual(0.15m, mid.AngleOrStrokeMaxLimit);
            Assert.AreEqual(0.00m, mid.FinalAngleOrStrokeTarget);
            Assert.AreEqual(new DateTime(2019, 11, 14, 14, 8, 5), mid.LastChangeInParameterSet);
            Assert.AreEqual(new DateTime(2019, 11, 25, 11, 22, 41), mid.TimeStamp);
            Assert.AreEqual(913, mid.SyncTighteningId);
            Assert.IsTrue(mid.SyncOverallStatus);
            Assert.AreEqual(2, mid.SpindlesOrPressesStatus.Count);
            Assert.AreEqual(SystemSubType.SystemRunningPresses, mid.SystemSubType);
            Assert.AreEqual(21, mid.JobSequenceNumber);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 6"), TestCategory("ASCII")]
        public void Mid0101Revision6()
        {
            var pack = "02220101006         010202BM3GA02111900601         030304003050001060001071080006800900092010000800110000012-00151300000142019-11-14:14:08:05152019-11-25:11:22:41160091317118010111000809100000020111000809100000190022000021";
            var mid = _midInterpreter.Parse<Mid0101>(pack);

            Assert.AreEqual(typeof(Mid0101), mid.GetType());
            Assert.AreEqual(2, mid.NumberOfSpindlesOrPresses);
            Assert.AreEqual("BM3GA02111900601", mid.VinNumber.TrimEnd());
            Assert.AreEqual(3, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(1, mid.BatchSize);
            Assert.AreEqual(1, mid.BatchCounter);
            Assert.AreEqual(BatchStatus.Ok, mid.BatchStatus);
            Assert.AreEqual(6.80m, mid.TorqueOrForceMinLimit);
            Assert.AreEqual(9.20m, mid.TorqueOrForceMaxLimit);
            Assert.AreEqual(8.00m, mid.TorqueOrForceFinalTarget);
            Assert.AreEqual(0.00m, mid.AngleOrStrokeMinLimit);
            Assert.AreEqual(-0.15m, mid.AngleOrStrokeMaxLimit);
            Assert.AreEqual(0.00m, mid.FinalAngleOrStrokeTarget);
            Assert.AreEqual(new DateTime(2019, 11, 14, 14, 8, 5), mid.LastChangeInParameterSet);
            Assert.AreEqual(new DateTime(2019, 11, 25, 11, 22, 41), mid.TimeStamp);
            Assert.AreEqual(913, mid.SyncTighteningId);
            Assert.IsTrue(mid.SyncOverallStatus);
            Assert.AreEqual(2, mid.SpindlesOrPressesStatus.Count);
            Assert.AreEqual(SystemSubType.SystemRunningPresses, mid.SystemSubType);
            Assert.AreEqual(21, mid.JobSequenceNumber);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 6"), TestCategory("ByteArray")]
        public void Mid0101ByteRevision6()
        {
            var package = "02220101006         010202BM3GA02111900601         030304003050001060001071080006800900092010000800110000012-00151300000142019-11-14:14:08:05152019-11-25:11:22:41160091317118010111000809100000020111000809100000190022000021";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0101>(bytes);

            Assert.AreEqual(typeof(Mid0101), mid.GetType());
            Assert.AreEqual(2, mid.NumberOfSpindlesOrPresses);
            Assert.AreEqual("BM3GA02111900601", mid.VinNumber.TrimEnd());
            Assert.AreEqual(3, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(1, mid.BatchSize);
            Assert.AreEqual(1, mid.BatchCounter);
            Assert.AreEqual(BatchStatus.Ok, mid.BatchStatus);
            Assert.AreEqual(6.80m, mid.TorqueOrForceMinLimit);
            Assert.AreEqual(9.20m, mid.TorqueOrForceMaxLimit);
            Assert.AreEqual(8.00m, mid.TorqueOrForceFinalTarget);
            Assert.AreEqual(0.00m, mid.AngleOrStrokeMinLimit);
            Assert.AreEqual(-0.15m, mid.AngleOrStrokeMaxLimit);
            Assert.AreEqual(0.00m, mid.FinalAngleOrStrokeTarget);
            Assert.AreEqual(new DateTime(2019, 11, 14, 14, 8, 5), mid.LastChangeInParameterSet);
            Assert.AreEqual(new DateTime(2019, 11, 25, 11, 22, 41), mid.TimeStamp);
            Assert.AreEqual(913, mid.SyncTighteningId);
            Assert.IsTrue(mid.SyncOverallStatus);
            Assert.AreEqual(2, mid.SpindlesOrPressesStatus.Count);
            Assert.AreEqual(SystemSubType.SystemRunningPresses, mid.SystemSubType);
            Assert.AreEqual(21, mid.JobSequenceNumber);
            AssertEqualPackages(bytes, mid);
        }
    }
}
