using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDTesters.Core.Converters
{
    [TestClass]
    [TestCategory("Converters")]
    public class ByteConverterTest
    {
        [TestMethod]
        [TestCategory("Byte")]
        public void GetBit()
        {
            var bytes = BitConverter.GetBytes(3);
            Assert.AreEqual(true, OpenProtocolConvert.GetBit(bytes[0], 1));
            Assert.AreEqual(true, OpenProtocolConvert.GetBit(bytes[0], 2));
            Assert.AreEqual(false, OpenProtocolConvert.GetBit(bytes[0], 3));
            Assert.AreEqual(false, OpenProtocolConvert.GetBit(bytes[0], 4));
            Assert.AreEqual(false, OpenProtocolConvert.GetBit(bytes[0], 5));
            Assert.AreEqual(false, OpenProtocolConvert.GetBit(bytes[0], 6));
            Assert.AreEqual(false, OpenProtocolConvert.GetBit(bytes[0], 7));
            Assert.AreEqual(false, OpenProtocolConvert.GetBit(bytes[0], 8));
        }

        [TestMethod]
        [TestCategory("Byte")]
        public void ToByte()
        {
            var booleans = new bool[]
            {
                false,
                true,
                false,
                false,
                true,
                true,
                false,
                true
            };

            var bytes = new byte[8];
            bytes[0] = OpenProtocolConvert.ToByte(booleans);
            var value = BitConverter.ToInt64(bytes, 0);
            Assert.AreEqual(178L, value);
        }
    }
}
