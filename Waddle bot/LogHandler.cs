using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waddle_bot
{
    public class LogHandler
    {
        public static async Task MessageCreatedHandler(DiscordClient s, MessageCreateEventArgs e)
        {


            if (e.Author.Id == 839677289427107840)
            {

                //await s.SendMessageAsync(e.Channel, "I love youu");
            }
        }
        public static async Task MessageUpdatedHandler(DiscordClient s, MessageUpdateEventArgs e)
        {
            DiscordEmbedBuilder builder = new DiscordEmbedBuilder();
            builder.Color = new DiscordColor(169, 216, 255);
            builder.Title = $"Message Edited in {e.Channel.Mention}";
            builder.Url = e.Message.JumpLink.ToString();
            builder.AddField("Before", e.MessageBefore.Content);
            builder.AddField("After", e.Message.Content);
            builder.Author = new DiscordEmbedBuilder.EmbedAuthor();
            builder.Author.IconUrl = e.Message.Author.AvatarUrl;
            builder.Author.Name = $"{e.Author.Username}#{e.Author.Discriminator}";
            builder.Author.Url = e.Message.Author.AvatarUrl;
            builder.Footer = new DiscordEmbedBuilder.EmbedFooter();
            builder.Footer.IconUrl = e.Message.Author.AvatarUrl;
            builder.Footer.Text = $"User ID: {e.Author.Id} || {DateTime.Now}";
            if (e.Guild.GetChannel(914026745668206592) != null)
            {
                await s.SendMessageAsync(e.Guild.GetChannel(914026745668206592), "", builder.Build());
            }
        }
        public static async Task MessageDeletedHandler(DiscordClient s, MessageDeleteEventArgs e)
        {
            DiscordEmbedBuilder builder = new DiscordEmbedBuilder();
            builder.Color = new DiscordColor(169, 216, 255);
            builder.Title = $"Message Deleted in {e.Channel.Mention}";
            builder.AddField("Deleted Message:", e.Message.Content);
            builder.Author = new DiscordEmbedBuilder.EmbedAuthor();
            builder.Author.IconUrl = e.Message.Author.AvatarUrl;
            builder.Author.Name = $"{e.Message.Author}#{e.Message.Author.Discriminator}";
            builder.Author.Url = e.Message.Author.AvatarUrl;
            builder.Footer = new DiscordEmbedBuilder.EmbedFooter();
            builder.Footer.IconUrl = e.Message.Author.AvatarUrl;
            builder.Footer.Text = $"User ID: {e.Message.Author.Id}";
            if (e.Guild.GetChannel(914026745668206592) != null)
            {
                await s.SendMessageAsync(e.Guild.GetChannel(914026745668206592), "", builder.Build());
            }

        }
        public static async Task ChannelDeletedHandler(DiscordClient s, ChannelDeleteEventArgs e)
        {
            DiscordEmbedBuilder builder = new DiscordEmbedBuilder();
            builder.Color = new DiscordColor(169, 216, 255);
            builder.Title = $"Channel deleted: {e.Channel.Name}";
            builder.Description = "**Channel**";
            builder.AddField("Name:", e.Channel.Name);
            builder.AddField("ID:", $"{e.Channel.Id}");
            builder.Footer = new DiscordEmbedBuilder.EmbedFooter();
            builder.Footer.Text = $"User ID: {DateTime.Now}";
            if (e.Guild.GetChannel(914026745668206592) != null)
            {
                await s.SendMessageAsync(e.Guild.GetChannel(914026745668206592), "", builder.Build());
            }
        }
        public static async Task ChannelCreatedHandler(DiscordClient s, ChannelDeleteEventArgs e)
        {
            DiscordEmbedBuilder builder = new DiscordEmbedBuilder();
            builder.Color = new DiscordColor(169, 216, 255);
            builder.Title = $"Channel created: {e.Channel.Name}";
            builder.Description = "**Channel**";
            builder.AddField("Name:", e.Channel.Name);
            builder.AddField("ID:", $"{e.Channel.Id}");
            builder.AddField("Mention", e.Channel.Mention);
            builder.Footer = new DiscordEmbedBuilder.EmbedFooter();
            builder.Footer.Text = $"User ID: {DateTime.Now}";
            if (e.Guild.GetChannel(914026745668206592) != null)
            {
                await s.SendMessageAsync(e.Guild.GetChannel(914026745668206592), "", builder.Build());
            }
        }
        public static async Task MemberJoinedHandler(DiscordClient s, GuildMemberAddEventArgs e)
        {
            if (e.Guild.Id == 1093989070436311185)
            {
                DiscordRole memberrole = e.Guild.GetRole(1093990495828594798);
                await e.Member.GrantRoleAsync(memberrole);
                await s.SendMessageAsync(e.Guild.GetChannel(1094000459632627762), $"Welcome to the cloudosphere {e.Member.Mention}!");
            }
            if (e.Guild.Id == 914017763939483708)
            {
                DiscordEmbedBuilder builder = new DiscordEmbedBuilder();
                builder.Color = new DiscordColor(255, 217, 1);
                builder.Title = $"Welcome {e.Member.DisplayName}#{e.Member.Discriminator}";
                builder.Description= $"**Welcome <@{e.Member.Id}>! We’re glad to have you. Please visit our info channels so you can be verified. Enjoy your stay!**\n You are our {e.Guild.MemberCount}th member!";
                //builder.Description = $"**Welcome {e.Member.Mention}! We’re glad to have you. Please visit our info channels so you can be verified. Enjoy your stay!**";
                //builder.Description = $"You are our {e.Guild.MemberCount}th member!";
                await s.SendMessageAsync(e.Guild.GetChannel(914019467493769277), "", builder.Build());
                DiscordRole member = e.Guild.GetRole(967958063845892166);
                DiscordRole demo = e.Guild.GetRole(1041237152907931688);
                DiscordRole commu = e.Guild.GetRole(1041237309426769920);
                await e.Member.GrantRoleAsync(demo);
                await e.Member.GrantRoleAsync(member);
                await e.Member.GrantRoleAsync(commu);
            }
        }

    }
}
