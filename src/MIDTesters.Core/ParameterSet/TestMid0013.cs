using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    [TestCategory("ParameterSet")]
    public class TestMid0013 : DefaultMidTests<Mid0013>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0013Revision1()
        {
            string pack = @"01040013            0100102Airbag1                  0310403050012000600150007001400080036009007201000480";
            var mid = _midInterpreter.Parse<Mid0013>(pack);

            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual("Airbag1", mid.ParameterSetName.TrimEnd());
            Assert.AreEqual(RotationDirection.Clockwise, mid.RotationDirection);
            Assert.AreEqual(3, mid.BatchSize);
            Assert.AreEqual(12.00m, mid.MinTorque);
            Assert.AreEqual(15.00m, mid.MaxTorque);
            Assert.AreEqual(14.00m, mid.TorqueFinalTarget);
            Assert.AreEqual(360, mid.MinAngle);
            Assert.AreEqual(720, mid.MaxAngle);
            Assert.AreEqual(480, mid.AngleFinalTarget);
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0013ByteRevision1()
        {
            string package = "01040013            0100102Airbag1                  0310403050012000600150007001400080036009007201000480";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0013>(bytes);

            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual("Airbag1", mid.ParameterSetName.TrimEnd());
            Assert.AreEqual(RotationDirection.Clockwise, mid.RotationDirection);
            Assert.AreEqual(3, mid.BatchSize);
            Assert.AreEqual(12.00m, mid.MinTorque);
            Assert.AreEqual(15.00m, mid.MaxTorque);
            Assert.AreEqual(14.00m, mid.TorqueFinalTarget);
            Assert.AreEqual(360, mid.MinAngle);
            Assert.AreEqual(720, mid.MaxAngle);
            Assert.AreEqual(480, mid.AngleFinalTarget);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0013Revision2()
        {
            string pack = @"01200013002         0100102Airbag1                  03104030500120006001500070014000800360090072010004801102021112017854";
            var mid = _midInterpreter.Parse<Mid0013>(pack);

            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual("Airbag1", mid.ParameterSetName.TrimEnd());
            Assert.AreEqual(RotationDirection.Clockwise, mid.RotationDirection);
            Assert.AreEqual(3, mid.BatchSize);
            Assert.AreEqual(12.00m, mid.MinTorque);
            Assert.AreEqual(15.00m, mid.MaxTorque);
            Assert.AreEqual(14.00m, mid.TorqueFinalTarget);
            Assert.AreEqual(360, mid.MinAngle);
            Assert.AreEqual(720, mid.MaxAngle);
            Assert.AreEqual(480, mid.AngleFinalTarget);
            Assert.AreEqual(202.11m, mid.FirstTarget);
            Assert.AreEqual(178.54m, mid.StartFinalAngle);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0013ByteRevision2()
        {
            string package = @"01200013002         0100102Airbag1                  03104030500120006001500070014000800360090072010004801102021112017854";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0013>(bytes);

            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual("Airbag1", mid.ParameterSetName.TrimEnd());
            Assert.AreEqual(RotationDirection.Clockwise, mid.RotationDirection);
            Assert.AreEqual(3, mid.BatchSize);
            Assert.AreEqual(12.00m, mid.MinTorque);
            Assert.AreEqual(15.00m, mid.MaxTorque);
            Assert.AreEqual(14.00m, mid.TorqueFinalTarget);
            Assert.AreEqual(360, mid.MinAngle);
            Assert.AreEqual(720, mid.MaxAngle);
            Assert.AreEqual(480, mid.AngleFinalTarget);
            Assert.AreEqual(202.11m, mid.FirstTarget);
            Assert.AreEqual(178.54m, mid.StartFinalAngle);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("ASCII")]
        public void Mid0013Revision5()
        {
            string pack = @"01410013005         0100102Airbag1                  03104030500120006001500070014000800360090072010004801102021112017854132001-05-29:12:34:33";
            var mid = _midInterpreter.Parse<Mid0013>(pack);

            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual("Airbag1", mid.ParameterSetName.TrimEnd());
            Assert.AreEqual(RotationDirection.Clockwise, mid.RotationDirection);
            Assert.AreEqual(3, mid.BatchSize);
            Assert.AreEqual(12.00m, mid.MinTorque);
            Assert.AreEqual(15.00m, mid.MaxTorque);
            Assert.AreEqual(14.00m, mid.TorqueFinalTarget);
            Assert.AreEqual(360, mid.MinAngle);
            Assert.AreEqual(720, mid.MaxAngle);
            Assert.AreEqual(480, mid.AngleFinalTarget);
            Assert.AreEqual(202.11m, mid.FirstTarget);
            Assert.AreEqual(178.54m, mid.StartFinalAngle);
            Assert.AreEqual(new DateTime(2001, 5, 29, 12, 34, 33), mid.LastChangeInParameterSet);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("ByteArray")]
        public void Mid0013ByteRevision5()
        {
            string package = @"01410013005         0100102Airbag1                  03104030500120006001500070014000800360090072010004801102021112017854132001-05-29:12:34:33";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0013>(bytes);

            Assert.AreEqual(1, mid.ParameterSetId);
            Assert.AreEqual("Airbag1", mid.ParameterSetName.TrimEnd());
            Assert.AreEqual(RotationDirection.Clockwise, mid.RotationDirection);
            Assert.AreEqual(3, mid.BatchSize);
            Assert.AreEqual(12.00m, mid.MinTorque);
            Assert.AreEqual(15.00m, mid.MaxTorque);
            Assert.AreEqual(14.00m, mid.TorqueFinalTarget);
            Assert.AreEqual(360, mid.MinAngle);
            Assert.AreEqual(720, mid.MaxAngle);
            Assert.AreEqual(480, mid.AngleFinalTarget);
            Assert.AreEqual(202.11m, mid.FirstTarget);
            Assert.AreEqual(178.54m, mid.StartFinalAngle);
            Assert.AreEqual(new DateTime(2001, 5, 29, 12, 34, 33), mid.LastChangeInParameterSet);
            AssertEqualPackages(bytes, mid);
        }
    }
}
