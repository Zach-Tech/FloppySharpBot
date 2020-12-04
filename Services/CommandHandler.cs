using System.Threading.Tasks;
using System.Reflection;
using Discord.Net;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
using Discord;
using Microsoft.Extensions.Configuration;
using DiscordRPC.Logging;
using Zachary_Childers_CPT_185_Final.Services;

namespace Zachary_Childers_CPT_185_Final.Services
{
    public class CommandHandler
    {
        private CommandService _commands;
        private DiscordSocketClient _client;
        private readonly IConfigurationRoot _config;
        private readonly IServiceProvider _services;

        public CommandHandler(IServiceProvider services)
        {
            _services = services;
            _config = services.GetRequiredService<IConfigurationRoot>();
            _client = services.GetRequiredService<DiscordSocketClient>();
            _commands = services.GetRequiredService<CommandService>();
            _client.MessageReceived += HandleCommand;
        }

        public async Task HandleCommand(SocketMessage parameterMessage)
        {
            // Don't handle the command if it is a system message
            var message = parameterMessage as SocketUserMessage;
            if (message == null) return;

            // Don't listen to bots
            if (message.Source != MessageSource.User)
            {
                return;
            }

            // Mark where the prefix ends and the command begins
            int argPos = 0;

            // Create a Command Context
            var context = new SocketCommandContext(_client, message);

            String prefix = (_config[">>"]);

            var serverPrefix = GetPrefix((long)context.Guild.Id);

            if (serverPrefix != null)
            {
                prefix = (">>");
            }

            var result = await _commands.ExecuteAsync(context, argPos, _services);

        }
        private object GetPrefix(long id)
        {
            throw new NotImplementedException();
        }
    }
}
