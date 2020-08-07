using Vigilance.API;
using Vigilance.API.Commands;

namespace MoreVigilanceCommands
{
    class CleanupCommand : Command
    {
        public MoreVigilanceCommands plugin;
        public CleanupCommand(MoreVigilanceCommands mvc) => plugin = mvc;
        public string Usage => "cleanup";

        public bool OverwriteBaseGameCommand => false;

        public string OnCall(Player sender, string[] args)
        {
            bool is049 = false;
            bool isScientistorClassD = false;
            bool is079 = false;
            foreach (Player p in Server.Players)
            {
                if (p.Role == RoleType.Scp049)
                {
                    is049 = true;
                }
            }
            foreach (Player p in Server.Players)
            {
                if (p.Role == RoleType.ClassD || p.Role == RoleType.Scientist)
                {
                    isScientistorClassD = true;
                }
            }
            foreach (Player p in Server.Players)
            {
                if (p.Role == RoleType.Scp079)
                {
                    is079 = true;
                }
            }
            if (!isScientistorClassD)
            {
                Server.RunCommand("clean 22");
                Server.RunCommand("clean 27");
                Server.RunCommand("clean 28");
                Server.RunCommand("clean 29");
            }
            if (!is079)
            {
                Server.RunCommand("clean 19");
            }
            if (!is049)
            {
                Server.RunCommand("clearragdolls");
            }
            return "Cleanup succesfull";
        }
    }
}
