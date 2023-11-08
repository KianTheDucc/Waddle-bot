using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using Discord;

namespace Waddle_bot
{
    public class Quotes : BaseCommandModule
    {

        [Command("quote")]
        public async Task AddQuote(CommandContext ctx, DiscordMember member, [RemainingText] string quote)
        {

            List<Quote> quotes = ReadJson();


            Quote quoteth = new Quote()
            {
                FunnyMessage = quote,
                GuildId = ctx.Guild.Id,
                UserId = member.Id,
                Username = member.Username
            };

            WriteJson(quoteth);


            await ctx.RespondAsync($"Quote Added for {member.Mention}!");


        }
        [Command("randoquote")]
        public async Task GetRandomQuote(CommandContext ctx, DiscordMember member)
        {
            if (member != null)
            {
                string json = File.ReadAllText(@"C:\Users\kiant\source\repos\Waddle bot\Waddle bot\Quotes.json");
                List<Quote> quotes = JsonConvert.DeserializeObject<List<Quote>>(json);
                List<Quote> memberQuotes = quotes.Where(x => x.UserId == member.Id && x.GuildId == ctx.Guild.Id).ToList();

                if (memberQuotes.Count > 0)
                {
                    Random rnd = new Random();
                    Quote selectedQuote = memberQuotes[rnd.Next(memberQuotes.Count - 1)];
                    await ctx.RespondAsync($"{member.Mention}: {selectedQuote.FunnyMessage}");
                }
                else
                {
                    await ctx.RespondAsync($"{member.Mention} has no quotes in this server!");
                }
            }
            else
            {
                await ctx.RespondAsync($"{ctx.Message.Author.Mention} you have not mentioned a member to quote!");
            }
            
        }

        [Command("quotes")]
        public async Task GetQuoteList(CommandContext ctx, DiscordMember member)
        {
            string json = File.ReadAllText(@"C:\Users\kiant\source\repos\Waddle bot\Waddle bot\Quotes.json");
            List<Quote> quotes = JsonConvert.DeserializeObject<List<Quote>>(json);
            List<Quote> memberQuotes = quotes.Where(x => x.UserId == member.Id && x.GuildId == ctx.Guild.Id).ToList();

            if (memberQuotes.Count > 0)
            {
                string selectedQuote = "";
                for (int i = 0; i < memberQuotes.Count; i++)
                {
                    selectedQuote += memberQuotes[i].FunnyMessage;
                    selectedQuote += "\n";
                }
                await ctx.RespondAsync($"{member.Mention} Quotes: {selectedQuote}");
            }
            else
            {
                await ctx.RespondAsync($"{member.Mention} has no quotes in this server!");
            }
        }


        public List<Quote> ReadJson()
        {
            try
            {
                string json = File.ReadAllText(@"C:\Users\kiant\source\repos\Waddle bot\Waddle bot\Quotes.json");
                if (json == "")
                {
                    return new List<Quote>();
                }
                return JsonConvert.DeserializeObject<List<Quote>>(json);

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public async void WriteJson(Quote quote)
        {
            List<Quote> list = ReadJson();
            list.Add(quote);
            File.WriteAllText(@"C:\Users\kiant\source\repos\Waddle bot\Waddle bot\Quotes.json", JsonConvert.SerializeObject(list));

            
        }

    }
}
