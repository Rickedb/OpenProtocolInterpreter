using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tightening;

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

        //[TestMethod]
        public void Mid0061Revision2()
        {
            string pack = "";
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

        //[TestMethod]
        public void Mid0061Revision3()
        {
            string pack = "";
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

        //[TestMethod]
        public void Mid0061Revision4()
        {
            string pack = "";
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

        //[TestMethod]
        public void Mid0061Revision5()
        {
            string pack = "";
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

        //[TestMethod]
        public void Mid0061Revision6()
        {
            string pack = "";
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

        //[TestMethod]
        public void Mid0061Revision7()
        {
            string pack = "";
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

        //[TestMethod]
        public void Mid0061Revision998()
        {
            string pack = "";
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
            Assert.IsNotNull(mid.NumberOfStagesInMultistage);
            Assert.IsNotNull(mid.NumberOfStageResults);
            Assert.IsNotNull(mid.StageResult);
            Assert.AreEqual(pack, mid.Pack());
        }

        //[TestMethod]
        public void Mid0061Revision999()
        {
            string pack = "01210061999         KPOL3456JKLO897          02001002000192111000500003602001-06-02:09:54:094294967295";
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
    }
}
