using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Communication;
using System;
using System.Text;

namespace MIDTesters
{
    /// <summary>
    /// <see cref="Mid.DefaultEncoding"/> is a global setting, so this class must never run alongside
    /// the other tests, otherwise they would pack/parse their packages with the encoding set here.
    /// </summary>
    [TestClass]
    [TestCategory("Encoding")]
    [DoNotParallelize]
    public class TestMidEncoding
    {
        private const string NonAsciiControllerName = "Estação";

        private readonly MidInterpreter _midInterpreter;

        public TestMidEncoding()
        {
            _midInterpreter = new MidInterpreter().UseAllMessages();
        }

        [TestCleanup]
        public void RestoreDefaultEncoding() => Mid.DefaultEncoding = Encoding.ASCII;

        private static Mid0002 BuildMid() => new(revision: 1)
        {
            CellId = 1,
            ChannelId = 1,
            ControllerName = NonAsciiControllerName
        };

        [TestMethod]
        public void TestDefaultEncodingIsAscii()
        {
            Assert.AreEqual(Encoding.ASCII, Mid.DefaultEncoding);
        }

        [TestMethod]
        public void TestDefaultEncodingDoesNotAcceptNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Mid.DefaultEncoding = null);
            Assert.AreEqual(Encoding.ASCII, Mid.DefaultEncoding);
        }

        [TestMethod]
        public void TestPackBytesUsesDefaultEncoding()
        {
            var mid = BuildMid();
            var package = mid.Pack();

            Mid.DefaultEncoding = Encoding.Latin1;

            CollectionAssert.AreEqual(Encoding.Latin1.GetBytes(package), mid.PackBytes());
        }

        [TestMethod]
        public void TestPackBytesWithNulUsesDefaultEncoding()
        {
            var mid = BuildMid();
            var package = mid.Pack();

            Mid.DefaultEncoding = Encoding.Latin1;

            CollectionAssert.AreEqual(Encoding.Latin1.GetBytes(package + '\0'), mid.PackBytesWithNul());
        }

        [TestMethod]
        public void TestPackBytesWithGivenEncodingDoesNotChangeTheDefault()
        {
            var mid = BuildMid();
            var package = mid.Pack();

            CollectionAssert.AreEqual(Encoding.UTF8.GetBytes(package), mid.PackBytes(Encoding.UTF8));
            CollectionAssert.AreEqual(Encoding.UTF8.GetBytes(package + '\0'), mid.PackBytesWithNul(Encoding.UTF8));
            Assert.AreEqual(Encoding.ASCII, Mid.DefaultEncoding);
            CollectionAssert.AreEqual(Encoding.ASCII.GetBytes(package), mid.PackBytes());
        }

        [TestMethod]
        public void TestParseUsesDefaultEncoding()
        {
            Mid.DefaultEncoding = Encoding.Latin1;

            var bytes = BuildMid().PackBytes();
            var parsed = _midInterpreter.Parse<Mid0002>(bytes);

            Assert.AreEqual(NonAsciiControllerName, parsed.ControllerName.Trim());
        }

        [TestMethod]
        public void TestParseWithGivenEncodingDoesNotChangeTheDefault()
        {
            var bytes = BuildMid().PackBytes(Encoding.Latin1);

            var parsed = _midInterpreter.Parse<Mid0002>(bytes, Encoding.Latin1);

            Assert.AreEqual(NonAsciiControllerName, parsed.ControllerName.Trim());
            Assert.AreEqual(Encoding.ASCII, Mid.DefaultEncoding);
        }

        [TestMethod]
        public void TestParseFromMidInstanceUsesGivenEncoding()
        {
            var bytes = BuildMid().PackBytes(Encoding.Latin1);

            var parsed = (Mid0002)new Mid0002(revision: 1).Parse(bytes, Encoding.Latin1);

            Assert.AreEqual(NonAsciiControllerName, parsed.ControllerName.Trim());
        }

        [TestMethod]
        public void TestAsciiEncodingReplacesNonAsciiCharacters()
        {
            var parsed = _midInterpreter.Parse<Mid0002>(BuildMid().PackBytes());

            Assert.AreEqual("Esta??o", parsed.ControllerName.Trim());
        }
    }
}
