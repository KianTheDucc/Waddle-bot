using DSharpPlus.Entities;
using DSharpPlus;
using DSharpPlus.Lavalink;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.SlashCommands.Attributes;
using DSharpPlus.VoiceNext;
using DSharpPlus.CommandsNext;
//using CliWrap.EventStream;
using DSharpPlus.CommandsNext.Attributes;

namespace Waddle_bot
{
    public class VoiceCommands : BaseCommandModule
    {
        
        public static VoiceNextExtension VoiceNext = Program.discord.GetVoiceNext();
        public static LavalinkExtension LavaLink = Program.discord.GetLavalink();

        public static List<LavalinkTrack> Queue = new List<LavalinkTrack>();

        public async Task<LavalinkGuildConnection> GetLavalinkConnection(CommandContext ctx)
        {
            var node = LavaLink.ConnectedNodes.Values.First();
            return node.GetGuildConnection(ctx.Guild);
        }

        public async Task PlayFromQueue(CommandContext ctx)
        {
        Start:
            var conn = LavaLink.GetGuildConnection(ctx.Guild);
            while (conn.CurrentState.CurrentTrack != null)
            {
                await Task.Delay(1);
            }
            if (Queue.Count > 0)
            {
                await conn.PlayAsync(Queue[0]);
                Queue.RemoveAt(0);
            }
            else
            {
                await Task.Delay(200000);
                if (conn.CurrentState.CurrentTrack == null)
                {
                    await conn.DisconnectAsync();
                    return;
                }
            }
            goto Start;
        }

        [Command("play")]
        public async Task Play(CommandContext ctx, [RemainingText]string search)
        {
            try
            {
                var node = LavaLink.ConnectedNodes.Values.First();
                var conn = await GetLavalinkConnection(ctx);

                var loadResult = await node.Rest.GetTracksAsync(search, LavalinkSearchType.Plain);

                if (loadResult.LoadResultType == LavalinkLoadResultType.LoadFailed
                    || loadResult.LoadResultType == LavalinkLoadResultType.NoMatches)
                {
                    await ctx.RespondAsync($"now playing {loadResult.Tracks.First().Title}");
                    return;
                }

                if (!LavaLink.ConnectedNodes.Any())
                {
                    await ctx.RespondAsync("The Lavalink connection is not established.");
                    return;
                }
                if (ctx.Member.VoiceState != null)
                {


                    await node.ConnectAsync(ctx.Member.VoiceState.Channel);
                }
                else
                {
                    await ctx.RespondAsync("You are not in a voice channel!");
                    return ;
                }
                var track = loadResult.Tracks.First();

                Queue.Add(track);
                await ctx.RespondAsync($"{track.Title} has been added to the queue!");
                await PlayFromQueue(ctx);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [Command("pause")]
        public async Task Pause(CommandContext ctx)
        {
            

            
                var conn = await GetLavalinkConnection(ctx);

                if (conn == null)
                {
                    await ctx.RespondAsync("The bot is not connected.");
                    return;
                }

                await conn.PauseAsync();

                await ctx.RespondAsync("Track has been paused.");
            

        }

        [Command("resume")]
        public async Task Resume(CommandContext ctx)
        {
            
                var conn = await GetLavalinkConnection(ctx);

                if (conn == null)
                {
                    await ctx.RespondAsync("The bot is not connected.");
                    return;
                }

                if (conn.CurrentState.CurrentTrack == null)
                {
                    await ctx.RespondAsync("There are no tracks loaded.");
                    return;
                }

                await conn.ResumeAsync();

                await ctx.RespondAsync("Track has been resumed.");
            

        }

        [Command("skip")]
        public async Task Skip(CommandContext ctx)
        {

                var conn = await GetLavalinkConnection(ctx);

                if (conn == null)
                {
                    await ctx.RespondAsync("The bot is not connected.");
                    return;
                }

                if (conn.CurrentState.CurrentTrack == null)
                {
                    await ctx.RespondAsync("There is nothing currently playing.");
                    return;
                }

                await ctx.RespondAsync("Track has been skipped.");
                await conn.StopAsync();
            

        }
        [Command("Queue")]
        public async Task QueueAsync(CommandContext ctx)
        {
            if (Queue.Count == 0)
            {
                ctx.RespondAsync("There's nothing in the queue!");
            }
            else
            {
                string responsestring = "";
                for (int i = 0; i < Queue.Count; i++)
                {
                    responsestring += $"{i + 1}: {Queue[i].Title}\n";
                }

                await ctx.RespondAsync(responsestring);
            }
        }
    }
}
