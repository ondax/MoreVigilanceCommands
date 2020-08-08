using Vigilance.API;
using Vigilance.API.Commands;
using Vigilance.API.Extensions;

namespace MoreVigilanceCommands
{
    class ClearNearCommand : Command
    {
        public MoreVigilanceCommands plugin;
        public ClearNearCommand(MoreVigilanceCommands mvc) => plugin = mvc;

        public string Usage => "clearnear <player> [radius-default=2]";

        public bool OverwriteBaseGameCommand => false;

        public string OnCall(Player sender, string[] args)
        {
            if (args.Length < 2)
            {
                return Usage;
            }
            else 
            {
                Player target = args[1].GetPlayer();
                int radius = 100;
                if(args.Length<3)
                {
                    radius = 2;
                }
                else
                {
                    radius = int.Parse(args[2]);
                }
                float playerX = target.Position.x;
                float playerY = target.Position.y;
                float playerZ = target.Position.z;
                foreach (Pickup pickup in Map.Pickups)
                {
                    float pickupX = pickup.position.x;
                    float pickupY = pickup.position.y;
                    float pickupZ = pickup.position.z;
                    if (pickupX-playerX<=radius&&pickupX-playerX>=-radius && pickupY - playerY <= radius && pickupY - playerY >= -radius && pickupZ - playerZ <= radius && pickupZ - playerZ >= -radius)
                    {
                        pickup.Delete();
                    }
                }
                return "Near items deleted";
            }
        }
    }
}
