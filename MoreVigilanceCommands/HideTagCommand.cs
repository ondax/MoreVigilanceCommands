using Vigilance;
using Vigilance.API;
using Vigilance.Extensions;

namespace MoreVigilanceCommands
{
    class HideTagCommand : GameCommandHandler
    {
        public string Command => "hidetag";

        public string Usage => "hidetag <player>";

        public string Aliases => "";

        public string Execute(Player sender, string[] args)
        {
            if (args.Length < 1)
            {
                if (sender.IsHost)
                {
                    return "Only players can use this command";
                }
                sender.BadgeHidden = true;
                return "Badge hidden";
            }
            else if (sender.CheckPermission(PlayerPermissions.SetGroup) || sender.CheckPermission(PlayerPermissions.PermissionsManagement))
            {
                if (args[0] == "*" || args[0] == "all")
                {
                    foreach (Player p in Server.Players)
                    {
                        p.BadgeHidden = true;
                    }
                    return "Badges of all players hidden";
                }
                else
                {
                    string[] players = args[0].Split('.');
                    string playerNames = "";
                    foreach (string p in players)
                    {
                        Player player = p.GetPlayer();
                        player.BadgeHidden = true;
                        if (playerNames == "")
                        {
                            playerNames += player.Nick;
                        }
                        else
                        {
                            playerNames += ", " + player.Nick;
                        }
                    }
                    return "Badge of player(s) " + playerNames + " hidden";
                }
            }
            return "You dont have permission";
        }
    }
}
