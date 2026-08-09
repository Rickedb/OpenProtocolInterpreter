using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.MotorTuning;
using OpenProtocolInterpreter.Tightening;
using System;

namespace OpenProtocolInterpreter.Benchmarks
{
    [CategoriesColumn]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public class RegistrationBenchmarks
    {
        private const string Registering = "Registering";
        private const string ColdStart = "Cold start";

        private static readonly Type[] CuratedMids =
        [
            typeof(Mid0001),
            typeof(Mid0002),
            typeof(Mid0003),
            typeof(Mid0004),
            typeof(Mid0061),
            typeof(Mid0500),
            typeof(Mid0501),
            typeof(Mid0502),
            typeof(Mid0503),
            typeof(Mid0504)
        ];

        [BenchmarkCategory(Registering)]
        [Benchmark(Description = "UseAllMessages()", Baseline = true)]
        public MidInterpreter RegisterAll() => new MidInterpreter().UseAllMessages();

        [BenchmarkCategory(Registering)]
        [Benchmark(Description = "UseAllMessages(Type[]) - 10 mids")]
        public MidInterpreter RegisterCurated() => new MidInterpreter().UseAllMessages(CuratedMids);

        [BenchmarkCategory(Registering)]
        [Benchmark(Description = "UseTighteningMessages() only")]
        public MidInterpreter RegisterSingleFamily() => new MidInterpreter().UseTighteningMessages();

        [BenchmarkCategory(ColdStart)]
        [Benchmark(Description = "UseAllMessages() + first parse", Baseline = true)]
        public Mid ColdStartAll() => new MidInterpreter().UseAllMessages().Parse(Packages.Mid0061Rev1);

        [BenchmarkCategory(ColdStart)]
        [Benchmark(Description = "UseAllMessages(Type[]) + first parse")]
        public Mid ColdStartCurated() => new MidInterpreter().UseAllMessages(CuratedMids).Parse(Packages.Mid0061Rev1);

        [BenchmarkCategory(ColdStart)]
        [Benchmark(Description = "UseTighteningMessages() + first parse")]
        public Mid ColdStartSingleFamily() => new MidInterpreter().UseTighteningMessages().Parse(Packages.Mid0061Rev1);
    }
}
