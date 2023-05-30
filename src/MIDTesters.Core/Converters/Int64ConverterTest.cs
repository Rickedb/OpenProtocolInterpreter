using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using System.Threading;
using System.Threading.Tasks;

namespace MIDTesters.Core.Converters
{
    [TestClass]
    [TestCategory("Converters")]
    public class Int64ConverterTest
    {
        [TestMethod]
        [TestCategory("Int64")]
        public void Int64ToString()
        {
            Assert.AreEqual("10", OpenProtocolConvert.ToString(10L));
        }

        [TestMethod]
        [TestCategory("Int64")]
        public void Int64ToPaddedString()
        {
            Assert.AreEqual("0010", OpenProtocolConvert.ToString('0', 4, DataField.PaddingOrientations.LeftPadded, 10L));
        }

        [TestMethod]
        [TestCategory("Int64")]
        public void StringToInt64()
        {
            Assert.AreEqual(10L, OpenProtocolConvert.ToInt64("10"));
        }

        [TestMethod]
        [TestCategory("Int64")]
        public void PaddedStringToInt64()
        {
            Assert.AreEqual(10L, OpenProtocolConvert.ToInt64("0010"));
        }

        [TestMethod]
        [TestCategory("Int64")]
        public void ConcurrencyTest()
        {
            var iterations = 10000;
            var done = new CountdownEvent(iterations);
            var result = Parallel.For(0, iterations, x =>
            {
                Int64ToString();
                Int64ToPaddedString();
                StringToInt64();
                PaddedStringToInt64();
                done.Signal();
            });

            done.Wait();
        }
    }
}
