using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0013 : MidTester
    {
        [TestMethod]
        public void Mid0013Revision1()
        {
            string pack = @"01040013            0100102Airbag1                  0310403050012000600150007001400080036009007201000480";
            var mid = _midInterpreter.Parse<Mid0013>(pack);

            Assert.AreEqual(typeof(Mid0013), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.ParameterSetName);
            Assert.IsNotNull(mid.RotationDirection);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.MinTorque);
            Assert.IsNotNull(mid.MaxTorque);
            Assert.IsNotNull(mid.TorqueFinalTarget);
            Assert.IsNotNull(mid.MinAngle);
            Assert.IsNotNull(mid.MaxAngle);
            Assert.IsNotNull(mid.AngleFinalTarget);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0013Revision2()
        {
            string pack = @"01200013002         0100102Airbag1                  03104030500120006001500070014000800360090072010004801102021112017854";
            var mid = _midInterpreter.Parse<Mid0013>(pack);

            Assert.AreEqual(typeof(Mid0013), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.ParameterSetName);
            Assert.IsNotNull(mid.RotationDirection);
            Assert.IsNotNull(mid.BatchSize);
            Assert.IsNotNull(mid.MinTorque);
            Assert.IsNotNull(mid.MaxTorque);
            Assert.IsNotNull(mid.TorqueFinalTarget);
            Assert.IsNotNull(mid.MinAngle);
            Assert.IsNotNull(mid.MaxAngle);
            Assert.IsNotNull(mid.AngleFinalTarget);
            Assert.IsNotNull(mid.FirstTarget);
            Assert.IsNotNull(mid.StartFinalAngle);
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
