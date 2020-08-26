using Vigilance;

namespace MoreVigilanceCommands
{
    class MoreVigilanceCommands : Plugin
    {
        public override string Name => "MoreVigilanceCommands";

        public override void Disable()
        {
            Log.Add(Name + " disabled succesfully", LogType.Info);
        }

        public override void Enable()
        {
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
            Log.Add(Name + " reloaded succesfully", LogType.Info);
        }
    }
}
