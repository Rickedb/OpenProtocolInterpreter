using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;
using System.Linq;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0024 : MidTester
    {
        [TestMethod]
        public void Mid0024Revision1()
        {
            string package = "00200024            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0024), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0024ByteRevision1()
        {
            string package = "00200024            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0024), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
