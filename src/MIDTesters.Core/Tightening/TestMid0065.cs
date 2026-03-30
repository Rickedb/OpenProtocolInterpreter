using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using System;
using OpenProtocolInterpreter.Tightening;
using System.Collections.Generic;

namespace MIDTesters.Tightening
{
    [TestClass]
    [TestCategory("Tightening")]
    public class TestMid0065 : DefaultMidTests<Mid0065>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0065Revision1()
        {
            string package = @"01180065001         01012345678902AIRBAG                   03001040002050060070080014670900046102001-04-22:14:54:34112";
            var mid = _midInterpreter.Parse<Mid0065>(package);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual(2, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(14.67m, mid.Torque);
            Assert.AreEqual(46, mid.Angle);
            Assert.AreEqual(new DateTime(2001,4,22,14,54,34), mid.Timestamp);
            Assert.AreEqual(BatchStatus.NotUsed, mid.BatchStatus);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0065ByteRevision1()
        {
            string package = @"01180065001         01012345678902AIRBAG                   03001040002050060070080014670900046102001-04-22:14:54:34112";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0065>(bytes);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual(2, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(14.67m, mid.Torque);
            Assert.AreEqual(46, mid.Angle);
            Assert.AreEqual(new DateTime(2001,4,22,14,54,34), mid.Timestamp);
            Assert.AreEqual(BatchStatus.NotUsed, mid.BatchStatus);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0065Revision2()
        {
            string package = @"02260065002         01012345678902AIRBAG                   030001040020510060093807000008000009010011112013214115016217118000004189819001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05";
            var mid = _midInterpreter.Parse<Mid0065>(package);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0065ByteRevision2()
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

            string untilStrategy = @"02260065002         01012345678902AIRBAG                   03000104002051006";
            bytes.AddRange(GetAsciiBytes(untilStrategy));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));

            string untilTighteningErrorStatus = "07000008000009010011112013214115016217118";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));

            string untilEnd = "19001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05";
            bytes.AddRange(GetAsciiBytes(untilEnd));
            var mid = _midInterpreter.Parse<Mid0065>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ASCII")]
        public void Mid0065Revision3()
        {
            string package = @"02330065003         01012345678902AIRBAG                   030001040020510060093807000008000009010011112013214115016217118000004189819001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:052973008";
            var mid = _midInterpreter.Parse<Mid0065>(package);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            Assert.AreEqual(TorqueValuesUnit.Percentage, mid.TorqueValuesUnit);
            Assert.AreEqual((ResultType)8, mid.ResultType);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ByteArray")]
        public void Mid0065ByteRevision3()
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

            string untilStrategy = @"02330065003         01012345678902AIRBAG                   03000104002051006";
            bytes.AddRange(GetAsciiBytes(untilStrategy));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));

            string untilTighteningErrorStatus = "07000008000009010011112013214115016217118";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));

            string untilEnd = "19001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:052973008";
            bytes.AddRange(GetAsciiBytes(untilEnd));
            var mid = _midInterpreter.Parse<Mid0065>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            Assert.AreEqual(TorqueValuesUnit.Percentage, mid.TorqueValuesUnit);
            Assert.AreEqual((ResultType)8, mid.ResultType);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ASCII")]
        public void Mid0065Revision4()
        {
            string package = @"03140065004         01012345678902AIRBAG                   030001040020510060093807000008000009010011112013214115016217118000004189819001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 ";
            var mid = _midInterpreter.Parse<Mid0065>(package);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            Assert.AreEqual(TorqueValuesUnit.Percentage, mid.TorqueValuesUnit);
            Assert.AreEqual((ResultType)8, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ByteArray")]
        public void Mid0065ByteRevision4()
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

            string untilStrategy = @"03140065004         01012345678902AIRBAG                   03000104002051006";
            bytes.AddRange(GetAsciiBytes(untilStrategy));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));

            string untilTighteningErrorStatus = "07000008000009010011112013214115016217118";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));

            string untilEnd = "19001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 ";
            bytes.AddRange(GetAsciiBytes(untilEnd));
            var mid = _midInterpreter.Parse<Mid0065>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            Assert.AreEqual(TorqueValuesUnit.Percentage, mid.TorqueValuesUnit);
            Assert.AreEqual((ResultType)8, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("ASCII")]
        public void Mid0065Revision5()
        {
            string package = @"03200065005         01012345678902AIRBAG                   030001040020510060093807000008000009010011112013214115016217118000004189819001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 34E124";
            var mid = _midInterpreter.Parse<Mid0065>(package);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            Assert.AreEqual(TorqueValuesUnit.Percentage, mid.TorqueValuesUnit);
            Assert.AreEqual((ResultType)8, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("ByteArray")]
        public void Mid0065ByteRevision5()
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

            string untilStrategy = @"03200065005         01012345678902AIRBAG                   03000104002051006";
            bytes.AddRange(GetAsciiBytes(untilStrategy));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));

            string untilTighteningErrorStatus = "07000008000009010011112013214115016217118";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));

            string untilEnd = "19001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 34E124";
            bytes.AddRange(GetAsciiBytes(untilEnd));
            var mid = _midInterpreter.Parse<Mid0065>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            Assert.AreEqual(TorqueValuesUnit.Percentage, mid.TorqueValuesUnit);
            Assert.AreEqual((ResultType)8, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 6"), TestCategory("ASCII")]
        public void Mid0065Revision6()
        {
            string package = @"03400065006         01012345678902AIRBAG                   030001040020510060093807000008000009010011112013214115016217118000004189819001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 34E12435005100360000000042";
            var mid = _midInterpreter.Parse<Mid0065>(package);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            Assert.AreEqual(TorqueValuesUnit.Percentage, mid.TorqueValuesUnit);
            Assert.AreEqual((ResultType)8, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(51m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 6"), TestCategory("ByteArray")]
        public void Mid0065ByteRevision6()
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
                0x2A, //0010 1010
                0x00, //Reserved from bit 7 to rest
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
           };

            string untilStrategy = @"03400065006         01012345678902AIRBAG                   03000104002051006";
            bytes.AddRange(GetAsciiBytes(untilStrategy));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));

            string untilTighteningErrorStatus = "07000008000009010011112013214115016217118";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));

            string untilTighteningErrorStatus2 = "19001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 34E1243500510036";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus2));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus2, 10));
            var mid = _midInterpreter.Parse<Mid0065>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            Assert.AreEqual(TorqueValuesUnit.Percentage, mid.TorqueValuesUnit);
            Assert.AreEqual((ResultType)8, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(51m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 7"), TestCategory("ASCII")]
        public void Mid0065Revision7()
        {
            string package = @"03790065007         01012345678902AIRBAG                   030001040020510060093807000008000009010011112013214115016217118000004189819001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 34E1243500510036000000004237429496729538Station Name             ";
            var mid = _midInterpreter.Parse<Mid0065>(package);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            Assert.AreEqual(TorqueValuesUnit.Percentage, mid.TorqueValuesUnit);
            Assert.AreEqual((ResultType)8, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(51m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(4294967295, mid.StationId);
            Assert.AreEqual("Station Name             ", mid.StationName);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 7"), TestCategory("ByteArray")]
        public void Mid0065ByteRevision7()
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
                0x2A, //0010 1010
                0x00, //Reserved from bit 7 to rest
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
           };

            string untilStrategy = @"03790065007         01012345678902AIRBAG                   03000104002051006";
            bytes.AddRange(GetAsciiBytes(untilStrategy));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));

            string untilTighteningErrorStatus = "07000008000009010011112013214115016217118";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));

            string untilTighteningErrorStatus2 = "19001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 34E1243500510036";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus2));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus2, 10));
            
            string untilEnd = "37429496729538Station Name             ";
            bytes.AddRange(GetAsciiBytes(untilEnd));
            var mid = _midInterpreter.Parse<Mid0065>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            Assert.AreEqual(TorqueValuesUnit.Percentage, mid.TorqueValuesUnit);
            Assert.AreEqual((ResultType)8, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(51m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(4294967295, mid.StationId);
            Assert.AreEqual("Station Name             ", mid.StationName);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 8"), TestCategory("ASCII")]
        public void Mid0065Revision8()
        {
            string package = @"04060065008         01012345678902AIRBAG                   030001040020510060093807000008000009010011112013214115016217118000004189819001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 34E1243500510036000000004237429496729538Station Name             390010004024165214342005232";
            var mid = _midInterpreter.Parse<Mid0065>(package);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            Assert.AreEqual(TorqueValuesUnit.Percentage, mid.TorqueValuesUnit);
            Assert.AreEqual((ResultType)8, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(51m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(4294967295, mid.StationId);
            Assert.AreEqual("Station Name             ", mid.StationName);
            Assert.AreEqual(10m, mid.StartFinalAngle);
            Assert.AreEqual(PostViewTorque.OnlyPVTHOn, mid.PostViewTorqueActivated);
            Assert.AreEqual(6521.43m, mid.PostViewTorqueHigh);
            Assert.AreEqual(52.32m, mid.PostViewTorqueLow);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 8"), TestCategory("ByteArray")]
        public void Mid0065ByteRevision8()
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
                0x2A, //0010 1010
                0x00, //Reserved from bit 7 to rest
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
           };

            string untilStrategy = @"04060065008         01012345678902AIRBAG                   03000104002051006";
            bytes.AddRange(GetAsciiBytes(untilStrategy));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));

            string untilTighteningErrorStatus = "07000008000009010011112013214115016217118";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));

            string untilTighteningErrorStatus2 = "19001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 34E1243500510036";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus2));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus2, 10));

            string untilEnd = "37429496729538Station Name             390010004024165214342005232";
            bytes.AddRange(GetAsciiBytes(untilEnd));
            var mid = _midInterpreter.Parse<Mid0065>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            Assert.AreEqual(TorqueValuesUnit.Percentage, mid.TorqueValuesUnit);
            Assert.AreEqual((ResultType)8, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(51m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(4294967295, mid.StationId);
            Assert.AreEqual("Station Name             ", mid.StationName);
            Assert.AreEqual(10m, mid.StartFinalAngle);
            Assert.AreEqual(PostViewTorque.OnlyPVTHOn, mid.PostViewTorqueActivated);
            Assert.AreEqual(6521.43m, mid.PostViewTorqueHigh);
            Assert.AreEqual(52.32m, mid.PostViewTorqueLow);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 9"), TestCategory("ASCII")]
        public void Mid0065Revision9()
        {
            string package = @"04270065009         01012345678902AIRBAG                   030001040020510060093807000008000009010011112013214115016217118000004189819001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 34E1243500510036000000004237429496729538Station Name             390010004024165214342005232430010044000504500150";
            var mid = _midInterpreter.Parse<Mid0065>(package);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            Assert.AreEqual(TorqueValuesUnit.Percentage, mid.TorqueValuesUnit);
            Assert.AreEqual((ResultType)8, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(51m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(4294967295, mid.StationId);
            Assert.AreEqual("Station Name             ", mid.StationName);
            Assert.AreEqual(10m, mid.StartFinalAngle);
            Assert.AreEqual(PostViewTorque.OnlyPVTHOn, mid.PostViewTorqueActivated);
            Assert.AreEqual(6521.43m, mid.PostViewTorqueHigh);
            Assert.AreEqual(52.32m, mid.PostViewTorqueLow);
            Assert.AreEqual(1m, mid.CurrentMonitoringAmpere);
            Assert.AreEqual(0.5m, mid.CurrentMonitoringAmpereMin);
            Assert.AreEqual(1.5m, mid.CurrentMonitoringAmpereMax);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 9"), TestCategory("ByteArray")]
        public void Mid0065ByteRevision9()
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
                0x2A, //0010 1010
                0x00, //Reserved from bit 7 to rest
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
           };

            string untilStrategy = @"04270065009         01012345678902AIRBAG                   03000104002051006";
            bytes.AddRange(GetAsciiBytes(untilStrategy));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));

            string untilTighteningErrorStatus = "07000008000009010011112013214115016217118";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));

            string untilTighteningErrorStatus2 = "19001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 34E1243500510036";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus2));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus2, 10));

            string untilEnd = "37429496729538Station Name             390010004024165214342005232430010044000504500150";
            bytes.AddRange(GetAsciiBytes(untilEnd));
            var mid = _midInterpreter.Parse<Mid0065>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            Assert.AreEqual(TorqueValuesUnit.Percentage, mid.TorqueValuesUnit);
            Assert.AreEqual((ResultType)8, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(51m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(4294967295, mid.StationId);
            Assert.AreEqual("Station Name             ", mid.StationName);
            Assert.AreEqual(10m, mid.StartFinalAngle);
            Assert.AreEqual(PostViewTorque.OnlyPVTHOn, mid.PostViewTorqueActivated);
            Assert.AreEqual(6521.43m, mid.PostViewTorqueHigh);
            Assert.AreEqual(52.32m, mid.PostViewTorqueLow);
            Assert.AreEqual(1m, mid.CurrentMonitoringAmpere);
            Assert.AreEqual(0.5m, mid.CurrentMonitoringAmpereMin);
            Assert.AreEqual(1.5m, mid.CurrentMonitoringAmpereMax);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 10"), TestCategory("ASCII")]
        public void Mid0065Revision10()
        {
            string pack = @"04970065010         01012345678902AIRBAG                   030001040020510060093807000008000009010011112013214115016217118000004189819001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 34E1243500510036000000004237429496729538Station Name             3900100040241652143420052324300100440005045001504600001470000148149-00205000100510012052003291530010055400011055009000";
            var mid = _midInterpreter.Parse<Mid0065>(pack);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            Assert.AreEqual(TorqueValuesUnit.Percentage, mid.TorqueValuesUnit);
            Assert.AreEqual((ResultType)8, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(51m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(4294967295, mid.StationId);
            Assert.AreEqual("Station Name             ", mid.StationName);
            Assert.AreEqual(10m, mid.StartFinalAngle);
            Assert.AreEqual(PostViewTorque.OnlyPVTHOn, mid.PostViewTorqueActivated);
            Assert.AreEqual(6521.43m, mid.PostViewTorqueHigh);
            Assert.AreEqual(52.32m, mid.PostViewTorqueLow);
            Assert.AreEqual(1m, mid.CurrentMonitoringAmpere);
            Assert.AreEqual(0.5m, mid.CurrentMonitoringAmpereMin);
            Assert.AreEqual(1.5m, mid.CurrentMonitoringAmpereMax);
            Assert.AreEqual(1, mid.AngleNumeratorScaleFactor);
            Assert.AreEqual(1, mid.AngleDenominatorScaleFactor);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.OverallAngleStatus);
            Assert.AreEqual(-20, mid.OverallAngleMin);
            Assert.AreEqual(100, mid.OverallAngleMax);
            Assert.AreEqual(120, mid.OverallAngle);
            Assert.AreEqual(32.91m, mid.PeakTorque);
            Assert.AreEqual(10.05m, mid.ResidualBreakawayTorque);
            Assert.AreEqual(1.1m, mid.StartRundownAngle);
            Assert.AreEqual(90m, mid.RundownAngleComplete);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 10"), TestCategory("ByteArray")]
        public void Mid0065ByteRevision10()
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
                0x2A, //0010 1010
                0x00, //Reserved from bit 7 to rest
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
           };

            string untilStrategy = @"04970065010         01012345678902AIRBAG                   03000104002051006";
            bytes.AddRange(GetAsciiBytes(untilStrategy));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));

            string untilTighteningErrorStatus = "07000008000009010011112013214115016217118";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));

            string untilTighteningErrorStatus2 = "19001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 34E1243500510036";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus2));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus2, 10));

            string untilEnd = "37429496729538Station Name             3900100040241652143420052324300100440005045001504600001470000148149-00205000100510012052003291530010055400011055009000";
            bytes.AddRange(GetAsciiBytes(untilEnd));
            var mid = _midInterpreter.Parse<Mid0065>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            Assert.AreEqual(TorqueValuesUnit.Percentage, mid.TorqueValuesUnit);
            Assert.AreEqual((ResultType)8, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(51m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(4294967295, mid.StationId);
            Assert.AreEqual("Station Name             ", mid.StationName);
            Assert.AreEqual(10m, mid.StartFinalAngle);
            Assert.AreEqual(PostViewTorque.OnlyPVTHOn, mid.PostViewTorqueActivated);
            Assert.AreEqual(6521.43m, mid.PostViewTorqueHigh);
            Assert.AreEqual(52.32m, mid.PostViewTorqueLow);
            Assert.AreEqual(1m, mid.CurrentMonitoringAmpere);
            Assert.AreEqual(0.5m, mid.CurrentMonitoringAmpereMin);
            Assert.AreEqual(1.5m, mid.CurrentMonitoringAmpereMax);
            Assert.AreEqual(1, mid.AngleNumeratorScaleFactor);
            Assert.AreEqual(1, mid.AngleDenominatorScaleFactor);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.OverallAngleStatus);
            Assert.AreEqual(-20, mid.OverallAngleMin);
            Assert.AreEqual(100, mid.OverallAngleMax);
            Assert.AreEqual(120, mid.OverallAngle);
            Assert.AreEqual(32.91m, mid.PeakTorque);
            Assert.AreEqual(10.05m, mid.ResidualBreakawayTorque);
            Assert.AreEqual(1.1m, mid.StartRundownAngle);
            Assert.AreEqual(90m, mid.RundownAngleComplete);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 11"), TestCategory("ASCII")]
        public void Mid0065Revision11()
        {
            string pack = @"05120065011         01012345678902AIRBAG                   030001040020510060093807000008000009010011112013214115016217118000004189819001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 34E1243500510036000000004237429496729538Station Name             3900100040241652143420052324300100440005045001504600001470000148149-00205000100510012052003291530010055400011055009000560001205700001";
            var mid = _midInterpreter.Parse<Mid0065>(pack);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            Assert.AreEqual(TorqueValuesUnit.Percentage, mid.TorqueValuesUnit);
            Assert.AreEqual((ResultType)8, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(51m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(4294967295, mid.StationId);
            Assert.AreEqual("Station Name             ", mid.StationName);
            Assert.AreEqual(10m, mid.StartFinalAngle);
            Assert.AreEqual(PostViewTorque.OnlyPVTHOn, mid.PostViewTorqueActivated);
            Assert.AreEqual(6521.43m, mid.PostViewTorqueHigh);
            Assert.AreEqual(52.32m, mid.PostViewTorqueLow);
            Assert.AreEqual(1m, mid.CurrentMonitoringAmpere);
            Assert.AreEqual(0.5m, mid.CurrentMonitoringAmpereMin);
            Assert.AreEqual(1.5m, mid.CurrentMonitoringAmpereMax);
            Assert.AreEqual(1, mid.AngleNumeratorScaleFactor);
            Assert.AreEqual(1, mid.AngleDenominatorScaleFactor);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.OverallAngleStatus);
            Assert.AreEqual(-20, mid.OverallAngleMin);
            Assert.AreEqual(100, mid.OverallAngleMax);
            Assert.AreEqual(120, mid.OverallAngle);
            Assert.AreEqual(32.91m, mid.PeakTorque);
            Assert.AreEqual(10.05m, mid.ResidualBreakawayTorque);
            Assert.AreEqual(1.1m, mid.StartRundownAngle);
            Assert.AreEqual(90m, mid.RundownAngleComplete);
            Assert.AreEqual(1.2m, mid.ClickTorque);
            Assert.AreEqual(1, mid.ClickAngle);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 11"), TestCategory("ByteArray")]
        public void Mid0065ByteRevision11()
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
                0x2A, //0010 1010
                0x00, //Reserved from bit 7 to rest
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00
           };

            string untilStrategy = @"05120065011         01012345678902AIRBAG                   03000104002051006";
            bytes.AddRange(GetAsciiBytes(untilStrategy));
            bytes.AddRange(GetAsciiBytes(strategyOptions, 5));

            string untilTighteningErrorStatus = "07000008000009010011112013214115016217118";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus, 10));

            string untilTighteningErrorStatus2 = "19001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 34E1243500510036";
            bytes.AddRange(GetAsciiBytes(untilTighteningErrorStatus2));
            bytes.AddRange(GetAsciiBytes(tighteningErrorStatus2, 10));

            string untilEnd = "37429496729538Station Name             3900100040241652143420052324300100440005045001504600001470000148149-00205000100510012052003291530010055400011055009000560001205700001";
            bytes.AddRange(GetAsciiBytes(untilEnd));
            var mid = _midInterpreter.Parse<Mid0065>(bytes.ToArray());

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.AreEqual(123456789L, mid.TighteningId);
            Assert.AreEqual("AIRBAG                   ", mid.VinNumber);
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(Strategy.RotateSpindleForward, mid.Strategy);
            Assert.IsNotNull(mid.StrategyOptions);
            Assert.AreEqual(0, mid.BatchSize);
            Assert.AreEqual(0, mid.BatchCounter);
            Assert.AreEqual(false, mid.TighteningStatus);
            Assert.AreEqual(BatchStatus.Nok, mid.BatchStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.TorqueStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.AngleStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.RundownAngleStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.CurrentMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Low, mid.SelftapStatus);
            Assert.AreEqual(TighteningValueStatus.High, mid.PrevailTorqueMonitoringStatus);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.AreEqual(10m, mid.Torque);
            Assert.AreEqual(360, mid.Angle);
            Assert.AreEqual(250, mid.RundownAngle);
            Assert.AreEqual(2, mid.CurrentMonitoringValue);
            Assert.AreEqual(2.15m, mid.SelftapTorque);
            Assert.AreEqual(10.25m, mid.PrevailTorque);
            Assert.AreEqual(12, mid.JobSequenceNumber);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual("ABCDEFG-123   ", mid.ToolSerialNumber);
            Assert.AreEqual(new DateTime(2019,1,5,9,0,5), mid.Timestamp);
            Assert.AreEqual(TorqueValuesUnit.Percentage, mid.TorqueValuesUnit);
            Assert.AreEqual((ResultType)8, mid.ResultType);
            Assert.AreEqual("Identifier result part 2 ", mid.IdentifierResultPart2);
            Assert.AreEqual("Identifier result part 3 ", mid.IdentifierResultPart3);
            Assert.AreEqual("Identifier result part 4 ", mid.IdentifierResultPart4);
            Assert.AreEqual("E124", mid.CustomerTighteningErrorCode);
            Assert.AreEqual(51m, mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreEqual(4294967295, mid.StationId);
            Assert.AreEqual("Station Name             ", mid.StationName);
            Assert.AreEqual(10m, mid.StartFinalAngle);
            Assert.AreEqual(PostViewTorque.OnlyPVTHOn, mid.PostViewTorqueActivated);
            Assert.AreEqual(6521.43m, mid.PostViewTorqueHigh);
            Assert.AreEqual(52.32m, mid.PostViewTorqueLow);
            Assert.AreEqual(1m, mid.CurrentMonitoringAmpere);
            Assert.AreEqual(0.5m, mid.CurrentMonitoringAmpereMin);
            Assert.AreEqual(1.5m, mid.CurrentMonitoringAmpereMax);
            Assert.AreEqual(1, mid.AngleNumeratorScaleFactor);
            Assert.AreEqual(1, mid.AngleDenominatorScaleFactor);
            Assert.AreEqual(TighteningValueStatus.Ok, mid.OverallAngleStatus);
            Assert.AreEqual(-20, mid.OverallAngleMin);
            Assert.AreEqual(100, mid.OverallAngleMax);
            Assert.AreEqual(120, mid.OverallAngle);
            Assert.AreEqual(32.91m, mid.PeakTorque);
            Assert.AreEqual(10.05m, mid.ResidualBreakawayTorque);
            Assert.AreEqual(1.1m, mid.StartRundownAngle);
            Assert.AreEqual(90m, mid.RundownAngleComplete);
            Assert.AreEqual(1.2m, mid.ClickTorque);
            Assert.AreEqual(1, mid.ClickAngle);
            AssertEqualPackages(bytes, mid);
        }
    }
}
