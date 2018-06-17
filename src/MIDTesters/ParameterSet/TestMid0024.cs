using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

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
    }
}
