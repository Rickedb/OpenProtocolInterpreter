﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultipleIdentifiers;

namespace MIDTesters.MultipleIdentifiers
{
    [TestClass]
    public class TestMid0153 : DefaultMidTests<Mid0153>
    {
        [TestMethod]
        public void Mid0153Revision1()
        {
            string package = "00200153            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0153), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0153ByteRevision1()
        {
            string package = "00200153            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0153), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
