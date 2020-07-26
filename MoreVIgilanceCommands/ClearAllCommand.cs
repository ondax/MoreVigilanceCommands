using Vigilance.Commands.API;
using Vigilance.API;

namespace MoreVIgilanceCommands
{
    class ClearAllCommand : Command
    {
        public MoreVigilanceCommands plugin;
        public ClearAllCommand(MoreVigilanceCommands mvc) => plugin = mvc;

        public string Usage => "clearall";

        public string Description => "Clears all items";

        public string OnCall(Player sender, string[] args)
        {
            foreach (Pickup pickup in Map.Pickups)
            {
                pickup.Delete();
            }
            return "All items deleted";
        }
    }
}
