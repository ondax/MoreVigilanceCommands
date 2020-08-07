using Vigilance.API;
using Vigilance.API.Commands;

namespace MoreVigilanceCommands
{
    class ClearCardsCommand : Command
    {
        public MoreVigilanceCommands plugin;
        public ClearCardsCommand(MoreVigilanceCommands mvc) => plugin = mvc;

        public string Usage => "clearcards";

        public bool OverwriteBaseGameCommand => false;

        public string OnCall(Player sender, string[] args)
        {
            for (int i = 0; i < 12; i++)
            {
                Server.RunCommand("clean " + i);
            }
            return "All cards cleared";
        }
    }
}
