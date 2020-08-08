using Vigilance.API;
using Vigilance.API.Commands;

namespace MoreVigilanceCommands
{
    class ClearCardsCommand : Command
    {
        public MoreVigilanceCommands plugin;
        public ClearCardsCommand(MoreVigilanceCommands mvc) => plugin = mvc;

        public string Usage => "clearcards";

        public bool OverwriteBaseGameCommand => false;

        public string OnCall(Player sender, string[] args)
        {
            foreach(Pickup pickup in Map.Pickups)
            {
                if(pickup.ItemId == ItemType.KeycardChaosInsurgency|| pickup.ItemId == ItemType.KeycardContainmentEngineer|| pickup.ItemId == ItemType.KeycardFacilityManager|| pickup.ItemId == ItemType.KeycardGuard|| pickup.ItemId == ItemType.KeycardJanitor|| pickup.ItemId == ItemType.KeycardNTFCommander|| pickup.ItemId == ItemType.KeycardNTFLieutenant|| pickup.ItemId == ItemType.KeycardO5|| pickup.ItemId == ItemType.KeycardScientist || pickup.ItemId == ItemType.KeycardScientistMajor || pickup.ItemId == ItemType.KeycardSeniorGuard || pickup.ItemId == ItemType.KeycardZoneManager)
                {
                    pickup.Delete();
                }
            }
            return "All cards cleared";
        }
    }
}
