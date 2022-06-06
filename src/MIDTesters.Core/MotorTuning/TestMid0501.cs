﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MotorTuning;

namespace MIDTesters.MotorTuning
{
    [TestClass]
    public class TestMid0501 : DefaultMidTests<Mid0501>
    {
        [TestMethod]
        public void Mid0501Revision1()
        {
            string package = "00230501            011";
            var mid = _midInterpreter.Parse<Mid0501>(package);

            Assert.IsNotNull(mid.MotorTuneResult);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0501ByteRevision1()
        {
            string package = "00230501            011";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0501>(bytes);

            Assert.IsNotNull(mid.MotorTuneResult);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
