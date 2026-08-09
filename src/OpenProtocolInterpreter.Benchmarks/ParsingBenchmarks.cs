using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Text;

namespace OpenProtocolInterpreter.Benchmarks
{
    public class ParsingBenchmarks
    {
        private static readonly Encoding NonDefaultEncoding = Encoding.UTF8;

        private MidInterpreter _interpreter;
        private byte[] _bytes;

        [ParamsSource(nameof(PackageCases))]
        public PackageCase Package { get; set; }

        public static IEnumerable<PackageCase> PackageCases()
        {
            yield return new PackageCase("Mid0060 header", Packages.Mid0060Rev998);
            yield return new PackageCase("Mid0035 r3", Packages.Mid0035Rev3);
            yield return new PackageCase("Mid0061 r1", Packages.Mid0061Rev1);
            yield return new PackageCase("Mid0101 r1 list", Packages.Mid0101Rev1);
            yield return new PackageCase("Mid0061 r11", Packages.Mid0061Rev11);
        }

        [GlobalSetup]
        public void Setup()
        {
            _interpreter = new MidInterpreter().UseAllMessages();
            _bytes = Packages.ToBytes(Package.Value);

            // Materialize the templates so the first measured iteration is not the one paying for them.
            _interpreter.Parse(Package.Value);
        }

        [Benchmark(Description = "Parse(string)", Baseline = true)]
        public Mid ParseString() => _interpreter.Parse(Package.Value);

        [Benchmark(Description = "Parse(byte[])")]
        public Mid ParseBytes() => _interpreter.Parse(_bytes);

        [Benchmark(Description = "Parse(byte[], encoding)")]
        public Mid ParseBytesWithEncoding() => _interpreter.Parse(_bytes, NonDefaultEncoding);

        public readonly struct PackageCase
        {
            public PackageCase(string name, string value)
            {
                Name = name;
                Value = value;
            }

            public string Name { get; }

            public string Value { get; }

            public override string ToString() => $"{Name} ({Value.Length}B)";
        }
    }
}
