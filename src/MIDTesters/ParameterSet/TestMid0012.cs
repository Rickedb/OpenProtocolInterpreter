using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0012 : MidTester
    {
        [TestMethod]
        public void Revision1()
        {
            string pack = @"00230012            002";
            var mid = _midInterpreter.Parse<MID_0012>(pack);

            Assert.AreEqual(typeof(MID_0012), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Revision2()
        {
            string pack = @"00230012002         002";
            var mid = _midInterpreter.Parse<MID_0012>(pack);

            Assert.AreEqual(typeof(MID_0012), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Revision3()
        {
            string pack = @"00310012003         00212345678";
            var mid = _midInterpreter.Parse<MID_0012>(pack);

            Assert.AreEqual(typeof(MID_0012), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.ParameterSetFileVersion);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Revision4()
        {
            string pack = @"00310012004         00212345678";
            var mid = _midInterpreter.Parse<MID_0012>(pack);

            Assert.AreEqual(typeof(MID_0012), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.ParameterSetFileVersion);
            Assert.AreEqual(pack, mid.Pack());
        }

    }
}
