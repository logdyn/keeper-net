using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;

namespace Logdyn.Keeper.Cli.Command
{
    internal interface IKeeperCmd
    {
        Task<int> OnExecute(CommandLineApplication app);
    }
}