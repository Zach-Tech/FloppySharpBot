using Discord;
namespace Zachary_Childers_CPT_185_Final.OnJoin
{
    public interface IOnboardingTask
    {
        void OnJoined(IGuild guild);
    }
}