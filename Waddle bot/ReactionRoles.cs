using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;

namespace Waddle_bot
{
    public class ReactionRoles : BaseCommandModule
    {
        [Command("CreateReactionRole")]
        public async Task CreateReactionRoleAsync(CommandContext ctx, [RemainingText] string RoleID, DiscordEmoji emoji)
        {
            DiscordRole role;
            try
            {
                ulong roleID = Convert.ToUInt64(RoleID);
                role = ctx.Guild.GetRole(roleID);
            }
            catch(Exception ex)
            {
                await ctx.Channel.SendMessageAsync(ex.ToString());
            }
            DiscordMessage message = (DiscordMessage)ctx.Channel.GetMessagesBeforeAsync(ctx.Message.Id, 1).Result;
            await message.CreateReactionAsync(emoji);
            
        }


    }
}
