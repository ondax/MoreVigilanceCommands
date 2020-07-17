using System;
using System.Collections.Generic;
using System.Text;
using Vigilance.Core;
using Vigilance.API;

namespace MoreVIgilanceCommands
{
    class ClearCardsCommand : Command
    {
        public MoreVigilanceCommands plugin;
        public ClearCardsCommand(MoreVigilanceCommands mvc) => plugin = mvc;

        public string Usage => "clearcards";

        public string Description => "Clears all keycards";

        public string OnCall(CommandSender sender, string[] args)
        {
            for(int i = 0; i<12; i++)
            {
                Server.RunCommand("clean "+i);
            }
            return "All cards cleared";
        }
    }
}
