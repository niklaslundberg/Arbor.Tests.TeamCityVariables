using System;
using System.Threading.Channels;
using Serilog;

namespace TeamCityVariables
{
    class Program
    {
        static int Main(string[] args)
        {
            using var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Verbose()
                .CreateLogger();

            logger.Information("##teamcity[dynamicParameterLogger 'logger1']");

            logger.Information("Regular logger");

            Console.WriteLine("Regular console");
            Console.WriteLine("##teamcity[dynamicParameterConsole 'console1']");

            return 0;
        }
    }
}
