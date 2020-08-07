using Vigilance.API;
using Vigilance.API.Commands;

namespace MoreVigilanceCommands
{
    public class ShakeCommand : Command
    {
        public MoreVigilanceCommands plugin;
        public ShakeCommand(MoreVigilanceCommands mvc) => plugin = mvc;
        public string Usage => "shake";

        public bool OverwriteBaseGameCommand => false;

        public string OnCall(Player sender, string[] args)
        {
            Map.Warhead.Shake();
            return "Success";
        }
    }
}
