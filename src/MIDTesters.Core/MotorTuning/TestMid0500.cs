using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MotorTuning;

namespace MIDTesters.MotorTuning
{
    [TestClass]
    public class TestMid0500 : DefaultMidTests<Mid0500>
    {
        [TestMethod]
        public void Mid0500Revision1()
        {
            string package = "00200500            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0500), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0500ByteRevision1()
        {
            string package = "00200500            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0500), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
