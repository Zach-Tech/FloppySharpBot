using Discord;
using Zachary_Childers_CPT_185_Final.Services;

namespace Zachary_Childers_CPT_185_Final.OnJoin
{
    public class HelloWorldTask : IOnboardingTask
    {
        private readonly Logger logger;

        public HelloWorldTask(Logger logger) { this.logger = logger; }

        public async void OnJoined(IGuild guild)
        {
            var defaultChannel = await guild.GetDefaultChannelAsync();
            if (defaultChannel is null)
            {
                await logger.Log(LogSeverity.Error, "Onboarding> HWTask", $"Default channel of a new guild ({guild.Name} is null.");
                return;
            }

            await defaultChannel.SendMessageAsync(":wave: Hey!!! I'm Floppy#... I'm here to assist you, just please be kind - and remember that Human x Robot relations are not appropriate! \nThank you!");
        }
    }
}