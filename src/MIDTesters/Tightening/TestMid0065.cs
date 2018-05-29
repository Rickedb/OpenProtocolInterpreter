using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tightening;

namespace MIDTesters.Tightening
{
    [TestClass]
    public class TestMid0065 : MidTester
    {
        [TestMethod]
        public void Mid0065Revision1()
        {
            string package = @"01180065001         01012345678902AIRBAG                   03001040002050060070080014670900046102001-04-22:14:54:34112";
            var mid = _midInterpreter.Parse<MID_0065>(package);

            Assert.AreEqual(typeof(MID_0065), mid.GetType());
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
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
