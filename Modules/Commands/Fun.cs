using System;
using System.Collections.Generic;
using System.Text;
using Discord.Commands;
using Discord.Webhook;
using System.Threading.Tasks;
using System.Globalization;
using System.Web;
using System.Linq;
using Discord;
using Discord.WebSocket;

namespace Zachary_Childers_CPT_185_Final.Modules.FunCommands
{
    public class Fun : ModuleBase
    {
        Random rnd = new Random();
        //D6 die command
        [Command("die")]
        [Summary("D6")]
        public async Task dice(int sides = 6)
        {
            if (sides >= 2 && sides <= 255)
            {
                int rolledNumber = rnd.Next(sides);
                await ReplyAsync(Context.User.Mention + " You rolled " + (rolledNumber + 1).ToString());
            }
            else
            {
                await ReplyAsync($"you entered {sides}, please try agian\nMin:2\nMax255");
            }
        }

        [Command("YTSearch")]
        [Summary("Searches YouTube for the provided value, returns a result")]
        public async Task YTSearch(string query)
        {
            var returnURL = "https://www.youtube.com/results?search_query=" + HttpUtility.UrlEncode(query);
            await ReplyAsync(returnURL);
            //should construct the search query and result
        }

        [Command("urban")]
        [Summary("Look up a word on the urban dictionary")]
        public async Task Urban(string key)
        {
            var url = "https://www.urbandictionary.com/define.php?term=" + HttpUtility.UrlEncode(key);
            await ReplyAsync(url);
        }

        [Command("LMGTFY")]
        [Summary("Whenever someone asks something obviousy, Google it for them!")]
        public async Task LetMeGoogleThatForYou(string search)
        {
            var sarcasm = "https://lmgtfy.com/?q=" + HttpUtility.UrlEncode(search);

            await ReplyAsync(sarcasm);
        }

        [Command("google")]
        [Summary("Searches YouTube for the provided value, returns a result")]
        public async Task Google(string query)
        {
            var returnURL = "https://www.google.com/search?q=" + HttpUtility.UrlEncode(query);
            await ReplyAsync(returnURL);
            //should construct the search query and result
        }

        [Command("coin")]
        [Summary("Simple coin toss game")]
        public async Task coin()
        {
            //gen rand num between 0 - 1, assigns heads and tails to each
            int ranNum = rnd.Next(2);
            if (ranNum == 0)
            {
                await ReplyAsync(Context.User.Mention + " Heads");
            }
            else if (ranNum == 1)
            {
                await ReplyAsync(Context.User.Mention + " Tails");
            }
            else
            {
                await ReplyAsync(Context.User.Mention + " Sorry! Your flipping skills are too powerful\nTry again.");
                Console.WriteLine("[ERROR] [" + Context.Guild.Name.ToString() + "] Invalid coin toss, threw " + ranNum.ToString());
            }
        }

        [Command("Palindrome")]
        [Summary("Checks to see if provided word is or is not a palindrome.")]
        public async Task CheckIfPalindrome(string wordToCheck)
        {
            char[] sArray = wordToCheck.ToCharArray();
            Array.Reverse(sArray);
            // If the reverse string is equal to the passed in paramenter and there is no space in the provided word.
            var wordIsPalindrome = wordToCheck == new string(sArray) && !sArray.Any(x => char.IsWhiteSpace(x));

            await ReplyAsync(wordToCheck + " is " + (wordIsPalindrome ? "" : "not ") + "a palindrome.");
        }

        [Command("Prime")]
        [Summary("Check if number is Prime")]
        public async Task PrimeNumberCheck(string number)
        {
            var isNumber = Int64.TryParse(number, out long num);
            string result = string.Empty;
            bool isPrime = true;
            if (!isNumber)
            {
                result = $"{number} is not a valid integer number.";

            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(num) + 1; i++)
                {
                    if (num % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }

            result = $"{number} is{(!isPrime ? " not" : string.Empty)} a prime number";
            await ReplyAsync(result);
        }


        [Command("cat")]
        [Summary("Searches YouTube for the provided value, returns a result")]
        public async Task cat()
        {
            var embed = new EmbedBuilder();
            // var returnURL = "http://theoldreader.com/kittens/600/400";
            embed.WithImageUrl("http://theoldreader.com/kittens/600/400");
            await ReplyAsync(embed: embed.Build());


        }

        [Command("null")]
        [Summary("Inside Joke :)")]
        public async Task Null()
        {
            await Context.Channel.SendFileAsync("C:\\Users\\ZChil\\Desktop\\Fall 2020\\C# Class\\Zachary-Childers-CPT-185-Final\\Modules\\MemeImages\\null_lmao.png");
        }

        [Command("Homies")]
        [Summary("Inside Joke :)")]
        public async Task Homies()
        {
            await Context.Channel.SendFileAsync("C:\\Users\\ZChil\\Desktop\\Fall 2020\\C# Class\\Zachary-Childers-CPT-185-Final\\Modules\\MemeImages\\homies.jpg");
        }
        [Command("mmm")]
        [Summary("Inside Joke :)")]
        public async Task Phallic()
        {
            await Context.Channel.SendFileAsync("C:\\Users\\ZChil\\Desktop\\Fall 2020\\C# Class\\Zachary-Childers-CPT-185-Final\\Modules\\MemeImages\\unknown.png");
        }

        [Command("BigPing")]
        [Summary("Inside Joke :)")]
        public async Task BIGPING()
        {
            await Context.Channel.SendFileAsync("C:\\Users\\ZChil\\Desktop\\Fall 2020\\C# Class\\Zachary-Childers-CPT-185-Final\\Modules\\MemeImages\\bigPing.png");
        }

        [Command("Clown")]
        [Summary("Inside Joke :)")]
        public async Task Clown()
        {
            await Context.Channel.SendFileAsync("C:\\Users\\ZChil\\Desktop\\Fall 2020\\C# Class\\Zachary-Childers-CPT-185-Final\\Modules\\MemeImages\\clown.png");
        }

        [Command("Sherpa")]
        [Summary("Inside Joke :)")]
        public async Task sherpa()
        {

            SocketUser user = null;

            string message = (
                 $"{""} {Format.Bold("The #1 Sherpa!")} The Legend!\n"
              ); 
            // $"{">>"} {Format.Bold("Ping: ")} Ping yourself, and return latency." +
            //  $"{">>"} {Format.Bold("Ping: ")} Ping yourself, and return latency." +
            //    $"{">>"} {Format.Bold("Ping: ")} Ping yourself, and return latency.
            Color color = new Color(220, 87, 121);
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
            var embed = new EmbedBuilder()
                .WithTitle("Brosario!\n\n")
                .WithColor(color)
                .AddField(x => { x.Name = "\n`                            ` \n"; x.Value = message; x.WithIsInline(true); })
                .WithDescription("I wish I could be Sherpa'd by his godly hands\nnestled between his Sherpa-ly abs....\nremember his name....\nBrosario...")
                //.AddField(x => { x.Name = "Avatar"; x.Value = footer; x.WithIsInline(true); })
                //    .AddField(x => { x.Name = "Note Types:"; x.Value = message; x.WithIsInline(true); })  
                //    .AddField(x => { x.Name = "Limits:"; x.Value = message; x.WithIsInline(true); })           
                .Build();
            await Context.Channel.SendMessageAsync("", false, embed);
            await Context.Channel.SendFileAsync("C:\\Users\\ZChil\\Desktop\\Fall 2020\\C# Class\\Zachary-Childers-CPT-185-Final\\Modules\\MemeImages\\image0.png");
        }

        [Command("Indeed")]
        [Summary("Inside Joke :)")]
        public async Task Indeed()
        {
            await Context.Channel.SendFileAsync("C:\\Users\\ZChil\\Desktop\\Fall 2020\\C# Class\\Zachary-Childers-CPT-185-Final\\Modules\\MemeImages\\Indeed.jpg");
        }

        [Command("spong")]
        [Summary("Inside Joke :)")]
        public async Task spong()
        {
            await Context.Channel.SendFileAsync("C:\\Users\\ZChil\\Desktop\\Fall 2020\\C# Class\\Zachary-Childers-CPT-185-Final\\Modules\\MemeImages\\sponge.png");
        }
    }
}
