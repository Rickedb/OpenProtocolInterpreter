using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using System.Threading;
using System.Threading.Tasks;

namespace MIDTesters.Core.Converters
{
    [TestClass]
    [TestCategory("Converters")]
    public class Int32ConverterTest
    {
        [TestMethod]
        [TestCategory("Int32")]
        public void Int32ToString()
        {
            Assert.AreEqual("10", OpenProtocolConvert.ToString(10));
        }

        [TestMethod]
        [TestCategory("Int32")]
        public void Int32ToPaddedString()
        {
            Assert.AreEqual("0010", OpenProtocolConvert.ToString('0', 4, PaddingOrientation.LeftPadded, 10));
        }

        [TestMethod]
        [TestCategory("Int32")]
        public void StringToInt32()
        {
            Assert.AreEqual(10, OpenProtocolConvert.ToInt32("10"));
        }

        [TestMethod]
        [TestCategory("Int32")]
        public void PaddedStringToInt32()
        {
            Assert.AreEqual(10, OpenProtocolConvert.ToInt32("0010"));
        }

        [TestMethod]
        [TestCategory("Int32")]
        public void ConcurrencyTest()
        {
            var iterations = 10000;
            var done = new CountdownEvent(iterations);
            var result = Parallel.For(0, iterations, x =>
            {
                Int32ToString();
                Int32ToPaddedString();
                StringToInt32();
                PaddedStringToInt32();
                done.Signal();
            });

            done.Wait();
        }
    }
}
