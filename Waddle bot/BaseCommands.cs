using ChatGPT.Net;
using DSharpPlus.SlashCommands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext.Attributes;
using ChatGPT.Net.DTO;
namespace Waddle_bot
{
    public class BasedCommands : BaseCommandModule
    {
        [Command("echo")]
        public async Task EchoCommand(CommandContext ctx, [RemainingText] string message)
        {
            if (ctx.User.Id == 295110922890903566 || ctx.User.Id == 353536672765313027)
            {
                await ctx.Message.DeleteAsync();
                await ctx.TriggerTypingAsync();
                await ctx.RespondAsync(message);
            }

        }
        [Command("alive")]
        public async Task aliveCommand(CommandContext ctx)
        {
            await ctx.RespondAsync("I'm alive");
        }
        [Command("quack")]
        public async Task quackCommand(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.Channel.SendMessageAsync("https://tenor.com/view/duck-gif-18144587");
        }
        [Command("Hug")]
        public async Task hugCommand(CommandContext ctx)
        {
            await ctx.RespondAsync("Waddle hugs you :)");
        }
        [Command("waddlelove")]
        public async Task waddleloveCommand(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.Member.SendMessageAsync("Hehe i love you <3");
        }
        [Command("wiggle")]
        public async Task wiggleCommand(CommandContext ctx)
        {
            await ctx.RespondAsync("https://tenor.com/view/bubu-dudu-stickers-gif-26502165");
        }
        [Command("mutecaezar")]
        public async Task muteCaezar(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.Guild.GetMemberAsync(361194147224223744).Result.SetMuteAsync(true);
        }
        [Command("unmutecaezar")]
        public async Task unmuteCaezar(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.Guild.GetMemberAsync(295110922890903566).Result.SetMuteAsync(false);
        }
        [Command("nessie")]
        public async Task findNessie(CommandContext ctx)
        {
            await ctx.RespondAsync("https://tenor.com/view/slushe-nessie-apex-legends-dancing-gif-26089899");
        }
        [Command("cheese")]
        public async Task cheeseCommand(CommandContext ctx)
        {
            await ctx.RespondAsync("https://tenor.com/view/cheese-gif-25732604");
        }
        [Command("banned")]
        public async Task bannedCommand(CommandContext ctx)
        {
            await ctx.RespondAsync("https://cdn.discordapp.com/attachments/1083193177432924312/1088637343902216223/B7651EAD-AB94-421D-93AF-429E19A67DC1.jpg");
        }
        [Command("creeper")]
        public async Task creeperCommand(CommandContext ctx)
        {

            await ctx.RespondAsync("https://media.discordapp.net/attachments/1083193177432924312/1088637672576254153/mined-discord.gif");
            await ctx.TriggerTypingAsync();
            await ctx.Channel.SendMessageAsync("aww man");
        }
        [Command("chatgpt")]
        public async Task ChatGPTCommand(CommandContext ctx, [RemainingText] string prompt, [RemainingText] string conversationId)
        {
            await ctx.RespondAsync("Waiting for GPT Response...");

            ChatGptClientConfig gptConfig = new ChatGptClientConfig
            {
                SessionToken = Resource1.SessionToken, 
                AccountType = ChatGPT.Net.Enums.AccountType.Free
            };
            ChatGpt chat = new ChatGpt();
            await chat.WaitForReady();
            var chatGptClient = await chat.CreateClient(gptConfig);

            var convoId = conversationId;
            var response =  chatGptClient.Ask(prompt, convoId).Result;
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(response);
        }
        [Command("DLM")]
        public async Task DLMCommand(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await ctx.Message.DeleteAsync();
            Task<IReadOnlyList<DiscordMessage>> LastMessage = ctx.Channel.GetMessagesBeforeAsync(ctx.Message.Id, 1);
            await LastMessage.Result.First().DeleteAsync();
        }
    
    }
}
