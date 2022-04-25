using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0014 : DefaultMidTests<Mid0014>
    {
        [TestMethod]
        public void Mid0014Revision1()
        {
            string package = "00200014            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0014), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0014ByteRevision1()
        {
            string package = "00200014            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0014), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
