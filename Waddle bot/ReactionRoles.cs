using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;

namespace Waddle_bot
{
    public class ReactionRoles : BaseCommandModule
    {
        [Command("CreateReactionRole")]
        public async Task CreateReactionRoleAsync(CommandContext ctx, string emoji,[RemainingText] string RoleID )
        {
            DiscordRole role;
            try
            {
                await ctx.Channel.SendMessageAsync("Working1");
                ulong roleID = Convert.ToUInt64(RoleID);
                role = ctx.Guild.GetRole(roleID);
                await ctx.Channel.SendMessageAsync("Working2");
            }
            catch (Exception ex)
            {
                await ctx.Channel.SendMessageAsync("Working3");
                await ctx.Channel.SendMessageAsync(ex.ToString());
                await ctx.Channel.SendMessageAsync("Working4");
            }
            await ctx.Channel.SendMessageAsync("Working5");
            try
            {
                await ctx.Channel.SendMessageAsync("Working6");
                DiscordMessage message = ctx.Channel.GetMessagesBeforeAsync(ctx.Message.Id, 1).Result[0];
                ulong someemoji = Convert.ToUInt64(emoji);
                DiscordEmoji roleEmoji = ctx.Guild.GetEmojiAsync(someemoji).Result;
                await message.CreateReactionAsync(roleEmoji);
                await ctx.Channel.SendMessageAsync("Working7");
            }
            catch(Exception ex)
            {
                await ctx.Channel.SendMessageAsync(ex.ToString());
            }
            
            
            
            

        }


    }
}
