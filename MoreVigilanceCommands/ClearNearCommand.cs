using UnityEngine;
using Vigilance;
using Vigilance.API;
using Vigilance.Extensions;

namespace MoreVigilanceCommands
{
    public class ClearNearCommand : CommandHandler
    {
        public string Command => "clearnear";
        public string Usage => "clearnear <player/all/*> [radius]";
        public string Aliases => "clrnear cleannear";

        public string Execute(Player sender, string[] args)
        {
            float radius = 2;
            if (args.Length < 1)
            {
                return Usage;
            }
            else
            {
                if (args.Length >= 2)
                {
                    radius = float.Parse(args[1]);
                }
                else
                {
                    radius = 2;
                }
                if (args[0] == "*" || args[0] == "all")
                {
                    foreach (Player player in Server.Players)
                    {
                        foreach (Pickup pickup in Map.Pickups)
                        {
                            if (Vector3.Distance(player.Position, pickup.position) <= radius)
                            {
                                pickup.Delete();
                            }
                        }
                    }
                }
                else
                {
                    Player player = args[0].GetPlayer();
                    foreach (Pickup pickup in Map.Pickups)
                    {
                        if (Vector3.Distance(player.Position, pickup.position) <= radius)
                        {
                            pickup.Delete();
                        }
                    }
                }
                Log.Add("Used command clearnear", Vigilance.LogType.Debug);
                return "All near items deleted";
            }
        }
    }
}
