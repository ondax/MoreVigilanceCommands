using Vigilance;
using Vigilance.API;
using Vigilance.Extensions;

namespace MoreVigilanceCommands
{
    class ClearNearCommand : CommandHandler
    {
        public string Command => "clearnear";

        public string Usage => "clearnear <player/all/*> [radius]";

        public string Aliases => "clrnear cleannear";

        public string Execute(Player sender, string[] args)
        {
            float radius = 2;
            if(args.Length<1)
            {
                return Usage;
            }
            else
            {
                if(args.Length>=2)
                {
                    radius = float.Parse(args[1]);
                }
                else
                {
                    radius = 2;
                }
                if (args[0]=="*"||args[0]=="all")
                {
                    foreach(Player player in Server.Players)
                    {
                        foreach(Pickup pickup in Map.Pickups)
                        {
                            if (isInRadius(player, pickup, radius))
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
                        if (isInRadius(player, pickup, radius))
                        {
                            pickup.Delete();
                        }
                    }
                }
                return "All near items deleted";
            }
        }
        bool isInRadius(Player player, Pickup pickup, float radius)
        {
            float playerX = player.Position.x;
            float playerY = player.Position.y;
            float playerZ = player.Position.z;
            float pickupX = pickup.position.x;
            float pickupY = pickup.position.y;
            float pickupZ = pickup.position.z;
            if (pickupX - playerX <= radius && pickupX - playerX >= -radius && pickupY - playerY <= radius && pickupY - playerY >= -radius && pickupZ - playerZ <= radius && pickupZ - playerZ >= -radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
