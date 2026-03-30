using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Statistic;

namespace MIDTesters.Statistic
{
    [TestClass]
    [TestCategory("Statistic")]
    public class TestMid0301 : DefaultMidTests<Mid0301>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0301Revision1()
        {
            string package = "01070301            010020205031234560465432105999999061111072222083333094444105555116666127777138888149999";
            var mid = _midInterpreter.Parse<Mid0301>(package);

            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(HistogramType.RundownAngle, mid.HistogramType);
            Assert.AreEqual(1234.56m, mid.SigmaHistogram);
            Assert.AreEqual(6543.21m, mid.MeanValueHistogram);
            Assert.AreEqual(9999.99m, mid.ClassRange);
            Assert.AreEqual(1111, mid.FirstBar);
            Assert.AreEqual(2222, mid.SecondBar);
            Assert.AreEqual(3333, mid.ThirdBar);
            Assert.AreEqual(4444, mid.FourthBar);
            Assert.AreEqual(5555, mid.FifthBar);
            Assert.AreEqual(6666, mid.SixthBar);
            Assert.AreEqual(7777, mid.SeventhBar);
            Assert.AreEqual(8888, mid.EighthBar);
            Assert.AreEqual(9999, mid.NinethBar);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0301ByteRevision1()
        {
            string package = "01070301            010020205031234560465432105999999061111072222083333094444105555116666127777138888149999";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0301>(bytes);

            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(HistogramType.RundownAngle, mid.HistogramType);
            Assert.AreEqual(1234.56m, mid.SigmaHistogram);
            Assert.AreEqual(6543.21m, mid.MeanValueHistogram);
            Assert.AreEqual(9999.99m, mid.ClassRange);
            Assert.AreEqual(1111, mid.FirstBar);
            Assert.AreEqual(2222, mid.SecondBar);
            Assert.AreEqual(3333, mid.ThirdBar);
            Assert.AreEqual(4444, mid.FourthBar);
            Assert.AreEqual(5555, mid.FifthBar);
            Assert.AreEqual(6666, mid.SixthBar);
            Assert.AreEqual(7777, mid.SeventhBar);
            Assert.AreEqual(8888, mid.EighthBar);
            Assert.AreEqual(9999, mid.NinethBar);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
