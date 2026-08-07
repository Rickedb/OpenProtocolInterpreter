using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.PowerMACS;
using System;

using System.Collections.Generic;
namespace MIDTesters.PowerMACS
{
    [TestClass]
    [TestCategory("PowerMACS")]
    public class TestMid0106 : DefaultMidTests<Mid0106>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0106Revision1()
        {
            string pack = @"05050106            010502010300000381270401050231                062017-05-25:09:51:38071108Ap.320Nm Diant.P11  091101119BM384069HB066171                       1204130114115116117329.9091835.854019360.00020310.000219999.002200.0000130214115116117328.73618-06.10219360.00020310.000219999.002200.0000130314115116117356.04518763.97619370.00020304.000219999.002200.0000130414115116117355.40718380.87219370.00020304.000219999.002200.00002302Data No Station     I 100000027897Free No 1           I 100000000002";
            var mid = _midInterpreter.Parse<Mid0106>(pack);

            Assert.AreEqual(5, mid.TotalNumberOfMessages);
            Assert.AreEqual(1, mid.MessageNumber);
            Assert.AreEqual(38127, mid.DataNumberSystem);
            Assert.AreEqual(1, mid.StationNumber);
            Assert.AreEqual("0231", mid.StationName.TrimEnd());
            Assert.AreEqual(new DateTime(2017, 5, 25, 9, 51, 38), mid.Time);
            Assert.AreEqual(11, mid.ModeNumber);
            Assert.AreEqual("Ap.320Nm Diant.P11", mid.ModeName.TrimEnd());
            Assert.IsTrue(mid.SimpleStatus);
            Assert.AreEqual(PowerMacsStatus.Okr, mid.PMStatus);
            Assert.AreEqual("9BM384069HB066171", mid.WpId.TrimEnd());
            Assert.AreEqual(4, mid.NumberOfBolts);
            Assert.AreEqual(4, mid.BoltsData.Count);
            Assert.AreEqual(2, mid.TotalSpecialValues);
            Assert.AreEqual(2, mid.SpecialValues.Count);
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0106ByteRevision1()
        {
            string package = @"05050106            010502010300000381270401050231                062017-05-25:09:51:38071108Ap.320Nm Diant.P11  091101119BM384069HB066171                       1204130114115116117329.9091835.854019360.00020310.000219999.002200.0000130214115116117328.73618-06.10219360.00020310.000219999.002200.0000130314115116117356.04518763.97619370.00020304.000219999.002200.0000130414115116117355.40718380.87219370.00020304.000219999.002200.00002302Data No Station     I 100000027897Free No 1           I 100000000002";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0106>(bytes);

            Assert.AreEqual(5, mid.TotalNumberOfMessages);
            Assert.AreEqual(1, mid.MessageNumber);
            Assert.AreEqual(38127, mid.DataNumberSystem);
            Assert.AreEqual(1, mid.StationNumber);
            Assert.AreEqual("0231", mid.StationName.TrimEnd());
            Assert.AreEqual(new DateTime(2017, 5, 25, 9, 51, 38), mid.Time);
            Assert.AreEqual(11, mid.ModeNumber);
            Assert.AreEqual("Ap.320Nm Diant.P11", mid.ModeName.TrimEnd());
            Assert.IsTrue(mid.SimpleStatus);
            Assert.AreEqual(PowerMacsStatus.Okr, mid.PMStatus);
            Assert.AreEqual("9BM384069HB066171", mid.WpId.TrimEnd());
            Assert.AreEqual(4, mid.NumberOfBolts);
            Assert.AreEqual(4, mid.BoltsData.Count);
            Assert.AreEqual(2, mid.TotalSpecialValues);
            Assert.AreEqual(2, mid.SpecialValues.Count);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0106PackRevision1()
        {
            string package = "05050106            010502010300000381270401050231                062017-05-25:09:51:38071108Ap.320Nm Diant.P11  091101119BM384069HB066171                       1204130114115116117329.9091835.854019360.00020310.000219999.002200.0000130214115116117328.73618-06.10219360.00020310.000219999.002200.0000130314115116117356.04518763.97619370.00020304.000219999.002200.0000130414115116117355.40718380.87219370.00020304.000219999.002200.00002302Data No Station     I 100000027897Free No 1           I 100000000002";

            AssertBuildAndParse(package, new Mid0106(1)
            {
                TotalNumberOfMessages = 5,
                MessageNumber = 1,
                DataNumberSystem = 38127L,
                StationNumber = 1,
                StationName = "0231",
                Time = new DateTime(2017, 5, 25, 9, 51, 38),
                ModeNumber = 11,
                ModeName = "Ap.320Nm Diant.P11",
                SimpleStatus = true,
                PMStatus = PowerMacsStatus.Okr,
                WpId = "9BM384069HB066171",
                NumberOfBolts = 4,
                BoltsData = new List<BoltData>()
                {
                    new BoltData()
                    {
                        OrdinalBoltNumber = 1,
                        SimpleBoltStatus = true,
                        TorqueStatus = TorqueStatus.BoltTorqueOk,
                        AngleStatus = AngleStatus.BoltAngleOk,
                        BoltTorque = 329.909m,
                        BoltAngle = 35.8540m,
                        BoltTorqueHighLimit = 360.000m,
                        BoltTorqueLowLimit = 310.000m,
                        BoltAngleHighLimit = 9999.00m,
                        BoltAngleLowLimit = 0.0000m
                    },
                    new BoltData()
                    {
                        OrdinalBoltNumber = 2,
                        SimpleBoltStatus = true,
                        TorqueStatus = TorqueStatus.BoltTorqueOk,
                        AngleStatus = AngleStatus.BoltAngleOk,
                        BoltTorque = 328.736m,
                        BoltAngle = -6.102m,
                        BoltTorqueHighLimit = 360.000m,
                        BoltTorqueLowLimit = 310.000m,
                        BoltAngleHighLimit = 9999.00m,
                        BoltAngleLowLimit = 0.0000m
                    },
                    new BoltData()
                    {
                        OrdinalBoltNumber = 3,
                        SimpleBoltStatus = true,
                        TorqueStatus = TorqueStatus.BoltTorqueOk,
                        AngleStatus = AngleStatus.BoltAngleOk,
                        BoltTorque = 356.045m,
                        BoltAngle = 763.976m,
                        BoltTorqueHighLimit = 370.000m,
                        BoltTorqueLowLimit = 304.000m,
                        BoltAngleHighLimit = 9999.00m,
                        BoltAngleLowLimit = 0.0000m
                    },
                    new BoltData()
                    {
                        OrdinalBoltNumber = 4,
                        SimpleBoltStatus = true,
                        TorqueStatus = TorqueStatus.BoltTorqueOk,
                        AngleStatus = AngleStatus.BoltAngleOk,
                        BoltTorque = 355.407m,
                        BoltAngle = 380.872m,
                        BoltTorqueHighLimit = 370.000m,
                        BoltTorqueLowLimit = 304.000m,
                        BoltAngleHighLimit = 9999.00m,
                        BoltAngleLowLimit = 0.0000m
                    }
                },
                SpecialValues = new List<SpecialValue>()
                {
                    new SpecialValue()
                    {
                        VariableName = "Data No Station",
                        Type = "I",
                        Length = 10,
                        Value = "0000027897",
                        StepNumber = 0
                    },
                    new SpecialValue()
                    {
                        VariableName = "Free No 1",
                        Type = "I",
                        Length = 10,
                        Value = "0000000002",
                        StepNumber = 0
                    }
                }
            }, true);
        }
    }
}
