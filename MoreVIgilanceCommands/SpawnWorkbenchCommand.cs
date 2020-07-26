using Vigilance.Commands.API;
using Vigilance.API;
using Vigilance;
using UnityEngine;

namespace MoreVIgilanceCommands
{
    class SpawnWorkbenchCommand : Command
    {
        public MoreVigilanceCommands plugin;
        public SpawnWorkbenchCommand(MoreVigilanceCommands mvc) => plugin = mvc;

        public string Usage => "spawnworkbench <player> <x> <y> <z> [rotx] [roty] [rotz]";

        public string Description => "Spawns a workbench";

        public string OnCall(Player sender, string[] args)
        {
            if (args.Length < 5)
            {
                return $"You must specify player and size\n{Usage}";
            }
            Vector3 size = new Vector3(float.Parse(args[2]), float.Parse(args[3]), float.Parse(args[4]));
            Vector3 rotation = new Vector3(float.Parse(args[5]), float.Parse(args[6]), float.Parse(args[7]));
            if (args[1].ToLower() == "all")
            {
                foreach (Player player in Server.Players)
                {
                    Data.Methods.SpawnWorkbench(player.Position, rotation, size);
                }
                return "Workbenches spawned";
            }
            Player player2 = args[1].GetPlayer();
            Data.Methods.SpawnWorkbench(player2.Position, rotation, size);
            return "Workbench Spawned";
        }
    }
}
