using Vigilance;

namespace MoreVigilanceCommands
{
    public class MVC : Plugin
    {
        public override string Name => "MoreVigilanceCommands";
        public static MVC Singleton { get; set; }

        public override void Disable() { }

        public override void Enable()
        {
            Singleton = this;
            CommandManager.RegisterCommand(new ClearNearCommand());
            CommandManager.RegisterCommand(new ShakeCommand());
            CommandManager.RegisterCommand(new CleanupCommand());
            CommandManager.RegisterCommand(new ClearCardsCommand());
            CommandManager.RegisterCommand(new PositionTeleportCommand());
            CommandManager.RegisterCommand(new WarpCommand());
            CommandManager.RegisterCommand(new MuteAllCommand());
            Log.Add(Name + " enabled succesfully", LogType.Info);
        }

        public override void Reload() { /* useless since there is nothing to reload */ }
    }
}
