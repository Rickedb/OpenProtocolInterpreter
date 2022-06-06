using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    public class TestMid0131 : DefaultMidTests<Mid0131>
    {
        [TestMethod]
        public void Mid0131Revision1()
        {
            string package = "00200131            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0131), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0131ByteRevision1()
        {
            string package = "00200131            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0131), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
