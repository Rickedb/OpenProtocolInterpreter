using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PowerMACS;

namespace MIDTesters.PowerMACS
{
    [TestClass]
    public class TestMid0106 : DefaultMidTests<Mid0106>
    {
        [TestMethod]
        public void Mid0106Revision1()
        {
            string pack = @"05050106            010502010300000381270401050231                062017-05-25:09:51:38071108Ap.320Nm Diant.P11  091101119BM384069HB066171                       1204130114115116117329.9091835.854019360.00020310.000219999.002200.0000130214115116117328.73618-06.10219360.00020310.000219999.002200.0000130314115116117356.04518763.97619370.00020304.000219999.002200.0000130414115116117355.40718380.87219370.00020304.000219999.002200.00002302Data No Station     I 100000027897Free No 1           I 100000000002";
            var mid = _midInterpreter.Parse<Mid0106>(pack);

            Assert.IsNotNull(mid.TotalNumberOfMessages);
            Assert.IsNotNull(mid.MessageNumber);
            Assert.IsNotNull(mid.DataNumberSystem);
            Assert.IsNotNull(mid.StationNumber);
            Assert.IsNotNull(mid.StationName);
            Assert.IsNotNull(mid.Time);
            Assert.IsNotNull(mid.ModeNumber);
            Assert.IsNotNull(mid.ModeName);
            Assert.IsNotNull(mid.SimpleStatus);
            Assert.IsNotNull(mid.PMStatus);
            Assert.IsNotNull(mid.WpId);
            Assert.IsNotNull(mid.NumberOfBolts);
            Assert.IsNotNull(mid.BoltsData);
            Assert.IsNotNull(mid.TotalSpecialValues);
            Assert.IsNotNull(mid.SpecialValues);
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        public void Mid0106ByteRevision1()
        {
            string package = @"05050106            010502010300000381270401050231                062017-05-25:09:51:38071108Ap.320Nm Diant.P11  091101119BM384069HB066171                       1204130114115116117329.9091835.854019360.00020310.000219999.002200.0000130214115116117328.73618-06.10219360.00020310.000219999.002200.0000130314115116117356.04518763.97619370.00020304.000219999.002200.0000130414115116117355.40718380.87219370.00020304.000219999.002200.00002302Data No Station     I 100000027897Free No 1           I 100000000002";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0106>(bytes);

            Assert.IsNotNull(mid.TotalNumberOfMessages);
            Assert.IsNotNull(mid.MessageNumber);
            Assert.IsNotNull(mid.DataNumberSystem);
            Assert.IsNotNull(mid.StationNumber);
            Assert.IsNotNull(mid.StationName);
            Assert.IsNotNull(mid.Time);
            Assert.IsNotNull(mid.ModeNumber);
            Assert.IsNotNull(mid.ModeName);
            Assert.IsNotNull(mid.SimpleStatus);
            Assert.IsNotNull(mid.PMStatus);
            Assert.IsNotNull(mid.WpId);
            Assert.IsNotNull(mid.NumberOfBolts);
            Assert.IsNotNull(mid.BoltsData);
            Assert.IsNotNull(mid.TotalSpecialValues);
            Assert.IsNotNull(mid.SpecialValues);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
