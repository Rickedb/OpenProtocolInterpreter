using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tightening;
using System.Collections.Generic;
using System.Linq;

namespace MIDTesters.Tightening
{
    [TestClass]
    public class TestMid0061 : MidTester
    {
        [TestMethod]
        public void Mid0061Revision1()
        {
            string pack = "02310061001         010001020103airbag7                  04KPOL3456JKLO897          050006003070000080000090100111120008401300140014001200150007391600000170999918000001900000202001-06-02:09:54:09212001-05-29:12:34:33221230000345675";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.TorqueControllerName);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.TorqueMinLimit);
            Assert.IsNotNull(mid.TorqueMaxLimit);
            Assert.IsNotNull(mid.TorqueFinalTarget);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.AngleMinLimit);
            Assert.IsNotNull(mid.AngleMaxLimit);
            Assert.IsNotNull(mid.AngleFinalTarget);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsNotNull(mid.BatchStatus);
            Assert.IsNotNull(mid.TighteningId);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0061ByteRevision1()
        {
            string package = "02310061001         010001020103airbag7                  04KPOL3456JKLO897          050006003070000080000090100111120008401300140014001200150007391600000170999918000001900000202001-06-02:09:54:09212001-05-29:12:34:33221230000345675";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0061>(bytes);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.TorqueControllerName);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.TorqueMinLimit);
            Assert.IsNotNull(mid.TorqueMaxLimit);
            Assert.IsNotNull(mid.TorqueFinalTarget);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.AngleMinLimit);
            Assert.IsNotNull(mid.AngleMaxLimit);
            Assert.IsNotNull(mid.AngleFinalTarget);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsNotNull(mid.BatchStatus);
            Assert.IsNotNull(mid.TighteningId);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0061Revision2()
        {
            var pack = "03850061002         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:53";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.TorqueControllerName);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.BatchStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.RundownAngleStatus);
            Assert.IsNotNull(mid.CurrentMonitoringStatus);
            Assert.IsNotNull(mid.SelftapStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.TorqueMinLimit);
            Assert.IsNotNull(mid.TorqueMaxLimit);
            Assert.IsNotNull(mid.TorqueFinalTarget);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.AngleMinLimit);
            Assert.IsNotNull(mid.AngleMaxLimit);
            Assert.IsNotNull(mid.AngleFinalTarget);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringMin);
            Assert.IsNotNull(mid.CurrentMonitoringMax);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapMin);
            Assert.IsNotNull(mid.SelftapMax);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMin);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMax);
            Assert.IsNotNull(mid.PrevailTorque);
            Assert.IsNotNull(mid.TighteningId);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
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
            bytes.AddRange(strategyOptions);
            string untilTighteningErrorStatus = "09000010000011012013114015216117018219120";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(tighteningErrorStatus);
            string untilEnd = "2100084022001400230012002400073925000002609999270000028000002900000300999931050003200033050340453500001036000125370005483800001039999900405555004142949672954265500436053544ABCDEFG-123456452001-06-02:09:54:09462001-05-29:12:34:33";

            bytes.AddRange(GetAsciiBytes(untilEnd));
            var mid = _midInterpreter.Parse<Mid0061>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.TorqueControllerName);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.BatchStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.RundownAngleStatus);
            Assert.IsNotNull(mid.CurrentMonitoringStatus);
            Assert.IsNotNull(mid.SelftapStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.TorqueMinLimit);
            Assert.IsNotNull(mid.TorqueMaxLimit);
            Assert.IsNotNull(mid.TorqueFinalTarget);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.AngleMinLimit);
            Assert.IsNotNull(mid.AngleMaxLimit);
            Assert.IsNotNull(mid.AngleFinalTarget);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringMin);
            Assert.IsNotNull(mid.CurrentMonitoringMax);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapMin);
            Assert.IsNotNull(mid.SelftapMax);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMin);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMax);
            Assert.IsNotNull(mid.PrevailTorque);
            Assert.IsNotNull(mid.TighteningId);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0061Revision3()
        {
            var pack = "04190061003         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       4824905";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.TorqueControllerName);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.BatchStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.RundownAngleStatus);
            Assert.IsNotNull(mid.CurrentMonitoringStatus);
            Assert.IsNotNull(mid.SelftapStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.TorqueMinLimit);
            Assert.IsNotNull(mid.TorqueMaxLimit);
            Assert.IsNotNull(mid.TorqueFinalTarget);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.AngleMinLimit);
            Assert.IsNotNull(mid.AngleMaxLimit);
            Assert.IsNotNull(mid.AngleFinalTarget);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringMin);
            Assert.IsNotNull(mid.CurrentMonitoringMax);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapMin);
            Assert.IsNotNull(mid.SelftapMax);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMin);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMax);
            Assert.IsNotNull(mid.PrevailTorque);
            Assert.IsNotNull(mid.TighteningId);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsNotNull(mid.ParameterSetName);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
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
            bytes.AddRange(strategyOptions);
            string untilTighteningErrorStatus = "09000010000011012013114015216117018219120";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(tighteningErrorStatus);
            string untilEnd = "2100084022001400230012002400073925000002609999270000028000002900000300999931050003200033050340453500001036000125370005483800001039999900405555004142949672954265500436053544ABCDEFG-123456452001-06-02:09:54:09462001-05-29:12:34:3347Test Parameter Set       4824905";

            bytes.AddRange(GetAsciiBytes(untilEnd));
            var mid = _midInterpreter.Parse<Mid0061>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.TorqueControllerName);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.BatchStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.RundownAngleStatus);
            Assert.IsNotNull(mid.CurrentMonitoringStatus);
            Assert.IsNotNull(mid.SelftapStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.TorqueMinLimit);
            Assert.IsNotNull(mid.TorqueMaxLimit);
            Assert.IsNotNull(mid.TorqueFinalTarget);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.AngleMinLimit);
            Assert.IsNotNull(mid.AngleMaxLimit);
            Assert.IsNotNull(mid.AngleFinalTarget);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringMin);
            Assert.IsNotNull(mid.CurrentMonitoringMax);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapMin);
            Assert.IsNotNull(mid.SelftapMax);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMin);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMax);
            Assert.IsNotNull(mid.PrevailTorque);
            Assert.IsNotNull(mid.TighteningId);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsNotNull(mid.ParameterSetName);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0061Revision4()
        {
            var pack = "05000061004         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 ";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.TorqueControllerName);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.BatchStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.RundownAngleStatus);
            Assert.IsNotNull(mid.CurrentMonitoringStatus);
            Assert.IsNotNull(mid.SelftapStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.TorqueMinLimit);
            Assert.IsNotNull(mid.TorqueMaxLimit);
            Assert.IsNotNull(mid.TorqueFinalTarget);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.AngleMinLimit);
            Assert.IsNotNull(mid.AngleMaxLimit);
            Assert.IsNotNull(mid.AngleFinalTarget);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringMin);
            Assert.IsNotNull(mid.CurrentMonitoringMax);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapMin);
            Assert.IsNotNull(mid.SelftapMax);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMin);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMax);
            Assert.IsNotNull(mid.PrevailTorque);
            Assert.IsNotNull(mid.TighteningId);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsNotNull(mid.ParameterSetName);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
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
            bytes.AddRange(strategyOptions);
            string untilTighteningErrorStatus = "09000010000011012013114015216117018219120";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(tighteningErrorStatus);
            string untilEnd = "2100084022001400230012002400073925000002609999270000028000002900000300999931050003200033050340453500001036000125370005483800001039999900405555004142949672954265500436053544ABCDEFG-123456452001-06-02:09:54:09462001-05-29:12:34:3347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 ";

            bytes.AddRange(GetAsciiBytes(untilEnd));
            var mid = _midInterpreter.Parse<Mid0061>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.TorqueControllerName);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.BatchStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.RundownAngleStatus);
            Assert.IsNotNull(mid.CurrentMonitoringStatus);
            Assert.IsNotNull(mid.SelftapStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.TorqueMinLimit);
            Assert.IsNotNull(mid.TorqueMaxLimit);
            Assert.IsNotNull(mid.TorqueFinalTarget);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.AngleMinLimit);
            Assert.IsNotNull(mid.AngleMaxLimit);
            Assert.IsNotNull(mid.AngleFinalTarget);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringMin);
            Assert.IsNotNull(mid.CurrentMonitoringMax);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapMin);
            Assert.IsNotNull(mid.SelftapMax);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMin);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMax);
            Assert.IsNotNull(mid.PrevailTorque);
            Assert.IsNotNull(mid.TighteningId);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsNotNull(mid.ParameterSetName);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0061Revision5()
        {
            var pack = "05060061005         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E124";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.TorqueControllerName);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.BatchStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.RundownAngleStatus);
            Assert.IsNotNull(mid.CurrentMonitoringStatus);
            Assert.IsNotNull(mid.SelftapStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.TorqueMinLimit);
            Assert.IsNotNull(mid.TorqueMaxLimit);
            Assert.IsNotNull(mid.TorqueFinalTarget);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.AngleMinLimit);
            Assert.IsNotNull(mid.AngleMaxLimit);
            Assert.IsNotNull(mid.AngleFinalTarget);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringMin);
            Assert.IsNotNull(mid.CurrentMonitoringMax);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapMin);
            Assert.IsNotNull(mid.SelftapMax);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMin);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMax);
            Assert.IsNotNull(mid.PrevailTorque);
            Assert.IsNotNull(mid.TighteningId);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsNotNull(mid.ParameterSetName);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsNotNull(mid.CustomerTighteningErrorCode);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
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
            bytes.AddRange(strategyOptions);
            string untilTighteningErrorStatus = "09000010000011012013114015216117018219120";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(tighteningErrorStatus);
            string untilEnd = "2100084022001400230012002400073925000002609999270000028000002900000300999931050003200033050340453500001036000125370005483800001039999900405555004142949672954265500436053544ABCDEFG-123456452001-06-02:09:54:09462001-05-29:12:34:3347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E124";

            bytes.AddRange(GetAsciiBytes(untilEnd));
            var mid = _midInterpreter.Parse<Mid0061>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.TorqueControllerName);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.BatchStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.RundownAngleStatus);
            Assert.IsNotNull(mid.CurrentMonitoringStatus);
            Assert.IsNotNull(mid.SelftapStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.TorqueMinLimit);
            Assert.IsNotNull(mid.TorqueMaxLimit);
            Assert.IsNotNull(mid.TorqueFinalTarget);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.AngleMinLimit);
            Assert.IsNotNull(mid.AngleMaxLimit);
            Assert.IsNotNull(mid.AngleFinalTarget);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringMin);
            Assert.IsNotNull(mid.CurrentMonitoringMax);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapMin);
            Assert.IsNotNull(mid.SelftapMax);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMin);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMax);
            Assert.IsNotNull(mid.PrevailTorque);
            Assert.IsNotNull(mid.TighteningId);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsNotNull(mid.ParameterSetName);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsNotNull(mid.CustomerTighteningErrorCode);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0061Revision6()
        {
            var pack = "05260061006         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E12454001500550000000042";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.TorqueControllerName);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.BatchStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.RundownAngleStatus);
            Assert.IsNotNull(mid.CurrentMonitoringStatus);
            Assert.IsNotNull(mid.SelftapStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.TorqueMinLimit);
            Assert.IsNotNull(mid.TorqueMaxLimit);
            Assert.IsNotNull(mid.TorqueFinalTarget);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.AngleMinLimit);
            Assert.IsNotNull(mid.AngleMaxLimit);
            Assert.IsNotNull(mid.AngleFinalTarget);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringMin);
            Assert.IsNotNull(mid.CurrentMonitoringMax);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapMin);
            Assert.IsNotNull(mid.SelftapMax);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMin);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMax);
            Assert.IsNotNull(mid.PrevailTorque);
            Assert.IsNotNull(mid.TighteningId);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsNotNull(mid.ParameterSetName);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsNotNull(mid.CustomerTighteningErrorCode);
            Assert.IsNotNull(mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
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
            bytes.AddRange(strategyOptions);

            string untilTighteningErrorStatus = "09000010000011012013114015216117018219120";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(tighteningErrorStatus);

            string untilTighteningErrorStatus2 = "2100084022001400230012002400073925000002609999270000028000002900000300999931050003200033050340453500001036000125370005483800001039999900405555004142949672954265500436053544ABCDEFG-123456452001-06-02:09:54:09462001-05-29:12:34:3347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E1245400150055";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus2));
            bytes.AddRange(tighteningErrorStatus2);

            var mid = _midInterpreter.Parse<Mid0061>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.TorqueControllerName);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.BatchStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.RundownAngleStatus);
            Assert.IsNotNull(mid.CurrentMonitoringStatus);
            Assert.IsNotNull(mid.SelftapStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.TorqueMinLimit);
            Assert.IsNotNull(mid.TorqueMaxLimit);
            Assert.IsNotNull(mid.TorqueFinalTarget);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.AngleMinLimit);
            Assert.IsNotNull(mid.AngleMaxLimit);
            Assert.IsNotNull(mid.AngleFinalTarget);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringMin);
            Assert.IsNotNull(mid.CurrentMonitoringMax);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapMin);
            Assert.IsNotNull(mid.SelftapMax);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMin);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMax);
            Assert.IsNotNull(mid.PrevailTorque);
            Assert.IsNotNull(mid.TighteningId);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsNotNull(mid.ParameterSetName);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsNotNull(mid.CustomerTighteningErrorCode);
            Assert.IsNotNull(mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0061Revision7()
        {
            var pack = "05440061007         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E12454001500550000000042560010000570999900";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.TorqueControllerName);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.BatchStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.RundownAngleStatus);
            Assert.IsNotNull(mid.CurrentMonitoringStatus);
            Assert.IsNotNull(mid.SelftapStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.TorqueMinLimit);
            Assert.IsNotNull(mid.TorqueMaxLimit);
            Assert.IsNotNull(mid.TorqueFinalTarget);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.AngleMinLimit);
            Assert.IsNotNull(mid.AngleMaxLimit);
            Assert.IsNotNull(mid.AngleFinalTarget);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringMin);
            Assert.IsNotNull(mid.CurrentMonitoringMax);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapMin);
            Assert.IsNotNull(mid.SelftapMax);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMin);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMax);
            Assert.IsNotNull(mid.PrevailTorque);
            Assert.IsNotNull(mid.TighteningId);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsNotNull(mid.ParameterSetName);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsNotNull(mid.CustomerTighteningErrorCode);
            Assert.IsNotNull(mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.IsNotNull(mid.CompensatedAngle);
            Assert.IsNotNull(mid.FinalAngleDecimal);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
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
            bytes.AddRange(strategyOptions);

            string untilTighteningErrorStatus = "09000010000011012013114015216117018219120";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(tighteningErrorStatus);

            string untilTighteningErrorStatus2 = "2100084022001400230012002400073925000002609999270000028000002900000300999931050003200033050340453500001036000125370005483800001039999900405555004142949672954265500436053544ABCDEFG-123456452001-06-02:09:54:09462001-05-29:12:34:3347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E1245400150055";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus2));
            bytes.AddRange(tighteningErrorStatus2);

            string untilEnd = "560010000570999900";
            bytes.AddRange(GetAsciiBytes(untilEnd));

            var mid = _midInterpreter.Parse<Mid0061>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.TorqueControllerName);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.BatchStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.RundownAngleStatus);
            Assert.IsNotNull(mid.CurrentMonitoringStatus);
            Assert.IsNotNull(mid.SelftapStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.TorqueMinLimit);
            Assert.IsNotNull(mid.TorqueMaxLimit);
            Assert.IsNotNull(mid.TorqueFinalTarget);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.AngleMinLimit);
            Assert.IsNotNull(mid.AngleMaxLimit);
            Assert.IsNotNull(mid.AngleFinalTarget);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringMin);
            Assert.IsNotNull(mid.CurrentMonitoringMax);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapMin);
            Assert.IsNotNull(mid.SelftapMax);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMin);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMax);
            Assert.IsNotNull(mid.PrevailTorque);
            Assert.IsNotNull(mid.TighteningId);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsNotNull(mid.ParameterSetName);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsNotNull(mid.CustomerTighteningErrorCode);
            Assert.IsNotNull(mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.IsNotNull(mid.CompensatedAngle);
            Assert.IsNotNull(mid.FinalAngleDecimal);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0061Revision998()
        {
            var pack = "05580061998         010000020003RA ST6.2 ETV100          04                         05000006001070208000670900001000001101221301401501611711811912000000081942100340022004600230040002400050525000202600420270000028000002900100300085031000043200033150340003500000036999900370000003800000039000000400000004100001848874200000430000044      C0761275452020-06-25:01:04:39462020-06-24:10:48:5347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E1245400150055000000004256025702580200000010001200000080";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.TorqueControllerName);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.BatchStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.RundownAngleStatus);
            Assert.IsNotNull(mid.CurrentMonitoringStatus);
            Assert.IsNotNull(mid.SelftapStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.TorqueMinLimit);
            Assert.IsNotNull(mid.TorqueMaxLimit);
            Assert.IsNotNull(mid.TorqueFinalTarget);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.AngleMinLimit);
            Assert.IsNotNull(mid.AngleMaxLimit);
            Assert.IsNotNull(mid.AngleFinalTarget);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringMin);
            Assert.IsNotNull(mid.CurrentMonitoringMax);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapMin);
            Assert.IsNotNull(mid.SelftapMax);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMin);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMax);
            Assert.IsNotNull(mid.PrevailTorque);
            Assert.IsNotNull(mid.TighteningId);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsNotNull(mid.ParameterSetName);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsNotNull(mid.CustomerTighteningErrorCode);
            Assert.IsNotNull(mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.IsNotNull(mid.NumberOfStagesInMultistage);
            Assert.IsNotNull(mid.NumberOfStageResults);
            Assert.IsNotNull(mid.StageResults);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
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
            bytes.AddRange(strategyOptions);

            string untilTighteningErrorStatus = "09000010000011012013114015216117018219120";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(tighteningErrorStatus);

            string untilTighteningErrorStatus2 = "2100084022001400230012002400073925000002609999270000028000002900000300999931050003200033050340453500001036000125370005483800001039999900405555004142949672954265500436053544ABCDEFG-123456452001-06-02:09:54:09462001-05-29:12:34:3347Test Parameter Set       482490550Identifier result part 2 51Identifier result part 3 52Identifier result part 4 53E1245400150055";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus2));
            bytes.AddRange(tighteningErrorStatus2);

            string untilEnd = "56025702580200000010001200000080";
            bytes.AddRange(GetAsciiBytes(untilEnd));

            var mid = _midInterpreter.Parse<Mid0061>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.IsNotNull(mid.CellId);
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.TorqueControllerName);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.BatchStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.RundownAngleStatus);
            Assert.IsNotNull(mid.CurrentMonitoringStatus);
            Assert.IsNotNull(mid.SelftapStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.TorqueMinLimit);
            Assert.IsNotNull(mid.TorqueMaxLimit);
            Assert.IsNotNull(mid.TorqueFinalTarget);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.AngleMinLimit);
            Assert.IsNotNull(mid.AngleMaxLimit);
            Assert.IsNotNull(mid.AngleFinalTarget);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringMin);
            Assert.IsNotNull(mid.CurrentMonitoringMax);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapMin);
            Assert.IsNotNull(mid.SelftapMax);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMin);
            Assert.IsNotNull(mid.PrevailTorqueMonitoringMax);
            Assert.IsNotNull(mid.PrevailTorque);
            Assert.IsNotNull(mid.TighteningId);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsNotNull(mid.ParameterSetName);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsNotNull(mid.CustomerTighteningErrorCode);
            Assert.IsNotNull(mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.IsNotNull(mid.NumberOfStagesInMultistage);
            Assert.IsNotNull(mid.NumberOfStageResults);
            Assert.IsNotNull(mid.StageResults);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0061Revision999()
        {
            string pack = "01210061999         KPOL3456JKLO897          02001002000192111000500003602001-06-02:09:54:092000-06-02:09:54:094294967295";
            var mid = _midInterpreter.Parse<Mid0061>(pack);

            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.BatchStatus);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsNotNull(mid.TighteningId);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0061ByteRevision999()
        {
            string package = "01210061999         KPOL3456JKLO897          02001002000192111000500003602001-06-02:09:54:092000-06-02:09:54:094294967295";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0061>(bytes);


            Assert.AreEqual(typeof(Mid0061), mid.GetType());
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.BatchStatus);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsNotNull(mid.TighteningId);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
