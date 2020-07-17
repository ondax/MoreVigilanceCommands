using System;
using System.Collections.Generic;
using System.Text;
using Vigilance.Core;
using Vigilance.API;

namespace MoreVIgilanceCommands
{
    class SpawnWorkbenchCommand : Command
    {
        public MoreVigilanceCommands plugin;
        public SpawnWorkbenchCommand(MoreVigilanceCommands mvc) => plugin = mvc;

        public string Usage => "spawnworkbench <player> <x> <y> <z> [rotx] [roty] [rotz]";

        public string Description => "Spawns a workbench";

        public string OnCall(CommandSender sender, string[] args)
        {
            if (args.Length < 5)
            {
                return "You must specify player and size";
            }
            else
            {
                UnityEngine.Vector3 position;
                float x;
                float y;
                float z;
                bool success1 = float.TryParse(args[2], out x);
                bool success2 = float.TryParse(args[3], out y);
                bool success3 = float.TryParse(args[4], out z);
                UnityEngine.Vector3 size = new UnityEngine.Vector3(x, y, z);
                UnityEngine.Vector3 rotation;
                if (args[5] != null && args[5] != "" && args[5] != " " && args[6] != null && args[6] != "" && args[6] != " " && args[7] != null && args[7] != "" && args[7] != " ")
                {
                    float rotx;
                    float roty;
                    float rotz;
                    bool success4 = float.TryParse(args[5], out rotx);
                    bool success5 = float.TryParse(args[6], out roty);
                    bool success6 = float.TryParse(args[7], out rotz);
                    if (success4 && success5 && success6)
                    {
                        rotation = new UnityEngine.Vector3(rotx, roty, rotz);
                    }
                    else
                    {
                        return "rotation must be number";
                    }
                }
                else
                {
                    rotation = new UnityEngine.Vector3(0, 0, 0);
                }
                if (success1 && success2 && success3)
                {
                    if (args[1].ToLower() == "all")
                    {
                        foreach (Player p in Server.Players)
                        {
                            Methods.SpawnWorkbench(p.Position, rotation, size);
                        }
                        return "Workbenches spawned";
                    }
                    else
                    {
                        position = args[1].GetPlayer().Position;
                        Methods.SpawnWorkbench(position, rotation, size);
                        return "Workbench Spawned";
                    }
                }
                else
                {
                    return "x y and z must be numbers";
                }
            }
        }
    }
}
