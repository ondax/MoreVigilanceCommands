using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using Vigilance;
using Vigilance.API;
using Vigilance.Extensions;

namespace MoreVigilanceCommands
{
    class WaypointCommand : CommandHandler
    {
        List<Waypoint> waypoints = new List<Waypoint>();
        public string Command => "waypoint";

        public string Usage => "waypoint <add/remove/list/teleport/change>";

        public string Aliases => "wp";

        public string Execute(Player sender, string[] args)
        {
            if (args.Length<1)
            {
                return Usage;
            }
            else
            {
                switch(args[0].ToLower())
                {
                    case "add":
                        if (args.Length<2)
                        {
                            return "waypoint add <name> <x> <y> <z> or waypoint add <name> <player> or waypoint add <name>";
                        }
                        else if (args.Length>2&&args.Length<5)
                        {
                            foreach (Waypoint waypoint in waypoints)
                            {
                                if (waypoint.name == args[1])
                                {
                                    return "Waypoint name already exists";
                                }
                            }
                            waypoints.Add(new Waypoint(args[2].GetPlayer().Position, args[1]));
                            return "Waypoint at player "+args[2].GetPlayer().Nick+" added";
                        }
                        else if (args.Length>=5)
                        {
                            foreach(Waypoint waypoint in waypoints)
                            {
                                if (waypoint.name==args[1])
                                {
                                    return "Waypoint name already exists";
                                }
                            }
                            float x = float.Parse(args[2]);
                            float y = float.Parse(args[3]);
                            float z = float.Parse(args[4]);
                            Vector3 position = new Vector3(x, y, z);
                            waypoints.Add(new Waypoint(position, args[1]));
                            return "Waypoint at position "+x+", "+y+", "+z+", "+" added";
                        }
                        else if (args.Length==2)
                        {
                            foreach (Waypoint waypoint in waypoints)
                            {
                                if (waypoint.name == args[1])
                                {
                                    return "Waypoint name already exists";
                                }
                            }
                            waypoints.Add(new Waypoint(sender.Position, args[1]));
                            return "Waypoint at your position added";
                        }
                        else
                        {
                            return "waypoint add <name> <x> <y> <z> or waypoint add <name> <player> or waypoint add <name>";
                        }
                    case "remove":
                        if (args.Length<2)
                        {
                            return "waypoint remove <name>";
                        }
                        else
                        {
                            foreach(Waypoint waypoint in waypoints)
                            {
                                if (waypoint.name==args[1])
                                {
                                    waypoints.Remove(waypoint);
                                    return "Waypoint " + waypoint.name + " removed";
                                }
                            }
                            return "Waypoint " + args[1] + " does not exist";
                        }
                    case "list":
                        string waypointNames = "";
                        foreach(Waypoint waypoint in waypoints)
                        {
                            waypointNames = waypointNames + waypoint.name + ", ";
                        }
                        return waypointNames;
                    case "teleport":
                        if(args.Length<2)
                        {
                            return "waypoint teleport <player> <waypoint> or waypoint teleport <waypoint>";
                        }
                        else if(args.Length<3)
                        {
                            foreach(Waypoint waypoint in waypoints)
                            {
                                if(waypoint.name==args[1])
                                {
                                    sender.Teleport(waypoint.pos);
                                    return "Teleported to waypoint " + waypoint.name;
                                }
                            }
                            return "Waypoint " + args[1] + " does not exist";
                        }
                        else if (args.Length>=3)
                        {
                            foreach (Waypoint waypoint in waypoints)
                            {
                                if (waypoint.name == args[2])
                                {
                                    string playerNicks = "";
                                    foreach(string player in args[1].Split('.'))
                                    {
                                        try
                                        {
                                            player.GetPlayer().Teleport(waypoint.pos);
                                            playerNicks = playerNicks + player.GetPlayer().Nick + ", ";
                                        }
                                        catch
                                        {

                                        }
                                    }
                                    return "Player(s) "+ playerNicks + " teleported to waypoint " + waypoint.name;
                                }
                            }
                            return "Waypoint " + args[2] + " does not exist";
                        }
                        else
                        {
                            return "waypoint teleport <player> <waypoint> or waypoint teleport <waypoint>";
                        }
                    case "change":
                        if (args.Length<2)
                        {
                            return "waypoint change <name> <x> <y> <z> or waypoint change <name> <player> or waypoint change <name>";
                        }
                        else if (args.Length == 2)
                        {
                            foreach(Waypoint waypoint in waypoints)
                            {
                                if(waypoint.name==args[1])
                                {
                                    waypoint.pos = sender.Position;
                                    return "Waypoint position changed to your position";
                                }
                            }
                            return "Waypoint " + args[1] + " does not exist";
                        }
                        else if(args.Length>=3&&args.Length<5)
                        {
                            foreach (Waypoint waypoint in waypoints)
                            {
                                if (waypoint.name == args[1])
                                {
                                    waypoint.pos = args[2].GetPlayer().Position;
                                    return "Waypoint position changed to position of player "+args[2].GetPlayer().Nick;
                                }
                            }
                            return "Waypoint " + args[1] + " does not exist";
                        }
                        else if(args.Length>=5)
                        {
                            float x = float.Parse(args[2]);
                            float y = float.Parse(args[3]);
                            float z = float.Parse(args[4]);
                            Vector3 position = new Vector3(x, y, z);
                            foreach (Waypoint waypoint in waypoints)
                            {
                                if (waypoint.name == args[1])
                                {
                                    waypoint.pos = position;
                                    return "Waypoint position changed to " + x + ", " + y + ", " + z;
                                }
                            }
                            return "Waypoint " + args[1] + " does not exist";
                        }
                        else
                        {
                            return "waypoint change<name> < x > < y > < z > or waypoint change<name> < player > or waypoint change<name>";
                        }
                    default:
                        return Usage;
                }
            }
        }
        public class Waypoint
        {
            public Vector3 pos;
            public string name;
            public Waypoint(Vector3 position, string waypointName)
            {
                pos = position;
                name = waypointName;
            }
        }
    }
}
