using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using OpenProtocolInterpreter.Benchmarks;
using System;
using System.Linq;
using System.Reflection;

var quick = args.Contains("--quick", StringComparer.OrdinalIgnoreCase);
var remaining = args.Where(x => !string.Equals(x, "--quick", StringComparison.OrdinalIgnoreCase)).ToList();
IConfig config = quick ? BenchmarkConfig.CreateQuick() : BenchmarkConfig.Create();

string[] selectionArguments = ["--filter", "-f", "--list", "--help", "-h", "--version", "--info"];
if (!remaining.Any(x => selectionArguments.Contains(x, StringComparer.OrdinalIgnoreCase)))
{
    remaining.Add("--filter");
    remaining.Add("*");
}

BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(remaining.ToArray(), config);
