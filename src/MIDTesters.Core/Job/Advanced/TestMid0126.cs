using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    public class TestMid0126 : DefaultMidTests<Mid0126>
    {
        [TestMethod]
        public void Mid0126Revision1()
        {
            string package = "00200126            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0126), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0126ByteRevision1()
        {
            string package = "00200126            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0126), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
