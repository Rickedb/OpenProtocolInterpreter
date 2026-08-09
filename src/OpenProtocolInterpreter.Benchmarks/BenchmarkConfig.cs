namespace OpenProtocolInterpreter.Benchmarks
{
    using BenchmarkDotNet.Columns;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Order;
    using BenchmarkDotNet.Reports;
    using Job = BenchmarkDotNet.Jobs.Job;

    internal static class BenchmarkConfig
    {
        public static IConfig Create() => Create(Job.Default);

        public static IConfig CreateQuick() => Create(Job.ShortRun);

        private static IConfig Create(Job job)
        {
            return ManualConfig.Create(DefaultConfig.Instance)
                               .AddJob(job)
                               .AddDiagnoser(MemoryDiagnoser.Default)
                               .AddColumn(RankColumn.Arabic)
                               .WithOrderer(new DefaultOrderer(SummaryOrderPolicy.Declared, MethodOrderPolicy.Declared))
                               .WithSummaryStyle(SummaryStyle.Default
                                                             .WithRatioStyle(RatioStyle.Trend)
                                                             .WithMaxParameterColumnWidth(30));
        }
    }
}
