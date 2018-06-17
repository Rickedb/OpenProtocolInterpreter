using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

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
    }
}
