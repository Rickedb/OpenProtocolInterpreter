using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    public class TestMid0132 : DefaultMidTests<Mid0132>
    {
        [TestMethod]
        public void Mid0132Revision1()
        {
            string package = "00200132            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0132), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0132ByteRevision1()
        {
            string package = "00200132            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0132), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
