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

            var value = "logger2";
            logger.Information("##teamcity[dynamicParameterLogger 'logger1']");
            logger.Information("##teamcity[setParameter name='dynamicParameterLogger2' value='{Value}']", value);

            logger.Information("Regular logger");

            Console.WriteLine("Regular console");
            Console.WriteLine("##teamcity[dynamicParameterConsole1 'console1']");
            Console.WriteLine("##teamcity[setParameter name='dynamicParameterConsole2' value='console2']");
            Console.WriteLine("##teamcity[setParameter name='env.dynamicParameterConsole3' value='console3']");
            Console.WriteLine("##teamcity[setParameter name='system.dynamicParameterConsole4' value='console4']");

            return 0;
        }
    }
}
