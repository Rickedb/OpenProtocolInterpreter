using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using System.Threading;
using System.Threading.Tasks;

namespace MIDTesters.Core.Converters
{
    [TestClass]
    [TestCategory("Converters")]
    public class DecimalConverterTest
    {
        [TestMethod]
        [TestCategory("Decimal")]
        public void DecimalToFloorString()
        {
            var value = 23.31231m;
            Assert.AreEqual("23.3123", OpenProtocolConvert.ToString(value));
        }

        [TestMethod]
        [TestCategory("Decimal")]
        public void DecimalToRoundString()
        {
            var value = 23.31237m;
            Assert.AreEqual("23.3124", OpenProtocolConvert.ToString(value));
        }

        [TestMethod]
        [TestCategory("Decimal")]
        public void DecimalToFloorPaddedString()
        {
            var value = 3.31231m;
            Assert.AreEqual("03.3123", OpenProtocolConvert.ToString('0', 7, PaddingOrientation.LeftPadded, value));
        }

        [TestMethod]
        [TestCategory("Decimal")]
        public void DecimalToRoundPaddedString()
        {
            var value = 3.31239m;
            Assert.AreEqual("03.3124", OpenProtocolConvert.ToString('0', 7, PaddingOrientation.LeftPadded, value));
        }

        [TestMethod]
        [TestCategory("Decimal")]
        public void StringToDecimal()
        {
            var value = "33.31239";
            var result = OpenProtocolConvert.ToDecimal(value);
            Assert.AreEqual(33.31239m, result);
        }

        [TestMethod]
        [TestCategory("Decimal")]
        public void ZeroPaddedStringToDecimal()
        {
            var value = "03.3123";
            var result = OpenProtocolConvert.ToDecimal(value);
            Assert.AreEqual(3.3123m, result);
        }

        [TestMethod]
        [TestCategory("Decimal")]
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
