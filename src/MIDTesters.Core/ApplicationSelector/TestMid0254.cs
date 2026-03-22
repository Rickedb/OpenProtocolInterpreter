using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.ApplicationSelector;
using System.Collections.Generic;

namespace MIDTesters.ApplicationSelector
{
    [TestClass]
    [TestCategory("ApplicationSelector")]
    public class TestMid0254 : DefaultMidTests<Mid0254>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0254Revision1()
        {
            string package = "00340254            01110201221022";
            var mid = _midInterpreter.Parse<Mid0254>(package);

            Assert.AreEqual(11, mid.DeviceId);
            CollectionAssert.AreEqual(
                new List<LightCommand> { LightCommand.Off, LightCommand.Steady, LightCommand.Flashing, LightCommand.Flashing, LightCommand.Steady, LightCommand.Off, LightCommand.Flashing, LightCommand.Flashing },
                mid.GreenLights);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0254ByteRevision1()
        {
            string package = "00340254            01110201221022";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0254>(bytes);

            Assert.AreEqual(11, mid.DeviceId);
            CollectionAssert.AreEqual(new List<LightCommand> 
            {
                 LightCommand.Off, 
                 LightCommand.Steady, 
                 LightCommand.Flashing, 
                 LightCommand.Flashing, 
                 LightCommand.Steady, 
                 LightCommand.Off, 
                 LightCommand.Flashing, 
                 LightCommand.Flashing 
            }, mid.GreenLights);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
