using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0010 : MidTester
    {
        [TestMethod]
        public void Mid0010AllRevisions()
        {
            string package = "00200010002         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0010), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
