using System.Collections.Generic;
using Vigilance;
using Vigilance.API;

namespace MoreVigilanceCommands
{
    class ListAdminsCommand : CommandHandler
    {
        public string Command => "listadmins";

        public string Usage => "listadmins";

        public string Aliases => "adminlist";

        public string Execute(Player sender, string[] args)
        {
            List<Player> admins = new List<Player>();
            foreach(Player player in Server.Players)
            {
                
                if(player.RemoteAdmin)
                {
                    admins.Add(player);   
                }
            }
            if (admins.IsEmpty())
            {
                return "There are no admins on server!";
            }
            else
            {
                string response = "";
                if (admins.Count == 1)
                {
                    response = "There is " + admins.Count + " admin on server.";
                }
                else {
                    response = "There are " + admins.Count + " admins on server.";
                }
                foreach(Player admin in admins)
                {
                    response += "\n(" + admin.PlayerId + ") " + admin.Nick;
                }
                return response;
            }
        }
    }
}
