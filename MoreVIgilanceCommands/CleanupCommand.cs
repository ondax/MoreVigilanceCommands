using Vigilance.API;
using Vigilance.API.Commands;
using Vigilance.API.Extensions;

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
                foreach(Pickup pickup in Map.Pickups)
                {
                    if(pickup.ItemId == ItemType.Ammo556|| pickup.ItemId == ItemType.Ammo762|| pickup.ItemId == ItemType.Ammo9mm|| pickup.ItemId == ItemType.Disarmer)
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
                foreach(Ragdoll ragdoll in Map.Ragdolls)
                {
                    ragdoll.Delete();
                }
            }
            return "Cleanup succesfull";
        }
    }
}
