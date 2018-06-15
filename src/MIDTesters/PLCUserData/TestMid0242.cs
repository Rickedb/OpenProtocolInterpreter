using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PLCUserData;

namespace MIDTesters.PLCUserData
{
    [TestClass]
    public class TestMid0242 : MidTester
    {
        [TestMethod]
        public void Mid0242Revision1()
        {
            string package = "00430242   1        My identifier less than";
            var mid = _midInterpreter.Parse<MID_0242>(package);

            Assert.AreEqual(typeof(MID_0242), mid.GetType());
            Assert.IsNotNull(mid.HeaderData.NoAckFlag);
            Assert.IsNotNull(mid.UserData);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
