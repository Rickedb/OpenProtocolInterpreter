using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;
using System.Linq;

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

        [TestMethod]
        public void Mid0011ByteRevision1()
        {
            string package = "00290011            002001002";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0011>(bytes);

            Assert.AreEqual(typeof(Mid0011), mid.GetType());
            Assert.IsNotNull(mid.TotalParameterSets);
            Assert.IsNotNull(mid.ParameterSets);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
