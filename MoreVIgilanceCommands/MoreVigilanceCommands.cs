using System;
using System.Collections.Generic;
using System.Text;
using Vigilance.Core;

namespace MoreVIgilanceCommands
{
    class MoreVigilanceCommands : Plugin
    {
        public override string Id => "morevigilancecommands";

        public override string Name => "MoreVigilanceCommands";

        public override void OnDisable()
        {
            Info(Name + " disabled succesfully");
        }

        public override void OnEnable()
        {
            Info(Name + " enabled succesfully");
            AddCommand("clearbc", new ClearBCCommand(this));
            AddCommand("shake", new ShakeCommand(this));
            AddCommand("spawnworkbench", new SpawnWorkbenchCommand(this));
            AddCommand("cleanup", new CleanupCommand(this));
            AddCommand("clearcards", new ClearCardsCommand(this));
        }
    }
}
