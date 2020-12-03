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
        //Basic first command, I say "Ping", bot replies "Pong"
        //Generally, all commands must be activated by a prefix,
        //Unless the bot utilizes listeners and kwargs.
        [Command("ping")]
        [Summary("Returns Pong!")]
        public async Task ping()
        {
            await ReplyAsync($"Pong! `Latency: {(Context.Client as DiscordSocketClient).Latency}ms`");
        }

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
     //    var embed = new EmbedBuilder();
     //    embed.WithTitle("Here's a cat!");
     //    embed.WithImageUrl("https://imgur.com/r/cats/oNPbwxs");
     //    embed.WithColor(new Color(52, 152, 219));
     //    embed.WithCurrentTimestamp();
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

        // Displays the number of days in a month for the current year
        [Command("MonthLength")]
        [Summary("Command to display how many days a month has this year. Pass the month number (e.g. 1 for January, 2 for February and so on) as an argument.")]
        public async Task MonthLength(uint month)
        {
            int feb;
            int year = DateTime.Now.Year;
            if (year % 4 == 0 && ((year % 100 != 0) || (year % 400 == 0)))
                feb = 29;
            else
                feb = 28;

            Tuple<string, int>[] months = {
                Tuple.Create("January", 31),
                Tuple.Create("February", feb),
                Tuple.Create("March", 31),
                Tuple.Create("April", 30),
                Tuple.Create("May", 31),
                Tuple.Create("June", 30),
                Tuple.Create("July", 31),
                Tuple.Create("August", 31),
                Tuple.Create("September", 30),
                Tuple.Create("October", 31),
                Tuple.Create("November", 30),
                Tuple.Create("December", 31)
            };
            string response = months[month - 1].Item1 + " has " + months[month - 1].Item2 + " days.";

            await ReplyAsync(response);
        }






    }
}
