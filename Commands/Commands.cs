using System;
using System.Collections.Generic;
using System.Text;
using Discord.Commands;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace Zachary_Childers_CPT_185_Final.Commands
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        Dictionary<string, string> HelpCommand = new Dictionary<string, string>()
        {
            {"\n**Ping**", "Returns Pong\n"}, {"\n**Help**", "Returns This command\n"},
            {"\n**Add**", "Adds together two numbers\n"}
        };


        private readonly CommandService _service;

        public Commands(CommandService service)
        {
            _service = service;
        }

        //Basic first command, I say "Ping", bot replies "Pong"
        //Generally, all commands must be activated by a prefix,
        //Unless the bot utilizes listeners and kwargs.
        [Command("Ping")]
        public async Task Ping() { await ReplyAsync("pong"); }

        // ~sample userinfo --> foxbot#0282
        // ~sample userinfo @Khionu --> Khionu#8708
        // ~sample userinfo Khionu#8708 --> Khionu#8708
        // ~sample userinfo Khionu --> Khionu#8708
        // ~sample userinfo 96642168176807936 --> Khionu#8708
        // ~sample whois 96642168176807936 --> Khionu#8708
        [Command("userinfo")]
        [Summary
        ("Returns info about the current user, or the user parameter, if one passed.")]
        [Alias("user", "whois")]
        public async Task UserInfoAsync(
            [Summary("The (optional) user to get info from")]
        SocketUser user = null)
        {
            var userInfo = user ?? Context.Client.CurrentUser;
            await ReplyAsync($"{userInfo.Username}#{userInfo.Discriminator}");
        }



    }
}
