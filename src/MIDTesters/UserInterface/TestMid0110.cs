﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.UserInterface;

namespace MIDTesters.UserInterface
{
    [TestClass]
    public class TestMid0110 : MidTester
    {
        [TestMethod]
        public void Mid0110Revision1()
        {
            string package = "00240110001         TEST";
            var mid = _midInterpreter.Parse<MID_0110>(package);

            Assert.AreEqual(typeof(MID_0110), mid.GetType());
            Assert.IsNotNull(mid.UserText);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
