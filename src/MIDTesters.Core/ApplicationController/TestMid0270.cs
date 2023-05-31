using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationController;

namespace MIDTesters.ApplicationController
{
    [TestClass]
    [TestCategory("ApplicationController")]
    public class TestMid0270 : DefaultMidTests<Mid0270>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0270Revision1()
        {
            string package = "00200270001         ";
            var mid = _midInterpreter.Parse<Mid0270>(package);

            Assert.AreEqual(typeof(Mid0270), mid.GetType());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0270ByteRevision1()
        {
            string package = "00200270001         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0270), mid.GetType());
            AssertEqualPackages(bytes, mid);
        }
    }
}
