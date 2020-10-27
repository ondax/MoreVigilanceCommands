using Vigilance;

namespace MoreVigilanceCommands
{
    class MoreVigilanceCommands : Plugin
    {
        public override string Name => "MoreVigilanceCommands";
        public static Plugin singleton;
        public override void Disable()
        {
            singleton = null;
            AddLog(Name + " disabled succesfully");
        }

        public override void Enable()
        {
            singleton = this;
            Log.Add(Name + " enabled succesfully", LogType.Info);
            CommandManager.RegisterCommand(new ClearNearCommand());
            CommandManager.RegisterCommand(new ShakeCommand());
            CommandManager.RegisterCommand(new CleanupCommand());
            CommandManager.RegisterCommand(new ClearCardsCommand());
            CommandManager.RegisterCommand(new PositionTeleportCommand());
            CommandManager.RegisterCommand(new WarpCommand());
            CommandManager.RegisterCommand(new MuteAllCommand());
        }

        public override void Reload()
        {
            AddLog(Name + " reloaded succesfully");
        }
    }
}
