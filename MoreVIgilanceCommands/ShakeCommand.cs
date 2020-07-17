using System;
using System.Collections.Generic;
using System.Text;
using Vigilance.Core;
using Vigilance.API;

namespace MoreVIgilanceCommands
{
    class ShakeCommand : Command
    {
        public MoreVigilanceCommands plugin;
        public ShakeCommand(MoreVigilanceCommands mvc) => plugin = mvc;
        public string Usage => "shake";

        public string Description => "Shakes the map";

        public string OnCall(CommandSender sender, string[] args)
        {
            Map.Shake();
            return "Shaked succesfully";
        }
    }
}
