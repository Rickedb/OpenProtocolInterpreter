using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;


namespace MIDTesters.Communication
{
    [TestClass]
    public class TestMid0001 : MidTester
    {
        [TestMethod]
        public void Mid0001AllRevisions()
        {
            string package = "00200001003         ";
            var mid = _midInterpreter.Parse(package);
            

            Assert.AreEqual(typeof(Mid0001), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
