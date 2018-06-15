using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0212 : MidTester
    {
        [TestMethod]
        public void Mid0212Revision1()
        {
            string package = "00200212            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0212), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
