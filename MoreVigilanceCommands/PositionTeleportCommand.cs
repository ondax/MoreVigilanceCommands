using UnityEngine;
using Vigilance;
using Vigilance.API;
using Vigilance.Extensions;

namespace MoreVigilanceCommands
{
    class PositionTeleportCommand : CommandHandler
    {
        public string Command => "positionteleport";

        public string Usage => "postp <player/all/*> <x> <y> <z>";

        public string Aliases => "postp tppos";

        public string Execute(Player sender, string[] args)
        {
            if(args.Length<4)
            {
                return Usage;
            }
            else
            {
                float x = float.Parse(args[1]);
                float y = float.Parse(args[2]);
                float z = float.Parse(args[3]);
                Vector3 position = new Vector3(x, y, z);
                if (args[0] == "*" || args[0] == "all")
                {
                    foreach(Player player in Server.Players)
                    {
                        player.Teleport(position);
                    }
                    return "All players teleported";
                }
                else
                {
                    Player player = args[0].GetPlayer();
                    player.Teleport(position);
                    return "Player teleported";
                }
            }
        }
    }
}
