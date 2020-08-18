using Vigilance;
using Vigilance.API;
using Vigilance.Extensions;

namespace MoreVigilanceCommands
{
    class ClearCardsCommand : CommandHandler
    {
        public string Command => "clearcards";

        public string Usage => "clearcards";

        public string Aliases => "clrcards cleancards";

        public string Execute(Player sender, string[] args)
        {
            foreach(Pickup pickup in Map.Pickups)
            {
                if (isCard(pickup))
                {
                    pickup.Delete();
                }
            }
            return "All cards deleted";
        }
        bool isCard(Pickup pickup)
        {
            if (pickup.ItemId == ItemType.KeycardChaosInsurgency || pickup.ItemId == ItemType.KeycardContainmentEngineer || pickup.ItemId == ItemType.KeycardFacilityManager || pickup.ItemId == ItemType.KeycardGuard || pickup.ItemId == ItemType.KeycardJanitor || pickup.ItemId == ItemType.KeycardNTFCommander || pickup.ItemId == ItemType.KeycardNTFLieutenant || pickup.ItemId == ItemType.KeycardO5 || pickup.ItemId == ItemType.KeycardScientist || pickup.ItemId == ItemType.KeycardScientistMajor || pickup.ItemId == ItemType.KeycardSeniorGuard || pickup.ItemId == ItemType.KeycardZoneManager)
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
