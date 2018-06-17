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
    }
}
