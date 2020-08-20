using Vigilance;
using Vigilance.API;

namespace MoreVigilanceCommands
{
    class ShakeCommand : CommandHandler
    {
        public string Command => "shake";

        public string Usage => "shake";

        public string Aliases => "shk";

        public string Execute(Player sender, string[] args)
        {
            Map.Warhead.Shake();
            Log.Add("Map shaked", LogType.Debug);
            return "Shaked succesfully";
        }
    }
}
