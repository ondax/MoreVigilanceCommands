using Vigilance.API.Commands;
using Vigilance.API;

namespace MoreVigilanceCommands
{
    class ClearAllCommand : Command
    {
        public MoreVigilanceCommands plugin;
        public ClearAllCommand(MoreVigilanceCommands mvc) => plugin = mvc;

        public string Usage => "clearall";

        public bool OverwriteBaseGameCommand => false;

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
