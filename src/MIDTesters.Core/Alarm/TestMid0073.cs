using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    public class TestMid0073 : DefaultMidTests<Mid0073>
    {
        [TestMethod]
        public void Mid0073AllRevisions()
        {
            string pack = @"00200073002         ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0073), mid.GetType());
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        public void Mid0073ByteAllRevisions()
        {
            string pack = @"00200073002         ";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0073), mid.GetType());
            AssertEqualPackages(bytes, mid);
        }
    }
}
