using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0041 : DefaultMidTests<Mid0041>
    {
        [TestMethod]
        public void Mid0041Revision1()
        {
            string package = "00810041001         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-10";
            var mid = _midInterpreter.Parse<Mid0041>(package);

            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.ToolNumberOfTightenings);
            Assert.IsNotNull(mid.LastCalibrationDate);
            Assert.IsNotNull(mid.ControllerSerialNumber);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0041ByteRevision1()
        {
            string package = "00810041001         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-10";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0041>(bytes);

            Assert.IsNotNull(mid.ToolSerialNumber);
            Assert.IsNotNull(mid.ToolNumberOfTightenings);
            Assert.IsNotNull(mid.LastCalibrationDate);
            Assert.IsNotNull(mid.ControllerSerialNumber);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        public void Mid0041Revision2()
        {
            string package = "01560041002         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      ";
            var mid = _midInterpreter.Parse<Mid0041>(package);

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
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0041ByteRevision2()
        {
            string package = "01560041002         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0041>(bytes);

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
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        public void Mid0041Revision3()
        {
            string package = "01800041003         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000";
            var mid = _midInterpreter.Parse<Mid0041>(package);

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
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0041ByteRevision3()
        {
            string package = "01800041003         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0041>(bytes);

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
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        public void Mid0041Revision4()
        {
            string package = "01840041004         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      1200060013001230140040001503";
            var mid = _midInterpreter.Parse<Mid0041>(package);

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
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0041ByteRevision4()
        {
            string package = "01840041004         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      1200060013001230140040001503";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0041>(bytes);

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
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        public void Mid0041Revision5()
        {
            string package = "01980041005         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000150316Tool Model  ";
            var mid = _midInterpreter.Parse<Mid0041>(package);

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
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0041ByteRevision5()
        {
            string package = "01980041005         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000150316Tool Model  ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0041>(bytes);

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
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        public void Mid0041Revision6()
        {
            string package = "02360041006         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000150316Tool Model  17000118Tool Article Number           ";
            var mid = _midInterpreter.Parse<Mid0041>(package);

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
            Assert.IsNotNull(mid.ToolNumber);
            Assert.IsNotNull(mid.ToolArticleNumber);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0041ByteRevision6()
        {
            string package = "02360041006         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000150316Tool Model  17000118Tool Article Number           ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0041>(bytes);

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
            Assert.IsNotNull(mid.ToolNumber);
            Assert.IsNotNull(mid.ToolArticleNumber);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        public void Mid0041Revision7()
        {
            string package = "02600041007         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000150316Tool Model  17000118Tool Article Number           190010002003200021013000";
            var mid = _midInterpreter.Parse<Mid0041>(package);

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
            Assert.IsNotNull(mid.ToolNumber);
            Assert.IsNotNull(mid.ToolArticleNumber);
            Assert.IsNotNull(mid.RundownMinSpeed);
            Assert.IsNotNull(mid.DownshiftMaxSpeed);
            Assert.IsNotNull(mid.DownshiftMinSpeed);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0041ByteRevision7()
        {
            string package = "02600041007         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000150316Tool Model  17000118Tool Article Number           190010002003200021013000";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0041>(bytes);

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
            Assert.IsNotNull(mid.ToolNumber);
            Assert.IsNotNull(mid.ToolArticleNumber);
            Assert.IsNotNull(mid.RundownMinSpeed);
            Assert.IsNotNull(mid.DownshiftMaxSpeed);
            Assert.IsNotNull(mid.DownshiftMinSpeed);
            AssertEqualPackages(bytes, mid);
        }
    }
}
