using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Statistic;

namespace MIDTesters.Statistic
{
    [TestClass]
    public class TestMid0301 : MidTester
    {
        [TestMethod]
        public void Mid0301Revision1()
        {
            string package = "01070301            010020205031234560465432105999999061111072222083333094444105555116666127777138888149999";
            var mid = _midInterpreter.Parse<MID_0301>(package);

            Assert.AreEqual(typeof(MID_0301), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.HistogramType);
            Assert.IsNotNull(mid.SigmaHistogram);
            Assert.IsNotNull(mid.MeanValueHistogram);
            Assert.IsNotNull(mid.ClassRange);
            Assert.IsNotNull(mid.FirstBar);
            Assert.IsNotNull(mid.SecondBar);
            Assert.IsNotNull(mid.ThirdBar);
            Assert.IsNotNull(mid.FourthBar);
            Assert.IsNotNull(mid.FifthBar);
            Assert.IsNotNull(mid.SixthBar);
            Assert.IsNotNull(mid.SeventhBar);
            Assert.IsNotNull(mid.EighthBar);
            Assert.IsNotNull(mid.NinethBar);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
