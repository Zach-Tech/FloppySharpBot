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
        //forces bot to leave a server based on server id
        [Command("leaveGuild")]
        [RequireOwner]
        public async Task LeaveGuild(ulong id)
        {
            var client = Context.Client as DiscordSocketClient;
            await client.GetGuild(id).LeaveAsync();
        }

        //displays information about a server based on server id
        [Command("serverinfo")]
        [Summary("displays info about the server")]
        public async Task ServerInfo(ulong id)
        {
            var application = await Context.Client.GetApplicationInfoAsync();
            if (Context.User.Id == application.Owner.Id)
            {
                var guild = await Context.Client.GetGuildAsync(id) as SocketGuild;
                var owner = guild.Owner.Username;
                var avatar = guild.IconUrl;
                var avatar2 = guild.IconUrl;
                var usersCount = guild.MemberCount;
                var botCount = guild.Users.Count(x => x.IsBot); ;
                var humanCount = (usersCount - botCount);
                var time = guild.CreatedAt;
                var verification = guild.VerificationLevel;
                var channels = guild.Channels.Count;
                var roles = guild.Roles.Count;

                if (avatar == null)
                {
                    avatar = "none";
                    avatar2 = avatar = "https://cdn.discordapp.com/embed/avatars/0.png";
                }

                if (avatar.Contains("/a_"))
                {
                    avatar = $"{avatar.Remove(avatar.Length - 12)}gif?size=128";
                    avatar2 = $"{avatar.Remove(avatar.Length - 12)}gif?size=128";
                }

                string message = (
                    $"- {Format.Bold("count:")} {usersCount} \n" +
                    $"\t- Humans:{humanCount} \n" +
                    $"\t- Bots:{botCount}"
                );
                string other = (
                    $"- {Format.Bold("Channel count:")} {channels} \n" +
                    $"- {Format.Bold("Role count:")} {roles} \n" +
                    $"- {Format.Bold("Verification Level:")} {verification}"
                );
                string footer;
                if (avatar == "none")
                {
                    footer = (
                        $"[{avatar}]({avatar})"
                    );
                }
                else
                {
                    footer = avatar;
                }

                Color color = new Color(0, 225, 255);

                var embed = new EmbedBuilder()
                    .WithThumbnailUrl(avatar2)
                    .WithTitle($"Server Info for {guild.Name}")
                    .AddField(x => { x.Name = "ID:"; x.Value = guild.Id; x.WithIsInline(true); })
                    .AddField(x => { x.Name = "Owner:"; x.Value = owner; x.WithIsInline(true); })
                    .AddField(x => { x.Name = "Created at:"; x.Value = time.ToString().Remove(time.ToString().Length - 6); ; x.WithIsInline(true); })
                    .AddField(x => { x.Name = "Members:"; x.Value = message; x.WithIsInline(true); })
                    .AddField(x => { x.Name = "Region:"; x.Value = guild.VoiceRegionId; x.WithIsInline(true); })
                    .AddField(x => { x.Name = "Other:"; x.Value = other; x.WithIsInline(true); })
                    .WithColor(color)
                    .Build();

                await Context.Channel.SendMessageAsync("", false, embed);
            }
        }


    }

}
