using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PowerMACS;

namespace MIDTesters.PowerMACS
{
    [TestClass]
    public class TestMid0106 : MidTester
    {
        [TestMethod]
        public void Revision1()
        {
            string pack = @"05050106            010502010300000381270401050231                062017-05-25:09:51:38071108Ap.320Nm Diant.P11  091101119BM384069HB066171                       1204130114115116117329.9091835.854019360.00020310.000219999.002200.0000130214115116117328.7361836.102219360.00020310.000219999.002200.0000130314115116117356.04518763.97619370.00020304.000219999.002200.0000130414115116117355.40718380.87219370.00020304.000219999.002200.00002302Data No Station     I 100000027897Free No 1           I 100000000002";
            var mid = _midInterpreter.Parse<MID_0106>(pack);


            Assert.AreEqual(typeof(MID_0106), mid.GetType());
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
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
