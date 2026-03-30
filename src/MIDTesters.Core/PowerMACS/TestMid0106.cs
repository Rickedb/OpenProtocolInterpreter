using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.PowerMACS;
using System;

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
    }
}
