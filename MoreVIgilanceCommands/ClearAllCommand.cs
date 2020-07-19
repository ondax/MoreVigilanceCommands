using System;
using System.Collections.Generic;
using System.Text;
using Vigilance.API;
using Vigilance.Core;

namespace MoreVIgilanceCommands
{
    class ClearAllCommand : Command
    {
        public MoreVigilanceCommands plugin;
        public ClearAllCommand(MoreVigilanceCommands mvc) => plugin = mvc;

        public string Usage => "clearall";

        public string Description => "Clears all items";

        public string OnCall(CommandSender sender, string[] args)
        {
            List<Pickup> items = Map.Pickups;
            foreach(Pickup pickup in items)
            {
                pickup.Delete();
            }
            return "All items deleted";
        }
    }
}
