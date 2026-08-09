using BenchmarkDotNet.Attributes;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.KeepAlive;
using OpenProtocolInterpreter.Tightening;
using System.Text;

namespace OpenProtocolInterpreter.Benchmarks
{
    /// <summary>
    /// Measures the other half of the round trip: turning a mid back into the package that goes on the wire.
    /// <para>
    ///     Packing is what a driver does on every message it sends, and <see cref="Mid.PackBytes()"/> is
    ///     <see cref="Mid.Pack()"/> plus an encode, so the pair shows what the encode step costs on top.
    /// </para>
    /// </summary>
    public class PackingBenchmarks
    {
        private static readonly Encoding NonDefaultEncoding = Encoding.UTF8;

        private Mid9999 _keepAlive;
        private Mid0001 _communicationStart;
        private Mid0061 _tighteningResult;
        private Mid0061 _wideTighteningResult;

        [GlobalSetup]
        public void Setup()
        {
            var interpreter = new MidInterpreter().UseAllMessages();

            _keepAlive = new Mid9999();
            _communicationStart = interpreter.Parse<Mid0001>(Packages.Mid0001Rev7);
            _tighteningResult = interpreter.Parse<Mid0061>(Packages.Mid0061Rev1);
            _wideTighteningResult = interpreter.Parse<Mid0061>(Packages.Mid0061Rev11);
        }

        [Benchmark(Description = "Pack Mid9999 (header only)")]
        public string PackKeepAlive() => _keepAlive.Pack();

        [Benchmark(Description = "Pack Mid0001 (23B)")]
        public string PackCommunicationStart() => _communicationStart.Pack();

        [Benchmark(Description = "Pack Mid0061 rev 1 (231B)", Baseline = true)]
        public string PackTighteningResult() => _tighteningResult.Pack();

        [Benchmark(Description = "Pack Mid0061 rev 11 (677B)")]
        public string PackWideTighteningResult() => _wideTighteningResult.Pack();

        [Benchmark(Description = "PackBytes Mid0061 rev 1 (default encoding)")]
        public byte[] PackBytesTighteningResult() => _tighteningResult.PackBytes();

        [Benchmark(Description = "PackBytes Mid0061 rev 1 (explicit encoding)")]
        public byte[] PackBytesTighteningResultWithEncoding() => _tighteningResult.PackBytes(NonDefaultEncoding);

        [Benchmark(Description = "PackBytes Mid0061 rev 11 (default encoding)")]
        public byte[] PackBytesWideTighteningResult() => _wideTighteningResult.PackBytes();
    }
}
