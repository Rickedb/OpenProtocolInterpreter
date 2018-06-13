using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PowerMACS;

namespace MIDTesters.PowerMACS
{
    [TestClass]
    public class TestMid0107 : MidTester
    {
        [TestMethod]
        public void Mid0107Revision1()
        {
            string pack = @"03510107001         010202020300000381270401052017-05-25:09:51:3806000107My first bolt       08Ap.320Nm Diant.P11  09310                                                  11E3211202Variable 1          I 1234567Variable 2          F 9999.9913002141Step Variable name 1I 765432101Step Variable name 2F 11.1234021501Special Value 1     S 13Got 13 digits01";
            var mid = _midInterpreter.Parse<MID_0107>(pack);

            Assert.AreEqual(typeof(MID_0107), mid.GetType());
            Assert.IsNotNull(mid.TotalNumberOfMessages);
            Assert.IsNotNull(mid.MessageNumber);
            Assert.IsNotNull(mid.DataNumberSystem);
            Assert.IsNotNull(mid.StationNumber);
            Assert.IsNotNull(mid.Time);
            Assert.IsNotNull(mid.BoltNumber);
            Assert.IsNotNull(mid.BoltName);
            Assert.IsNotNull(mid.ProgramName);
            Assert.IsNotNull(mid.PowerMacsStatus);
            Assert.IsNotNull(mid.Errors);
            Assert.IsNotNull(mid.CustomerErrorCode);
            Assert.IsNotNull(mid.BoltResults);
            Assert.IsNotNull(mid.StepResults);
            Assert.IsNotNull(mid.AllStepDataSent);
            Assert.IsNotNull(mid.SpecialValues);
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
