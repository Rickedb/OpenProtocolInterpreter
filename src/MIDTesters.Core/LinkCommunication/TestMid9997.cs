﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.LinkCommunication;

namespace MIDTesters.LinkCommunication
{
    [TestClass]
    public class TestMid9997 : DefaultMidTests<Mid9997>
    {
        [TestMethod]
        public void Mid9997Revision1()
        {
            string package = "00249997001         0061";
            var mid = _midInterpreter.Parse<Mid9997>(package);

            Assert.AreNotEqual(0, mid.MidNumber);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid9997ByteRevision1()
        {
            string package = "00249997001         0065";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid9997>(bytes);

            Assert.AreNotEqual(0, mid.MidNumber);
            AssertEqualPackages(bytes, mid);
        }
    }
}
