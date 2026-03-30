using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    [TestCategory("ParameterSet")]
    public class TestMid0015 : DefaultMidTests<Mid0015>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0015Revision1()
        {
            string package = "00420015001         0022017-06-02:09:54:09";
            var mid = _midInterpreter.Parse<Mid0015>(package);

            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(new DateTime(2017, 6, 2, 9, 54, 9), mid.LastChangeInParameterSet);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0015ByteRevision1()
        {
            string package = "00420015001         0022017-06-02:09:54:09";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0015>(bytes);

            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(new DateTime(2017, 6, 2, 9, 54, 9), mid.LastChangeInParameterSet);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0015Revision2()
        {
            string package = "01410015002         0100202Airbag parameter         032017-06-02:09:54:0904205040600510107010009080050050900001109999911003601200123413001006";
            var mid = _midInterpreter.Parse<Mid0015>(package);

            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual("Airbag parameter", mid.ParameterSetName.TrimEnd());
            Assert.AreEqual(new DateTime(2017, 6, 2, 9, 54, 9), mid.LastChangeInParameterSet);
            Assert.AreEqual(RotationDirection.Counterclockwise, mid.RotationDirection);
            Assert.AreEqual(4, mid.BatchSize);
            Assert.AreEqual(51.01m, mid.MinTorque);
            Assert.AreEqual(100.09m, mid.MaxTorque);
            Assert.AreEqual(50.05m, mid.TorqueFinalTarget);
            Assert.AreEqual(1, mid.MinAngle);
            Assert.AreEqual(99999, mid.MaxAngle);
            Assert.AreEqual(360, mid.AngleFinalTarget);
            Assert.AreEqual(12.34m, mid.FirstTarget);
            Assert.AreEqual(10.06m, mid.StartFinalAngle);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0015ByteRevision2()
        {
            string package = "01410015002         0100202Airbag parameter         032017-06-02:09:54:0904205040600510107010009080050050900001109999911003601200123413001006";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0015>(bytes);

            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual("Airbag parameter", mid.ParameterSetName.TrimEnd());
            Assert.AreEqual(new DateTime(2017, 6, 2, 9, 54, 9), mid.LastChangeInParameterSet);
            Assert.AreEqual(RotationDirection.Counterclockwise, mid.RotationDirection);
            Assert.AreEqual(4, mid.BatchSize);
            Assert.AreEqual(51.01m, mid.MinTorque);
            Assert.AreEqual(100.09m, mid.MaxTorque);
            Assert.AreEqual(50.05m, mid.TorqueFinalTarget);
            Assert.AreEqual(1, mid.MinAngle);
            Assert.AreEqual(99999, mid.MaxAngle);
            Assert.AreEqual(360, mid.AngleFinalTarget);
            Assert.AreEqual(12.34m, mid.FirstTarget);
            Assert.AreEqual(10.06m, mid.StartFinalAngle);
            AssertEqualPackages(bytes, mid);
        }
    }
}

