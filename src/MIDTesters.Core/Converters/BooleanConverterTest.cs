using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using System.Threading;
using System.Threading.Tasks;

namespace MIDTesters.Core.Converters
{
    [TestClass]
    [TestCategory("Converters")]
    public class BooleanConverterTest
    {
        [TestMethod]
        [TestCategory("Boolean")]
        public void BooleanToString()
        {
            Assert.AreEqual("1", OpenProtocolConvert.ToString(true));
            Assert.AreEqual("0", OpenProtocolConvert.ToString(false));
        }

        [TestMethod]
        [TestCategory("Boolean")]
        public void BooleanToPaddedString()
        {
            Assert.AreEqual("1", OpenProtocolConvert.ToString('0', 1, DataField.PaddingOrientations.LeftPadded, true));
            Assert.AreEqual("0", OpenProtocolConvert.ToString('0', 1, DataField.PaddingOrientations.LeftPadded, false));
        }

        [TestMethod]
        [TestCategory("Boolean")]
        public void StringToBoolean()
        {
            Assert.AreEqual(true, OpenProtocolConvert.ToBoolean("1"));
            Assert.AreEqual(false, OpenProtocolConvert.ToBoolean("0"));
            Assert.AreEqual(true, OpenProtocolConvert.ToBoolean("-123"));
        }

        [TestMethod]
        [TestCategory("Boolean")]
        public void ConcurrencyTest()
        {
            var iterations = 10000;
            var done = new CountdownEvent(iterations);
            var result = Parallel.For(0, iterations, x =>
            {
                BooleanToString();
                BooleanToPaddedString();
                StringToBoolean();
                done.Signal();
            });

            done.Wait();
        }
    }
}
