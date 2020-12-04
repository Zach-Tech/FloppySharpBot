using System;
using Discord.Commands;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using System.Linq;
using Zachary_Childers_CPT_185_Final.Helpers;

namespace Zachary_Childers_CPT_185_Final.Admin
{
    [Name("Admin Commands")]
    [RequireContext(ContextType.Guild)]
    [RequireUserPermission(GuildPermission.ManageRoles)]
    public class AdminStuff : ModuleBase<SocketCommandContext>
    {

        [Command("say"), Summary("Bot will repeat argument -> ")]
        public async Task Say([Remainder, Summary("User's words repeated by Floppy")] string say)
        {
            await ReplyAsync(say);
            await Context.Message.DeleteAsync();
        }
        //gotta have a purge command when dealing with bots
        //testing functions will quickly fill up a channel
        //gotta clear it afterwards
        [Command("purge", RunMode = RunMode.Async)]
        [Remarks("Purges messages (int) amount from guild channel")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Clear(int amountOfMessagesToDelete)
        {
            await (Context.Message.Channel as SocketTextChannel).DeleteMessagesAsync(await Context.Message.Channel.GetMessagesAsync(amountOfMessagesToDelete + 1).FlattenAsync());
            await Context.Message.DeleteAsync();
        }



        [Command("purge")]
        [Remarks("Purges A User's Last Messages. Default Amount To Purge Is 100")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Clear(SocketGuildUser user, int amountOfMessagesToDelete = 100)
        {
            if (user == Context.User)
                amountOfMessagesToDelete++; //Because it will count the purge command as a message

            var messages = await Context.Message.Channel.GetMessagesAsync(amountOfMessagesToDelete).FlattenAsync();

            var result = messages.Where(x => x.Author.Id == user.Id && x.CreatedAt >= DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(14)));

            await (Context.Message.Channel as SocketTextChannel).DeleteMessagesAsync(result);

        }
        //This will set the bot's "Playing" status
        [Command("Game"), Alias("ChangeGame", "SetGame")]
        [Remarks("Change what the bot is currently playing.")]
        [RequireOwner]
        public async Task SetGame([Remainder] string gamename)
        {
            await Context.Client.SetGameAsync(gamename);
            await ReplyAsync($"Changed game to `{gamename}`");
            await Context.Message.DeleteAsync();
        }
        [Command("createtext")]
        [Remarks("Make A Text Channel")]
        [RequireUserPermission(GuildPermission.ManageChannels)]
        public async Task Text(string channelname)
        {
            await Context.Guild.CreateTextChannelAsync(channelname);
        }
        [Command("createvoice")]
        [Remarks("Make A Voice Channel")]
        [RequireUserPermission(GuildPermission.ManageChannels)]
        public async Task Voice([Remainder] string channelname)
        {
            await Context.Guild.CreateVoiceChannelAsync(channelname);
        }
        [Command("announce")]
        [Remarks("Make A Announcement")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Announce([Remainder] string announcement)
        {
            var embed = EmbedHandler.CreateEmbed("Announcement By " + Context.Message.Author, announcement, EmbedHandler.EmbedMessageType.Info, true);

            await Context.Channel.SendMessageAsync("", false, embed);
            await Context.Message.DeleteAsync();
        }
        [Command("nickname")]
        [Remarks("Set A User's Nickname")]
        [RequireUserPermission(Discord.GuildPermission.ManageNicknames)]
        public async Task Nickname(SocketGuildUser username, [Remainder] string name)
        {
            await Context.Guild.GetUser(username.Id).ModifyAsync(x => x.Nickname = name);
        }

        [Command("ban")]
        [Remarks("Ban A User")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task Ban(SocketGuildUser user)
        {
            await Context.Guild.AddBanAsync(user);
        }

        [Command("unban")]
        [Remarks("Unban A User")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task Unban(ulong id)
        {
            var bans = await Context.Guild.GetBansAsync();

            var theUser = bans.FirstOrDefault(x => x.User.Id == id);

            await Context.Guild.RemoveBanAsync(theUser.User);
        }

      




    }
}
