using Discord.WebSocket;
using Discord;
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
            if (e.Message.Content.Contains("crazy") && !e.Author.IsBot && e.Author.Id == 918154206362353684 
                || e.Message.Content.Contains("crazy") && e.Author.Id == 938834731867443241 
                || e.Message.Content.Contains("crazy") && e.Author.Id == 295110922890903566 || e.Message.Content.Contains("crazy") && e.Author.Id == 402133515375869953)
            {
                await s.SendMessageAsync(e.Channel, "Crazy?");
                await Task.Delay(500);
                await s.SendMessageAsync(e.Channel, "I was crazy once");
                await Task.Delay(500);
                await s.SendMessageAsync(e.Channel, "They locked me in a room");
                await Task.Delay(500);
                await s.SendMessageAsync(e.Channel, "A rubber room");
                await Task.Delay(500);
                await s.SendMessageAsync(e.Channel, "A rubber room with rats.");
                await Task.Delay(500);
                await s.SendMessageAsync(e.Channel, "And the rats made me crazy.");
            }
            if (e.Message.Content.Contains("Bimbo") && e.Author.Id == 938834731867443241 
                || e.Message.Content.Contains("bimbo") && e.Author.Id == 938834731867443241)
            {
                await s.SendMessageAsync(e.Channel, "I wanna be a bimbo doll,");
                await Task.Delay(500);
                await s.SendMessageAsync(e.Channel, "My boobs are huge but I am small.");
                await Task.Delay(500);
                await s.SendMessageAsync(e.Channel, "B.I.M.B.O!! I just wanna be a stupid hoe!!");
            }
            if (e.Message.Content.Contains("hell") && e.Message.Content.Contains("yeah") && !e.Author.IsBot|| e.Message.Content.Contains("Hell") && e.Message.Content.Contains("Yeah") && !e.Author.IsBot)
            {
                await s.SendMessageAsync(e.Channel, "<:HellYeah:1006502295132966932>");
            }
            if (e.Message.Content.Contains("youre"))
            {
                await s.SendMessageAsync(e.Channel, "https://images-ext-1.discordapp.net/external/eW1eC9kdQ16634LlLhjLPGgR6gA6j7yqGkXSWg42cMo/https/media.tenor.com/g4ROd47vVEkAAAPo/yroue.mp4");
            }

            //if (e.Author.Id == 918154206362353684)
            //{

                //    await s.SendMessageAsync(e.Channel, "get rizzed");
                //}
                //if (e.Author.Id == 842041129993895988)
                //{

                //    await Task.Delay(3000);
                //    await s.SendMessageAsync(e.Channel, "Blake loves BBC");
                //}
                //if (e.Author.Id == 194914472937127936)
                //{
                //    await s.SendMessageAsync(e.Channel, "Perish.");
                //}
                //if (e.Author.Id == 800364278439346226)
                //{
                //    await s.SendMessageAsync(e.Channel, "You can't escape");
                //}
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
        public static async Task MessageReactionAdded(DiscordClient s, MessageReactionAddEventArgs e)
        {
            if (e.Message.Id != 1168372495036985434) return;
            if (e.Emoji.Name != ":wave_animated:") return;
            var role = e.Guild.GetRole(1094372526030864426);
            var userMember = e.Guild.GetMemberAsync(e.User.Id).Result;
            await userMember.GrantRoleAsync(role);
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
