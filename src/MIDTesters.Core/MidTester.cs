using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIDTesters
{
    public abstract class MidTester
    {
        protected readonly MidInterpreter _midInterpreter;

        public MidTester()
        {
            _midInterpreter = new MidInterpreter().UseAllMessages();
        }

        protected byte[] GetAsciiBytes(string package) => Encoding.ASCII.GetBytes(package);
        protected byte[] GetAsciiBytes(byte[] package, int byteLength)
        {
            var asciiInt = (byteLength > 8 ? BitConverter.ToInt64(package, 0) : BitConverter.ToInt32(package, 0)).ToString().PadLeft(byteLength, '0');
            return Encoding.ASCII.GetBytes(asciiInt);
        }

        protected void AssertEqualPackages(string expected, Mid mid, bool useEmptyRevision = false)
        {
            if(useEmptyRevision)
            {
                mid.Header.Revision = 0;
            }

            mid.Header.StationId = mid.Header.SpindleId = null;
            Assert.AreEqual(expected, mid.Pack());
        }

        protected void AssertEqualPackages(IEnumerable<byte> expected, Mid mid, bool useEmptyRevision = false)
        {
            if (useEmptyRevision)
            {
                mid.Header.Revision = 0;
            }

            mid.Header.StationId = mid.Header.SpindleId = null;
            Assert.IsTrue(mid.PackBytes().SequenceEqual(expected));
        }
    }
}
