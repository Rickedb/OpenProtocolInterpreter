﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0030 : DefaultMidTests<Mid0030>
    {
        [TestMethod]
        public void Mid0030AllRevisions()
        {
            string package = "00200030002         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0030), mid.GetType());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0030ByteAllRevisions()
        {
            string package = "00200030002         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0030), mid.GetType());
            AssertEqualPackages(bytes, mid);
        }
    }
}
