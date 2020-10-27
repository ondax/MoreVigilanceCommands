using Vigilance;
using Vigilance.API;

namespace MoreVigilanceCommands
{
    public class MuteAllCommand : CommandHandler
    {
        public bool muted = false;
        public string Command => "muteall";
        public string Usage => "muteall";
        public string Aliases => "mall";

        public string Execute(Player sender, string[] args)
        {
            foreach (Player player in Server.Players)
            {
                if (!player.RemoteAdmin)
                {
                    player.IsMuted = !muted;
                }
            }
            muted = !muted;
            if (muted)
            {
                return "All players muted";
            }
            else
            {
                return "All players unmuted";
            }
        }
    }
}
