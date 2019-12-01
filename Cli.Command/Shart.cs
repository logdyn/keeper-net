using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;

namespace Logdyn.Keeper.Cli.Command
{
    [Command(Name = "shart", Description = "pffffbbttttt")]
    public class Shart : IKeeperCmd
    {
        public Task<int> OnExecute(CommandLineApplication app)
        {
            throw new System.NotImplementedException();
        }
    }
}