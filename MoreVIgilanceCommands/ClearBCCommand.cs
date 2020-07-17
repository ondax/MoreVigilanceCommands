using System;
using System.Collections.Generic;
using System.Text;
using Vigilance.Core;
using Vigilance.API;

namespace MoreVIgilanceCommands
{
    class ClearBCCommand : Command
    {
        public MoreVigilanceCommands plugin;
        public ClearBCCommand(MoreVigilanceCommands mvc) => plugin = mvc;
        public string Usage => "clearbc";

        public string Description => "Clears all broadcasts";

        public string OnCall(CommandSender sender, string[] args)
        {
            Map.ClearBroadcasts();
            return "Broadcasts cleared";
        }
    }
}
