using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.AutomaticManualMode;

namespace MIDTesters.AutomaticManualMode
{
    [TestClass]
    public class TestMid0403 : DefaultMidTests<Mid0403>
    {
        [TestMethod]
        public void Mid0403Revision1()
        {
            string package = "00200403            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0403), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0403ByteRevision1()
        {
            string package = "00200403            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0403), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
