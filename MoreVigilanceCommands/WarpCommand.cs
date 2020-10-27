using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using Vigilance;
using Vigilance.API;
using Vigilance.Extensions;

namespace MoreVigilanceCommands
{
    public class WarpCommand : CommandHandler
    {
        List<Warp> warps = new List<Warp>();
        public string Command => "warp";
        public string Usage => "warp <add/remove/list/teleport/change>";
        public string Aliases => "wp";

        public string Execute(Player sender, string[] args)
        {
            if (args.Length < 1)
            {
                return Usage;
            }
            else
            {
                switch (args[0].ToLower())
                {
                    case "add":
                        if (args.Length < 2)
                        {
                            return "warp add <name> <x> <y> <z> or warp add <name> <player> or warp add <name>";
                        }
                        else if (args.Length > 2 && args.Length < 5)
                        {
                            foreach (Warp warp in warps)
                            {
                                if (warp.name == args[1])
                                {
                                    return "Warp name already exists";
                                }
                            }
                            warps.Add(new Warp(args[2].GetPlayer().Position, args[1]));
                            Log.Add("Warp at player " + args[2].GetPlayer().Nick + " added", Vigilance.LogType.Debug);
                            return "Warp at player " + args[2].GetPlayer().Nick + " added";
                        }
                        else if (args.Length >= 5)
                        {
                            foreach (Warp warp in warps)
                            {
                                if (warp.name == args[1])
                                {
                                    return "Warp name already exists";
                                }
                            }
                            float x = float.Parse(args[2]);
                            float y = float.Parse(args[3]);
                            float z = float.Parse(args[4]);
                            Vector3 position = new Vector3(x, y, z);
                            warps.Add(new Warp(position, args[1]));
                            Log.Add("Warp at position " + x + ", " + y + ", " + z + ", " + " added", Vigilance.LogType.Debug);
                            return "Warp at position " + x + ", " + y + ", " + z + ", " + " added";
                        }
                        else if (args.Length == 2)
                        {
                            foreach (Warp warp in warps)
                            {
                                if (warp.name == args[1])
                                {
                                    return "Warp name already exists";
                                }
                            }
                            warps.Add(new Warp(sender.Position, args[1]));
                            Log.Add("Warp at player " + sender.Nick + " added", Vigilance.LogType.Debug);
                            return "Warp at your position added";
                        }
                        else
                        {
                            return "warp add <name> <x> <y> <z> or warp add <name> <player> or warp add <name>";
                        }
                    case "remove":
                        if (args.Length < 2)
                        {
                            return "warp remove <name>";
                        }
                        else
                        {
                            foreach (Warp warp in warps)
                            {
                                if (warp.name == args[1])
                                {
                                    warps.Remove(warp);
                                    Log.Add("Warp " + warp.name + " removed", Vigilance.LogType.Debug);
                                    return "Warp " + warp.name + " removed";
                                }
                            }
                            return "Warp " + args[1] + " does not exist";
                        }
                    case "list":
                        string warpNames = "";
                        foreach (Warp warp in warps)
                        {
                            warpNames = warpNames + warp.name + ", ";
                        }
                        return warpNames;
                    case "teleport":
                        if (args.Length < 2)
                        {
                            return "warp teleport <player> <warp> or warp teleport <warp>";
                        }
                        else if (args.Length < 3)
                        {
                            foreach (Warp warp in warps)
                            {
                                if (warp.name == args[1])
                                {
                                    sender.Teleport(warp.pos);
                                    return "Teleported to warp " + warp.name;
                                }
                            }
                            return "Warp " + args[1] + " does not exist";
                        }
                        else if (args.Length >= 3)
                        {
                            foreach (Warp warp in warps)
                            {
                                if (warp.name == args[2])
                                {
                                    if (args[1] == "*" || args[1] == "all")
                                    {
                                        foreach (Player player in Server.Players)
                                        {
                                            player.Teleport(warp.pos);
                                        }
                                        Log.Add("All players teleported to warp" + warp.name, Vigilance.LogType.Debug);
                                        return "All players teleported to warp" + warp.name;
                                    }
                                    string playerNicks = "";
                                    foreach (string player in args[1].Split('.'))
                                    {
                                        try
                                        {
                                            player.GetPlayer().Teleport(warp.pos);
                                            playerNicks = playerNicks + player.GetPlayer().Nick + ", ";
                                        }
                                        catch
                                        {

                                        }
                                    }
                                    Log.Add("Player(s) " + playerNicks + " teleported to warp " + warp.name, Vigilance.LogType.Debug);
                                    return "Player(s) " + playerNicks + " teleported to warp " + warp.name;
                                }
                            }
                            return "Warp " + args[2] + " does not exist";
                        }
                        else
                        {
                            return "warp teleport <player> <warp> or warp teleport <warp>";
                        }
                    case "change":
                        if (args.Length < 2)
                        {
                            return "warp change <name> <x> <y> <z> or warp change <name> <player> or warp change <name>";
                        }
                        else if (args.Length == 2)
                        {
                            foreach (Warp warp in warps)
                            {
                                if (warp.name == args[1])
                                {
                                    warp.pos = sender.Position;
                                    Log.Add("Warp position changed to position of player " + sender.Nick, Vigilance.LogType.Debug);
                                    return "Warp position changed to your position";
                                }
                            }
                            return "Warp " + args[1] + " does not exist";
                        }
                        else if (args.Length >= 3 && args.Length < 5)
                        {
                            foreach (Warp warp in warps)
                            {
                                if (warp.name == args[1])
                                {
                                    warp.pos = args[2].GetPlayer().Position;
                                    Log.Add("Warp position changed to position of player " + args[2].GetPlayer().Nick, Vigilance.LogType.Debug);
                                    return "Warp position changed to position of player " + args[2].GetPlayer().Nick;
                                }
                            }
                            return "Warp " + args[1] + " does not exist";
                        }
                        else if (args.Length >= 5)
                        {
                            float x = float.Parse(args[2]);
                            float y = float.Parse(args[3]);
                            float z = float.Parse(args[4]);
                            Vector3 position = new Vector3(x, y, z);
                            foreach (Warp warp in warps)
                            {
                                if (warp.name == args[1])
                                {
                                    warp.pos = position;
                                    Log.Add("Warp position changed to " + x + ", " + y + ", " + z, Vigilance.LogType.Debug);
                                    return "Warp position changed to " + x + ", " + y + ", " + z;
                                }
                            }
                            return "Warp " + args[1] + " does not exist";
                        }
                        else
                        {
                            return "warp change<name> < x > < y > < z > or warp change<name> < player > or warp change<name>";
                        }
                    default:
                        return Usage;
                }
            }
        }
        public class Warp
        {
            public Vector3 pos;
            public string name;
            public Warp(Vector3 position, string warpName)
            {
                pos = position;
                name = warpName;
            }
        }
    }
}
