using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MotorTuning;

namespace MIDTesters.MotorTuning
{
    [TestClass]
    [TestCategory("MotorTuning")]
    public class TestMid0500 : DefaultMidTests<Mid0500>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0500Revision1()
        {
            string package = "00200500            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0500), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
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
