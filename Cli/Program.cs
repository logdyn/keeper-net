using System;
using System.IO;
using System.Net.Security;
using System.Threading.Tasks;
using Logdyn.Keeper.Cli.Command;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;

namespace Logdyn.Keeper.Cli
{
    internal class Program
    {
        private static async Task<int> Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(AppDomain.CurrentDomain.BaseDirectory + "\\appsettings.json", 
                    optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging(config =>
                    {
                        config.ClearProviders();
                        config.AddProvider(new SerilogLoggerProvider(Log.Logger));
                    });
                    services.AddHttpClient();
                });

            try
            {
                return await builder.RunCommandLineApplicationAsync<KeeperCmd>(args);
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex, "An exception occurred during startup.");
                return 1;
            }
        }
    }
}