using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.OpenProtocolCommandsDisabled;

namespace MIDTesters.OpenProtocolCommandsDisabled
{
    [TestClass]
    public class TestMid0421 : DefaultMidTests<Mid0421>
    {
        [TestMethod]
        public void Mid0421Revision1()
        {
            string package = "00210421            1";
            var mid = _midInterpreter.Parse<Mid0421>(package);

            Assert.IsNotNull(mid.DigitalInputStatus);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0421ByteRevision1()
        {
            string package = "00210421            1";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0421>(bytes);

            Assert.IsNotNull(mid.DigitalInputStatus);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
