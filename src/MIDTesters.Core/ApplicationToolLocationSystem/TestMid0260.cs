﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationToolLocationSystem;

namespace MIDTesters.ApplicationToolLocationSystem
{
    [TestClass]
    public class TestMid0260 : DefaultMidTests<Mid0260>
    {
        [TestMethod]
        public void Mid0260Revision1()
        {
            string package = "00200260            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0260), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0260ByteRevision1()
        {
            string package = "00200260            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0260), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
