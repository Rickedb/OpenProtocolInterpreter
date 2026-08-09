using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    [TestCategory("Tool")]
    public class TestMid0041 : DefaultMidTests<Mid0041>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0041Revision1()
        {
            string package = "00810041001         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-10";
            var mid = _midInterpreter.Parse<Mid0041>(package);

            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber.TrimEnd());
            Assert.AreEqual(4294967295L, mid.ToolNumberOfTightenings);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.LastCalibrationDate);
            Assert.AreEqual("GFEDCBA-10", mid.ControllerSerialNumber.TrimEnd());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0041ByteRevision1()
        {
            string package = "00810041001         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-10";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0041>(bytes);

            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber.TrimEnd());
            Assert.AreEqual(4294967295L, mid.ToolNumberOfTightenings);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.LastCalibrationDate);
            Assert.AreEqual("GFEDCBA-10", mid.ControllerSerialNumber.TrimEnd());
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0041Revision2()
        {
            string package = "01560041002         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      ";
            var mid = _midInterpreter.Parse<Mid0041>(package);

            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber.TrimEnd());
            Assert.AreEqual(4294967295L, mid.ToolNumberOfTightenings);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.LastCalibrationDate);
            Assert.AreEqual("GFEDCBA-10", mid.ControllerSerialNumber.TrimEnd());
            Assert.AreEqual(20.00m, mid.CalibrationValue);
            Assert.AreEqual(new DateTime(2018, 6, 4, 10, 12, 45), mid.LastServiceDate);
            Assert.AreEqual(4284967295L, mid.TighteningsSinceService);
            Assert.AreEqual(ToolType.STB_Tool, mid.ToolType);
            Assert.AreEqual(55, mid.MotorSize);
            Assert.IsTrue(mid.OpenEndData.UseOpenEnd);
            Assert.AreEqual(TighteningDirection.Counterclockwise, mid.OpenEndData.TighteningDirection);
            Assert.AreEqual(MotorRotation.Inverted, mid.OpenEndData.MotorRotation);
            Assert.AreEqual("Version 1.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0041ByteRevision2()
        {
            string package = "01560041002         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0041>(bytes);

            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber.TrimEnd());
            Assert.AreEqual(4294967295L, mid.ToolNumberOfTightenings);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.LastCalibrationDate);
            Assert.AreEqual("GFEDCBA-10", mid.ControllerSerialNumber.TrimEnd());
            Assert.AreEqual(20.00m, mid.CalibrationValue);
            Assert.AreEqual(new DateTime(2018, 6, 4, 10, 12, 45), mid.LastServiceDate);
            Assert.AreEqual(4284967295L, mid.TighteningsSinceService);
            Assert.AreEqual(ToolType.STB_Tool, mid.ToolType);
            Assert.AreEqual(55, mid.MotorSize);
            Assert.IsTrue(mid.OpenEndData.UseOpenEnd);
            Assert.AreEqual(TighteningDirection.Counterclockwise, mid.OpenEndData.TighteningDirection);
            Assert.AreEqual(MotorRotation.Inverted, mid.OpenEndData.MotorRotation);
            Assert.AreEqual("Version 1.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ASCII")]
        public void Mid0041Revision3()
        {
            string package = "01800041003         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000";
            var mid = _midInterpreter.Parse<Mid0041>(package);

            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber.TrimEnd());
            Assert.AreEqual(4294967295L, mid.ToolNumberOfTightenings);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.LastCalibrationDate);
            Assert.AreEqual("GFEDCBA-10", mid.ControllerSerialNumber.TrimEnd());
            Assert.AreEqual(20.00m, mid.CalibrationValue);
            Assert.AreEqual(new DateTime(2018, 6, 4, 10, 12, 45), mid.LastServiceDate);
            Assert.AreEqual(4284967295L, mid.TighteningsSinceService);
            Assert.AreEqual(ToolType.STB_Tool, mid.ToolType);
            Assert.AreEqual(55, mid.MotorSize);
            Assert.IsTrue(mid.OpenEndData.UseOpenEnd);
            Assert.AreEqual(TighteningDirection.Counterclockwise, mid.OpenEndData.TighteningDirection);
            Assert.AreEqual(MotorRotation.Inverted, mid.OpenEndData.MotorRotation);
            Assert.AreEqual("Version 1.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual(6.00m, mid.ToolMaxTorque);
            Assert.AreEqual(12.30m, mid.GearRatio);
            Assert.AreEqual(40.00m, mid.ToolFullSpeed);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ByteArray")]
        public void Mid0041ByteRevision3()
        {
            string package = "01800041003         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0041>(bytes);

            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber.TrimEnd());
            Assert.AreEqual(4294967295L, mid.ToolNumberOfTightenings);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.LastCalibrationDate);
            Assert.AreEqual("GFEDCBA-10", mid.ControllerSerialNumber.TrimEnd());
            Assert.AreEqual(20.00m, mid.CalibrationValue);
            Assert.AreEqual(new DateTime(2018, 6, 4, 10, 12, 45), mid.LastServiceDate);
            Assert.AreEqual(4284967295L, mid.TighteningsSinceService);
            Assert.AreEqual(ToolType.STB_Tool, mid.ToolType);
            Assert.AreEqual(55, mid.MotorSize);
            Assert.IsTrue(mid.OpenEndData.UseOpenEnd);
            Assert.AreEqual(TighteningDirection.Counterclockwise, mid.OpenEndData.TighteningDirection);
            Assert.AreEqual(MotorRotation.Inverted, mid.OpenEndData.MotorRotation);
            Assert.AreEqual("Version 1.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual(6.00m, mid.ToolMaxTorque);
            Assert.AreEqual(12.30m, mid.GearRatio);
            Assert.AreEqual(40.00m, mid.ToolFullSpeed);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ASCII")]
        public void Mid0041Revision4()
        {
            string package = "01840041004         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      1200060013001230140040001503";
            var mid = _midInterpreter.Parse<Mid0041>(package);

            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber.TrimEnd());
            Assert.AreEqual(4294967295L, mid.ToolNumberOfTightenings);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.LastCalibrationDate);
            Assert.AreEqual("GFEDCBA-10", mid.ControllerSerialNumber.TrimEnd());
            Assert.AreEqual(20.00m, mid.CalibrationValue);
            Assert.AreEqual(new DateTime(2018, 6, 4, 10, 12, 45), mid.LastServiceDate);
            Assert.AreEqual(4284967295L, mid.TighteningsSinceService);
            Assert.AreEqual(ToolType.STB_Tool, mid.ToolType);
            Assert.AreEqual(55, mid.MotorSize);
            Assert.IsTrue(mid.OpenEndData.UseOpenEnd);
            Assert.AreEqual(TighteningDirection.Counterclockwise, mid.OpenEndData.TighteningDirection);
            Assert.AreEqual(MotorRotation.Inverted, mid.OpenEndData.MotorRotation);
            Assert.AreEqual("Version 1.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual(6.00m, mid.ToolMaxTorque);
            Assert.AreEqual(12.30m, mid.GearRatio);
            Assert.AreEqual(40.00m, mid.ToolFullSpeed);
            Assert.AreEqual(PrimaryTool.IRC_W, mid.PrimaryTool);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ByteArray")]
        public void Mid0041ByteRevision4()
        {
            string package = "01840041004         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      1200060013001230140040001503";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0041>(bytes);

            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber.TrimEnd());
            Assert.AreEqual(4294967295L, mid.ToolNumberOfTightenings);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.LastCalibrationDate);
            Assert.AreEqual("GFEDCBA-10", mid.ControllerSerialNumber.TrimEnd());
            Assert.AreEqual(20.00m, mid.CalibrationValue);
            Assert.AreEqual(new DateTime(2018, 6, 4, 10, 12, 45), mid.LastServiceDate);
            Assert.AreEqual(4284967295L, mid.TighteningsSinceService);
            Assert.AreEqual(ToolType.STB_Tool, mid.ToolType);
            Assert.AreEqual(55, mid.MotorSize);
            Assert.IsTrue(mid.OpenEndData.UseOpenEnd);
            Assert.AreEqual(TighteningDirection.Counterclockwise, mid.OpenEndData.TighteningDirection);
            Assert.AreEqual(MotorRotation.Inverted, mid.OpenEndData.MotorRotation);
            Assert.AreEqual("Version 1.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual(6.00m, mid.ToolMaxTorque);
            Assert.AreEqual(12.30m, mid.GearRatio);
            Assert.AreEqual(40.00m, mid.ToolFullSpeed);
            Assert.AreEqual(PrimaryTool.IRC_W, mid.PrimaryTool);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("ASCII")]
        public void Mid0041Revision5()
        {
            string package = "01980041005         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000150316Tool Model  ";
            var mid = _midInterpreter.Parse<Mid0041>(package);

            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber.TrimEnd());
            Assert.AreEqual(4294967295L, mid.ToolNumberOfTightenings);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.LastCalibrationDate);
            Assert.AreEqual("GFEDCBA-10", mid.ControllerSerialNumber.TrimEnd());
            Assert.AreEqual(20.00m, mid.CalibrationValue);
            Assert.AreEqual(new DateTime(2018, 6, 4, 10, 12, 45), mid.LastServiceDate);
            Assert.AreEqual(4284967295L, mid.TighteningsSinceService);
            Assert.AreEqual(ToolType.STB_Tool, mid.ToolType);
            Assert.AreEqual(55, mid.MotorSize);
            Assert.IsTrue(mid.OpenEndData.UseOpenEnd);
            Assert.AreEqual(TighteningDirection.Counterclockwise, mid.OpenEndData.TighteningDirection);
            Assert.AreEqual(MotorRotation.Inverted, mid.OpenEndData.MotorRotation);
            Assert.AreEqual("Version 1.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual(6.00m, mid.ToolMaxTorque);
            Assert.AreEqual(12.30m, mid.GearRatio);
            Assert.AreEqual(40.00m, mid.ToolFullSpeed);
            Assert.AreEqual(PrimaryTool.IRC_W, mid.PrimaryTool);
            Assert.AreEqual("Tool Model", mid.ToolModel.TrimEnd());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("ByteArray")]
        public void Mid0041ByteRevision5()
        {
            string package = "01980041005         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000150316Tool Model  ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0041>(bytes);

            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber.TrimEnd());
            Assert.AreEqual(4294967295L, mid.ToolNumberOfTightenings);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.LastCalibrationDate);
            Assert.AreEqual("GFEDCBA-10", mid.ControllerSerialNumber.TrimEnd());
            Assert.AreEqual(20.00m, mid.CalibrationValue);
            Assert.AreEqual(new DateTime(2018, 6, 4, 10, 12, 45), mid.LastServiceDate);
            Assert.AreEqual(4284967295L, mid.TighteningsSinceService);
            Assert.AreEqual(ToolType.STB_Tool, mid.ToolType);
            Assert.AreEqual(55, mid.MotorSize);
            Assert.IsTrue(mid.OpenEndData.UseOpenEnd);
            Assert.AreEqual(TighteningDirection.Counterclockwise, mid.OpenEndData.TighteningDirection);
            Assert.AreEqual(MotorRotation.Inverted, mid.OpenEndData.MotorRotation);
            Assert.AreEqual("Version 1.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual(6.00m, mid.ToolMaxTorque);
            Assert.AreEqual(12.30m, mid.GearRatio);
            Assert.AreEqual(40.00m, mid.ToolFullSpeed);
            Assert.AreEqual(PrimaryTool.IRC_W, mid.PrimaryTool);
            Assert.AreEqual("Tool Model", mid.ToolModel.TrimEnd());
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 6"), TestCategory("ASCII")]
        public void Mid0041Revision6()
        {
            string package = "02360041006         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000150316Tool Model  17000118Tool Article Number           ";
            var mid = _midInterpreter.Parse<Mid0041>(package);

            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber.TrimEnd());
            Assert.AreEqual(4294967295L, mid.ToolNumberOfTightenings);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.LastCalibrationDate);
            Assert.AreEqual("GFEDCBA-10", mid.ControllerSerialNumber.TrimEnd());
            Assert.AreEqual(20.00m, mid.CalibrationValue);
            Assert.AreEqual(new DateTime(2018, 6, 4, 10, 12, 45), mid.LastServiceDate);
            Assert.AreEqual(4284967295L, mid.TighteningsSinceService);
            Assert.AreEqual(ToolType.STB_Tool, mid.ToolType);
            Assert.AreEqual(55, mid.MotorSize);
            Assert.IsTrue(mid.OpenEndData.UseOpenEnd);
            Assert.AreEqual(TighteningDirection.Counterclockwise, mid.OpenEndData.TighteningDirection);
            Assert.AreEqual(MotorRotation.Inverted, mid.OpenEndData.MotorRotation);
            Assert.AreEqual("Version 1.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual(6.00m, mid.ToolMaxTorque);
            Assert.AreEqual(12.30m, mid.GearRatio);
            Assert.AreEqual(40.00m, mid.ToolFullSpeed);
            Assert.AreEqual(PrimaryTool.IRC_W, mid.PrimaryTool);
            Assert.AreEqual("Tool Model", mid.ToolModel.TrimEnd());
            Assert.AreEqual(1, mid.ToolNumber);
            Assert.AreEqual("Tool Article Number", mid.ToolArticleNumber.TrimEnd());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 6"), TestCategory("ByteArray")]
        public void Mid0041ByteRevision6()
        {
            string package = "02360041006         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000150316Tool Model  17000118Tool Article Number           ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0041>(bytes);

            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber.TrimEnd());
            Assert.AreEqual(4294967295L, mid.ToolNumberOfTightenings);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.LastCalibrationDate);
            Assert.AreEqual("GFEDCBA-10", mid.ControllerSerialNumber.TrimEnd());
            Assert.AreEqual(20.00m, mid.CalibrationValue);
            Assert.AreEqual(new DateTime(2018, 6, 4, 10, 12, 45), mid.LastServiceDate);
            Assert.AreEqual(4284967295L, mid.TighteningsSinceService);
            Assert.AreEqual(ToolType.STB_Tool, mid.ToolType);
            Assert.AreEqual(55, mid.MotorSize);
            Assert.IsTrue(mid.OpenEndData.UseOpenEnd);
            Assert.AreEqual(TighteningDirection.Counterclockwise, mid.OpenEndData.TighteningDirection);
            Assert.AreEqual(MotorRotation.Inverted, mid.OpenEndData.MotorRotation);
            Assert.AreEqual("Version 1.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual(6.00m, mid.ToolMaxTorque);
            Assert.AreEqual(12.30m, mid.GearRatio);
            Assert.AreEqual(40.00m, mid.ToolFullSpeed);
            Assert.AreEqual(PrimaryTool.IRC_W, mid.PrimaryTool);
            Assert.AreEqual("Tool Model", mid.ToolModel.TrimEnd());
            Assert.AreEqual(1, mid.ToolNumber);
            Assert.AreEqual("Tool Article Number", mid.ToolArticleNumber.TrimEnd());
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 7"), TestCategory("ASCII")]
        public void Mid0041Revision7()
        {
            string package = "02600041007         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000150316Tool Model  17000118Tool Article Number           190010002003200021013000";
            var mid = _midInterpreter.Parse<Mid0041>(package);

            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber.TrimEnd());
            Assert.AreEqual(4294967295L, mid.ToolNumberOfTightenings);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.LastCalibrationDate);
            Assert.AreEqual("GFEDCBA-10", mid.ControllerSerialNumber.TrimEnd());
            Assert.AreEqual(20.00m, mid.CalibrationValue);
            Assert.AreEqual(new DateTime(2018, 6, 4, 10, 12, 45), mid.LastServiceDate);
            Assert.AreEqual(4284967295L, mid.TighteningsSinceService);
            Assert.AreEqual(ToolType.STB_Tool, mid.ToolType);
            Assert.AreEqual(55, mid.MotorSize);
            Assert.IsTrue(mid.OpenEndData.UseOpenEnd);
            Assert.AreEqual(TighteningDirection.Counterclockwise, mid.OpenEndData.TighteningDirection);
            Assert.AreEqual(MotorRotation.Inverted, mid.OpenEndData.MotorRotation);
            Assert.AreEqual("Version 1.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual(6.00m, mid.ToolMaxTorque);
            Assert.AreEqual(12.30m, mid.GearRatio);
            Assert.AreEqual(40.00m, mid.ToolFullSpeed);
            Assert.AreEqual(PrimaryTool.IRC_W, mid.PrimaryTool);
            Assert.AreEqual("Tool Model", mid.ToolModel.TrimEnd());
            Assert.AreEqual(1, mid.ToolNumber);
            Assert.AreEqual("Tool Article Number", mid.ToolArticleNumber.TrimEnd());
            Assert.AreEqual(10.00m, mid.RundownMinSpeed);
            Assert.AreEqual(320.00m, mid.DownshiftMaxSpeed);
            Assert.AreEqual(130.00m, mid.DownshiftMinSpeed);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 7"), TestCategory("ByteArray")]
        public void Mid0041ByteRevision7()
        {
            string package = "02600041007         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000150316Tool Model  17000118Tool Article Number           190010002003200021013000";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0041>(bytes);

            Assert.AreEqual("ABCDEFG-123456", mid.ToolSerialNumber.TrimEnd());
            Assert.AreEqual(4294967295L, mid.ToolNumberOfTightenings);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.LastCalibrationDate);
            Assert.AreEqual("GFEDCBA-10", mid.ControllerSerialNumber.TrimEnd());
            Assert.AreEqual(20.00m, mid.CalibrationValue);
            Assert.AreEqual(new DateTime(2018, 6, 4, 10, 12, 45), mid.LastServiceDate);
            Assert.AreEqual(4284967295L, mid.TighteningsSinceService);
            Assert.AreEqual(ToolType.STB_Tool, mid.ToolType);
            Assert.AreEqual(55, mid.MotorSize);
            Assert.IsTrue(mid.OpenEndData.UseOpenEnd);
            Assert.AreEqual(TighteningDirection.Counterclockwise, mid.OpenEndData.TighteningDirection);
            Assert.AreEqual(MotorRotation.Inverted, mid.OpenEndData.MotorRotation);
            Assert.AreEqual("Version 1.0.0", mid.ControllerSoftwareVersion.TrimEnd());
            Assert.AreEqual(6.00m, mid.ToolMaxTorque);
            Assert.AreEqual(12.30m, mid.GearRatio);
            Assert.AreEqual(40.00m, mid.ToolFullSpeed);
            Assert.AreEqual(PrimaryTool.IRC_W, mid.PrimaryTool);
            Assert.AreEqual("Tool Model", mid.ToolModel.TrimEnd());
            Assert.AreEqual(1, mid.ToolNumber);
            Assert.AreEqual("Tool Article Number", mid.ToolArticleNumber.TrimEnd());
            Assert.AreEqual(10.00m, mid.RundownMinSpeed);
            Assert.AreEqual(320.00m, mid.DownshiftMaxSpeed);
            Assert.AreEqual(130.00m, mid.DownshiftMinSpeed);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0041PackRevision1()
        {
            string package = "00810041001         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-10";

            AssertBuildAndParse(package, new Mid0041(1)
            {
                ToolSerialNumber = "ABCDEFG-123456",
                ToolNumberOfTightenings = 4294967295L,
                LastCalibrationDate = new DateTime(2017, 12, 1, 20, 12, 45),
                ControllerSerialNumber = "GFEDCBA-10"
            });
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("Pack")]
        public void Mid0041PackRevision2()
        {
            string package = "01560041002         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      ";

            AssertBuildAndParse(package, new Mid0041(2)
            {
                ToolSerialNumber = "ABCDEFG-123456",
                ToolNumberOfTightenings = 4294967295L,
                LastCalibrationDate = new DateTime(2017, 12, 1, 20, 12, 45),
                ControllerSerialNumber = "GFEDCBA-10",
                CalibrationValue = 20m,
                LastServiceDate = new DateTime(2018, 6, 4, 10, 12, 45),
                TighteningsSinceService = 4284967295L,
                ToolType = ToolType.STB_Tool,
                MotorSize = 55,
                OpenEndData = new OpenEndData()
                {
                    UseOpenEnd = true,
                    TighteningDirection = TighteningDirection.Counterclockwise,
                    MotorRotation = MotorRotation.Inverted
                },
                ControllerSoftwareVersion = "Version 1.0.0"
            });
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("Pack")]
        public void Mid0041PackRevision3()
        {
            string package = "01800041003         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000";

            AssertBuildAndParse(package, new Mid0041(3)
            {
                ToolSerialNumber = "ABCDEFG-123456",
                ToolNumberOfTightenings = 4294967295L,
                LastCalibrationDate = new DateTime(2017, 12, 1, 20, 12, 45),
                ControllerSerialNumber = "GFEDCBA-10",
                CalibrationValue = 20m,
                LastServiceDate = new DateTime(2018, 6, 4, 10, 12, 45),
                TighteningsSinceService = 4284967295L,
                ToolType = ToolType.STB_Tool,
                MotorSize = 55,
                OpenEndData = new OpenEndData()
                {
                    UseOpenEnd = true,
                    TighteningDirection = TighteningDirection.Counterclockwise,
                    MotorRotation = MotorRotation.Inverted
                },
                ControllerSoftwareVersion = "Version 1.0.0",
                ToolMaxTorque = 6m,
                GearRatio = 12.3m,
                ToolFullSpeed = 40m
            });
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("Pack")]
        public void Mid0041PackRevision4()
        {
            string package = "01840041004         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      1200060013001230140040001503";

            AssertBuildAndParse(package, new Mid0041(4)
            {
                ToolSerialNumber = "ABCDEFG-123456",
                ToolNumberOfTightenings = 4294967295L,
                LastCalibrationDate = new DateTime(2017, 12, 1, 20, 12, 45),
                ControllerSerialNumber = "GFEDCBA-10",
                CalibrationValue = 20m,
                LastServiceDate = new DateTime(2018, 6, 4, 10, 12, 45),
                TighteningsSinceService = 4284967295L,
                ToolType = ToolType.STB_Tool,
                MotorSize = 55,
                OpenEndData = new OpenEndData()
                {
                    UseOpenEnd = true,
                    TighteningDirection = TighteningDirection.Counterclockwise,
                    MotorRotation = MotorRotation.Inverted
                },
                ControllerSoftwareVersion = "Version 1.0.0",
                ToolMaxTorque = 6m,
                GearRatio = 12.3m,
                ToolFullSpeed = 40m,
                PrimaryTool = PrimaryTool.IRC_W
            });
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("Pack")]
        public void Mid0041PackRevision5()
        {
            string package = "01980041005         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000150316Tool Model  ";

            AssertBuildAndParse(package, new Mid0041(5)
            {
                ToolSerialNumber = "ABCDEFG-123456",
                ToolNumberOfTightenings = 4294967295L,
                LastCalibrationDate = new DateTime(2017, 12, 1, 20, 12, 45),
                ControllerSerialNumber = "GFEDCBA-10",
                CalibrationValue = 20m,
                LastServiceDate = new DateTime(2018, 6, 4, 10, 12, 45),
                TighteningsSinceService = 4284967295L,
                ToolType = ToolType.STB_Tool,
                MotorSize = 55,
                OpenEndData = new OpenEndData()
                {
                    UseOpenEnd = true,
                    TighteningDirection = TighteningDirection.Counterclockwise,
                    MotorRotation = MotorRotation.Inverted
                },
                ControllerSoftwareVersion = "Version 1.0.0",
                ToolMaxTorque = 6m,
                GearRatio = 12.3m,
                ToolFullSpeed = 40m,
                PrimaryTool = PrimaryTool.IRC_W,
                ToolModel = "Tool Model"
            });
        }

        [TestMethod]
        [TestCategory("Revision 6"), TestCategory("Pack")]
        public void Mid0041PackRevision6()
        {
            string package = "02360041006         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000150316Tool Model  17000118Tool Article Number           ";

            AssertBuildAndParse(package, new Mid0041(6)
            {
                ToolSerialNumber = "ABCDEFG-123456",
                ToolNumberOfTightenings = 4294967295L,
                LastCalibrationDate = new DateTime(2017, 12, 1, 20, 12, 45),
                ControllerSerialNumber = "GFEDCBA-10",
                CalibrationValue = 20m,
                LastServiceDate = new DateTime(2018, 6, 4, 10, 12, 45),
                TighteningsSinceService = 4284967295L,
                ToolType = ToolType.STB_Tool,
                MotorSize = 55,
                OpenEndData = new OpenEndData()
                {
                    UseOpenEnd = true,
                    TighteningDirection = TighteningDirection.Counterclockwise,
                    MotorRotation = MotorRotation.Inverted
                },
                ControllerSoftwareVersion = "Version 1.0.0",
                ToolMaxTorque = 6m,
                GearRatio = 12.3m,
                ToolFullSpeed = 40m,
                PrimaryTool = PrimaryTool.IRC_W,
                ToolModel = "Tool Model",
                ToolNumber = 1,
                ToolArticleNumber = "Tool Article Number"
            });
        }

        [TestMethod]
        [TestCategory("Revision 7"), TestCategory("Pack")]
        public void Mid0041PackRevision7()
        {
            string package = "02600041007         01ABCDEFG-123456024294967295032017-12-01:20:12:4504GFEDCBA-1005002000062018-06-04:10:12:45074284967295081009551011111Version 1.0.0      120006001300123014004000150316Tool Model  17000118Tool Article Number           190010002003200021013000";

            AssertBuildAndParse(package, new Mid0041(7)
            {
                ToolSerialNumber = "ABCDEFG-123456",
                ToolNumberOfTightenings = 4294967295L,
                LastCalibrationDate = new DateTime(2017, 12, 1, 20, 12, 45),
                ControllerSerialNumber = "GFEDCBA-10",
                CalibrationValue = 20m,
                LastServiceDate = new DateTime(2018, 6, 4, 10, 12, 45),
                TighteningsSinceService = 4284967295L,
                ToolType = ToolType.STB_Tool,
                MotorSize = 55,
                OpenEndData = new OpenEndData()
                {
                    UseOpenEnd = true,
                    TighteningDirection = TighteningDirection.Counterclockwise,
                    MotorRotation = MotorRotation.Inverted
                },
                ControllerSoftwareVersion = "Version 1.0.0",
                ToolMaxTorque = 6m,
                GearRatio = 12.3m,
                ToolFullSpeed = 40m,
                PrimaryTool = PrimaryTool.IRC_W,
                ToolModel = "Tool Model",
                ToolNumber = 1,
                ToolArticleNumber = "Tool Article Number",
                RundownMinSpeed = 10m,
                DownshiftMaxSpeed = 320m,
                DownshiftMinSpeed = 130m
            });
        }
    }
}
