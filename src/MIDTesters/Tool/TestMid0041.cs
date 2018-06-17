using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0041 : MidTester
    {
        [TestMethod]
        public void Mid0041Revision1()
        {
            string package = "00810041001         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-10";
            var mid = _midInterpreter.Parse<Mid0041>(package);

            Assert.AreEqual(typeof(Mid0041), mid.GetType());
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.ToolNumberOfTightenings);
            Assert.IsNotNull(mid.LastCalibrationDate);
            Assert.IsNotNull(mid.ControllerSerialNumber);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0041Revision2()
        {
            string package = "01560041002         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      ";
            var mid = _midInterpreter.Parse<Mid0041>(package);

            Assert.AreEqual(typeof(Mid0041), mid.GetType());
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.ToolNumberOfTightenings);
            Assert.IsNotNull(mid.LastCalibrationDate);
            Assert.IsNotNull(mid.ControllerSerialNumber);
            Assert.IsNotNull(mid.CalibrationValue);
            Assert.IsNotNull(mid.LastServiceDate);
            Assert.IsNotNull(mid.TighteningsSinceService);
            Assert.IsNotNull(mid.ToolType);
            Assert.IsNotNull(mid.MotorSize);
            Assert.IsNotNull(mid.OpenEndData);
            Assert.IsNotNull(mid.OpenEndData.UseOpenEnd);
            Assert.IsNotNull(mid.OpenEndData.TighteningDirection);
            Assert.IsNotNull(mid.OpenEndData.MotorRotation);
            Assert.IsNotNull(mid.ControllerSoftwareVersion);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0041Revision3()
        {
            string package = "01800041003         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000";
            var mid = _midInterpreter.Parse<Mid0041>(package);

            Assert.AreEqual(typeof(Mid0041), mid.GetType());
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.ToolNumberOfTightenings);
            Assert.IsNotNull(mid.LastCalibrationDate);
            Assert.IsNotNull(mid.ControllerSerialNumber);
            Assert.IsNotNull(mid.CalibrationValue);
            Assert.IsNotNull(mid.LastServiceDate);
            Assert.IsNotNull(mid.TighteningsSinceService);
            Assert.IsNotNull(mid.ToolType);
            Assert.IsNotNull(mid.MotorSize);
            Assert.IsNotNull(mid.OpenEndData);
            Assert.IsNotNull(mid.OpenEndData.UseOpenEnd);
            Assert.IsNotNull(mid.OpenEndData.TighteningDirection);
            Assert.IsNotNull(mid.OpenEndData.MotorRotation);
            Assert.IsNotNull(mid.ControllerSoftwareVersion);
            Assert.IsNotNull(mid.ToolMaxTorque);
            Assert.IsNotNull(mid.GearRatio);
            Assert.IsNotNull(mid.ToolFullSpeed);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0041Revision4()
        {
            string package = "01840041004         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      1200060013001230140040001503";
            var mid = _midInterpreter.Parse<Mid0041>(package);

            Assert.AreEqual(typeof(Mid0041), mid.GetType());
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.ToolNumberOfTightenings);
            Assert.IsNotNull(mid.LastCalibrationDate);
            Assert.IsNotNull(mid.ControllerSerialNumber);
            Assert.IsNotNull(mid.CalibrationValue);
            Assert.IsNotNull(mid.LastServiceDate);
            Assert.IsNotNull(mid.TighteningsSinceService);
            Assert.IsNotNull(mid.ToolType);
            Assert.IsNotNull(mid.MotorSize);
            Assert.IsNotNull(mid.OpenEndData);
            Assert.IsNotNull(mid.OpenEndData.UseOpenEnd);
            Assert.IsNotNull(mid.OpenEndData.TighteningDirection);
            Assert.IsNotNull(mid.OpenEndData.MotorRotation);
            Assert.IsNotNull(mid.ControllerSoftwareVersion);
            Assert.IsNotNull(mid.ToolMaxTorque);
            Assert.IsNotNull(mid.GearRatio);
            Assert.IsNotNull(mid.ToolFullSpeed);
            Assert.IsNotNull(mid.PrimaryTool);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0041Revision5()
        {
            string package = "01980041005         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000150316Tool Model  ";
            var mid = _midInterpreter.Parse<Mid0041>(package);

            Assert.AreEqual(typeof(Mid0041), mid.GetType());
            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.ToolNumberOfTightenings);
            Assert.IsNotNull(mid.LastCalibrationDate);
            Assert.IsNotNull(mid.ControllerSerialNumber);
            Assert.IsNotNull(mid.CalibrationValue);
            Assert.IsNotNull(mid.LastServiceDate);
            Assert.IsNotNull(mid.TighteningsSinceService);
            Assert.IsNotNull(mid.ToolType);
            Assert.IsNotNull(mid.MotorSize);
            Assert.IsNotNull(mid.OpenEndData);
            Assert.IsNotNull(mid.OpenEndData.UseOpenEnd);
            Assert.IsNotNull(mid.OpenEndData.TighteningDirection);
            Assert.IsNotNull(mid.OpenEndData.MotorRotation);
            Assert.IsNotNull(mid.ControllerSoftwareVersion);
            Assert.IsNotNull(mid.ToolMaxTorque);
            Assert.IsNotNull(mid.GearRatio);
            Assert.IsNotNull(mid.ToolFullSpeed);
            Assert.IsNotNull(mid.PrimaryTool);
            Assert.IsNotNull(mid.ToolModel);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
