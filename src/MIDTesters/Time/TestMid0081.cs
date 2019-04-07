using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Time;

namespace MIDTesters.Time
{
    [TestClass]
    public class TestMid0081 : MidTester
    {
        [TestMethod]
        public void Mid0081Revision1()
        {
            string pack = @"00390081            2017-12-01:20:12:45";
            var mid = _midInterpreter.Parse<Mid0081>(pack);

            Assert.AreEqual(typeof(Mid0081), mid.GetType());
            Assert.IsNotNull(mid.Time);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0081ByteRevision1()
        {
            string package = @"00390081            2017-12-01:20:12:45";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0081>(bytes);

            Assert.AreEqual(typeof(Mid0081), mid.GetType());
            Assert.IsNotNull(mid.Time);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
