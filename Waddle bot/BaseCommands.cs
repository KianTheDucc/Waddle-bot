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
        public async Task ChatGPTCommand(CommandContext ctx, [RemainingText] string prompt)
        {
            await ctx.RespondAsync("No.");
            //await ctx.RespondAsync("Waiting for GPT Response...");

            //ChatGptClientConfig gptConfig = new ChatGptClientConfig
            //{
            //    SessionToken = Resource1.SessionToken, 
            //    AccountType = ChatGPT.Net.Enums.AccountType.Free
            //};
            //ChatGpt chat = new ChatGpt();
            //await chat.WaitForReady();
            //var chatGptClient = await chat.CreateClient(gptConfig);

            //var response =  chatGptClient.Ask(prompt).Result;
            //await ctx.TriggerTypingAsync();
            //await ctx.RespondAsync(response);
        }
        [Command("DLM")]
        public async Task DLMCommand(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await ctx.Message.DeleteAsync();
            Task<IReadOnlyList<DiscordMessage>> LastMessage = ctx.Channel.GetMessagesBeforeAsync(ctx.Message.Id, 1);
            await LastMessage.Result.First().DeleteAsync();
        }
        [Command("bambambam")]
        public async Task DuckSongCommand(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync("A duck walked up to a lemonade stand\r\nAnd he said to the man runnin' the stand\r\n\"Hey! [(bam bam bam)] Got any grapes?\"\r\nThe man said: \"No, we just sell lemonade\r\nBut it's cold, and it's fresh, and it's all home-made!\r\nCan I get you a glass?\"\r\nThe duck said, \"I'll pass.\"\r\nThen he waddled away - waddle waddle");
        }
        [Command("cheeseballs")]
        public async Task CheeseballsCommand(CommandContext ctx)
        {
            await ctx.RespondAsync("https://tenor.com/view/alvin-and-the-chipmunks-theodore-we-can-play-monopoly-monopoly-board-games-gif-21853083");
        }
        [Command("CheeseBallDoggo")]
        [Description("CHEEEEEEEZBALLLLSSSSSSS")]
        [Aliases("CBD")]
        public async Task CheeseBallDoggoCommand(CommandContext ctx)
        {
            await ctx.RespondAsync("https://media.discordapp.net/attachments/1164001227042992191/1169430673157783593/IMG_0885.gif?ex=6555602f&is=6542eb2f&hm=a3c7a6c566becd7eabe2ca467dcb2d0f18a2f076f1b51072dea50f7aa3742cd4&=");
        }
        [Command("LosDrogas")]
        [Description("DRUUUUUGS")]
        [Aliases("drugs", "Heroin")]
        public async Task DrugsCommand(CommandContext ctx)
        {
            await ctx.RespondAsync("https://media.discordapp.net/attachments/1164001227042992191/1169433741920321618/IMG_0886.gif?ex=6555630b&is=6542ee0b&hm=23861b760cf11dc378f450778a5c082f749a23bbe63f4f7ea9f2434bcc2ac178&=");
        }
        [Command("florenwins")]
        [Description("Floren moment")]
        public async Task getRealCommand(CommandContext ctx)
        {
            await ctx.RespondAsync("https://tenor.com/view/beat-saber-get-real-gaming-funny-beating-sabers-gif-6919461099124524561");
        }
        [Command("stella")]
        [Description("Stella when minors")]
        public async Task StellaCommand(CommandContext ctx)
        {
            await ctx.RespondAsync("https://media.discordapp.net/attachments/949085464978145283/1105147550429872179/s.gif");
        }
    }
}
