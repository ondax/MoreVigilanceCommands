using Vigilance;
using Vigilance.API;
using Vigilance.Extensions;

namespace MoreVigilanceCommands
{
    class CleanupCommand : CommandHandler
    {
        public string Command => "cleanup";

        public string Usage => "cleanup";

        public string Aliases => "cleanunneeded";

        public string Execute(Player sender, string[] args)
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
                foreach (Pickup pickup in Map.Pickups)
                {
                    if (pickup.ItemId == ItemType.Ammo556 || pickup.ItemId == ItemType.Ammo762 || pickup.ItemId == ItemType.Ammo9mm || pickup.ItemId == ItemType.Disarmer)
                    {
                        pickup.Delete();
                    }
                }
            }
            if (!is079)
            {
                foreach (Pickup pickup in Map.Pickups)
                {
                    if (pickup.ItemId == ItemType.WeaponManagerTablet)
                    {
                        pickup.Delete();
                    }
                }
            }
            if (!is049)
            {
                foreach (Ragdoll ragdoll in Map.Ragdolls)
                {
                    ragdoll.Delete();
                }
            }
            return "Cleanup succesfull";
        }
    }
}
