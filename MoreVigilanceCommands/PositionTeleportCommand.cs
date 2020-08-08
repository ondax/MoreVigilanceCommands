using Vigilance.API;
using Vigilance.API.Commands;
using Vigilance.API.Extensions;

namespace MoreVigilanceCommands
{
    class PositionTeleportCommand : Command
    {
        public MoreVigilanceCommands plugin;
        public PositionTeleportCommand(MoreVigilanceCommands mvc) => plugin = mvc;

        public string Usage => "postp <player> <x> <y> <z>";

        public bool OverwriteBaseGameCommand => false;

        public string OnCall(Player sender, string[] args)
        {
            if (args.Length<5)
            {
                return Usage;
            }
            else
            {
                Player target = args[1].GetPlayer();
                float x = float.Parse(args[2]);
                float y = float.Parse(args[3]);
                float z = float.Parse(args[4]);
                target.Position = new UnityEngine.Vector3(x, y, z);
                return "Player teleported";
            }
        }
    }
}
