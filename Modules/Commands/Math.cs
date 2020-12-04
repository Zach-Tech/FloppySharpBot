using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Discord.WebSocket;
using Discord.Rest;
using System.Globalization;
using static MiNET.Net.McpeSetScoreboardIdentity;

namespace Zachary_Childers_CPT_185_Final.Modules.Commands
{
    public class Math : ModuleBase
    {


        [Command("add")]
        [Summary("Adds 2 numbers together.")]
        public async Task AddAsync(float num1, float num2)
        {
            await ReplyAsync($"The Answer To That Is: {num1 + num2}");
        }

        [Command("Subtract")]
        [Summary("Subtracts 2 numbers.")]
        public async Task SubstractAsync(float num1, float num2)
        {
            await ReplyAsync($"The Answer To That Is: {num1 - num2}");
        }

        [Command("Multiply")]
        [Summary("Multiplys 2 Numbers.")]
        public async Task MultiplyAsync(float num1, float num2)
        {
            await ReplyAsync($"The Answer To That Is {num1 * num2}");
        }

        [Command("Divide")]
        [Summary("Divides 2 Numbers.")]
        public async Task DivideAsync(float num1, float num2)
        {
            await ReplyAsync($"The Answer To That Is: {num1 / num2}");
        }

      


    }
}
