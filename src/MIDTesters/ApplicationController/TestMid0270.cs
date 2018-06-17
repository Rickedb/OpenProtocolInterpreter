using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationController;

namespace MIDTesters.ApplicationController
{
    [TestClass]
    public class TestMid0270 : MidTester
    {
        [TestMethod]
        public void Mid0270Revision1()
        {
            string package = "00200270001         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0270), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
