using Vigilance.Commands.API;
using Vigilance.API;

namespace MoreVIgilanceCommands
{
    class ClearCardsCommand : Command
    {
        public MoreVigilanceCommands plugin;
        public ClearCardsCommand(MoreVigilanceCommands mvc) => plugin = mvc;

        public string Usage => "clearcards";

        public string Description => "Clears all keycards";

        public string OnCall(Player sender, string[] args)
        {
            for (int i = 0; i < 12; i++)
            {
                Server.RunCommand("clean "+i);
            }
            return "All cards cleared";
        }
    }
}
