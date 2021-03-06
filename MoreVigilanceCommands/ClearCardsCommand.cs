﻿using Vigilance;
using Vigilance.API;
using Vigilance.Extensions;

namespace MoreVigilanceCommands
{
    public class ClearCardsCommand : CommandHandler
    {
        public string Command => "clearcards";

        public string Usage => "clearcards";

        public string Aliases => "clrcards cleancards";

        public string Execute(Player sender, string[] args)
        {
            foreach (Pickup pickup in Map.Pickups)
            {
                if (pickup.ItemId.IsKeycard())
                {
                    pickup.Delete();
                }
            }
            MVC.Singleton.Info("All cards deleted");
            return "All cards deleted";
        }
    }
}