using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0012 : MidTester
    {
        [TestMethod]
        public void Mid0012Revision1()
        {
            string pack = @"00230012            002";
            var mid = _midInterpreter.Parse<Mid0012>(pack);

            Assert.AreEqual(typeof(Mid0012), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0012ByteRevision1()
        {
            string package = "00230012            002";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0012>(bytes);

            Assert.AreEqual(typeof(Mid0012), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0012Revision2()
        {
            string pack = @"00230012002         002";
            var mid = _midInterpreter.Parse<Mid0012>(pack);

            Assert.AreEqual(typeof(Mid0012), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0012ByteRevision2()
        {
            string package = @"00230012002         002";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0012>(bytes);

            Assert.AreEqual(typeof(Mid0012), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0012Revision3()
        {
            string pack = @"00310012003         00212345678";
            var mid = _midInterpreter.Parse<Mid0012>(pack);

            Assert.AreEqual(typeof(Mid0012), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.ParameterSetFileVersion);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0012ByteRevision3()
        {
            string package = "00310012003         00212345678";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0012>(bytes);

            Assert.AreEqual(typeof(Mid0012), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.ParameterSetFileVersion);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0012Revision4()
        {
            string pack = @"00310012004         00212345678";
            var mid = _midInterpreter.Parse<Mid0012>(pack);

            Assert.AreEqual(typeof(Mid0012), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.ParameterSetFileVersion);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0012ByteRevision4()
        {
            string package = @"00310012004         00212345678";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0012>(bytes);

            Assert.AreEqual(typeof(Mid0012), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.ParameterSetFileVersion);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
