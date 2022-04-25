using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MotorTuning;

namespace MIDTesters.MotorTuning
{
    [TestClass]
    public class TestMid0504 : DefaultMidTests<Mid0504>
    {
        [TestMethod]
        public void Mid0504Revision1()
        {
            string package = "00200504            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0504), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0504ByteRevision1()
        {
            string package = "00200504            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0504), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
