using Discord;
namespace Zachary_Childers_CPT_185_Final.OnJoin
{
    public interface IOnboardingTask
    {
        void OnJoined(IGuild guild);
    }
}
//this should help in making a 
// "Hi im xyz, use my X command" on bot invite to server
// Most professional, user friendly bots have this feature - those that do not leave
// users wondering  - where the hell is my bot? how do I access it? And it's very frustrating
// for everyone involved.