using System;
using System.Collections.Generic;
using System.Text;
using Discord.Commands;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using Discord.Net;
using MiNET.Plugins.Commands;
using Zachary_Childers_CPT_185_Final.APIStuff;
using RestSharp;
using Zachary_Childers_CPT_185_Final.Services;


namespace Zachary_Childers_CPT_185_Final.Commands
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        private static readonly RestClient client = new RestClient();

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
            //{userInfo.Username}#{userInfo.Discriminator}\n{userInfo.Status}\n{userInfo.CreatedAt}\n{userInfo.Activity}
            string nickname = "none";
            IGuildUser self = Context.User as IGuildUser;
            var uID = self.Id;
            var userN = self.Username;
            var time = self.CreatedAt;
            var joined = self.JoinedAt;
            var mention = self.Mention;
            var Descrim = self.Discriminator;
            var avatar = self.GetAvatarUrl();
            var avatar2 = self.GetAvatarUrl();
            if (self.Nickname != null && user == null)
            {
                nickname = self.Nickname;
            }

            if (user != null)
            {
                uID = user.Id;
                userN = user.Username;
                time = user.CreatedAt;
                mention = user.Mention;
                Descrim = user.Discriminator;
                avatar = user.GetAvatarUrl();
                avatar2 = user.GetAvatarUrl();
           
            }
            if (avatar == null)
            {
                avatar = "none";
                avatar2 = "https://cdn.discordapp.com/embed/avatars/0.png";
            }

            if (avatar.Contains("/a_"))
            {
                avatar = $"{avatar.Remove(avatar.Length - 12)}gif?size=128";
                avatar2 = $"{avatar.Remove(avatar.Length - 12)}gif?size=128";
            }

            string footer;
            if (avatar != "none")
            {
                footer = (
                    $"[{avatar}]({avatar})"
                );
            }
            else
            {
                footer = avatar;
            }
            Color color = new Color(250, 0, 255);
            var embed = new EmbedBuilder()
                .WithThumbnailUrl(avatar2)
                .WithColor(color)
                .WithTitle("User Info:")
                .AddField(x => { x.Name = "Name:"; x.Value = userN; x.WithIsInline(true); })
                .AddField(x => { x.Name = "ID:"; x.Value = uID; x.WithIsInline(true); })
                .AddField(x => { x.Name = "Descrim:"; x.Value = Descrim; x.WithIsInline(true); })
                .AddField(x => { x.Name = "Created at:"; x.Value = time.ToString().Remove(time.ToString().Length - 6); x.WithIsInline(true); })
                .AddField(x => { x.Name = "Joined at:"; x.Value = joined.ToString().Remove(joined.ToString().Length - 6); x.WithIsInline(true); x.IsInline = true; })
                .AddField(x => { x.Name = "Avatar:"; x.Value = footer; x.WithIsInline(false); })
                .Build();

            await Context.Channel.SendMessageAsync($"{mention}", false, embed);
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

        [Command("cool")]
        public async Task cool()
        {
            var msg = await ReplyAsync("( ͡° ͜ʖ ͡°)>⌐■-■");
            await Task.Delay(1500);
            await msg.ModifyAsync(x => { x.Content = "( ͡⌐■ ͜ʖ ͡-■)"; });
        }

        //[Command("CurrentWeather")]
        //[Summary("Gets current weather details (temperature in celcius) for the city")]
        //public async Task GetCurrentWeather(string city)
        //{
        //    var openWeatherAPIClient = new OpenWeatherAPI(Configuration.config.OpenWeatherAPIKey);
        //    var result = await openWeatherAPIClient.QueryAsync(city);
        //    string response = $"The temperature in {city} is {result}C";
        //    await ReplyAsync(response);
        //}
           //Api Seems to be good, will work on this in the future.


    }
}
