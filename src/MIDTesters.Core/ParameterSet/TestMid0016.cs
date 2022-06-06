using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0016 : DefaultMidTests<Mid0016>
    {
        [TestMethod]
        public void Mid0016Revision1()
        {
            string package = "00200016            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0016), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0016ByteRevision1()
        {
            string package = "00200016            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0016), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
