using System.Runtime.CompilerServices;
using Vigilance;
using Vigilance.API;
using Vigilance.Events;
using Vigilance.Handlers;

namespace MoreVigilanceCommands
{
    class RemoteKeycardHandler : DoorInteractEventHandler
    {
        public MoreVigilanceCommands plugin;
        public bool enabled => ConfigManager.GetBool("mvc_remotekeycard_enabled");
        public RemoteKeycardHandler(MoreVigilanceCommands mvc) => plugin = mvc;
        public bool AllowAccess(DoorInteractEvent doorev)
        {
            if (doorev.Player.BypassMode)
            {
                return true;
            }
            else if (!doorev.Door.locked)
            {
                foreach (Inventory.SyncItemInfo i in doorev.Player.Inventory.items)
                {
                    foreach (string perm in doorev.Player.Inventory.GetItemByID(i.id).permissions)
                    {
                        if (perm.ToLower() == doorev.Door.permissionLevel.ToLower())
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        public void OnInteract(DoorInteractEvent ev)
        {
            if (enabled && AllowAccess(ev))
            {
                ev.Door.ChangeState();
                ev.Allow = true;
            }
        }
    }
}
