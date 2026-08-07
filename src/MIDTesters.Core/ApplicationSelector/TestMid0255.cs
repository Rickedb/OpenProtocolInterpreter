using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.ApplicationSelector;
using System.Collections.Generic;

namespace MIDTesters.ApplicationSelector
{
    [TestClass]
    [TestCategory("ApplicationSelector")]
    public class TestMid0255 : DefaultMidTests<Mid0255>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0255Revision1()
        {
            string package = "00340255            01510221112022";
            var mid = _midInterpreter.Parse<Mid0255>(package);

            Assert.AreEqual(51, mid.DeviceId);
            CollectionAssert.AreEqual(new List<LightCommand> 
            { 
                LightCommand.Flashing, 
                LightCommand.Steady, 
                LightCommand.Steady, 
                LightCommand.Steady, 
                LightCommand.Flashing, 
                LightCommand.Off, 
                LightCommand.Flashing, 
                LightCommand.Flashing 
            }, mid.RedLights);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0255ByteRevision1()
        {
            string package = "00340255            01510221112022";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0255>(bytes);

            Assert.AreEqual(51, mid.DeviceId);
            CollectionAssert.AreEqual(new List<LightCommand> 
            { 
                LightCommand.Flashing, 
                LightCommand.Steady, 
                LightCommand.Steady, 
                LightCommand.Steady, 
                LightCommand.Flashing, 
                LightCommand.Off, 
                LightCommand.Flashing, 
                LightCommand.Flashing 
            }, mid.RedLights);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0255PackRevision1()
        {
            string package = "00340255            01510221112022";

            AssertBuildAndParse(package, new Mid0255()
            {
                DeviceId = 51,
                RedLights = new List<LightCommand>()
                {
                    LightCommand.Flashing, LightCommand.Steady, LightCommand.Steady, LightCommand.Steady,
                    LightCommand.Flashing, LightCommand.Off, LightCommand.Flashing, LightCommand.Flashing
                }
            }, true);
        }
    }
}
