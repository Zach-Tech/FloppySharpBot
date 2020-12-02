using System;
using System.Collections.Generic;
using System.Text;
using Discord.Commands;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using Discord.Net;
using MiNET.Plugins.Commands;

namespace Zachary_Childers_CPT_185_Final.Commands
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        List<string> HelpCommand = new List<string>(10)
            HelpCommand.Add("Ping");
      
        private readonly CommandService _service;

        public Commands(CommandService service)
        {
            _service = service;

        }


        [Command("Help")]
        public async Task Help()
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Help in your time of need!");
            embed.WithColor(new Color(52, 152, 219));
            embed.WithCurrentTimestamp();
            await Context.Channel.SendMessageAsync("", embed: embed.Build(), HelpCommand);
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

      // [Command("cat")]
      // [Summary("Returns a kitty")]
      // public async Task Cat()
      // {
      //    //var embed = new EmbedBuilder();
      //    //embed.WithTitle("Here's a cat!");
      //    //embed.WithImageUrl("https://imgur.com/r/cats/oNPbwxs");
      //    //embed.WithColor(new Color(52, 152, 219));
      //    //embed.WithCurrentTimestamp();
      //     await Context.Channel.SendMessageAsync("", embed: embed.Build());
      // }

        [Command("xkcd")]
        [Summary("Returns an xkcd comic")]
        public async Task xkcd()
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("xkcd comic!");
            embed.WithImageUrl("https://imgs.xkcd.com/comics/life_before_the_pandemic.png");
            embed.WithColor(new Color(52, 152, 219));
            embed.WithCurrentTimestamp();
            await Context.Channel.SendMessageAsync("", embed: embed.Build());
        }

      
        



    }
}
