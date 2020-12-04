using System;
using Discord;
using Discord.WebSocket;
using System.Reflection;
using System.Threading.Tasks;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;
using Zachary_Childers_CPT_185_Final.Services;

namespace Zachary_Childers_CPT_185_Final
{

    class Floppy
    {
        public static void Main(string[] args) 
        {
            try
            {
                new Floppy().RunBotAsync().GetAwaiter().GetResult();
            }
            catch(Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }
         
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;

        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();
            string token = "YOUR TOKEN HERE";
            _client.Log += _client_Log;
            await RegisterCommandsAsync();
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            await Task.Delay(-1);

        }
        private Task _client_Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }
        public async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }
        private async Task HandleCommandAsync(SocketMessage arg)
        {
            
            var message = arg as SocketUserMessage;
            if (message == null) return;
            if (message.Source != MessageSource.User) { return; };


            int argPos = 0;
            if (message.HasStringPrefix(str: ">>", ref argPos))
            {
                var context = new SocketCommandContext(_client, message);
                var result = await _commands.ExecuteAsync(context, argPos, services: _services);
                if (!result.IsSuccess)
                {
                    if (result.ErrorReason != "Unknown command.")
                    {
                        await message.Channel.SendMessageAsync($"**Error:** {result.ErrorReason}");
                    }
                }
            }
        }

    }
}