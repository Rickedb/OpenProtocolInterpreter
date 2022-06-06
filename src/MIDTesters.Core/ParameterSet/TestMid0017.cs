using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0017 : DefaultMidTests<Mid0017>
    {
        [TestMethod]
        public void Mid0017Revision1()
        {
            string package = "00200017            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0017), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0017ByteRevision1()
        {
            string package = "00200017            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0017), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
