using System;
using System.Reflection;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace Logdyn.Keeper.Cli.Command
{
    [Command(Name = "keeper", ThrowOnUnexpectedArgument = false, 
        OptionsComparison = StringComparison.InvariantCultureIgnoreCase)]
    [VersionOptionFromMember("--version", MemberName = nameof(GetVersion))]
    [Subcommand(typeof(Shart))]
    public class KeeperCmd : IKeeperCmd
    {
        private readonly ILogger<KeeperCmd> _logger;
        private readonly IConsole _console;

        public KeeperCmd(ILogger<KeeperCmd> logger, IConsole console)
        {
            _logger = logger;
            _console = console;
        }
        
        public Task<int> OnExecute(CommandLineApplication app)
        {
            app.ShowHelp();
            return Task.FromResult(0);
        }

        private static string GetVersion() => typeof(KeeperCmd).Assembly
            .GetCustomAttributes<AssemblyInformationalVersionAttribute>().ToString();
    }
}