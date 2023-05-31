using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MotorTuning;

namespace MIDTesters.MotorTuning
{
    [TestClass]
    [TestCategory("MotorTuning")]
    public class TestMid0502 : DefaultMidTests<Mid0502>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0502Revision1()
        {
            string package = "00200502            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0502), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0502ByteRevision1()
        {
            string package = "00200502            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0502), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
