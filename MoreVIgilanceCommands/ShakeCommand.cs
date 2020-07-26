using Vigilance.Commands.API;
using Vigilance.API;

namespace MoreVIgilanceCommands
{
    class ShakeCommand : Command
    {
        public MoreVigilanceCommands plugin;
        public ShakeCommand(MoreVigilanceCommands mvc) => plugin = mvc;
        public string Usage => "shake";

        public string Description => "Shakes the map";

        public string OnCall(Player sender, string[] args)
        {
            Map.Warhead.Shake();
            return "Shaked succesfully";
        }
    }
}
