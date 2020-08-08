using Vigilance;
using Vigilance.Commands;
using Vigilance.API.Commands;
using Vigilance.API.Handlers;

namespace MoreVigilanceCommands
{
    public class MoreVigilanceCommands : Plugin
    {
        public override string Id => "morevigilancecommands";

        public override string Name => "MoreVigilanceCommands";

        public override void OnDisable()
        {
            Info(Name + " disabled");
        }

        public override void OnEnable()
        {
            Info(Name + " enabled");
            AddCommand("shake", new ShakeCommand(this));
            AddCommand("cleanup", new CleanupCommand(this));
            AddCommand("clearcards", new ClearCardsCommand(this));
            AddCommand("clearall", new ClearAllCommand(this));
            AddCommand("clearnear", new ClearNearCommand(this));
            AddCommand("postp", new PositionTeleportCommand(this));
            AddHandler(new RemoteKeycardHandler(this));
        }
    }
}
