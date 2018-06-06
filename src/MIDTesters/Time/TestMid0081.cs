using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Time;

namespace MIDTesters.Time
{
    [TestClass]
    public class TestMid0081 : MidTester
    {
        [TestMethod]
        public void Mid0081Revision1()
        {
            string pack = @"00390081            2017-12-01:20:12:45";
            var mid = _midInterpreter.Parse<MID_0081>(pack);

            Assert.AreEqual(typeof(MID_0081), mid.GetType());
            Assert.IsNotNull(mid.Time);
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
