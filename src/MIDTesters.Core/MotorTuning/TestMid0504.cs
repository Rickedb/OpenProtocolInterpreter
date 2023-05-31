using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MotorTuning;

namespace MIDTesters.MotorTuning
{
    [TestClass]
    [TestCategory("MotorTuning")]
    public class TestMid0504 : DefaultMidTests<Mid0504>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0504Revision1()
        {
            string package = "00200504            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0504), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
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
