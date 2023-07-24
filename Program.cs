using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace bmtool
{
    class Program
    {
        // 定义命令行选项
        class Options
        {
            [Option('r', "run", Required = false, HelpText = "Specify the benchmark to run: 3dmark, pcmark, cinebench, 7z")]
            public string Benchmark
            {
                get; set;
            }

            [Option('i', "install", Required = false, HelpText = "Install the benchmarking tool")]
            public bool Install
            {
                get; set;
            }

        }

        static void Main(string[] args)
        {
            // 解析命令行参数
            var parser = new Parser(with => with.EnableDashDash = true);
            var result = parser.ParseArguments<Options>(args);

            result.WithParsed(options =>
            {
                if (options.Benchmark != null)
                {
                    // 处理 -run 子项
                    switch (options.Benchmark.ToLower())
                    {
                        case "3dmark":
                            Run3DMark();
                            break;
                        case "pcmark":
                            RunPCMark();
                            break;
                        case "cinebench":
                            RunCinebench();
                            break;
                        case "7z":
                            Run7z();
                            break;
                        default:
                            Console.WriteLine($"Unknown benchmark: {options.Benchmark}");
                            break;
                    }
                }
                else if (options.Install)
                {
                    // 处理 -install 选项
                    InstallBenchmarkTool();
                }
                else
                {
                    Console.WriteLine(GetUsage());
                }
            });
        }

        // 模拟运行各个子项
        static void Run3DMark()
        {
            Console.WriteLine("Running 3DMark...");
        }

        static void RunPCMark()
        {
            Console.WriteLine("Running PCMark...");
        }

        static void RunCinebench()
        {
            Console.WriteLine("Running Cinebench...");
        }

        static void Run7z()
        {
            Console.WriteLine("Running 7z benchmark...");
        }

        // 模拟安装
        static void InstallBenchmarkTool()
        {
            Console.WriteLine("Installing benchmarking tool...");
        }

        static string GetUsage()
        {
            return "Usage: mybenchmarktool [--run <benchmark>] [--install]\n" +
                   "Options:\n" +
                   "  -r, --run <benchmark>     Specify the benchmark to run: 3dmark, pcmark, cinebench, 7z\n" +
                   "  -i, --install             Install the benchmarking tool";
        }
    }
}
