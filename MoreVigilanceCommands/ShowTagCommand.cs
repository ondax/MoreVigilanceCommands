using Vigilance;
using Vigilance.API;
using Vigilance.Extensions;

namespace MoreVigilanceCommands
{
    class ShowTagCommand : GameCommandHandler
    {
        public string Command => "showtag";

        public string Usage => "showtag <player>";

        public string Aliases => "";

        public string Execute(Player sender, string[] args)
        {
            if (args.Length < 1)
            {
                if (sender.IsHost)
                {
                    return "Only players can use this command";
                }
                sender.BadgeHidden = false;
                return "Badge shown";
            }
            else if (sender.CheckPermission(PlayerPermissions.SetGroup)||sender.CheckPermission(PlayerPermissions.PermissionsManagement))
            {
                if (args[0] == "*" || args[0] == "all")
                {
                    foreach (Player p in Server.Players)
                    {
                        p.BadgeHidden = false;
                    }
                    return "Badges of all players shown";
                }
                else
                {
                    string[] players = args[0].Split('.');
                    string playerNames = "";
                    foreach (string p in players)
                    {
                        Player player = p.GetPlayer();
                        player.BadgeHidden = false;
                        if (playerNames == "")
                        {
                            playerNames += player.Nick;
                        }
                        else
                        {
                            playerNames += ", " + player.Nick;
                        }
                    }
                    return "Badge of player(s) " + playerNames + " shown";
                }
            }
            return "You dont have permission";
        }
    }
}
