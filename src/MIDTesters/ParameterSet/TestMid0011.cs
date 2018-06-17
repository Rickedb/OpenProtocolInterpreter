using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0011 : MidTester
    {
        [TestMethod]
        public void Mid0011Revision1()
        {
            string pack = @"00290011            002001002";
            var mid = _midInterpreter.Parse<Mid0011>(pack);

            Assert.AreEqual(typeof(Mid0011), mid.GetType());
            Assert.IsNotNull(mid.TotalParameterSets);
            Assert.IsNotNull(mid.ParameterSets);
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
