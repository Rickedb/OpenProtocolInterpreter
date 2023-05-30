using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;

namespace MIDTesters.Core.Converters
{
    [TestClass]
    [TestCategory("Converters")]
    public class PaddingConverterTest
    {
        [TestMethod]
        [TestCategory("Padding")]
        public void LeftPaddingTest()
        {
            Assert.AreEqual("       ABC", OpenProtocolConvert.TruncatePadded(' ', 10, PaddingOrientation.LeftPadded, "ABC"));
        }

        [TestMethod]
        [TestCategory("Padding")]
        public void RightPaddingTest()
        {
            Assert.AreEqual("ABC       ", OpenProtocolConvert.TruncatePadded(' ', 10, PaddingOrientation.RightPadded, "ABC"));
        }
    }
}
