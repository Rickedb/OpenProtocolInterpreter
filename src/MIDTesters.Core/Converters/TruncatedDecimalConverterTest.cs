using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using System.Threading;
using System.Threading.Tasks;

namespace MIDTesters.Core.Converters
{
    [TestClass]
    [TestCategory("Converters")]
    public class TruncatedDecimalConverterTest
    {
        [TestMethod]
        [TestCategory("TruncatedDecimal")]
        public void DecimalToFloorString()
        {
            var value = 23.31231m;
            Assert.AreEqual("2331", OpenProtocolConvert.TruncatedDecimalToString(value));
        }

        [TestMethod]
        [TestCategory("TruncatedDecimal")]
        public void DecimalToRoundString()
        {
            var value = 23.31837m;
            Assert.AreEqual("2332", OpenProtocolConvert.TruncatedDecimalToString(value));
        }

        [TestMethod]
        [TestCategory("TruncatedDecimal")]
        public void DecimalToFloorPaddedString()
        {
            var value = 3.31231m;
            Assert.AreEqual("0000331", OpenProtocolConvert.TruncatedDecimalToString('0', 7, DataField.PaddingOrientations.LeftPadded, value));
        }

        [TestMethod]
        [TestCategory("TruncatedDecimal")]
        public void DecimalToRoundPaddedString()
        {
            var value = 3.31739m;
            Assert.AreEqual("0000332", OpenProtocolConvert.TruncatedDecimalToString('0', 7, DataField.PaddingOrientations.LeftPadded, value));
        }

        [TestMethod]
        [TestCategory("TruncatedDecimal")]
        public void StringToDecimal()
        {
            var value = "31239";
            var result = OpenProtocolConvert.ToTruncatedDecimal(value);
            Assert.AreEqual(312.39m, result);
        }

        [TestMethod]
        [TestCategory("TruncatedDecimal")]
        public void ZeroPaddedStringToDecimal()
        {
            var value = "03123";
            var result = OpenProtocolConvert.ToTruncatedDecimal(value);
            Assert.AreEqual(31.23m, result);
        }

        [TestMethod]
        [TestCategory("TruncatedDecimal")]
        public void ConcurrencyTest()
        {
            var iterations = 10000;
            var done = new CountdownEvent(iterations);
            var result = Parallel.For(0, iterations, x =>
            {
                DecimalToFloorString();
                DecimalToRoundString();
                DecimalToFloorPaddedString();
                DecimalToRoundPaddedString();
                StringToDecimal();
                ZeroPaddedStringToDecimal();
                done.Signal();
            });

            done.Wait();
        }
    }
}
