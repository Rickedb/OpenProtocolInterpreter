using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tightening;
using System.Collections.Generic;

namespace MIDTesters.Tightening
{
    [TestClass]
    [TestCategory("Tightening")]
    public class TestMid0065 : MidTester
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0065Revision1()
        {
            string package = @"01180065001         01012345678902AIRBAG                   03001040002050060070080014670900046102001-04-22:14:54:34112";
            var mid = _midInterpreter.Parse<Mid0065>(package);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.IsNotNull(mid.TighteningId);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.BatchStatus);
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
            Assert.IsNotNull(mid.TighteningId);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.BatchCounter);
            Assert.IsNotNull(mid.TighteningStatus);
            Assert.IsNotNull(mid.TorqueStatus);
            Assert.IsNotNull(mid.AngleStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.BatchStatus);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0065Revision2()
        {
            string package = @"02260065002         01012345678902AIRBAG                   030001040020510060093807000008000009010011112013214115016217118000004189819001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05";
            var mid = _midInterpreter.Parse<Mid0065>(package);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.IsNotNull(mid.TighteningId);
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
            Assert.IsNotNull(mid.PrevailTorqueMonitoringStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
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
            Assert.IsNotNull(mid.TighteningId);
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
            Assert.IsNotNull(mid.PrevailTorqueMonitoringStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ASCII")]
        public void Mid0065Revision3()
        {
            string package = @"02330065003         01012345678902AIRBAG                   030001040020510060093807000008000009010011112013214115016217118000004189819001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:052973008";
            var mid = _midInterpreter.Parse<Mid0065>(package);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.IsNotNull(mid.TighteningId);
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
            Assert.IsNotNull(mid.PrevailTorqueMonitoringStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
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
            Assert.IsNotNull(mid.TighteningId);
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
            Assert.IsNotNull(mid.PrevailTorqueMonitoringStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ASCII")]
        public void Mid0065Revision4()
        {
            string package = @"03140065004         01012345678902AIRBAG                   030001040020510060093807000008000009010011112013214115016217118000004189819001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 ";
            var mid = _midInterpreter.Parse<Mid0065>(package);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.IsNotNull(mid.TighteningId);
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
            Assert.IsNotNull(mid.PrevailTorqueMonitoringStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
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
            Assert.IsNotNull(mid.TighteningId);
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
            Assert.IsNotNull(mid.PrevailTorqueMonitoringStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("ASCII")]
        public void Mid0065Revision5()
        {
            string package = @"03200065005         01012345678902AIRBAG                   030001040020510060093807000008000009010011112013214115016217118000004189819001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 34E124";
            var mid = _midInterpreter.Parse<Mid0065>(package);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.IsNotNull(mid.TighteningId);
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
            Assert.IsNotNull(mid.PrevailTorqueMonitoringStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsNotNull(mid.CustomerTighteningErrorCode);
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
            Assert.IsNotNull(mid.TighteningId);
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
            Assert.IsNotNull(mid.PrevailTorqueMonitoringStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsNotNull(mid.CustomerTighteningErrorCode);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 6"), TestCategory("ASCII")]
        public void Mid0065Revision6()
        {
            string package = @"03400065006         01012345678902AIRBAG                   030001040020510060093807000008000009010011112013214115016217118000004189819001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 34E12435005100360000000042";
            var mid = _midInterpreter.Parse<Mid0065>(package);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.IsNotNull(mid.TighteningId);
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
            Assert.IsNotNull(mid.PrevailTorqueMonitoringStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsNotNull(mid.CustomerTighteningErrorCode);
            Assert.IsNotNull(mid.PrevailTorqueCompensateValue);
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
            Assert.IsNotNull(mid.TighteningId);
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
            Assert.IsNotNull(mid.PrevailTorqueMonitoringStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsNotNull(mid.CustomerTighteningErrorCode);
            Assert.IsNotNull(mid.PrevailTorqueCompensateValue);
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
            Assert.IsNotNull(mid.TighteningId);
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
            Assert.IsNotNull(mid.PrevailTorqueMonitoringStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsNotNull(mid.CustomerTighteningErrorCode);
            Assert.IsNotNull(mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreNotEqual(0, mid.StationId);
            Assert.IsNotNull(mid.StationName);
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
            Assert.IsNotNull(mid.TighteningId);
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
            Assert.IsNotNull(mid.PrevailTorqueMonitoringStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsNotNull(mid.CustomerTighteningErrorCode);
            Assert.IsNotNull(mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreNotEqual(0, mid.StationId);
            Assert.IsNotNull(mid.StationName);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 8"), TestCategory("ASCII")]
        public void Mid0065Revision8()
        {
            string package = @"04060065008         01012345678902AIRBAG                   030001040020510060093807000008000009010011112013214115016217118000004189819001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 34E1243500510036000000004237429496729538Station Name             390010004024165214342005232";
            var mid = _midInterpreter.Parse<Mid0065>(package);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.IsNotNull(mid.TighteningId);
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
            Assert.IsNotNull(mid.PrevailTorqueMonitoringStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsNotNull(mid.CustomerTighteningErrorCode);
            Assert.IsNotNull(mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreNotEqual(0, mid.StationId);
            Assert.IsNotNull(mid.StationName);
            Assert.AreNotEqual(0, mid.StartFinalAngle);
            Assert.IsNotNull(mid.PostViewTorqueActivated);
            Assert.AreNotEqual(0, mid.PostViewTorqueHigh);
            Assert.AreNotEqual(0, mid.PostViewTorqueLow);
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
            Assert.IsNotNull(mid.TighteningId);
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
            Assert.IsNotNull(mid.PrevailTorqueMonitoringStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsNotNull(mid.CustomerTighteningErrorCode);
            Assert.IsNotNull(mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreNotEqual(0, mid.StationId);
            Assert.IsNotNull(mid.StationName);
            Assert.AreNotEqual(0, mid.StartFinalAngle);
            Assert.IsNotNull(mid.PostViewTorqueActivated);
            Assert.AreNotEqual(0, mid.PostViewTorqueHigh);
            Assert.AreNotEqual(0, mid.PostViewTorqueLow);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 9"), TestCategory("ASCII")]
        public void Mid0065Revision9()
        {
            string package = @"04270065009         01012345678902AIRBAG                   030001040020510060093807000008000009010011112013214115016217118000004189819001000200036021002502200223000215240010252500012266553527ABCDEFG-123   282019-01-05:09:00:05297300831Identifier result part 2 32Identifier result part 3 33Identifier result part 4 34E1243500510036000000004237429496729538Station Name             390010004024165214342005232430010044000504500150";
            var mid = _midInterpreter.Parse<Mid0065>(package);

            Assert.AreEqual(typeof(Mid0065), mid.GetType());
            Assert.IsNotNull(mid.TighteningId);
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
            Assert.IsNotNull(mid.PrevailTorqueMonitoringStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsNotNull(mid.CustomerTighteningErrorCode);
            Assert.IsNotNull(mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreNotEqual(0, mid.StationId);
            Assert.IsNotNull(mid.StationName);
            Assert.AreNotEqual(0, mid.StartFinalAngle);
            Assert.IsNotNull(mid.PostViewTorqueActivated);
            Assert.AreNotEqual(0, mid.PostViewTorqueHigh);
            Assert.AreNotEqual(0, mid.PostViewTorqueLow);
            Assert.AreNotEqual(0, mid.CurrentMonitoringAmpere);
            Assert.AreNotEqual(0, mid.CurrentMonitoringAmpereMin);
            Assert.AreNotEqual(0, mid.CurrentMonitoringAmpereMax);
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
            Assert.IsNotNull(mid.TighteningId);
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
            Assert.IsNotNull(mid.PrevailTorqueMonitoringStatus);
            Assert.IsNotNull(mid.PrevailTorqueCompensateStatus);
            Assert.IsNotNull(mid.TighteningErrorStatus);
            Assert.IsNotNull(mid.Torque);
            Assert.IsNotNull(mid.Angle);
            Assert.IsNotNull(mid.RundownAngle);
            Assert.IsNotNull(mid.CurrentMonitoringValue);
            Assert.IsNotNull(mid.SelftapTorque);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.Timestamp);
            Assert.IsNotNull(mid.TorqueValuesUnit);
            Assert.IsNotNull(mid.ResultType);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsNotNull(mid.CustomerTighteningErrorCode);
            Assert.IsNotNull(mid.PrevailTorqueCompensateValue);
            Assert.IsNotNull(mid.TighteningErrorStatus2);
            Assert.AreNotEqual(0, mid.StationId);
            Assert.IsNotNull(mid.StationName);
            Assert.AreNotEqual(0, mid.StartFinalAngle);
            Assert.IsNotNull(mid.PostViewTorqueActivated);
            Assert.AreNotEqual(0, mid.PostViewTorqueHigh);
            Assert.AreNotEqual(0, mid.PostViewTorqueLow);
            Assert.AreNotEqual(0, mid.CurrentMonitoringAmpere);
            Assert.AreNotEqual(0, mid.CurrentMonitoringAmpereMin);
            Assert.AreNotEqual(0, mid.CurrentMonitoringAmpereMax);
            AssertEqualPackages(bytes, mid);
        }
    }
}
