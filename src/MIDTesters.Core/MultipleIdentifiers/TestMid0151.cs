using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultipleIdentifiers;

namespace MIDTesters.MultipleIdentifiers
{
    [TestClass]
    [TestCategory("MultipleIdentifiers")]
    public class TestMid0151 : DefaultMidTests<Mid0151>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0151Revision1()
        {
            string package = "00200151001         ";
            var mid = _midInterpreter.Parse<Mid0151>(package);

            Assert.AreEqual(typeof(Mid0151), mid.GetType());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0151ByteRevision1()
        {
            string package = "00200151001         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0151>(bytes);

            Assert.AreEqual(typeof(Mid0151), mid.GetType());
            AssertEqualPackages(bytes, mid);
        }
    }
}
