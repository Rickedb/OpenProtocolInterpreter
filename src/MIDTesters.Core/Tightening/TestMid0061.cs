using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using System;
using OpenProtocolInterpreter.Tightening;
using System.Collections.Generic;

namespace MIDTesters.Tightening
{
    [TestClass]
    [TestCategory("Tightening")]
    public class TestMid0061 : DefaultMidTests<Mid0061>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0061Revision1()
        {
            string pack = "02310061001         010001020103airbag7                  04KPOL3456JKLO897          050006003070000080000090100111120008401300140014001200150007391600000170999918000001900000202001-06-02:09:54:09212001-05-29:12:34:33221230000345675";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("airbag7                  ", mid.TorqueControllerName);
            Assert.AreEqual("KPOL3456JKLO897          ", mid.VinNumber);
            Assert.AreEqual(0, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.AngleStatus);
            Assert.AreEqual(8.40m, mid.TorqueMinLimit);
            Assert.AreEqual(14m, mid.TorqueMaxLimit);
            Assert.AreEqual(12m, mid.TorqueFinalTarget);
            Assert.AreEqual(7.39m, mid.Torque);
            Assert.AreEqual(0, mid.AngleMinLimit);
            Assert.AreEqual(9999, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(new DateTime(2001, 6, 2, 9, 54, 9), mid.Timestamp);
            Assert.AreEqual(new DateTime(2001, 5, 29, 12, 34, 33), mid.LastChangeInParameterSet);
            Assert.AreEqual(BatchStatus.Ok, mid.BatchStatus);
            Assert.AreEqual(345675, mid.TighteningId);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0061ByteRevision1()
        {
            string package = "02310061001         010001020103airbag7                  04KPOL3456JKLO897          050006003070000080000090100111120008401300140014001200150007391600000170999918000001900000202001-06-02:09:54:09212001-05-29:12:34:33221230000345675";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0061>(bytes);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("airbag7                  ", mid.TorqueControllerName);
            Assert.AreEqual("KPOL3456JKLO897          ", mid.VinNumber);
            Assert.AreEqual(0, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.AngleStatus);
            Assert.AreEqual(8.40m, mid.TorqueMinLimit);
            Assert.AreEqual(14m, mid.TorqueMaxLimit);
            Assert.AreEqual(12m, mid.TorqueFinalTarget);
            Assert.AreEqual(7.39m, mid.Torque);
            Assert.AreEqual(0, mid.AngleMinLimit);
            Assert.AreEqual(9999, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(new DateTime(2001, 6, 2, 9, 54, 9), mid.Timestamp);
            Assert.AreEqual(new DateTime(2001, 5, 29, 12, 34, 33), mid.LastChangeInParameterSet);
            Assert.AreEqual(BatchStatus.Ok, mid.BatchStatus);
            Assert.AreEqual(345675, mid.TighteningId);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0061Revision2()
        {
            var pack = "03850061002         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:53";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(0, mid.CellId);
            Assert.AreEqual(0, mid.ChannelId);
            Assert.AreEqual("RA ST6.2 ETV100          ", mid.TorqueControllerName);
            Assert.AreEqual("                         ", mid.VinNumber);
            Assert.AreEqual(0, mid.JobId);
            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual(Strategy.TorqueControlAndAngleMonitoring, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.NotUsed, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(34m, mid.TorqueMinLimit);
            Assert.AreEqual(46m, mid.TorqueMaxLimit);
            Assert.AreEqual(40m, mid.TorqueFinalTarget);
            Assert.AreEqual(5.05m, mid.Torque);
            Assert.AreEqual(20, mid.AngleMinLimit);
            Assert.AreEqual(420, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(100, mid.RundownAngleMin);
            Assert.AreEqual(850, mid.RundownAngleMax);
            Assert.AreEqual(4, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(150, mid.CurrentMonitoringMax);
            Assert.AreEqual(0, mid.CurrentMonitoringValue);
            Assert.AreEqual(0m, mid.SelftapMin);
            Assert.AreEqual(9999m, mid.SelftapMax);
            Assert.AreEqual(0m, mid.SelftapTorque);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(0m, mid.PrevailTorque);
            Assert.AreEqual(184887, mid.TighteningId);
            Assert.AreEqual(0, mid.JobSequenceNumber);
            Assert.AreEqual(0, mid.SyncTighteningId);
            Assert.AreEqual("      C0761275", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2020, 6, 25, 1, 4, 39), mid.Timestamp);
            Assert.AreEqual(new DateTime(2020, 6, 24, 10, 48, 53), mid.LastChangeInParameterSet);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0061ByteRevision2()
        {
            List<byte> bytes = new List<byte>();

            var strategyOptions = new byte[] //5 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x00,
                0x00,
                0x00
            };
            var tighteningErrorStatus = new byte[] //10 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x0A, //0000 1010
                0xD1, //1101 0001
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
            };

            string untilStrategyOptions = "03850061002         010001020103airbag7                  04KPOL3456JKLO897          05000606003071208";
            bytes.AddRange(GetAsciiBytes(untilStrategyOptions));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));
            string untilTighteningErrorStatus = "09000010000011012013114015216117018219120";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));
            string untilEnd = "2100084022001400230012002400073925000002609999270000028000002900000300999931050003200033050340453500001036000125370005483800001039999900405555004142949672954265500436053544ABCDEFG-123456452001-06-02:09:54:09462001-05-29:12:34:33";

            bytes.AddRange(GetAsciiBytes(untilEnd));
            var mid = _midInterpreter.Parse<Mid0061>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("airbag7                  ", mid.TorqueControllerName);
            Assert.AreEqual("KPOL3456JKLO897          ", mid.VinNumber);
            Assert.AreEqual(6, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleReverse, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(8.40m, mid.TorqueMinLimit);
            Assert.AreEqual(14m, mid.TorqueMaxLimit);
            Assert.AreEqual(12m, mid.TorqueFinalTarget);
            Assert.AreEqual(7.39m, mid.Torque);
            Assert.AreEqual(0, mid.AngleMinLimit);
            Assert.AreEqual(9999, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(0, mid.RundownAngleMin);
            Assert.AreEqual(9999, mid.RundownAngleMax);
            Assert.AreEqual(5000, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(50, mid.CurrentMonitoringMax);
            Assert.AreEqual(45, mid.CurrentMonitoringValue);
            Assert.AreEqual(0.10m, mid.SelftapMin);
            Assert.AreEqual(1.25m, mid.SelftapMax);
            Assert.AreEqual(5.48m, mid.SelftapTorque);
            Assert.AreEqual(0.10m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(9999m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(5555m, mid.PrevailTorque);
            Assert.AreEqual(4294967295, mid.TighteningId);
            Assert.AreEqual(65500, mid.JobSequenceNumber);
            Assert.AreEqual(60535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2001, 6, 2, 9, 54, 9), mid.Timestamp);
            Assert.AreEqual(new DateTime(2001, 5, 29, 12, 34, 33), mid.LastChangeInParameterSet);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ASCII")]
        public void Mid0061Revision3()
        {
            var pack = "04190061003         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       4824905";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(0, mid.CellId);
            Assert.AreEqual(0, mid.ChannelId);
            Assert.AreEqual("RA ST6.2 ETV100          ", mid.TorqueControllerName);
            Assert.AreEqual("                         ", mid.VinNumber);
            Assert.AreEqual(0, mid.JobId);
            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual(Strategy.TorqueControlAndAngleMonitoring, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.NotUsed, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(34m, mid.TorqueMinLimit);
            Assert.AreEqual(46m, mid.TorqueMaxLimit);
            Assert.AreEqual(40m, mid.TorqueFinalTarget);
            Assert.AreEqual(5.05m, mid.Torque);
            Assert.AreEqual(20, mid.AngleMinLimit);
            Assert.AreEqual(420, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(100, mid.RundownAngleMin);
            Assert.AreEqual(850, mid.RundownAngleMax);
            Assert.AreEqual(4, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(150, mid.CurrentMonitoringMax);
            Assert.AreEqual(0, mid.CurrentMonitoringValue);
            Assert.AreEqual(0m, mid.SelftapMin);
            Assert.AreEqual(9999m, mid.SelftapMax);
            Assert.AreEqual(0m, mid.SelftapTorque);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(0m, mid.PrevailTorque);
            Assert.AreEqual(184887, mid.TighteningId);
            Assert.AreEqual(0, mid.JobSequenceNumber);
            Assert.AreEqual(0, mid.SyncTighteningId);
            Assert.AreEqual("      C0761275", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2020, 6, 25, 1, 4, 39), mid.Timestamp);
            Assert.AreEqual(new DateTime(2020, 6, 24, 10, 48, 53), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ByteArray")]
        public void Mid0061ByteRevision3()
        {
            List<byte> bytes = new List<byte>();

            var strategyOptions = new byte[] //5 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x00,
                0x00,
                0x00
            };
            var tighteningErrorStatus = new byte[] //10 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x0A, //0000 1010
                0xD1, //1101 0001
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
            };

            string untilStrategyOptions = "04190061003         010001020103airbag7                  04KPOL3456JKLO897          05000606003071208";
            bytes.AddRange(GetAsciiBytes(untilStrategyOptions));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));
            string untilTighteningErrorStatus = "09000010000011012013114015216117018219120";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));
            string untilEnd = "2100084022001400230012002400073925000002609999270000028000002900000300999931050003200033050340453500001036000125370005483800001039999900405555004142949672954265500436053544ABCDEFG-123456452001-06-02:09:54:09462001-05-29:12:34:3347Test Parameter Set       4824905";

            bytes.AddRange(GetAsciiBytes(untilEnd));
            var mid = _midInterpreter.Parse<Mid0061>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("airbag7                  ", mid.TorqueControllerName);
            Assert.AreEqual("KPOL3456JKLO897          ", mid.VinNumber);
            Assert.AreEqual(6, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleReverse, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(8.40m, mid.TorqueMinLimit);
            Assert.AreEqual(14m, mid.TorqueMaxLimit);
            Assert.AreEqual(12m, mid.TorqueFinalTarget);
            Assert.AreEqual(7.39m, mid.Torque);
            Assert.AreEqual(0, mid.AngleMinLimit);
            Assert.AreEqual(9999, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(0, mid.RundownAngleMin);
            Assert.AreEqual(9999, mid.RundownAngleMax);
            Assert.AreEqual(5000, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(50, mid.CurrentMonitoringMax);
            Assert.AreEqual(45, mid.CurrentMonitoringValue);
            Assert.AreEqual(0.10m, mid.SelftapMin);
            Assert.AreEqual(1.25m, mid.SelftapMax);
            Assert.AreEqual(5.48m, mid.SelftapTorque);
            Assert.AreEqual(0.10m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(9999m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(5555m, mid.PrevailTorque);
            Assert.AreEqual(4294967295, mid.TighteningId);
            Assert.AreEqual(65500, mid.JobSequenceNumber);
            Assert.AreEqual(60535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2001, 6, 2, 9, 54, 9), mid.Timestamp);
            Assert.AreEqual(new DateTime(2001, 5, 29, 12, 34, 33), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ASCII")]
        public void Mid0061Revision4()
        {
            var pack = "05000061004         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 ";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(0, mid.CellId);
            Assert.AreEqual(0, mid.ChannelId);
            Assert.AreEqual("RA ST6.2 ETV100          ", mid.TorqueControllerName);
            Assert.AreEqual("                         ", mid.VinNumber);
            Assert.AreEqual(0, mid.JobId);
            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual(Strategy.TorqueControlAndAngleMonitoring, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.NotUsed, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(34m, mid.TorqueMinLimit);
            Assert.AreEqual(46m, mid.TorqueMaxLimit);
            Assert.AreEqual(40m, mid.TorqueFinalTarget);
            Assert.AreEqual(5.05m, mid.Torque);
            Assert.AreEqual(20, mid.AngleMinLimit);
            Assert.AreEqual(420, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(100, mid.RundownAngleMin);
            Assert.AreEqual(850, mid.RundownAngleMax);
            Assert.AreEqual(4, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(150, mid.CurrentMonitoringMax);
            Assert.AreEqual(0, mid.CurrentMonitoringValue);
            Assert.AreEqual(0m, mid.SelftapMin);
            Assert.AreEqual(9999m, mid.SelftapMax);
            Assert.AreEqual(0m, mid.SelftapTorque);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(0m, mid.PrevailTorque);
            Assert.AreEqual(184887, mid.TighteningId);
            Assert.AreEqual(0, mid.JobSequenceNumber);
            Assert.AreEqual(0, mid.SyncTighteningId);
            Assert.AreEqual("      C0761275", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2020, 6, 25, 1, 4, 39), mid.Timestamp);
            Assert.AreEqual(new DateTime(2020, 6, 24, 10, 48, 53), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ByteArray")]
        public void Mid0061ByteRevision4()
        {
            List<byte> bytes = new List<byte>();

            var strategyOptions = new byte[] //5 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x00,
                0x00,
                0x00
            };
            var tighteningErrorStatus = new byte[] //10 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x0A, //0000 1010
                0xD1, //1101 0001
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
            };

            string untilStrategyOptions = "05000061004         010001020103airbag7                  04KPOL3456JKLO897          05000606003071208";
            bytes.AddRange(GetAsciiBytes(untilStrategyOptions));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));
            string untilTighteningErrorStatus = "09000010000011012013114015216117018219120";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));
            string untilEnd = "2100084022001400230012002400073925000002609999270000028000002900000300999931050003200033050340453500001036000125370005483800001039999900405555004142949672954265500436053544ABCDEFG-123456452001-06-02:09:54:09462001-05-29:12:34:3347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 ";

            bytes.AddRange(GetAsciiBytes(untilEnd));
            var mid = _midInterpreter.Parse<Mid0061>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("airbag7                  ", mid.TorqueControllerName);
            Assert.AreEqual("KPOL3456JKLO897          ", mid.VinNumber);
            Assert.AreEqual(6, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleReverse, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(8.40m, mid.TorqueMinLimit);
            Assert.AreEqual(14m, mid.TorqueMaxLimit);
            Assert.AreEqual(12m, mid.TorqueFinalTarget);
            Assert.AreEqual(7.39m, mid.Torque);
            Assert.AreEqual(0, mid.AngleMinLimit);
            Assert.AreEqual(9999, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(0, mid.RundownAngleMin);
            Assert.AreEqual(9999, mid.RundownAngleMax);
            Assert.AreEqual(5000, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(50, mid.CurrentMonitoringMax);
            Assert.AreEqual(45, mid.CurrentMonitoringValue);
            Assert.AreEqual(0.10m, mid.SelftapMin);
            Assert.AreEqual(1.25m, mid.SelftapMax);
            Assert.AreEqual(5.48m, mid.SelftapTorque);
            Assert.AreEqual(0.10m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(9999m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(5555m, mid.PrevailTorque);
            Assert.AreEqual(4294967295, mid.TighteningId);
            Assert.AreEqual(65500, mid.JobSequenceNumber);
            Assert.AreEqual(60535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2001, 6, 2, 9, 54, 9), mid.Timestamp);
            Assert.AreEqual(new DateTime(2001, 5, 29, 12, 34, 33), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("ASCII")]
        public void Mid0061Revision5()
        {
            var pack = "05060061005         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E124";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(0, mid.CellId);
            Assert.AreEqual(0, mid.ChannelId);
            Assert.AreEqual("RA ST6.2 ETV100          ", mid.TorqueControllerName);
            Assert.AreEqual("                         ", mid.VinNumber);
            Assert.AreEqual(0, mid.JobId);
            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual(Strategy.TorqueControlAndAngleMonitoring, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.NotUsed, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(34m, mid.TorqueMinLimit);
            Assert.AreEqual(46m, mid.TorqueMaxLimit);
            Assert.AreEqual(40m, mid.TorqueFinalTarget);
            Assert.AreEqual(5.05m, mid.Torque);
            Assert.AreEqual(20, mid.AngleMinLimit);
            Assert.AreEqual(420, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(100, mid.RundownAngleMin);
            Assert.AreEqual(850, mid.RundownAngleMax);
            Assert.AreEqual(4, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(150, mid.CurrentMonitoringMax);
            Assert.AreEqual(0, mid.CurrentMonitoringValue);
            Assert.AreEqual(0m, mid.SelftapMin);
            Assert.AreEqual(9999m, mid.SelftapMax);
            Assert.AreEqual(0m, mid.SelftapTorque);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(0m, mid.PrevailTorque);
            Assert.AreEqual(184887, mid.TighteningId);
            Assert.AreEqual(0, mid.JobSequenceNumber);
            Assert.AreEqual(0, mid.SyncTighteningId);
            Assert.AreEqual("      C0761275", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2020, 6, 25, 1, 4, 39), mid.Timestamp);
            Assert.AreEqual(new DateTime(2020, 6, 24, 10, 48, 53), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("ByteArray")]
        public void Mid0061ByteRevision5()
        {
            List<byte> bytes = new List<byte>();

            var strategyOptions = new byte[] //5 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x00,
                0x00,
                0x00
            };
            var tighteningErrorStatus = new byte[] //10 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x0A, //0000 1010
                0xD1, //1101 0001
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
            };

            string untilStrategyOptions = "05060061005         010001020103airbag7                  04KPOL3456JKLO897          05000606003071208";
            bytes.AddRange(GetAsciiBytes(untilStrategyOptions));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));
            string untilTighteningErrorStatus = "09000010000011012013114015216117018219120";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));
            string untilEnd = "2100084022001400230012002400073925000002609999270000028000002900000300999931050003200033050340453500001036000125370005483800001039999900405555004142949672954265500436053544ABCDEFG-123456452001-06-02:09:54:09462001-05-29:12:34:3347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E124";

            bytes.AddRange(GetAsciiBytes(untilEnd));
            var mid = _midInterpreter.Parse<Mid0061>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("airbag7                  ", mid.TorqueControllerName);
            Assert.AreEqual("KPOL3456JKLO897          ", mid.VinNumber);
            Assert.AreEqual(6, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleReverse, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(8.40m, mid.TorqueMinLimit);
            Assert.AreEqual(14m, mid.TorqueMaxLimit);
            Assert.AreEqual(12m, mid.TorqueFinalTarget);
            Assert.AreEqual(7.39m, mid.Torque);
            Assert.AreEqual(0, mid.AngleMinLimit);
            Assert.AreEqual(9999, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(0, mid.RundownAngleMin);
            Assert.AreEqual(9999, mid.RundownAngleMax);
            Assert.AreEqual(5000, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(50, mid.CurrentMonitoringMax);
            Assert.AreEqual(45, mid.CurrentMonitoringValue);
            Assert.AreEqual(0.10m, mid.SelftapMin);
            Assert.AreEqual(1.25m, mid.SelftapMax);
            Assert.AreEqual(5.48m, mid.SelftapTorque);
            Assert.AreEqual(0.10m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(9999m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(5555m, mid.PrevailTorque);
            Assert.AreEqual(4294967295, mid.TighteningId);
            Assert.AreEqual(65500, mid.JobSequenceNumber);
            Assert.AreEqual(60535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2001, 6, 2, 9, 54, 9), mid.Timestamp);
            Assert.AreEqual(new DateTime(2001, 5, 29, 12, 34, 33), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 6"), TestCategory("ASCII")]
        public void Mid0061Revision6()
        {
            var pack = "05260061006         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E12454001500550000000042";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(0, mid.CellId);
            Assert.AreEqual(0, mid.ChannelId);
            Assert.AreEqual("RA ST6.2 ETV100          ", mid.TorqueControllerName);
            Assert.AreEqual("                         ", mid.VinNumber);
            Assert.AreEqual(0, mid.JobId);
            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual(Strategy.TorqueControlAndAngleMonitoring, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.NotUsed, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(34m, mid.TorqueMinLimit);
            Assert.AreEqual(46m, mid.TorqueMaxLimit);
            Assert.AreEqual(40m, mid.TorqueFinalTarget);
            Assert.AreEqual(5.05m, mid.Torque);
            Assert.AreEqual(20, mid.AngleMinLimit);
            Assert.AreEqual(420, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(100, mid.RundownAngleMin);
            Assert.AreEqual(850, mid.RundownAngleMax);
            Assert.AreEqual(4, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(150, mid.CurrentMonitoringMax);
            Assert.AreEqual(0, mid.CurrentMonitoringValue);
            Assert.AreEqual(0m, mid.SelftapMin);
            Assert.AreEqual(9999m, mid.SelftapMax);
            Assert.AreEqual(0m, mid.SelftapTorque);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(0m, mid.PrevailTorque);
            Assert.AreEqual(184887, mid.TighteningId);
            Assert.AreEqual(0, mid.JobSequenceNumber);
            Assert.AreEqual(0, mid.SyncTighteningId);
            Assert.AreEqual("      C0761275", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2020, 6, 25, 1, 4, 39), mid.Timestamp);
            Assert.AreEqual(new DateTime(2020, 6, 24, 10, 48, 53), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(15m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 6"), TestCategory("ByteArray")]
        public void Mid0061ByteRevision6()
        {
            List<byte> bytes = new List<byte>();

            var strategyOptions = new byte[] //5 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x00,
                0x00,
                0x00
            };
            var tighteningErrorStatus = new byte[] //10 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x0A, //0000 1010
                0xD1, //1101 0001
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
            };

            var tighteningErrorStatus2 = new byte[] //10 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x02, //0000 0010
                0x00, //Reserved from bit 19 to rest
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
            };

            string untilStrategyOptions = "05260061006         010001020103airbag7                  04KPOL3456JKLO897          05000606003071208";
            bytes.AddRange(GetAsciiBytes(untilStrategyOptions));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));

            string untilTighteningErrorStatus = "09000010000011012013114015216117018219120";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));

            string untilTighteningErrorStatus2 = "2100084022001400230012002400073925000002609999270000028000002900000300999931050003200033050340453500001036000125370005483800001039999900405555004142949672954265500436053544ABCDEFG-123456452001-06-02:09:54:09462001-05-29:12:34:3347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E1245400150055";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus2));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus2, 10));

            var mid = _midInterpreter.Parse<Mid0061>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("airbag7                  ", mid.TorqueControllerName);
            Assert.AreEqual("KPOL3456JKLO897          ", mid.VinNumber);
            Assert.AreEqual(6, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleReverse, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(8.40m, mid.TorqueMinLimit);
            Assert.AreEqual(14m, mid.TorqueMaxLimit);
            Assert.AreEqual(12m, mid.TorqueFinalTarget);
            Assert.AreEqual(7.39m, mid.Torque);
            Assert.AreEqual(0, mid.AngleMinLimit);
            Assert.AreEqual(9999, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(0, mid.RundownAngleMin);
            Assert.AreEqual(9999, mid.RundownAngleMax);
            Assert.AreEqual(5000, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(50, mid.CurrentMonitoringMax);
            Assert.AreEqual(45, mid.CurrentMonitoringValue);
            Assert.AreEqual(0.10m, mid.SelftapMin);
            Assert.AreEqual(1.25m, mid.SelftapMax);
            Assert.AreEqual(5.48m, mid.SelftapTorque);
            Assert.AreEqual(0.10m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(9999m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(5555m, mid.PrevailTorque);
            Assert.AreEqual(4294967295, mid.TighteningId);
            Assert.AreEqual(65500, mid.JobSequenceNumber);
            Assert.AreEqual(60535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2001, 6, 2, 9, 54, 9), mid.Timestamp);
            Assert.AreEqual(new DateTime(2001, 5, 29, 12, 34, 33), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(15m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 7"), TestCategory("ASCII")]
        public void Mid0061Revision7()
        {
            var pack = "05440061007         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E12454001500550000000042560010000570999900";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(0, mid.CellId);
            Assert.AreEqual(0, mid.ChannelId);
            Assert.AreEqual("RA ST6.2 ETV100          ", mid.TorqueControllerName);
            Assert.AreEqual("                         ", mid.VinNumber);
            Assert.AreEqual(0, mid.JobId);
            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual(Strategy.TorqueControlAndAngleMonitoring, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.NotUsed, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(34m, mid.TorqueMinLimit);
            Assert.AreEqual(46m, mid.TorqueMaxLimit);
            Assert.AreEqual(40m, mid.TorqueFinalTarget);
            Assert.AreEqual(5.05m, mid.Torque);
            Assert.AreEqual(20, mid.AngleMinLimit);
            Assert.AreEqual(420, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(100, mid.RundownAngleMin);
            Assert.AreEqual(850, mid.RundownAngleMax);
            Assert.AreEqual(4, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(150, mid.CurrentMonitoringMax);
            Assert.AreEqual(0, mid.CurrentMonitoringValue);
            Assert.AreEqual(0m, mid.SelftapMin);
            Assert.AreEqual(9999m, mid.SelftapMax);
            Assert.AreEqual(0m, mid.SelftapTorque);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(0m, mid.PrevailTorque);
            Assert.AreEqual(184887, mid.TighteningId);
            Assert.AreEqual(0, mid.JobSequenceNumber);
            Assert.AreEqual(0, mid.SyncTighteningId);
            Assert.AreEqual("      C0761275", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2020, 6, 25, 1, 4, 39), mid.Timestamp);
            Assert.AreEqual(new DateTime(2020, 6, 24, 10, 48, 53), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(15m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(100m, mid.CompensatedAngle);
            Assert.AreEqual(9999m, mid.FinalAngleDecimal);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 7"), TestCategory("ByteArray")]
        public void Mid0061ByteRevision7()
        {
            List<byte> bytes = new List<byte>();

            var strategyOptions = new byte[] //5 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x00,
                0x00,
                0x00
            };
            var tighteningErrorStatus = new byte[] //10 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x0A, //0000 1010
                0xD1, //1101 0001
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
            };

            var tighteningErrorStatus2 = new byte[] //10 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x02, //0000 0010
                0x00, //Reserved from bit 19 to rest
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
            };

            string untilStrategyOptions = "05440061007         010001020103airbag7                  04KPOL3456JKLO897          05000606003071208";
            bytes.AddRange(GetAsciiBytes(untilStrategyOptions));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));

            string untilTighteningErrorStatus = "09000010000011012013114015216117018219120";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));

            string untilTighteningErrorStatus2 = "2100084022001400230012002400073925000002609999270000028000002900000300999931050003200033050340453500001036000125370005483800001039999900405555004142949672954265500436053544ABCDEFG-123456452001-06-02:09:54:09462001-05-29:12:34:3347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E1245400150055";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus2));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus2, 10));

            string untilEnd = "560010000570999900";
            bytes.AddRange(GetAsciiBytes(untilEnd));

            var mid = _midInterpreter.Parse<Mid0061>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("airbag7                  ", mid.TorqueControllerName);
            Assert.AreEqual("KPOL3456JKLO897          ", mid.VinNumber);
            Assert.AreEqual(6, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleReverse, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(8.40m, mid.TorqueMinLimit);
            Assert.AreEqual(14m, mid.TorqueMaxLimit);
            Assert.AreEqual(12m, mid.TorqueFinalTarget);
            Assert.AreEqual(7.39m, mid.Torque);
            Assert.AreEqual(0, mid.AngleMinLimit);
            Assert.AreEqual(9999, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(0, mid.RundownAngleMin);
            Assert.AreEqual(9999, mid.RundownAngleMax);
            Assert.AreEqual(5000, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(50, mid.CurrentMonitoringMax);
            Assert.AreEqual(45, mid.CurrentMonitoringValue);
            Assert.AreEqual(0.10m, mid.SelftapMin);
            Assert.AreEqual(1.25m, mid.SelftapMax);
            Assert.AreEqual(5.48m, mid.SelftapTorque);
            Assert.AreEqual(0.10m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(9999m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(5555m, mid.PrevailTorque);
            Assert.AreEqual(4294967295, mid.TighteningId);
            Assert.AreEqual(65500, mid.JobSequenceNumber);
            Assert.AreEqual(60535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2001, 6, 2, 9, 54, 9), mid.Timestamp);
            Assert.AreEqual(new DateTime(2001, 5, 29, 12, 34, 33), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(15m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(100m, mid.CompensatedAngle);
            Assert.AreEqual(9999m, mid.FinalAngleDecimal);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 8"), TestCategory("ASCII")]
        public void Mid0061Revision8()
        {
            var pack = "05710061008         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E12454001500550000000042560010000570999900580010005926065214361005232";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(0, mid.CellId);
            Assert.AreEqual(0, mid.ChannelId);
            Assert.AreEqual("RA ST6.2 ETV100          ", mid.TorqueControllerName);
            Assert.AreEqual("                         ", mid.VinNumber);
            Assert.AreEqual(0, mid.JobId);
            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual(Strategy.TorqueControlAndAngleMonitoring, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.NotUsed, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(34m, mid.TorqueMinLimit);
            Assert.AreEqual(46m, mid.TorqueMaxLimit);
            Assert.AreEqual(40m, mid.TorqueFinalTarget);
            Assert.AreEqual(5.05m, mid.Torque);
            Assert.AreEqual(20, mid.AngleMinLimit);
            Assert.AreEqual(420, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(100, mid.RundownAngleMin);
            Assert.AreEqual(850, mid.RundownAngleMax);
            Assert.AreEqual(4, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(150, mid.CurrentMonitoringMax);
            Assert.AreEqual(0, mid.CurrentMonitoringValue);
            Assert.AreEqual(0m, mid.SelftapMin);
            Assert.AreEqual(9999m, mid.SelftapMax);
            Assert.AreEqual(0m, mid.SelftapTorque);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(0m, mid.PrevailTorque);
            Assert.AreEqual(184887, mid.TighteningId);
            Assert.AreEqual(0, mid.JobSequenceNumber);
            Assert.AreEqual(0, mid.SyncTighteningId);
            Assert.AreEqual("      C0761275", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2020, 6, 25, 1, 4, 39), mid.Timestamp);
            Assert.AreEqual(new DateTime(2020, 6, 24, 10, 48, 53), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(15m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(100m, mid.CompensatedAngle);
            Assert.AreEqual(9999m, mid.FinalAngleDecimal);
            Assert.AreEqual(10m, mid.StartFinalAngle);
            Assert.AreEqual(PostViewTorque.OnlyPVTHOn, mid.PostViewTorqueActivated);
            Assert.AreEqual(6521.43m, mid.PostViewTorqueHigh);
            Assert.AreEqual(52.32m, mid.PostViewTorqueLow);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 8"), TestCategory("ByteArray")]
        public void Mid0061ByteRevision8()
        {
            List<byte> bytes = new List<byte>();

            var strategyOptions = new byte[] //5 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x00,
                0x00,
                0x00
            };
            var tighteningErrorStatus = new byte[] //10 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x0A, //0000 1010
                0xD1, //1101 0001
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
            };

            var tighteningErrorStatus2 = new byte[] //10 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x02, //0000 0010
                0x00, //Reserved from bit 19 to rest
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
            };

            string untilStrategyOptions = "05710061008         010001020103airbag7                  04KPOL3456JKLO897          05000606003071208";
            bytes.AddRange(GetAsciiBytes(untilStrategyOptions));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));

            string untilTighteningErrorStatus = "09000010000011012013114015216117018219120";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));

            string untilTighteningErrorStatus2 = "2100084022001400230012002400073925000002609999270000028000002900000300999931050003200033050340453500001036000125370005483800001039999900405555004142949672954265500436053544ABCDEFG-123456452001-06-02:09:54:09462001-05-29:12:34:3347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E1245400150055";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus2));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus2, 10));

            string untilEnd = "560010000570999900580010005926065214361005232";
            bytes.AddRange(GetAsciiBytes(untilEnd));

            var mid = _midInterpreter.Parse<Mid0061>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("airbag7                  ", mid.TorqueControllerName);
            Assert.AreEqual("KPOL3456JKLO897          ", mid.VinNumber);
            Assert.AreEqual(6, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleReverse, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(8.40m, mid.TorqueMinLimit);
            Assert.AreEqual(14m, mid.TorqueMaxLimit);
            Assert.AreEqual(12m, mid.TorqueFinalTarget);
            Assert.AreEqual(7.39m, mid.Torque);
            Assert.AreEqual(0, mid.AngleMinLimit);
            Assert.AreEqual(9999, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(0, mid.RundownAngleMin);
            Assert.AreEqual(9999, mid.RundownAngleMax);
            Assert.AreEqual(5000, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(50, mid.CurrentMonitoringMax);
            Assert.AreEqual(45, mid.CurrentMonitoringValue);
            Assert.AreEqual(0.10m, mid.SelftapMin);
            Assert.AreEqual(1.25m, mid.SelftapMax);
            Assert.AreEqual(5.48m, mid.SelftapTorque);
            Assert.AreEqual(0.10m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(9999m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(5555m, mid.PrevailTorque);
            Assert.AreEqual(4294967295, mid.TighteningId);
            Assert.AreEqual(65500, mid.JobSequenceNumber);
            Assert.AreEqual(60535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2001, 6, 2, 9, 54, 9), mid.Timestamp);
            Assert.AreEqual(new DateTime(2001, 5, 29, 12, 34, 33), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(15m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(100m, mid.CompensatedAngle);
            Assert.AreEqual(9999m, mid.FinalAngleDecimal);
            Assert.AreEqual(10m, mid.StartFinalAngle);
            Assert.AreEqual(PostViewTorque.OnlyPVTHOn, mid.PostViewTorqueActivated);
            Assert.AreEqual(6521.43m, mid.PostViewTorqueHigh);
            Assert.AreEqual(52.32m, mid.PostViewTorqueLow);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 9"), TestCategory("ASCII")]
        public void Mid0061Revision9()
        {
            var pack = "05920061009         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E12454001500550000000042560010000570999900580010005926065214361005232620010063000506400150";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(0, mid.CellId);
            Assert.AreEqual(0, mid.ChannelId);
            Assert.AreEqual("RA ST6.2 ETV100          ", mid.TorqueControllerName);
            Assert.AreEqual("                         ", mid.VinNumber);
            Assert.AreEqual(0, mid.JobId);
            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual(Strategy.TorqueControlAndAngleMonitoring, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.NotUsed, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(34m, mid.TorqueMinLimit);
            Assert.AreEqual(46m, mid.TorqueMaxLimit);
            Assert.AreEqual(40m, mid.TorqueFinalTarget);
            Assert.AreEqual(5.05m, mid.Torque);
            Assert.AreEqual(20, mid.AngleMinLimit);
            Assert.AreEqual(420, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(100, mid.RundownAngleMin);
            Assert.AreEqual(850, mid.RundownAngleMax);
            Assert.AreEqual(4, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(150, mid.CurrentMonitoringMax);
            Assert.AreEqual(0, mid.CurrentMonitoringValue);
            Assert.AreEqual(0m, mid.SelftapMin);
            Assert.AreEqual(9999m, mid.SelftapMax);
            Assert.AreEqual(0m, mid.SelftapTorque);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(0m, mid.PrevailTorque);
            Assert.AreEqual(184887, mid.TighteningId);
            Assert.AreEqual(0, mid.JobSequenceNumber);
            Assert.AreEqual(0, mid.SyncTighteningId);
            Assert.AreEqual("      C0761275", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2020, 6, 25, 1, 4, 39), mid.Timestamp);
            Assert.AreEqual(new DateTime(2020, 6, 24, 10, 48, 53), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(15m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(100m, mid.CompensatedAngle);
            Assert.AreEqual(9999m, mid.FinalAngleDecimal);
            Assert.AreEqual(10m, mid.StartFinalAngle);
            Assert.AreEqual(PostViewTorque.OnlyPVTHOn, mid.PostViewTorqueActivated);
            Assert.AreEqual(6521.43m, mid.PostViewTorqueHigh);
            Assert.AreEqual(52.32m, mid.PostViewTorqueLow);
            Assert.AreEqual(1m, mid.CurrentMonitoringAmpere);
            Assert.AreEqual(0.50m, mid.CurrentMonitoringAmpereMin);
            Assert.AreEqual(1.50m, mid.CurrentMonitoringAmpereMax);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 9"), TestCategory("ByteArray")]
        public void Mid0061ByteRevision9()
        {
            List<byte> bytes = new List<byte>();

            var strategyOptions = new byte[] //5 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x00,
                0x00,
                0x00
            };
            var tighteningErrorStatus = new byte[] //10 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x0A, //0000 1010
                0xD1, //1101 0001
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
            };

            var tighteningErrorStatus2 = new byte[] //10 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x02, //0000 0010
                0x00, //Reserved from bit 19 to rest
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
            };

            string untilStrategyOptions = "05920061009         010001020103airbag7                  04KPOL3456JKLO897          05000606003071208";
            bytes.AddRange(GetAsciiBytes(untilStrategyOptions));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));

            string untilTighteningErrorStatus = "09000010000011012013114015216117018219120";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));

            string untilTighteningErrorStatus2 = "2100084022001400230012002400073925000002609999270000028000002900000300999931050003200033050340453500001036000125370005483800001039999900405555004142949672954265500436053544ABCDEFG-123456452001-06-02:09:54:09462001-05-29:12:34:3347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E1245400150055";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus2));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus2, 10));

            string untilEnd = "560010000570999900580010005926065214361005232620010063000506400150";
            bytes.AddRange(GetAsciiBytes(untilEnd));

            var mid = _midInterpreter.Parse<Mid0061>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("airbag7                  ", mid.TorqueControllerName);
            Assert.AreEqual("KPOL3456JKLO897          ", mid.VinNumber);
            Assert.AreEqual(6, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleReverse, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(8.40m, mid.TorqueMinLimit);
            Assert.AreEqual(14m, mid.TorqueMaxLimit);
            Assert.AreEqual(12m, mid.TorqueFinalTarget);
            Assert.AreEqual(7.39m, mid.Torque);
            Assert.AreEqual(0, mid.AngleMinLimit);
            Assert.AreEqual(9999, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(0, mid.RundownAngleMin);
            Assert.AreEqual(9999, mid.RundownAngleMax);
            Assert.AreEqual(5000, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(50, mid.CurrentMonitoringMax);
            Assert.AreEqual(45, mid.CurrentMonitoringValue);
            Assert.AreEqual(0.10m, mid.SelftapMin);
            Assert.AreEqual(1.25m, mid.SelftapMax);
            Assert.AreEqual(5.48m, mid.SelftapTorque);
            Assert.AreEqual(0.10m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(9999m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(5555m, mid.PrevailTorque);
            Assert.AreEqual(4294967295, mid.TighteningId);
            Assert.AreEqual(65500, mid.JobSequenceNumber);
            Assert.AreEqual(60535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2001, 6, 2, 9, 54, 9), mid.Timestamp);
            Assert.AreEqual(new DateTime(2001, 5, 29, 12, 34, 33), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(15m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(100m, mid.CompensatedAngle);
            Assert.AreEqual(9999m, mid.FinalAngleDecimal);
            Assert.AreEqual(10m, mid.StartFinalAngle);
            Assert.AreEqual(PostViewTorque.OnlyPVTHOn, mid.PostViewTorqueActivated);
            Assert.AreEqual(6521.43m, mid.PostViewTorqueHigh);
            Assert.AreEqual(52.32m, mid.PostViewTorqueLow);
            Assert.AreEqual(1m, mid.CurrentMonitoringAmpere);
            Assert.AreEqual(0.50m, mid.CurrentMonitoringAmpereMin);
            Assert.AreEqual(1.50m, mid.CurrentMonitoringAmpereMax);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 10"), TestCategory("ASCII")]
        public void Mid0061Revision10()
        {
            var pack = "06620061010         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E124540015005500000000425600100005709999005800100059260652143610052326200100630005064001506500001660000167168-00206900100700012071003291720010057300011074009000";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(0, mid.CellId);
            Assert.AreEqual(0, mid.ChannelId);
            Assert.AreEqual("RA ST6.2 ETV100          ", mid.TorqueControllerName);
            Assert.AreEqual("                         ", mid.VinNumber);
            Assert.AreEqual(0, mid.JobId);
            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual(Strategy.TorqueControlAndAngleMonitoring, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.NotUsed, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(34m, mid.TorqueMinLimit);
            Assert.AreEqual(46m, mid.TorqueMaxLimit);
            Assert.AreEqual(40m, mid.TorqueFinalTarget);
            Assert.AreEqual(5.05m, mid.Torque);
            Assert.AreEqual(20, mid.AngleMinLimit);
            Assert.AreEqual(420, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(100, mid.RundownAngleMin);
            Assert.AreEqual(850, mid.RundownAngleMax);
            Assert.AreEqual(4, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(150, mid.CurrentMonitoringMax);
            Assert.AreEqual(0, mid.CurrentMonitoringValue);
            Assert.AreEqual(0m, mid.SelftapMin);
            Assert.AreEqual(9999m, mid.SelftapMax);
            Assert.AreEqual(0m, mid.SelftapTorque);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(0m, mid.PrevailTorque);
            Assert.AreEqual(184887, mid.TighteningId);
            Assert.AreEqual(0, mid.JobSequenceNumber);
            Assert.AreEqual(0, mid.SyncTighteningId);
            Assert.AreEqual("      C0761275", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2020, 6, 25, 1, 4, 39), mid.Timestamp);
            Assert.AreEqual(new DateTime(2020, 6, 24, 10, 48, 53), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(15m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(100m, mid.CompensatedAngle);
            Assert.AreEqual(9999m, mid.FinalAngleDecimal);
            Assert.AreEqual(10m, mid.StartFinalAngle);
            Assert.AreEqual(PostViewTorque.OnlyPVTHOn, mid.PostViewTorqueActivated);
            Assert.AreEqual(6521.43m, mid.PostViewTorqueHigh);
            Assert.AreEqual(52.32m, mid.PostViewTorqueLow);
            Assert.AreEqual(1m, mid.CurrentMonitoringAmpere);
            Assert.AreEqual(0.50m, mid.CurrentMonitoringAmpereMin);
            Assert.AreEqual(1.50m, mid.CurrentMonitoringAmpereMax);
            Assert.AreEqual(1, mid.AngleNumeratorScaleFactor);
            Assert.AreEqual(1, mid.AngleDenominatorScaleFactor);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.OverallAngleStatus);
            Assert.AreEqual(-20, mid.OverallAngleMin);
            Assert.AreEqual(100, mid.OverallAngleMax);
            Assert.AreEqual(120, mid.OverallAngle);
            Assert.AreEqual(32.91m, mid.PeakTorque);
            Assert.AreEqual(10.05m, mid.ResidualBreakawayTorque);
            Assert.AreEqual(1.10m, mid.StartRundownAngle);
            Assert.AreEqual(90m, mid.RundownAngleComplete);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 10"), TestCategory("ByteArray")]
        public void Mid0061ByteRevision10()
        {
            List<byte> bytes = new List<byte>();

            var strategyOptions = new byte[] //5 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x00,
                0x00,
                0x00
            };
            var tighteningErrorStatus = new byte[] //10 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x0A, //0000 1010
                0xD1, //1101 0001
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
            };

            var tighteningErrorStatus2 = new byte[] //10 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x02, //0000 0010
                0x00, //Reserved from bit 19 to rest
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
            };

            string untilStrategyOptions = "06620061010         010001020103airbag7                  04KPOL3456JKLO897          05000606003071208";
            bytes.AddRange(GetAsciiBytes(untilStrategyOptions));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));

            string untilTighteningErrorStatus = "09000010000011012013114015216117018219120";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));

            string untilTighteningErrorStatus2 = "2100084022001400230012002400073925000002609999270000028000002900000300999931050003200033050340453500001036000125370005483800001039999900405555004142949672954265500436053544ABCDEFG-123456452001-06-02:09:54:09462001-05-29:12:34:3347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E1245400150055";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus2));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus2, 10));

            string untilEnd = "5600100005709999005800100059260652143610052326200100630005064001506500001660000167168-00206900100700012071003291720010057300011074009000";
            bytes.AddRange(GetAsciiBytes(untilEnd));

            var mid = _midInterpreter.Parse<Mid0061>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("airbag7                  ", mid.TorqueControllerName);
            Assert.AreEqual("KPOL3456JKLO897          ", mid.VinNumber);
            Assert.AreEqual(6, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleReverse, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(8.40m, mid.TorqueMinLimit);
            Assert.AreEqual(14m, mid.TorqueMaxLimit);
            Assert.AreEqual(12m, mid.TorqueFinalTarget);
            Assert.AreEqual(7.39m, mid.Torque);
            Assert.AreEqual(0, mid.AngleMinLimit);
            Assert.AreEqual(9999, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(0, mid.RundownAngleMin);
            Assert.AreEqual(9999, mid.RundownAngleMax);
            Assert.AreEqual(5000, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(50, mid.CurrentMonitoringMax);
            Assert.AreEqual(45, mid.CurrentMonitoringValue);
            Assert.AreEqual(0.10m, mid.SelftapMin);
            Assert.AreEqual(1.25m, mid.SelftapMax);
            Assert.AreEqual(5.48m, mid.SelftapTorque);
            Assert.AreEqual(0.10m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(9999m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(5555m, mid.PrevailTorque);
            Assert.AreEqual(4294967295, mid.TighteningId);
            Assert.AreEqual(65500, mid.JobSequenceNumber);
            Assert.AreEqual(60535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2001, 6, 2, 9, 54, 9), mid.Timestamp);
            Assert.AreEqual(new DateTime(2001, 5, 29, 12, 34, 33), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(15m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(100m, mid.CompensatedAngle);
            Assert.AreEqual(9999m, mid.FinalAngleDecimal);
            Assert.AreEqual(10m, mid.StartFinalAngle);
            Assert.AreEqual(PostViewTorque.OnlyPVTHOn, mid.PostViewTorqueActivated);
            Assert.AreEqual(6521.43m, mid.PostViewTorqueHigh);
            Assert.AreEqual(52.32m, mid.PostViewTorqueLow);
            Assert.AreEqual(1m, mid.CurrentMonitoringAmpere);
            Assert.AreEqual(0.50m, mid.CurrentMonitoringAmpereMin);
            Assert.AreEqual(1.50m, mid.CurrentMonitoringAmpereMax);
            Assert.AreEqual(1, mid.AngleNumeratorScaleFactor);
            Assert.AreEqual(1, mid.AngleDenominatorScaleFactor);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.OverallAngleStatus);
            Assert.AreEqual(-20, mid.OverallAngleMin);
            Assert.AreEqual(100, mid.OverallAngleMax);
            Assert.AreEqual(120, mid.OverallAngle);
            Assert.AreEqual(32.91m, mid.PeakTorque);
            Assert.AreEqual(10.05m, mid.ResidualBreakawayTorque);
            Assert.AreEqual(1.10m, mid.StartRundownAngle);
            Assert.AreEqual(90m, mid.RundownAngleComplete);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 11"), TestCategory("ASCII")]
        public void Mid0061Revision11()
        {
            var pack = "06770061011         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E124540015005500000000425600100005709999005800100059260652143610052326200100630005064001506500001660000167168-00206900100700012071003291720010057300011074009000750001207600001";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(0, mid.CellId);
            Assert.AreEqual(0, mid.ChannelId);
            Assert.AreEqual("RA ST6.2 ETV100          ", mid.TorqueControllerName);
            Assert.AreEqual("                         ", mid.VinNumber);
            Assert.AreEqual(0, mid.JobId);
            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual(Strategy.TorqueControlAndAngleMonitoring, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.NotUsed, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(34m, mid.TorqueMinLimit);
            Assert.AreEqual(46m, mid.TorqueMaxLimit);
            Assert.AreEqual(40m, mid.TorqueFinalTarget);
            Assert.AreEqual(5.05m, mid.Torque);
            Assert.AreEqual(20, mid.AngleMinLimit);
            Assert.AreEqual(420, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(100, mid.RundownAngleMin);
            Assert.AreEqual(850, mid.RundownAngleMax);
            Assert.AreEqual(4, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(150, mid.CurrentMonitoringMax);
            Assert.AreEqual(0, mid.CurrentMonitoringValue);
            Assert.AreEqual(0m, mid.SelftapMin);
            Assert.AreEqual(9999m, mid.SelftapMax);
            Assert.AreEqual(0m, mid.SelftapTorque);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(0m, mid.PrevailTorque);
            Assert.AreEqual(184887, mid.TighteningId);
            Assert.AreEqual(0, mid.JobSequenceNumber);
            Assert.AreEqual(0, mid.SyncTighteningId);
            Assert.AreEqual("      C0761275", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2020, 6, 25, 1, 4, 39), mid.Timestamp);
            Assert.AreEqual(new DateTime(2020, 6, 24, 10, 48, 53), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(15m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(100m, mid.CompensatedAngle);
            Assert.AreEqual(9999m, mid.FinalAngleDecimal);
            Assert.AreEqual(10m, mid.StartFinalAngle);
            Assert.AreEqual(PostViewTorque.OnlyPVTHOn, mid.PostViewTorqueActivated);
            Assert.AreEqual(6521.43m, mid.PostViewTorqueHigh);
            Assert.AreEqual(52.32m, mid.PostViewTorqueLow);
            Assert.AreEqual(1m, mid.CurrentMonitoringAmpere);
            Assert.AreEqual(0.50m, mid.CurrentMonitoringAmpereMin);
            Assert.AreEqual(1.50m, mid.CurrentMonitoringAmpereMax);
            Assert.AreEqual(1, mid.AngleNumeratorScaleFactor);
            Assert.AreEqual(1, mid.AngleDenominatorScaleFactor);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.OverallAngleStatus);
            Assert.AreEqual(-20, mid.OverallAngleMin);
            Assert.AreEqual(100, mid.OverallAngleMax);
            Assert.AreEqual(120, mid.OverallAngle);
            Assert.AreEqual(32.91m, mid.PeakTorque);
            Assert.AreEqual(10.05m, mid.ResidualBreakawayTorque);
            Assert.AreEqual(1.10m, mid.StartRundownAngle);
            Assert.AreEqual(90m, mid.RundownAngleComplete);
            Assert.AreEqual(1.20m, mid.ClickTorque);
            Assert.AreEqual(1, mid.ClickAngle);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 11"), TestCategory("ByteArray")]
        public void Mid0061ByteRevision11()
        {
            List<byte> bytes = new List<byte>();

            var strategyOptions = new byte[] //5 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x00,
                0x00,
                0x00
            };
            var tighteningErrorStatus = new byte[] //10 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x0A, //0000 1010
                0xD1, //1101 0001
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
            };

            var tighteningErrorStatus2 = new byte[] //10 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x02, //0000 0010
                0x00, //Reserved from bit 19 to rest
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
            };

            string untilStrategyOptions = "06770061011         010001020103airbag7                  04KPOL3456JKLO897          05000606003071208";
            bytes.AddRange(GetAsciiBytes(untilStrategyOptions));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));

            string untilTighteningErrorStatus = "09000010000011012013114015216117018219120";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));

            string untilTighteningErrorStatus2 = "2100084022001400230012002400073925000002609999270000028000002900000300999931050003200033050340453500001036000125370005483800001039999900405555004142949672954265500436053544ABCDEFG-123456452001-06-02:09:54:09462001-05-29:12:34:3347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E1245400150055";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus2));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus2, 10));

            string untilEnd = "5600100005709999005800100059260652143610052326200100630005064001506500001660000167168-00206900100700012071003291720010057300011074009000750001207600001";
            bytes.AddRange(GetAsciiBytes(untilEnd));

            var mid = _midInterpreter.Parse<Mid0061>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("airbag7                  ", mid.TorqueControllerName);
            Assert.AreEqual("KPOL3456JKLO897          ", mid.VinNumber);
            Assert.AreEqual(6, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleReverse, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(8.40m, mid.TorqueMinLimit);
            Assert.AreEqual(14m, mid.TorqueMaxLimit);
            Assert.AreEqual(12m, mid.TorqueFinalTarget);
            Assert.AreEqual(7.39m, mid.Torque);
            Assert.AreEqual(0, mid.AngleMinLimit);
            Assert.AreEqual(9999, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(0, mid.RundownAngleMin);
            Assert.AreEqual(9999, mid.RundownAngleMax);
            Assert.AreEqual(5000, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(50, mid.CurrentMonitoringMax);
            Assert.AreEqual(45, mid.CurrentMonitoringValue);
            Assert.AreEqual(0.10m, mid.SelftapMin);
            Assert.AreEqual(1.25m, mid.SelftapMax);
            Assert.AreEqual(5.48m, mid.SelftapTorque);
            Assert.AreEqual(0.10m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(9999m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(5555m, mid.PrevailTorque);
            Assert.AreEqual(4294967295, mid.TighteningId);
            Assert.AreEqual(65500, mid.JobSequenceNumber);
            Assert.AreEqual(60535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2001, 6, 2, 9, 54, 9), mid.Timestamp);
            Assert.AreEqual(new DateTime(2001, 5, 29, 12, 34, 33), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(15m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(100m, mid.CompensatedAngle);
            Assert.AreEqual(9999m, mid.FinalAngleDecimal);
            Assert.AreEqual(10m, mid.StartFinalAngle);
            Assert.AreEqual(PostViewTorque.OnlyPVTHOn, mid.PostViewTorqueActivated);
            Assert.AreEqual(6521.43m, mid.PostViewTorqueHigh);
            Assert.AreEqual(52.32m, mid.PostViewTorqueLow);
            Assert.AreEqual(1m, mid.CurrentMonitoringAmpere);
            Assert.AreEqual(0.50m, mid.CurrentMonitoringAmpereMin);
            Assert.AreEqual(1.50m, mid.CurrentMonitoringAmpereMax);
            Assert.AreEqual(1, mid.AngleNumeratorScaleFactor);
            Assert.AreEqual(1, mid.AngleDenominatorScaleFactor);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.OverallAngleStatus);
            Assert.AreEqual(-20, mid.OverallAngleMin);
            Assert.AreEqual(100, mid.OverallAngleMax);
            Assert.AreEqual(120, mid.OverallAngle);
            Assert.AreEqual(32.91m, mid.PeakTorque);
            Assert.AreEqual(10.05m, mid.ResidualBreakawayTorque);
            Assert.AreEqual(1.10m, mid.StartRundownAngle);
            Assert.AreEqual(90m, mid.RundownAngleComplete);
            Assert.AreEqual(1.20m, mid.ClickTorque);
            Assert.AreEqual(1, mid.ClickAngle);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 998"), TestCategory("ASCII")]
        public void Mid0061Revision998()
        {
            var pack = "05580061998         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E1245400150055000000004256025702580200000010001200000080";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(0, mid.CellId);
            Assert.AreEqual(0, mid.ChannelId);
            Assert.AreEqual("RA ST6.2 ETV100          ", mid.TorqueControllerName);
            Assert.AreEqual("                         ", mid.VinNumber);
            Assert.AreEqual(0, mid.JobId);
            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual(Strategy.TorqueControlAndAngleMonitoring, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.NotUsed, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(34m, mid.TorqueMinLimit);
            Assert.AreEqual(46m, mid.TorqueMaxLimit);
            Assert.AreEqual(40m, mid.TorqueFinalTarget);
            Assert.AreEqual(5.05m, mid.Torque);
            Assert.AreEqual(20, mid.AngleMinLimit);
            Assert.AreEqual(420, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(100, mid.RundownAngleMin);
            Assert.AreEqual(850, mid.RundownAngleMax);
            Assert.AreEqual(4, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(150, mid.CurrentMonitoringMax);
            Assert.AreEqual(0, mid.CurrentMonitoringValue);
            Assert.AreEqual(0m, mid.SelftapMin);
            Assert.AreEqual(9999m, mid.SelftapMax);
            Assert.AreEqual(0m, mid.SelftapTorque);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(0m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(0m, mid.PrevailTorque);
            Assert.AreEqual(184887, mid.TighteningId);
            Assert.AreEqual(0, mid.JobSequenceNumber);
            Assert.AreEqual(0, mid.SyncTighteningId);
            Assert.AreEqual("      C0761275", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2020, 6, 25, 1, 4, 39), mid.Timestamp);
            Assert.AreEqual(new DateTime(2020, 6, 24, 10, 48, 53), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(15m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(2, mid.NumberOfStagesInMultistage);
            Assert.AreEqual(2, mid.NumberOfStageResults);
            Assert.IsNotNull(mid.StageResults);
            Assert.AreEqual(2, mid.StageResults.Count);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 998"), TestCategory("ByteArray")]
        public void Mid0061ByteRevision998()
        {
            List<byte> bytes = new List<byte>();

            var strategyOptions = new byte[] //5 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x00,
                0x00,
                0x00
            };
            var tighteningErrorStatus = new byte[] //10 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x0A, //0000 1010
                0xD1, //1101 0001
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
            };

            var tighteningErrorStatus2 = new byte[] //10 bytes long
            {
                0xAA, //1010 1010
                0x03, //0000 0011
                0x02, //0000 0010
                0x00, //Reserved from bit 19 to rest
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
            };

            string untilStrategyOptions = "05580061998         010001020103airbag7                  04KPOL3456JKLO897          05000606003071208";
            bytes.AddRange(GetAsciiBytes(untilStrategyOptions));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));

            string untilTighteningErrorStatus = "09000010000011012013114015216117018219120";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));

            string untilTighteningErrorStatus2 = "2100084022001400230012002400073925000002609999270000028000002900000300999931050003200033050340453500001036000125370005483800001039999900405555004142949672954265500436053544ABCDEFG-123456452001-06-02:09:54:09462001-05-29:12:34:3347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E1245400150055";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus2));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus2, 10));

            string untilEnd = "56025702580200000010001200000080";
            bytes.AddRange(GetAsciiBytes(untilEnd));

            var mid = _midInterpreter.Parse<Mid0061>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual(1, mid.CellId);
            Assert.AreEqual(1, mid.ChannelId);
            Assert.AreEqual("airbag7                  ", mid.TorqueControllerName);
            Assert.AreEqual("KPOL3456JKLO897          ", mid.VinNumber);
            Assert.AreEqual(6, mid.JobId);
            Assert.AreEqual(3, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleReverse, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.IsFalse(mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(8.40m, mid.TorqueMinLimit);
            Assert.AreEqual(14m, mid.TorqueMaxLimit);
            Assert.AreEqual(12m, mid.TorqueFinalTarget);
            Assert.AreEqual(7.39m, mid.Torque);
            Assert.AreEqual(0, mid.AngleMinLimit);
            Assert.AreEqual(9999, mid.AngleMaxLimit);
            Assert.AreEqual(0, mid.AngleFinalTarget);
            Assert.AreEqual(0, mid.Angle);
            Assert.AreEqual(0, mid.RundownAngleMin);
            Assert.AreEqual(9999, mid.RundownAngleMax);
            Assert.AreEqual(5000, mid.RundownAngle);
            Assert.AreEqual(0, mid.CurrentMonitoringMin);
            Assert.AreEqual(50, mid.CurrentMonitoringMax);
            Assert.AreEqual(45, mid.CurrentMonitoringValue);
            Assert.AreEqual(0.10m, mid.SelftapMin);
            Assert.AreEqual(1.25m, mid.SelftapMax);
            Assert.AreEqual(5.48m, mid.SelftapTorque);
            Assert.AreEqual(0.10m, mid.PrevailTorqueMonitoringMin);
            Assert.AreEqual(9999m, mid.PrevailTorqueMonitoringMax);
            Assert.AreEqual(5555m, mid.PrevailTorque);
            Assert.AreEqual(4294967295, mid.TighteningId);
            Assert.AreEqual(65500, mid.JobSequenceNumber);
            Assert.AreEqual(60535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2001, 6, 2, 9, 54, 9), mid.Timestamp);
            Assert.AreEqual(new DateTime(2001, 5, 29, 12, 34, 33), mid.LastChangeInParameterSet);
            Assert.AreEqual("Test Parameter Set       ", mid.ParameterSetName);
            Assert.AreEqual(TorqueValuesUnit.LbfFt, mid.TorqueValuesUnit);
            Assert.AreEqual(ResultType.BypassParameterSetResult, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(15m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(2, mid.NumberOfStagesInMultistage);
            Assert.AreEqual(2, mid.NumberOfStageResults);
            Assert.IsNotNull(mid.StageResults);
            Assert.AreEqual(2, mid.StageResults.Count);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 999"), TestCategory("ASCII")]
        public void Mid0061Revision999()
        {
            string pack = "01210061999         KPOL3456JKLO897          02001002000192111000500003602001-06-02:09:54:092000-06-02:09:54:094294967295";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual("KPOL3456JKLO897          ", mid.VinNumber);
            Assert.AreEqual(2, mid.JobId);
            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual(20, mid.BatchSize);
            Assert.AreEqual(19, mid.BatchCounter);
            Assert.AreEqual(BatchStatus.NotUsed, mid.BatchStatus);
            Assert.IsTrue(mid.TighteningStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.AngleStatus);
            Assert.AreEqual(5m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(new DateTime(2001, 6, 2, 9, 54, 9), mid.Timestamp);
            Assert.AreEqual(new DateTime(2000, 6, 2, 9, 54, 9), mid.LastChangeInParameterSet);
            Assert.AreEqual(4294967295L, mid.TighteningId);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 999"), TestCategory("ByteArray")]
        public void Mid0061ByteRevision999()
        {
            string package = "01210061999         KPOL3456JKLO897          02001002000192111000500003602001-06-02:09:54:092000-06-02:09:54:094294967295";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0061>(bytes);


            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.AreEqual("KPOL3456JKLO897          ", mid.VinNumber);
            Assert.AreEqual(2, mid.JobId);
            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual(20, mid.BatchSize);
            Assert.AreEqual(19, mid.BatchCounter);
            Assert.AreEqual(BatchStatus.NotUsed, mid.BatchStatus);
            Assert.IsTrue(mid.TighteningStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.AngleStatus);
            Assert.AreEqual(5m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(new DateTime(2001, 6, 2, 9, 54, 9), mid.Timestamp);
            Assert.AreEqual(new DateTime(2000, 6, 2, 9, 54, 9), mid.LastChangeInParameterSet);
            Assert.AreEqual(4294967295L, mid.TighteningId);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0061PackRevision1()
        {
            string package = "02310061001         010001020103airbag7                  04KPOL3456JKLO897          050006003070000080000090100111120008401300140014001200150007391600000170999918000001900000202001-06-02:09:54:09212001-05-29:12:34:33221230000345675";

            AssertBuildAndParse(package, new Mid0061(1)
            {
                CellId = 1,
                ChannelId = 1,
                TorqueControllerName = "airbag7",
                VinNumber = "KPOL3456JKLO897",
                JobId = 0,
                ParameterSetId = 3,
                BatchSize = 0,
                BatchCounter = 0,
                TighteningStatus = false,
                TorqueStatus = TighteningValueStatus.Low,
                AngleStatus = TighteningValueStatus.Ok,
                TorqueMinLimit = 8.4m,
                TorqueMaxLimit = 14m,
                TorqueFinalTarget = 12m,
                Torque = 7.39m,
                AngleMinLimit = 0,
                AngleMaxLimit = 9999,
                AngleFinalTarget = 0,
                Angle = 0,
                Timestamp = new DateTime(2001, 6, 2, 9, 54, 9),
                LastChangeInParameterSet = new DateTime(2001, 5, 29, 12, 34, 33),
                BatchStatus = BatchStatus.Ok,
                TighteningId = 345675L
            });
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("Pack")]
        public void Mid0061PackRevision2()
        {
            string package = "03850061002         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:53";

            AssertBuildAndParse(package, new Mid0061(2)
            {
                CellId = 0,
                ChannelId = 0,
                TorqueControllerName = "RA ST6.2 ETV100",
                VinNumber = "",
                JobId = 0,
                ParameterSetId = 1,
                BatchSize = 0,
                BatchCounter = 0,
                TighteningStatus = false,
                TorqueStatus = TighteningValueStatus.Low,
                AngleStatus = TighteningValueStatus.Low,
                TorqueMinLimit = 34m,
                TorqueMaxLimit = 46m,
                TorqueFinalTarget = 40m,
                Torque = 5.05m,
                AngleMinLimit = 20,
                AngleMaxLimit = 420,
                AngleFinalTarget = 0,
                Angle = 0,
                Timestamp = new DateTime(2020, 6, 25, 1, 4, 39),
                LastChangeInParameterSet = new DateTime(2020, 6, 24, 10, 48, 53),
                BatchStatus = BatchStatus.NotUsed,
                TighteningId = 184887L,
                Strategy = Strategy.TorqueControlAndAngleMonitoring,
                StrategyOptions = new StrategyOptions()
                {
                    Torque = true,
                    Angle = true,
                    Batch = false,
                    PvtMonitoring = false,
                    PvtCompensate = false,
                    Selftap = false,
                    Rundown = true,
                    CM = false,
                    DsControl = false,
                    ClickWrench = false,
                    RbwMonitoring = false
                },
                RundownAngleStatus = TighteningValueStatus.Low,
                CurrentMonitoringStatus = TighteningValueStatus.Ok,
                SelftapStatus = TighteningValueStatus.Ok,
                PrevailTorqueMonitoringStatus = TighteningValueStatus.Ok,
                PrevailTorqueCompensateStatus = TighteningValueStatus.Ok,
                TighteningErrorStatus = new TighteningErrorStatus()
                {
                    RundownAngleMaxShutOff = false,
                    RundownAngleMinShutOff = true,
                    TorqueMaxShutOff = false,
                    AngleMaxShutOff = false,
                    SelftapTorqueMaxShutOff = false,
                    SelftapTorqueMinShutOff = false,
                    PrevailTorqueMaxShutOff = false,
                    PrevailTorqueMinShutOff = false,
                    PrevailTorqueCompensateOverflow = false,
                    CurrentMonitoringMaxShutOff = false,
                    PostViewTorqueMinTorqueShutOff = false,
                    PostViewTorqueMaxTorqueShutOff = false,
                    PostViewTorqueAngleTooSmall = false,
                    TriggerLost = true,
                    TorqueLessThanTarget = false,
                    ToolHot = false,
                    MultistageAbort = false,
                    Rehit = false,
                    DsMeasureFailed = false,
                    CurrentLimitReached = false,
                    EndTimeOutShutOff = false,
                    RemoveFastenerLimitExceeded = false,
                    DisableDrive = false,
                    TransducerLost = false,
                    TransducerShorted = false,
                    TransducerCorrupt = false,
                    SyncTimeout = false,
                    DynamicCurrentMonitoringMin = false,
                    DynamicCurrentMonitoringMax = false,
                    AngleMaxMonitor = false,
                    YieldNutOff = false,
                    YieldTooFewSamples = false
                },
                RundownAngleMin = 100,
                RundownAngleMax = 850,
                RundownAngle = 4,
                CurrentMonitoringMin = 0,
                CurrentMonitoringMax = 150,
                CurrentMonitoringValue = 0,
                SelftapMin = 0m,
                SelftapMax = 9999m,
                SelftapTorque = 0m,
                PrevailTorqueMonitoringMin = 0m,
                PrevailTorqueMonitoringMax = 0m,
                PrevailTorque = 0m,
                JobSequenceNumber = 0,
                SyncTighteningId = 0,
                ToolSerialNumber = "      C0761275"
            });
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("Pack")]
        public void Mid0061PackRevision3()
        {
            string package = "04190061003         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       4824905";

            AssertBuildAndParse(package, new Mid0061(3)
            {
                CellId = 0,
                ChannelId = 0,
                TorqueControllerName = "RA ST6.2 ETV100",
                VinNumber = "",
                JobId = 0,
                ParameterSetId = 1,
                BatchSize = 0,
                BatchCounter = 0,
                TighteningStatus = false,
                TorqueStatus = TighteningValueStatus.Low,
                AngleStatus = TighteningValueStatus.Low,
                TorqueMinLimit = 34m,
                TorqueMaxLimit = 46m,
                TorqueFinalTarget = 40m,
                Torque = 5.05m,
                AngleMinLimit = 20,
                AngleMaxLimit = 420,
                AngleFinalTarget = 0,
                Angle = 0,
                Timestamp = new DateTime(2020, 6, 25, 1, 4, 39),
                LastChangeInParameterSet = new DateTime(2020, 6, 24, 10, 48, 53),
                BatchStatus = BatchStatus.NotUsed,
                TighteningId = 184887L,
                Strategy = Strategy.TorqueControlAndAngleMonitoring,
                StrategyOptions = new StrategyOptions()
                {
                    Torque = true,
                    Angle = true,
                    Batch = false,
                    PvtMonitoring = false,
                    PvtCompensate = false,
                    Selftap = false,
                    Rundown = true,
                    CM = false,
                    DsControl = false,
                    ClickWrench = false,
                    RbwMonitoring = false
                },
                RundownAngleStatus = TighteningValueStatus.Low,
                CurrentMonitoringStatus = TighteningValueStatus.Ok,
                SelftapStatus = TighteningValueStatus.Ok,
                PrevailTorqueMonitoringStatus = TighteningValueStatus.Ok,
                PrevailTorqueCompensateStatus = TighteningValueStatus.Ok,
                TighteningErrorStatus = new TighteningErrorStatus()
                {
                    RundownAngleMaxShutOff = false,
                    RundownAngleMinShutOff = true,
                    TorqueMaxShutOff = false,
                    AngleMaxShutOff = false,
                    SelftapTorqueMaxShutOff = false,
                    SelftapTorqueMinShutOff = false,
                    PrevailTorqueMaxShutOff = false,
                    PrevailTorqueMinShutOff = false,
                    PrevailTorqueCompensateOverflow = false,
                    CurrentMonitoringMaxShutOff = false,
                    PostViewTorqueMinTorqueShutOff = false,
                    PostViewTorqueMaxTorqueShutOff = false,
                    PostViewTorqueAngleTooSmall = false,
                    TriggerLost = true,
                    TorqueLessThanTarget = false,
                    ToolHot = false,
                    MultistageAbort = false,
                    Rehit = false,
                    DsMeasureFailed = false,
                    CurrentLimitReached = false,
                    EndTimeOutShutOff = false,
                    RemoveFastenerLimitExceeded = false,
                    DisableDrive = false,
                    TransducerLost = false,
                    TransducerShorted = false,
                    TransducerCorrupt = false,
                    SyncTimeout = false,
                    DynamicCurrentMonitoringMin = false,
                    DynamicCurrentMonitoringMax = false,
                    AngleMaxMonitor = false,
                    YieldNutOff = false,
                    YieldTooFewSamples = false
                },
                RundownAngleMin = 100,
                RundownAngleMax = 850,
                RundownAngle = 4,
                CurrentMonitoringMin = 0,
                CurrentMonitoringMax = 150,
                CurrentMonitoringValue = 0,
                SelftapMin = 0m,
                SelftapMax = 9999m,
                SelftapTorque = 0m,
                PrevailTorqueMonitoringMin = 0m,
                PrevailTorqueMonitoringMax = 0m,
                PrevailTorque = 0m,
                JobSequenceNumber = 0,
                SyncTighteningId = 0,
                ToolSerialNumber = "      C0761275",
                ParameterSetName = "Test Parameter Set",
                TorqueValuesUnit = TorqueValuesUnit.LbfFt,
                ResultType = ResultType.BypassParameterSetResult
            });
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("Pack")]
        public void Mid0061PackRevision4()
        {
            string package = "05000061004         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 ";

            AssertBuildAndParse(package, new Mid0061(4)
            {
                CellId = 0,
                ChannelId = 0,
                TorqueControllerName = "RA ST6.2 ETV100",
                VinNumber = "",
                JobId = 0,
                ParameterSetId = 1,
                BatchSize = 0,
                BatchCounter = 0,
                TighteningStatus = false,
                TorqueStatus = TighteningValueStatus.Low,
                AngleStatus = TighteningValueStatus.Low,
                TorqueMinLimit = 34m,
                TorqueMaxLimit = 46m,
                TorqueFinalTarget = 40m,
                Torque = 5.05m,
                AngleMinLimit = 20,
                AngleMaxLimit = 420,
                AngleFinalTarget = 0,
                Angle = 0,
                Timestamp = new DateTime(2020, 6, 25, 1, 4, 39),
                LastChangeInParameterSet = new DateTime(2020, 6, 24, 10, 48, 53),
                BatchStatus = BatchStatus.NotUsed,
                TighteningId = 184887L,
                Strategy = Strategy.TorqueControlAndAngleMonitoring,
                StrategyOptions = new StrategyOptions()
                {
                    Torque = true,
                    Angle = true,
                    Batch = false,
                    PvtMonitoring = false,
                    PvtCompensate = false,
                    Selftap = false,
                    Rundown = true,
                    CM = false,
                    DsControl = false,
                    ClickWrench = false,
                    RbwMonitoring = false
                },
                RundownAngleStatus = TighteningValueStatus.Low,
                CurrentMonitoringStatus = TighteningValueStatus.Ok,
                SelftapStatus = TighteningValueStatus.Ok,
                PrevailTorqueMonitoringStatus = TighteningValueStatus.Ok,
                PrevailTorqueCompensateStatus = TighteningValueStatus.Ok,
                TighteningErrorStatus = new TighteningErrorStatus()
                {
                    RundownAngleMaxShutOff = false,
                    RundownAngleMinShutOff = true,
                    TorqueMaxShutOff = false,
                    AngleMaxShutOff = false,
                    SelftapTorqueMaxShutOff = false,
                    SelftapTorqueMinShutOff = false,
                    PrevailTorqueMaxShutOff = false,
                    PrevailTorqueMinShutOff = false,
                    PrevailTorqueCompensateOverflow = false,
                    CurrentMonitoringMaxShutOff = false,
                    PostViewTorqueMinTorqueShutOff = false,
                    PostViewTorqueMaxTorqueShutOff = false,
                    PostViewTorqueAngleTooSmall = false,
                    TriggerLost = true,
                    TorqueLessThanTarget = false,
                    ToolHot = false,
                    MultistageAbort = false,
                    Rehit = false,
                    DsMeasureFailed = false,
                    CurrentLimitReached = false,
                    EndTimeOutShutOff = false,
                    RemoveFastenerLimitExceeded = false,
                    DisableDrive = false,
                    TransducerLost = false,
                    TransducerShorted = false,
                    TransducerCorrupt = false,
                    SyncTimeout = false,
                    DynamicCurrentMonitoringMin = false,
                    DynamicCurrentMonitoringMax = false,
                    AngleMaxMonitor = false,
                    YieldNutOff = false,
                    YieldTooFewSamples = false
                },
                RundownAngleMin = 100,
                RundownAngleMax = 850,
                RundownAngle = 4,
                CurrentMonitoringMin = 0,
                CurrentMonitoringMax = 150,
                CurrentMonitoringValue = 0,
                SelftapMin = 0m,
                SelftapMax = 9999m,
                SelftapTorque = 0m,
                PrevailTorqueMonitoringMin = 0m,
                PrevailTorqueMonitoringMax = 0m,
                PrevailTorque = 0m,
                JobSequenceNumber = 0,
                SyncTighteningId = 0,
                ToolSerialNumber = "      C0761275",
                ParameterSetName = "Test Parameter Set",
                TorqueValuesUnit = TorqueValuesUnit.LbfFt,
                ResultType = ResultType.BypassParameterSetResult,
                IdentifierResultPart2 = "Identifier result part 2",
                IdentifierResultPart3 = "Identifier result part 3",
                IdentifierResultPart4 = "Identifier result part 4"
            });
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("Pack")]
        public void Mid0061PackRevision5()
        {
            string package = "05060061005         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E124";

            AssertBuildAndParse(package, new Mid0061(5)
            {
                CellId = 0,
                ChannelId = 0,
                TorqueControllerName = "RA ST6.2 ETV100",
                VinNumber = "",
                JobId = 0,
                ParameterSetId = 1,
                BatchSize = 0,
                BatchCounter = 0,
                TighteningStatus = false,
                TorqueStatus = TighteningValueStatus.Low,
                AngleStatus = TighteningValueStatus.Low,
                TorqueMinLimit = 34m,
                TorqueMaxLimit = 46m,
                TorqueFinalTarget = 40m,
                Torque = 5.05m,
                AngleMinLimit = 20,
                AngleMaxLimit = 420,
                AngleFinalTarget = 0,
                Angle = 0,
                Timestamp = new DateTime(2020, 6, 25, 1, 4, 39),
                LastChangeInParameterSet = new DateTime(2020, 6, 24, 10, 48, 53),
                BatchStatus = BatchStatus.NotUsed,
                TighteningId = 184887L,
                Strategy = Strategy.TorqueControlAndAngleMonitoring,
                StrategyOptions = new StrategyOptions()
                {
                    Torque = true,
                    Angle = true,
                    Batch = false,
                    PvtMonitoring = false,
                    PvtCompensate = false,
                    Selftap = false,
                    Rundown = true,
                    CM = false,
                    DsControl = false,
                    ClickWrench = false,
                    RbwMonitoring = false
                },
                RundownAngleStatus = TighteningValueStatus.Low,
                CurrentMonitoringStatus = TighteningValueStatus.Ok,
                SelftapStatus = TighteningValueStatus.Ok,
                PrevailTorqueMonitoringStatus = TighteningValueStatus.Ok,
                PrevailTorqueCompensateStatus = TighteningValueStatus.Ok,
                TighteningErrorStatus = new TighteningErrorStatus()
                {
                    RundownAngleMaxShutOff = false,
                    RundownAngleMinShutOff = true,
                    TorqueMaxShutOff = false,
                    AngleMaxShutOff = false,
                    SelftapTorqueMaxShutOff = false,
                    SelftapTorqueMinShutOff = false,
                    PrevailTorqueMaxShutOff = false,
                    PrevailTorqueMinShutOff = false,
                    PrevailTorqueCompensateOverflow = false,
                    CurrentMonitoringMaxShutOff = false,
                    PostViewTorqueMinTorqueShutOff = false,
                    PostViewTorqueMaxTorqueShutOff = false,
                    PostViewTorqueAngleTooSmall = false,
                    TriggerLost = true,
                    TorqueLessThanTarget = false,
                    ToolHot = false,
                    MultistageAbort = false,
                    Rehit = false,
                    DsMeasureFailed = false,
                    CurrentLimitReached = false,
                    EndTimeOutShutOff = false,
                    RemoveFastenerLimitExceeded = false,
                    DisableDrive = false,
                    TransducerLost = false,
                    TransducerShorted = false,
                    TransducerCorrupt = false,
                    SyncTimeout = false,
                    DynamicCurrentMonitoringMin = false,
                    DynamicCurrentMonitoringMax = false,
                    AngleMaxMonitor = false,
                    YieldNutOff = false,
                    YieldTooFewSamples = false
                },
                RundownAngleMin = 100,
                RundownAngleMax = 850,
                RundownAngle = 4,
                CurrentMonitoringMin = 0,
                CurrentMonitoringMax = 150,
                CurrentMonitoringValue = 0,
                SelftapMin = 0m,
                SelftapMax = 9999m,
                SelftapTorque = 0m,
                PrevailTorqueMonitoringMin = 0m,
                PrevailTorqueMonitoringMax = 0m,
                PrevailTorque = 0m,
                JobSequenceNumber = 0,
                SyncTighteningId = 0,
                ToolSerialNumber = "      C0761275",
                ParameterSetName = "Test Parameter Set",
                TorqueValuesUnit = TorqueValuesUnit.LbfFt,
                ResultType = ResultType.BypassParameterSetResult,
                IdentifierResultPart2 = "Identifier result part 2",
                IdentifierResultPart3 = "Identifier result part 3",
                IdentifierResultPart4 = "Identifier result part 4",
                CustomerTighteningErrorCode = "E124"
            });
        }

        [TestMethod]
        [TestCategory("Revision 6"), TestCategory("Pack")]
        public void Mid0061PackRevision6()
        {
            string package = "05260061006         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E12454001500550000000042";

            AssertBuildAndParse(package, new Mid0061(6)
            {
                CellId = 0,
                ChannelId = 0,
                TorqueControllerName = "RA ST6.2 ETV100",
                VinNumber = "",
                JobId = 0,
                ParameterSetId = 1,
                BatchSize = 0,
                BatchCounter = 0,
                TighteningStatus = false,
                TorqueStatus = TighteningValueStatus.Low,
                AngleStatus = TighteningValueStatus.Low,
                TorqueMinLimit = 34m,
                TorqueMaxLimit = 46m,
                TorqueFinalTarget = 40m,
                Torque = 5.05m,
                AngleMinLimit = 20,
                AngleMaxLimit = 420,
                AngleFinalTarget = 0,
                Angle = 0,
                Timestamp = new DateTime(2020, 6, 25, 1, 4, 39),
                LastChangeInParameterSet = new DateTime(2020, 6, 24, 10, 48, 53),
                BatchStatus = BatchStatus.NotUsed,
                TighteningId = 184887L,
                Strategy = Strategy.TorqueControlAndAngleMonitoring,
                StrategyOptions = new StrategyOptions()
                {
                    Torque = true,
                    Angle = true,
                    Batch = false,
                    PvtMonitoring = false,
                    PvtCompensate = false,
                    Selftap = false,
                    Rundown = true,
                    CM = false,
                    DsControl = false,
                    ClickWrench = false,
                    RbwMonitoring = false
                },
                RundownAngleStatus = TighteningValueStatus.Low,
                CurrentMonitoringStatus = TighteningValueStatus.Ok,
                SelftapStatus = TighteningValueStatus.Ok,
                PrevailTorqueMonitoringStatus = TighteningValueStatus.Ok,
                PrevailTorqueCompensateStatus = TighteningValueStatus.Ok,
                TighteningErrorStatus = new TighteningErrorStatus()
                {
                    RundownAngleMaxShutOff = false,
                    RundownAngleMinShutOff = true,
                    TorqueMaxShutOff = false,
                    AngleMaxShutOff = false,
                    SelftapTorqueMaxShutOff = false,
                    SelftapTorqueMinShutOff = false,
                    PrevailTorqueMaxShutOff = false,
                    PrevailTorqueMinShutOff = false,
                    PrevailTorqueCompensateOverflow = false,
                    CurrentMonitoringMaxShutOff = false,
                    PostViewTorqueMinTorqueShutOff = false,
                    PostViewTorqueMaxTorqueShutOff = false,
                    PostViewTorqueAngleTooSmall = false,
                    TriggerLost = true,
                    TorqueLessThanTarget = false,
                    ToolHot = false,
                    MultistageAbort = false,
                    Rehit = false,
                    DsMeasureFailed = false,
                    CurrentLimitReached = false,
                    EndTimeOutShutOff = false,
                    RemoveFastenerLimitExceeded = false,
                    DisableDrive = false,
                    TransducerLost = false,
                    TransducerShorted = false,
                    TransducerCorrupt = false,
                    SyncTimeout = false,
                    DynamicCurrentMonitoringMin = false,
                    DynamicCurrentMonitoringMax = false,
                    AngleMaxMonitor = false,
                    YieldNutOff = false,
                    YieldTooFewSamples = false
                },
                RundownAngleMin = 100,
                RundownAngleMax = 850,
                RundownAngle = 4,
                CurrentMonitoringMin = 0,
                CurrentMonitoringMax = 150,
                CurrentMonitoringValue = 0,
                SelftapMin = 0m,
                SelftapMax = 9999m,
                SelftapTorque = 0m,
                PrevailTorqueMonitoringMin = 0m,
                PrevailTorqueMonitoringMax = 0m,
                PrevailTorque = 0m,
                JobSequenceNumber = 0,
                SyncTighteningId = 0,
                ToolSerialNumber = "      C0761275",
                ParameterSetName = "Test Parameter Set",
                TorqueValuesUnit = TorqueValuesUnit.LbfFt,
                ResultType = ResultType.BypassParameterSetResult,
                IdentifierResultPart2 = "Identifier result part 2",
                IdentifierResultPart3 = "Identifier result part 3",
                IdentifierResultPart4 = "Identifier result part 4",
                CustomerTighteningErrorCode = "E124",
                PrevailTorqueCompensateValue = 15m,
                TighteningErrorStatus2 = new TighteningErrorStatus2()
                {
                    DriveDeactivated = false,
                    ToolStall = true,
                    DriveHot = false,
                    GradientMonitoringHigh = true,
                    GradientMonitoringLow = false,
                    ReactionBarFailed = true,
                    SnugMax = false,
                    CycleAbort = false,
                    NeckingFailure = false,
                    EffectiveLoosening = false,
                    OverSpeed = false,
                    NoResidualTorque = false,
                    PositioningFail = false,
                    SnugMonLow = false,
                    SnugMonHigh = false,
                    DynamicMinCurrent = false,
                    DynamicMaxCurrent = false,
                    LatentResult = false,
                    Reserved = new byte[]
                    {
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0
                    }
                }
            });
        }

        [TestMethod]
        [TestCategory("Revision 7"), TestCategory("Pack")]
        public void Mid0061PackRevision7()
        {
            string package = "05440061007         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E12454001500550000000042560010000570999900";

            AssertBuildAndParse(package, new Mid0061(7)
            {
                CellId = 0,
                ChannelId = 0,
                TorqueControllerName = "RA ST6.2 ETV100",
                VinNumber = "",
                JobId = 0,
                ParameterSetId = 1,
                BatchSize = 0,
                BatchCounter = 0,
                TighteningStatus = false,
                TorqueStatus = TighteningValueStatus.Low,
                AngleStatus = TighteningValueStatus.Low,
                TorqueMinLimit = 34m,
                TorqueMaxLimit = 46m,
                TorqueFinalTarget = 40m,
                Torque = 5.05m,
                AngleMinLimit = 20,
                AngleMaxLimit = 420,
                AngleFinalTarget = 0,
                Angle = 0,
                Timestamp = new DateTime(2020, 6, 25, 1, 4, 39),
                LastChangeInParameterSet = new DateTime(2020, 6, 24, 10, 48, 53),
                BatchStatus = BatchStatus.NotUsed,
                TighteningId = 184887L,
                Strategy = Strategy.TorqueControlAndAngleMonitoring,
                StrategyOptions = new StrategyOptions()
                {
                    Torque = true,
                    Angle = true,
                    Batch = false,
                    PvtMonitoring = false,
                    PvtCompensate = false,
                    Selftap = false,
                    Rundown = true,
                    CM = false,
                    DsControl = false,
                    ClickWrench = false,
                    RbwMonitoring = false
                },
                RundownAngleStatus = TighteningValueStatus.Low,
                CurrentMonitoringStatus = TighteningValueStatus.Ok,
                SelftapStatus = TighteningValueStatus.Ok,
                PrevailTorqueMonitoringStatus = TighteningValueStatus.Ok,
                PrevailTorqueCompensateStatus = TighteningValueStatus.Ok,
                TighteningErrorStatus = new TighteningErrorStatus()
                {
                    RundownAngleMaxShutOff = false,
                    RundownAngleMinShutOff = true,
                    TorqueMaxShutOff = false,
                    AngleMaxShutOff = false,
                    SelftapTorqueMaxShutOff = false,
                    SelftapTorqueMinShutOff = false,
                    PrevailTorqueMaxShutOff = false,
                    PrevailTorqueMinShutOff = false,
                    PrevailTorqueCompensateOverflow = false,
                    CurrentMonitoringMaxShutOff = false,
                    PostViewTorqueMinTorqueShutOff = false,
                    PostViewTorqueMaxTorqueShutOff = false,
                    PostViewTorqueAngleTooSmall = false,
                    TriggerLost = true,
                    TorqueLessThanTarget = false,
                    ToolHot = false,
                    MultistageAbort = false,
                    Rehit = false,
                    DsMeasureFailed = false,
                    CurrentLimitReached = false,
                    EndTimeOutShutOff = false,
                    RemoveFastenerLimitExceeded = false,
                    DisableDrive = false,
                    TransducerLost = false,
                    TransducerShorted = false,
                    TransducerCorrupt = false,
                    SyncTimeout = false,
                    DynamicCurrentMonitoringMin = false,
                    DynamicCurrentMonitoringMax = false,
                    AngleMaxMonitor = false,
                    YieldNutOff = false,
                    YieldTooFewSamples = false
                },
                RundownAngleMin = 100,
                RundownAngleMax = 850,
                RundownAngle = 4,
                CurrentMonitoringMin = 0,
                CurrentMonitoringMax = 150,
                CurrentMonitoringValue = 0,
                SelftapMin = 0m,
                SelftapMax = 9999m,
                SelftapTorque = 0m,
                PrevailTorqueMonitoringMin = 0m,
                PrevailTorqueMonitoringMax = 0m,
                PrevailTorque = 0m,
                JobSequenceNumber = 0,
                SyncTighteningId = 0,
                ToolSerialNumber = "      C0761275",
                ParameterSetName = "Test Parameter Set",
                TorqueValuesUnit = TorqueValuesUnit.LbfFt,
                ResultType = ResultType.BypassParameterSetResult,
                IdentifierResultPart2 = "Identifier result part 2",
                IdentifierResultPart3 = "Identifier result part 3",
                IdentifierResultPart4 = "Identifier result part 4",
                CustomerTighteningErrorCode = "E124",
                PrevailTorqueCompensateValue = 15m,
                TighteningErrorStatus2 = new TighteningErrorStatus2()
                {
                    DriveDeactivated = false,
                    ToolStall = true,
                    DriveHot = false,
                    GradientMonitoringHigh = true,
                    GradientMonitoringLow = false,
                    ReactionBarFailed = true,
                    SnugMax = false,
                    CycleAbort = false,
                    NeckingFailure = false,
                    EffectiveLoosening = false,
                    OverSpeed = false,
                    NoResidualTorque = false,
                    PositioningFail = false,
                    SnugMonLow = false,
                    SnugMonHigh = false,
                    DynamicMinCurrent = false,
                    DynamicMaxCurrent = false,
                    LatentResult = false,
                    Reserved = new byte[]
                    {
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0
                    }
                },
                CompensatedAngle = 100m,
                FinalAngleDecimal = 9999m
            });
        }

        [TestMethod]
        [TestCategory("Revision 8"), TestCategory("Pack")]
        public void Mid0061PackRevision8()
        {
            string package = "05710061008         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E12454001500550000000042560010000570999900580010005926065214361005232";

            AssertBuildAndParse(package, new Mid0061(8)
            {
                CellId = 0,
                ChannelId = 0,
                TorqueControllerName = "RA ST6.2 ETV100",
                VinNumber = "",
                JobId = 0,
                ParameterSetId = 1,
                BatchSize = 0,
                BatchCounter = 0,
                TighteningStatus = false,
                TorqueStatus = TighteningValueStatus.Low,
                AngleStatus = TighteningValueStatus.Low,
                TorqueMinLimit = 34m,
                TorqueMaxLimit = 46m,
                TorqueFinalTarget = 40m,
                Torque = 5.05m,
                AngleMinLimit = 20,
                AngleMaxLimit = 420,
                AngleFinalTarget = 0,
                Angle = 0,
                Timestamp = new DateTime(2020, 6, 25, 1, 4, 39),
                LastChangeInParameterSet = new DateTime(2020, 6, 24, 10, 48, 53),
                BatchStatus = BatchStatus.NotUsed,
                TighteningId = 184887L,
                Strategy = Strategy.TorqueControlAndAngleMonitoring,
                StrategyOptions = new StrategyOptions()
                {
                    Torque = true,
                    Angle = true,
                    Batch = false,
                    PvtMonitoring = false,
                    PvtCompensate = false,
                    Selftap = false,
                    Rundown = true,
                    CM = false,
                    DsControl = false,
                    ClickWrench = false,
                    RbwMonitoring = false
                },
                RundownAngleStatus = TighteningValueStatus.Low,
                CurrentMonitoringStatus = TighteningValueStatus.Ok,
                SelftapStatus = TighteningValueStatus.Ok,
                PrevailTorqueMonitoringStatus = TighteningValueStatus.Ok,
                PrevailTorqueCompensateStatus = TighteningValueStatus.Ok,
                TighteningErrorStatus = new TighteningErrorStatus()
                {
                    RundownAngleMaxShutOff = false,
                    RundownAngleMinShutOff = true,
                    TorqueMaxShutOff = false,
                    AngleMaxShutOff = false,
                    SelftapTorqueMaxShutOff = false,
                    SelftapTorqueMinShutOff = false,
                    PrevailTorqueMaxShutOff = false,
                    PrevailTorqueMinShutOff = false,
                    PrevailTorqueCompensateOverflow = false,
                    CurrentMonitoringMaxShutOff = false,
                    PostViewTorqueMinTorqueShutOff = false,
                    PostViewTorqueMaxTorqueShutOff = false,
                    PostViewTorqueAngleTooSmall = false,
                    TriggerLost = true,
                    TorqueLessThanTarget = false,
                    ToolHot = false,
                    MultistageAbort = false,
                    Rehit = false,
                    DsMeasureFailed = false,
                    CurrentLimitReached = false,
                    EndTimeOutShutOff = false,
                    RemoveFastenerLimitExceeded = false,
                    DisableDrive = false,
                    TransducerLost = false,
                    TransducerShorted = false,
                    TransducerCorrupt = false,
                    SyncTimeout = false,
                    DynamicCurrentMonitoringMin = false,
                    DynamicCurrentMonitoringMax = false,
                    AngleMaxMonitor = false,
                    YieldNutOff = false,
                    YieldTooFewSamples = false
                },
                RundownAngleMin = 100,
                RundownAngleMax = 850,
                RundownAngle = 4,
                CurrentMonitoringMin = 0,
                CurrentMonitoringMax = 150,
                CurrentMonitoringValue = 0,
                SelftapMin = 0m,
                SelftapMax = 9999m,
                SelftapTorque = 0m,
                PrevailTorqueMonitoringMin = 0m,
                PrevailTorqueMonitoringMax = 0m,
                PrevailTorque = 0m,
                JobSequenceNumber = 0,
                SyncTighteningId = 0,
                ToolSerialNumber = "      C0761275",
                ParameterSetName = "Test Parameter Set",
                TorqueValuesUnit = TorqueValuesUnit.LbfFt,
                ResultType = ResultType.BypassParameterSetResult,
                IdentifierResultPart2 = "Identifier result part 2",
                IdentifierResultPart3 = "Identifier result part 3",
                IdentifierResultPart4 = "Identifier result part 4",
                CustomerTighteningErrorCode = "E124",
                PrevailTorqueCompensateValue = 15m,
                TighteningErrorStatus2 = new TighteningErrorStatus2()
                {
                    DriveDeactivated = false,
                    ToolStall = true,
                    DriveHot = false,
                    GradientMonitoringHigh = true,
                    GradientMonitoringLow = false,
                    ReactionBarFailed = true,
                    SnugMax = false,
                    CycleAbort = false,
                    NeckingFailure = false,
                    EffectiveLoosening = false,
                    OverSpeed = false,
                    NoResidualTorque = false,
                    PositioningFail = false,
                    SnugMonLow = false,
                    SnugMonHigh = false,
                    DynamicMinCurrent = false,
                    DynamicMaxCurrent = false,
                    LatentResult = false,
                    Reserved = new byte[]
                    {
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0
                    }
                },
                CompensatedAngle = 100m,
                FinalAngleDecimal = 9999m,
                StartFinalAngle = 10m,
                PostViewTorqueActivated = PostViewTorque.OnlyPVTHOn,
                PostViewTorqueHigh = 6521.43m,
                PostViewTorqueLow = 52.32m
            });
        }

        [TestMethod]
        [TestCategory("Revision 9"), TestCategory("Pack")]
        public void Mid0061PackRevision9()
        {
            string package = "05920061009         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E12454001500550000000042560010000570999900580010005926065214361005232620010063000506400150";

            AssertBuildAndParse(package, new Mid0061(9)
            {
                CellId = 0,
                ChannelId = 0,
                TorqueControllerName = "RA ST6.2 ETV100",
                VinNumber = "",
                JobId = 0,
                ParameterSetId = 1,
                BatchSize = 0,
                BatchCounter = 0,
                TighteningStatus = false,
                TorqueStatus = TighteningValueStatus.Low,
                AngleStatus = TighteningValueStatus.Low,
                TorqueMinLimit = 34m,
                TorqueMaxLimit = 46m,
                TorqueFinalTarget = 40m,
                Torque = 5.05m,
                AngleMinLimit = 20,
                AngleMaxLimit = 420,
                AngleFinalTarget = 0,
                Angle = 0,
                Timestamp = new DateTime(2020, 6, 25, 1, 4, 39),
                LastChangeInParameterSet = new DateTime(2020, 6, 24, 10, 48, 53),
                BatchStatus = BatchStatus.NotUsed,
                TighteningId = 184887L,
                Strategy = Strategy.TorqueControlAndAngleMonitoring,
                StrategyOptions = new StrategyOptions()
                {
                    Torque = true,
                    Angle = true,
                    Batch = false,
                    PvtMonitoring = false,
                    PvtCompensate = false,
                    Selftap = false,
                    Rundown = true,
                    CM = false,
                    DsControl = false,
                    ClickWrench = false,
                    RbwMonitoring = false
                },
                RundownAngleStatus = TighteningValueStatus.Low,
                CurrentMonitoringStatus = TighteningValueStatus.Ok,
                SelftapStatus = TighteningValueStatus.Ok,
                PrevailTorqueMonitoringStatus = TighteningValueStatus.Ok,
                PrevailTorqueCompensateStatus = TighteningValueStatus.Ok,
                TighteningErrorStatus = new TighteningErrorStatus()
                {
                    RundownAngleMaxShutOff = false,
                    RundownAngleMinShutOff = true,
                    TorqueMaxShutOff = false,
                    AngleMaxShutOff = false,
                    SelftapTorqueMaxShutOff = false,
                    SelftapTorqueMinShutOff = false,
                    PrevailTorqueMaxShutOff = false,
                    PrevailTorqueMinShutOff = false,
                    PrevailTorqueCompensateOverflow = false,
                    CurrentMonitoringMaxShutOff = false,
                    PostViewTorqueMinTorqueShutOff = false,
                    PostViewTorqueMaxTorqueShutOff = false,
                    PostViewTorqueAngleTooSmall = false,
                    TriggerLost = true,
                    TorqueLessThanTarget = false,
                    ToolHot = false,
                    MultistageAbort = false,
                    Rehit = false,
                    DsMeasureFailed = false,
                    CurrentLimitReached = false,
                    EndTimeOutShutOff = false,
                    RemoveFastenerLimitExceeded = false,
                    DisableDrive = false,
                    TransducerLost = false,
                    TransducerShorted = false,
                    TransducerCorrupt = false,
                    SyncTimeout = false,
                    DynamicCurrentMonitoringMin = false,
                    DynamicCurrentMonitoringMax = false,
                    AngleMaxMonitor = false,
                    YieldNutOff = false,
                    YieldTooFewSamples = false
                },
                RundownAngleMin = 100,
                RundownAngleMax = 850,
                RundownAngle = 4,
                CurrentMonitoringMin = 0,
                CurrentMonitoringMax = 150,
                CurrentMonitoringValue = 0,
                SelftapMin = 0m,
                SelftapMax = 9999m,
                SelftapTorque = 0m,
                PrevailTorqueMonitoringMin = 0m,
                PrevailTorqueMonitoringMax = 0m,
                PrevailTorque = 0m,
                JobSequenceNumber = 0,
                SyncTighteningId = 0,
                ToolSerialNumber = "      C0761275",
                ParameterSetName = "Test Parameter Set",
                TorqueValuesUnit = TorqueValuesUnit.LbfFt,
                ResultType = ResultType.BypassParameterSetResult,
                IdentifierResultPart2 = "Identifier result part 2",
                IdentifierResultPart3 = "Identifier result part 3",
                IdentifierResultPart4 = "Identifier result part 4",
                CustomerTighteningErrorCode = "E124",
                PrevailTorqueCompensateValue = 15m,
                TighteningErrorStatus2 = new TighteningErrorStatus2()
                {
                    DriveDeactivated = false,
                    ToolStall = true,
                    DriveHot = false,
                    GradientMonitoringHigh = true,
                    GradientMonitoringLow = false,
                    ReactionBarFailed = true,
                    SnugMax = false,
                    CycleAbort = false,
                    NeckingFailure = false,
                    EffectiveLoosening = false,
                    OverSpeed = false,
                    NoResidualTorque = false,
                    PositioningFail = false,
                    SnugMonLow = false,
                    SnugMonHigh = false,
                    DynamicMinCurrent = false,
                    DynamicMaxCurrent = false,
                    LatentResult = false,
                    Reserved = new byte[]
                    {
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0
                    }
                },
                CompensatedAngle = 100m,
                FinalAngleDecimal = 9999m,
                StartFinalAngle = 10m,
                PostViewTorqueActivated = PostViewTorque.OnlyPVTHOn,
                PostViewTorqueHigh = 6521.43m,
                PostViewTorqueLow = 52.32m,
                CurrentMonitoringAmpere = 1m,
                CurrentMonitoringAmpereMin = 0.5m,
                CurrentMonitoringAmpereMax = 1.5m
            });
        }

        [TestMethod]
        [TestCategory("Revision 10"), TestCategory("Pack")]
        public void Mid0061PackRevision10()
        {
            string package = "06620061010         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E124540015005500000000425600100005709999005800100059260652143610052326200100630005064001506500001660000167168-00206900100700012071003291720010057300011074009000";

            AssertBuildAndParse(package, new Mid0061(10)
            {
                CellId = 0,
                ChannelId = 0,
                TorqueControllerName = "RA ST6.2 ETV100",
                VinNumber = "",
                JobId = 0,
                ParameterSetId = 1,
                BatchSize = 0,
                BatchCounter = 0,
                TighteningStatus = false,
                TorqueStatus = TighteningValueStatus.Low,
                AngleStatus = TighteningValueStatus.Low,
                TorqueMinLimit = 34m,
                TorqueMaxLimit = 46m,
                TorqueFinalTarget = 40m,
                Torque = 5.05m,
                AngleMinLimit = 20,
                AngleMaxLimit = 420,
                AngleFinalTarget = 0,
                Angle = 0,
                Timestamp = new DateTime(2020, 6, 25, 1, 4, 39),
                LastChangeInParameterSet = new DateTime(2020, 6, 24, 10, 48, 53),
                BatchStatus = BatchStatus.NotUsed,
                TighteningId = 184887L,
                Strategy = Strategy.TorqueControlAndAngleMonitoring,
                StrategyOptions = new StrategyOptions()
                {
                    Torque = true,
                    Angle = true,
                    Batch = false,
                    PvtMonitoring = false,
                    PvtCompensate = false,
                    Selftap = false,
                    Rundown = true,
                    CM = false,
                    DsControl = false,
                    ClickWrench = false,
                    RbwMonitoring = false
                },
                RundownAngleStatus = TighteningValueStatus.Low,
                CurrentMonitoringStatus = TighteningValueStatus.Ok,
                SelftapStatus = TighteningValueStatus.Ok,
                PrevailTorqueMonitoringStatus = TighteningValueStatus.Ok,
                PrevailTorqueCompensateStatus = TighteningValueStatus.Ok,
                TighteningErrorStatus = new TighteningErrorStatus()
                {
                    RundownAngleMaxShutOff = false,
                    RundownAngleMinShutOff = true,
                    TorqueMaxShutOff = false,
                    AngleMaxShutOff = false,
                    SelftapTorqueMaxShutOff = false,
                    SelftapTorqueMinShutOff = false,
                    PrevailTorqueMaxShutOff = false,
                    PrevailTorqueMinShutOff = false,
                    PrevailTorqueCompensateOverflow = false,
                    CurrentMonitoringMaxShutOff = false,
                    PostViewTorqueMinTorqueShutOff = false,
                    PostViewTorqueMaxTorqueShutOff = false,
                    PostViewTorqueAngleTooSmall = false,
                    TriggerLost = true,
                    TorqueLessThanTarget = false,
                    ToolHot = false,
                    MultistageAbort = false,
                    Rehit = false,
                    DsMeasureFailed = false,
                    CurrentLimitReached = false,
                    EndTimeOutShutOff = false,
                    RemoveFastenerLimitExceeded = false,
                    DisableDrive = false,
                    TransducerLost = false,
                    TransducerShorted = false,
                    TransducerCorrupt = false,
                    SyncTimeout = false,
                    DynamicCurrentMonitoringMin = false,
                    DynamicCurrentMonitoringMax = false,
                    AngleMaxMonitor = false,
                    YieldNutOff = false,
                    YieldTooFewSamples = false
                },
                RundownAngleMin = 100,
                RundownAngleMax = 850,
                RundownAngle = 4,
                CurrentMonitoringMin = 0,
                CurrentMonitoringMax = 150,
                CurrentMonitoringValue = 0,
                SelftapMin = 0m,
                SelftapMax = 9999m,
                SelftapTorque = 0m,
                PrevailTorqueMonitoringMin = 0m,
                PrevailTorqueMonitoringMax = 0m,
                PrevailTorque = 0m,
                JobSequenceNumber = 0,
                SyncTighteningId = 0,
                ToolSerialNumber = "      C0761275",
                ParameterSetName = "Test Parameter Set",
                TorqueValuesUnit = TorqueValuesUnit.LbfFt,
                ResultType = ResultType.BypassParameterSetResult,
                IdentifierResultPart2 = "Identifier result part 2",
                IdentifierResultPart3 = "Identifier result part 3",
                IdentifierResultPart4 = "Identifier result part 4",
                CustomerTighteningErrorCode = "E124",
                PrevailTorqueCompensateValue = 15m,
                TighteningErrorStatus2 = new TighteningErrorStatus2()
                {
                    DriveDeactivated = false,
                    ToolStall = true,
                    DriveHot = false,
                    GradientMonitoringHigh = true,
                    GradientMonitoringLow = false,
                    ReactionBarFailed = true,
                    SnugMax = false,
                    CycleAbort = false,
                    NeckingFailure = false,
                    EffectiveLoosening = false,
                    OverSpeed = false,
                    NoResidualTorque = false,
                    PositioningFail = false,
                    SnugMonLow = false,
                    SnugMonHigh = false,
                    DynamicMinCurrent = false,
                    DynamicMaxCurrent = false,
                    LatentResult = false,
                    Reserved = new byte[]
                    {
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0
                    }
                },
                CompensatedAngle = 100m,
                FinalAngleDecimal = 9999m,
                StartFinalAngle = 10m,
                PostViewTorqueActivated = PostViewTorque.OnlyPVTHOn,
                PostViewTorqueHigh = 6521.43m,
                PostViewTorqueLow = 52.32m,
                CurrentMonitoringAmpere = 1m,
                CurrentMonitoringAmpereMin = 0.5m,
                CurrentMonitoringAmpereMax = 1.5m,
                AngleNumeratorScaleFactor = 1,
                AngleDenominatorScaleFactor = 1,
                OverallAngleStatus = TighteningValueStatus.Ok,
                OverallAngleMin = -20,
                OverallAngleMax = 100,
                OverallAngle = 120,
                PeakTorque = 32.91m,
                ResidualBreakawayTorque = 10.05m,
                StartRundownAngle = 1.1m,
                RundownAngleComplete = 90m
            });
        }

        [TestMethod]
        [TestCategory("Revision 11"), TestCategory("Pack")]
        public void Mid0061PackRevision11()
        {
            string package = "06770061011         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E124540015005500000000425600100005709999005800100059260652143610052326200100630005064001506500001660000167168-00206900100700012071003291720010057300011074009000750001207600001";

            AssertBuildAndParse(package, new Mid0061(11)
            {
                CellId = 0,
                ChannelId = 0,
                TorqueControllerName = "RA ST6.2 ETV100",
                VinNumber = "",
                JobId = 0,
                ParameterSetId = 1,
                BatchSize = 0,
                BatchCounter = 0,
                TighteningStatus = false,
                TorqueStatus = TighteningValueStatus.Low,
                AngleStatus = TighteningValueStatus.Low,
                TorqueMinLimit = 34m,
                TorqueMaxLimit = 46m,
                TorqueFinalTarget = 40m,
                Torque = 5.05m,
                AngleMinLimit = 20,
                AngleMaxLimit = 420,
                AngleFinalTarget = 0,
                Angle = 0,
                Timestamp = new DateTime(2020, 6, 25, 1, 4, 39),
                LastChangeInParameterSet = new DateTime(2020, 6, 24, 10, 48, 53),
                BatchStatus = BatchStatus.NotUsed,
                TighteningId = 184887L,
                Strategy = Strategy.TorqueControlAndAngleMonitoring,
                StrategyOptions = new StrategyOptions()
                {
                    Torque = true,
                    Angle = true,
                    Batch = false,
                    PvtMonitoring = false,
                    PvtCompensate = false,
                    Selftap = false,
                    Rundown = true,
                    CM = false,
                    DsControl = false,
                    ClickWrench = false,
                    RbwMonitoring = false
                },
                RundownAngleStatus = TighteningValueStatus.Low,
                CurrentMonitoringStatus = TighteningValueStatus.Ok,
                SelftapStatus = TighteningValueStatus.Ok,
                PrevailTorqueMonitoringStatus = TighteningValueStatus.Ok,
                PrevailTorqueCompensateStatus = TighteningValueStatus.Ok,
                TighteningErrorStatus = new TighteningErrorStatus()
                {
                    RundownAngleMaxShutOff = false,
                    RundownAngleMinShutOff = true,
                    TorqueMaxShutOff = false,
                    AngleMaxShutOff = false,
                    SelftapTorqueMaxShutOff = false,
                    SelftapTorqueMinShutOff = false,
                    PrevailTorqueMaxShutOff = false,
                    PrevailTorqueMinShutOff = false,
                    PrevailTorqueCompensateOverflow = false,
                    CurrentMonitoringMaxShutOff = false,
                    PostViewTorqueMinTorqueShutOff = false,
                    PostViewTorqueMaxTorqueShutOff = false,
                    PostViewTorqueAngleTooSmall = false,
                    TriggerLost = true,
                    TorqueLessThanTarget = false,
                    ToolHot = false,
                    MultistageAbort = false,
                    Rehit = false,
                    DsMeasureFailed = false,
                    CurrentLimitReached = false,
                    EndTimeOutShutOff = false,
                    RemoveFastenerLimitExceeded = false,
                    DisableDrive = false,
                    TransducerLost = false,
                    TransducerShorted = false,
                    TransducerCorrupt = false,
                    SyncTimeout = false,
                    DynamicCurrentMonitoringMin = false,
                    DynamicCurrentMonitoringMax = false,
                    AngleMaxMonitor = false,
                    YieldNutOff = false,
                    YieldTooFewSamples = false
                },
                RundownAngleMin = 100,
                RundownAngleMax = 850,
                RundownAngle = 4,
                CurrentMonitoringMin = 0,
                CurrentMonitoringMax = 150,
                CurrentMonitoringValue = 0,
                SelftapMin = 0m,
                SelftapMax = 9999m,
                SelftapTorque = 0m,
                PrevailTorqueMonitoringMin = 0m,
                PrevailTorqueMonitoringMax = 0m,
                PrevailTorque = 0m,
                JobSequenceNumber = 0,
                SyncTighteningId = 0,
                ToolSerialNumber = "      C0761275",
                ParameterSetName = "Test Parameter Set",
                TorqueValuesUnit = TorqueValuesUnit.LbfFt,
                ResultType = ResultType.BypassParameterSetResult,
                IdentifierResultPart2 = "Identifier result part 2",
                IdentifierResultPart3 = "Identifier result part 3",
                IdentifierResultPart4 = "Identifier result part 4",
                CustomerTighteningErrorCode = "E124",
                PrevailTorqueCompensateValue = 15m,
                TighteningErrorStatus2 = new TighteningErrorStatus2()
                {
                    DriveDeactivated = false,
                    ToolStall = true,
                    DriveHot = false,
                    GradientMonitoringHigh = true,
                    GradientMonitoringLow = false,
                    ReactionBarFailed = true,
                    SnugMax = false,
                    CycleAbort = false,
                    NeckingFailure = false,
                    EffectiveLoosening = false,
                    OverSpeed = false,
                    NoResidualTorque = false,
                    PositioningFail = false,
                    SnugMonLow = false,
                    SnugMonHigh = false,
                    DynamicMinCurrent = false,
                    DynamicMaxCurrent = false,
                    LatentResult = false,
                    Reserved = new byte[]
                    {
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0
                    }
                },
                CompensatedAngle = 100m,
                FinalAngleDecimal = 9999m,
                StartFinalAngle = 10m,
                PostViewTorqueActivated = PostViewTorque.OnlyPVTHOn,
                PostViewTorqueHigh = 6521.43m,
                PostViewTorqueLow = 52.32m,
                CurrentMonitoringAmpere = 1m,
                CurrentMonitoringAmpereMin = 0.5m,
                CurrentMonitoringAmpereMax = 1.5m,
                AngleNumeratorScaleFactor = 1,
                AngleDenominatorScaleFactor = 1,
                OverallAngleStatus = TighteningValueStatus.Ok,
                OverallAngleMin = -20,
                OverallAngleMax = 100,
                OverallAngle = 120,
                PeakTorque = 32.91m,
                ResidualBreakawayTorque = 10.05m,
                StartRundownAngle = 1.1m,
                RundownAngleComplete = 90m,
                ClickTorque = 1.2m,
                ClickAngle = 1
            });
        }

        [TestMethod]
        [TestCategory("Revision 998"), TestCategory("Pack")]
        public void Mid0061PackRevision998()
        {
            string package = "05580061998         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E1245400150055000000004256025702580200000010001200000080";

            AssertBuildAndParse(package, new Mid0061(998)
            {
                CellId = 0,
                ChannelId = 0,
                TorqueControllerName = "RA ST6.2 ETV100",
                VinNumber = "",
                JobId = 0,
                ParameterSetId = 1,
                BatchSize = 0,
                BatchCounter = 0,
                TighteningStatus = false,
                TorqueStatus = TighteningValueStatus.Low,
                AngleStatus = TighteningValueStatus.Low,
                TorqueMinLimit = 34m,
                TorqueMaxLimit = 46m,
                TorqueFinalTarget = 40m,
                Torque = 5.05m,
                AngleMinLimit = 20,
                AngleMaxLimit = 420,
                AngleFinalTarget = 0,
                Angle = 0,
                Timestamp = new DateTime(2020, 6, 25, 1, 4, 39),
                LastChangeInParameterSet = new DateTime(2020, 6, 24, 10, 48, 53),
                BatchStatus = BatchStatus.NotUsed,
                TighteningId = 184887L,
                Strategy = Strategy.TorqueControlAndAngleMonitoring,
                StrategyOptions = new StrategyOptions()
                {
                    Torque = true,
                    Angle = true,
                    Batch = false,
                    PvtMonitoring = false,
                    PvtCompensate = false,
                    Selftap = false,
                    Rundown = true,
                    CM = false,
                    DsControl = false,
                    ClickWrench = false,
                    RbwMonitoring = false
                },
                RundownAngleStatus = TighteningValueStatus.Low,
                CurrentMonitoringStatus = TighteningValueStatus.Ok,
                SelftapStatus = TighteningValueStatus.Ok,
                PrevailTorqueMonitoringStatus = TighteningValueStatus.Ok,
                PrevailTorqueCompensateStatus = TighteningValueStatus.Ok,
                TighteningErrorStatus = new TighteningErrorStatus()
                {
                    RundownAngleMaxShutOff = false,
                    RundownAngleMinShutOff = true,
                    TorqueMaxShutOff = false,
                    AngleMaxShutOff = false,
                    SelftapTorqueMaxShutOff = false,
                    SelftapTorqueMinShutOff = false,
                    PrevailTorqueMaxShutOff = false,
                    PrevailTorqueMinShutOff = false,
                    PrevailTorqueCompensateOverflow = false,
                    CurrentMonitoringMaxShutOff = false,
                    PostViewTorqueMinTorqueShutOff = false,
                    PostViewTorqueMaxTorqueShutOff = false,
                    PostViewTorqueAngleTooSmall = false,
                    TriggerLost = true,
                    TorqueLessThanTarget = false,
                    ToolHot = false,
                    MultistageAbort = false,
                    Rehit = false,
                    DsMeasureFailed = false,
                    CurrentLimitReached = false,
                    EndTimeOutShutOff = false,
                    RemoveFastenerLimitExceeded = false,
                    DisableDrive = false,
                    TransducerLost = false,
                    TransducerShorted = false,
                    TransducerCorrupt = false,
                    SyncTimeout = false,
                    DynamicCurrentMonitoringMin = false,
                    DynamicCurrentMonitoringMax = false,
                    AngleMaxMonitor = false,
                    YieldNutOff = false,
                    YieldTooFewSamples = false
                },
                RundownAngleMin = 100,
                RundownAngleMax = 850,
                RundownAngle = 4,
                CurrentMonitoringMin = 0,
                CurrentMonitoringMax = 150,
                CurrentMonitoringValue = 0,
                SelftapMin = 0m,
                SelftapMax = 9999m,
                SelftapTorque = 0m,
                PrevailTorqueMonitoringMin = 0m,
                PrevailTorqueMonitoringMax = 0m,
                PrevailTorque = 0m,
                JobSequenceNumber = 0,
                SyncTighteningId = 0,
                ToolSerialNumber = "      C0761275",
                ParameterSetName = "Test Parameter Set",
                TorqueValuesUnit = TorqueValuesUnit.LbfFt,
                ResultType = ResultType.BypassParameterSetResult,
                IdentifierResultPart2 = "Identifier result part 2",
                IdentifierResultPart3 = "Identifier result part 3",
                IdentifierResultPart4 = "Identifier result part 4",
                CustomerTighteningErrorCode = "E124",
                PrevailTorqueCompensateValue = 15m,
                TighteningErrorStatus2 = new TighteningErrorStatus2()
                {
                    DriveDeactivated = false,
                    ToolStall = true,
                    DriveHot = false,
                    GradientMonitoringHigh = true,
                    GradientMonitoringLow = false,
                    ReactionBarFailed = true,
                    SnugMax = false,
                    CycleAbort = false,
                    NeckingFailure = false,
                    EffectiveLoosening = false,
                    OverSpeed = false,
                    NoResidualTorque = false,
                    PositioningFail = false,
                    SnugMonLow = false,
                    SnugMonHigh = false,
                    DynamicMinCurrent = false,
                    DynamicMaxCurrent = false,
                    LatentResult = false,
                    Reserved = new byte[]
                    {
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0,
                        0
                    }
                },
                CompensatedAngle = 0m,
                FinalAngleDecimal = 0m,
                StartFinalAngle = 0m,
                PostViewTorqueActivated = PostViewTorque.Off,
                PostViewTorqueHigh = 0m,
                PostViewTorqueLow = 0m,
                CurrentMonitoringAmpere = 0m,
                CurrentMonitoringAmpereMin = 0m,
                CurrentMonitoringAmpereMax = 0m,
                AngleNumeratorScaleFactor = 0,
                AngleDenominatorScaleFactor = 0,
                OverallAngleStatus = TighteningValueStatus.Low,
                OverallAngleMin = 0,
                OverallAngleMax = 0,
                OverallAngle = 0,
                PeakTorque = 0m,
                ResidualBreakawayTorque = 0m,
                StartRundownAngle = 0m,
                RundownAngleComplete = 0m,
                ClickTorque = 0m,
                ClickAngle = 0,
                SelectedIdentifierNumber = 0,
                NumberOfStagesInMultistage = 2,
                NumberOfStageResults = 2,
                StageResults = new List<StageResult>()
                {
                    new StageResult()
                    {
                        Torque = 200m,
                        Angle = 100
                    },
                    new StageResult()
                    {
                        Torque = 120m,
                        Angle = 80
                    }
                }
            });
        }

        [TestMethod]
        [TestCategory("Revision 999"), TestCategory("Pack")]
        public void Mid0061PackRevision999()
        {
            string package = "01210061999         KPOL3456JKLO897          02001002000192111000500003602001-06-02:09:54:092000-06-02:09:54:094294967295";

            AssertBuildAndParse(package, new Mid0061(999)
            {
                CellId = 0,
                ChannelId = 0,
                VinNumber = "KPOL3456JKLO897",
                JobId = 2,
                ParameterSetId = 1,
                BatchSize = 20,
                BatchCounter = 19,
                TighteningStatus = true,
                TorqueStatus = TighteningValueStatus.Ok,
                AngleStatus = TighteningValueStatus.Ok,
                TorqueMinLimit = 0m,
                TorqueMaxLimit = 0m,
                TorqueFinalTarget = 0m,
                Torque = 5m,
                AngleMinLimit = 0,
                AngleMaxLimit = 0,
                AngleFinalTarget = 0,
                Angle = 360,
                Timestamp = new DateTime(2001, 6, 2, 9, 54, 9),
                LastChangeInParameterSet = new DateTime(2000, 6, 2, 9, 54, 9),
                BatchStatus = BatchStatus.NotUsed,
                TighteningId = 4294967295L,
                Strategy = (Strategy)0,
                RundownAngleStatus = TighteningValueStatus.Low,
                CurrentMonitoringStatus = TighteningValueStatus.Low,
                SelftapStatus = TighteningValueStatus.Low,
                PrevailTorqueMonitoringStatus = TighteningValueStatus.Low,
                PrevailTorqueCompensateStatus = TighteningValueStatus.Low,
                RundownAngleMin = 0,
                RundownAngleMax = 0,
                RundownAngle = 0,
                CurrentMonitoringMin = 0,
                CurrentMonitoringMax = 0,
                CurrentMonitoringValue = 0,
                SelftapMin = 0m,
                SelftapMax = 0m,
                SelftapTorque = 0m,
                PrevailTorqueMonitoringMin = 0m,
                PrevailTorqueMonitoringMax = 0m,
                PrevailTorque = 0m,
                JobSequenceNumber = 0,
                SyncTighteningId = 0,
                TorqueValuesUnit = (TorqueValuesUnit)0,
                ResultType = (ResultType)0,
                PrevailTorqueCompensateValue = 0m,
                CompensatedAngle = 0m,
                FinalAngleDecimal = 0m,
                StartFinalAngle = 0m,
                PostViewTorqueActivated = PostViewTorque.Off,
                PostViewTorqueHigh = 0m,
                PostViewTorqueLow = 0m,
                CurrentMonitoringAmpere = 0m,
                CurrentMonitoringAmpereMin = 0m,
                CurrentMonitoringAmpereMax = 0m,
                AngleNumeratorScaleFactor = 0,
                AngleDenominatorScaleFactor = 0,
                OverallAngleStatus = TighteningValueStatus.Low,
                OverallAngleMin = 0,
                OverallAngleMax = 0,
                OverallAngle = 0,
                PeakTorque = 0m,
                ResidualBreakawayTorque = 0m,
                StartRundownAngle = 0m,
                RundownAngleComplete = 0m,
                ClickTorque = 0m,
                ClickAngle = 0,
                SelectedIdentifierNumber = 0,
                NumberOfStagesInMultistage = 0,
                NumberOfStageResults = 0
            });
        }
    }
}
