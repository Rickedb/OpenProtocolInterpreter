using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0015 : MidTester
    {
        [TestMethod]
        public void Mid0015Revision1()
        {
            string package = "00420015001         0022017-06-02:09:54:09";
            var mid = _midInterpreter.Parse<Mid0015>(package);

            Assert.AreEqual(typeof(Mid0015), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0015ByteRevision1()
        {
            string package = "00420015001         0022017-06-02:09:54:09";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0015>(bytes);

            Assert.AreEqual(typeof(Mid0015), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0015Revision2()
        {
            string package = "01410015002         0100202Airbag parameter         032017-06-02:09:54:0904205040600510107010009080050050900001109999911003601200123413001006";
            var mid = _midInterpreter.Parse<Mid0015>(package);

            Assert.AreEqual(typeof(Mid0015), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.ParameterSetName);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
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
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0015ByteRevision2()
        {
            string package = "01410015002         0100202Airbag parameter         032017-06-02:09:54:0904205040600510107010009080050050900001109999911003601200123413001006";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0015>(bytes);

            Assert.AreEqual(typeof(Mid0015), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.ParameterSetName);
            Assert.IsNotNull(mid.LastChangeInParameterSet);
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
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}

