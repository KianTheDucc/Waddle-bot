using Discord.Interactions;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waddle_bot
{
    public class Tickets : BaseCommandModule
    {
        public static async Task MessageReactionAddedHandler(DiscordClient s, MessageReactionAddEventArgs e)
        {
            
            
            if (e.Message.Id == 1088857129693233214)
            {
                DiscordGuild guild = await s.GetGuildAsync(914017763939483708);

                DiscordUser user = await s.GetUserAsync(e.User.Id);

                await e.Message.DeleteReactionAsync(e.Emoji, user);

                DiscordMember member = guild.GetMemberAsync(e.User.Id).Result;

                var lEveryoneRoleOfYourServer = guild.GetRole(914017763939483708);

                var staffrole = guild.GetRole(1041237005507497994);

                var lYourOverWriteBuilderList = new DiscordOverwriteBuilder[] { 
                     new DiscordOverwriteBuilder(lEveryoneRoleOfYourServer)
                        .Deny(Permissions.SendMessages)
                        .Deny(Permissions.AccessChannels),

                     new DiscordOverwriteBuilder(staffrole)
                        .Allow(Permissions.All),

                     new DiscordOverwriteBuilder(member)
                        .Allow(Permissions.AccessChannels)
                        .Allow(Permissions.SendMessages)};



                DiscordChannel channel = guild.CreateChannelCategoryAsync("Ticket", lYourOverWriteBuilderList, 0).Result;

                await guild.CreateChannelAsync($"{e.User.Username} - Ticket", ChannelType.Text, channel, null, null, null, null, null, null, null, 0);
            }
        }
        [Command("closeTicket")]
        [RequireRole("•••Staff•••")]
        public async Task CloseTicketCommand(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync();
            await ctx.Channel.SendMessageAsync("Closing Ticket...");
            DiscordChannel logChannel = ctx.Guild.GetChannel(1088911203100790905);

            IReadOnlyList<DiscordMessage> messages = new List<DiscordMessage>();

            messages = ctx.Channel.GetMessagesAsync().Result;

            for (int i = 0; i < messages.Count; i++)
            {
                await logChannel.SendMessageAsync(messages[i].Author.Mention);
                await logChannel.SendMessageAsync(messages[i].Content);
            }
            
            await ctx.Channel.Parent.DeleteAsync();
            await ctx.Channel.DeleteAsync();

        }
        
    }
}
