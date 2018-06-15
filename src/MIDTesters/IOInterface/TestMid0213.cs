using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0213 : MidTester
    {
        [TestMethod]
        public void Mid0213Revision1()
        {
            string package = "00200213            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0213), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
