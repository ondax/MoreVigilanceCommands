using Vigilance.API;
using Vigilance;
using Vigilance.Extensions;

namespace MoreVigilanceCommands
{
    class MaxHPCommand : CommandHandler
    {
        public string Command => "maxhp";

        public string Usage => "maxhp <player> <hp>";

        public string Aliases => "maxhealth";

        public string Execute(Player sender, string[] args)
        {
            if (args.Length<2)
            {
                return Usage;
            }
            else
            {
                foreach (string s in args[0].Split('.'))
                {
                    Player player = args[0].GetPlayer();
                    player.MaxHealth = int.Parse(args[1]);
                }
                return "Success";
            }
        }
    }
}
