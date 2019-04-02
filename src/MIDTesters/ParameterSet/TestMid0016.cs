using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;
using System.Linq;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0016 :MidTester
    {
        [TestMethod]
        public void Mid0016Revision1()
        {
            string package = "00200016            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0016), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0016ByteRevision1()
        {
            string package = "00200016            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0016), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
