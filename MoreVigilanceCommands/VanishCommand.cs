using Vigilance.API;
using Vigilance;
using Vigilance.Extensions;

namespace MoreVigilanceCommands
{
    class VanishCommand : CommandHandler
    {
        public string Command => "vanish";

        public string Usage => "vanish <player>";

        public string Aliases => "hideme";

        public string Execute(Player sender, string[] args)
        {
            if(args.Length<1)
            {
                if ((bool)Server.PlayerList.Contains(sender.Hub))
                {
                    Server.PlayerList.Remove(sender.Hub);
                    return "Hidden you from player list";
                }
                else
                {
                    Server.PlayerList.Add(sender.Hub);
                    return "Added you to player list";
                }
            }
            else
            {
                foreach(string playerStr in args[0].Split('.'))
                {
                    Player player = playerStr.GetPlayer();
                    if ((bool)Server.PlayerList.Contains(player.Hub))
                    {
                        Server.PlayerList.Remove(player.Hub);
                    }
                    else
                    {
                        Server.PlayerList.Add(player.Hub);
                    }
                }
                return "Toggled player list for specified people";
            }
        }
    }
}
