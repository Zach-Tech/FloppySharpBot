﻿//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using Discord;
//using Discord.Commands;
//using Zachary_Childers_CPT_185_Final.Services;

//namespace Zachary_Childers_CPT_185_Final.Music
//{
//    public class AudioModule : ModuleBase
//    {
//        private static readonly string[] YoutubeHosts = new[] { "youtu.be", "youtube.com", "www.youtube.com" };
//        private readonly AudioService _service;
//        public AudioModule(AudioService service)
//        {
//            _service = service;
//        }

//        [Command("StartMusic", RunMode = RunMode.Async)]
//        public async Task JoinVoiceChannel()
//        {
//            if ((Context.User as IVoiceState).VoiceChannel != null)
//            {
//                await _service.JoinAudioAsync((Context.User as IVoiceState).VoiceChannel);
//            }
//            else
//            {
//                await ReplyAsync("You must be in a voice channel to use this.");
//            }
//        }

//        [Command("Play", RunMode = RunMode.Async)]
//        public async Task Play([Remainder] string song)
//        {
//            if (!Uri.TryCreate(song, UriKind.Absolute, out var uri))
//            {
//                return;
//            }
//            if (YoutubeHosts.Contains(uri.Host))
//            {
//                await _service.SendAudioFromYoutubeLinkAsync(Context.Guild, song);
//            }
//        }

//        [Command("StopMusic", RunMode = RunMode.Async)]
//        public async Task LeaveVoiceChannel()
//        {
//            await _service.LeaveAudio(Context.Guild);
//        }
//    }
//}



