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
            //commands
            //Not currently working
            //CommandManager.RegisterCommand(new ClearNearCommand());
            CommandManager.RegisterCommand(new ShakeCommand());
            CommandManager.RegisterCommand(new CleanupCommand());
            CommandManager.RegisterCommand(new ClearCardsCommand());
            CommandManager.RegisterCommand(new PositionTeleportCommand());
            CommandManager.RegisterCommand(new WarpCommand());
            CommandManager.RegisterCommand(new MuteAllCommand());
            CommandManager.RegisterCommand(new ListAdminsCommand());
            CommandManager.RegisterCommand(new VanishCommand());
            //game commands
            CommandManager.RegisterGameCommand(new ShowTagCommand());
            CommandManager.RegisterGameCommand(new HideTagCommand());
            Log.Add(Name + " enabled succesfully", LogType.Info);
        }

        public override void Reload() { /* useless since there is nothing to reload */ }
    }
}
