using System;
using System.Collections.Generic;
using System.Text;
using Discord.Commands;
using Discord;
using Discord.WebSocket;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Zachary_Childers_CPT_185_Final.Modules.OwnerCommands
{
    public class OwnerModule : ModuleBase
    {
        [Command("shutDown")]
        [RequireOwner]
        public async Task shutDown()
        {
            await ReplyAsync("shutting down...");
            Environment.Exit(0);
        }

        [Command("restart")]
        [RequireOwner]
        public async Task Restart()
        {
            await ReplyAsync("Restarting...");

        }

    }

}
