using ChatGPT;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Emzi0767.Utilities;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;
using Waddle_bot;
using DSharpPlus.VoiceNext;
using Lavalink4NET.Player;
using Discord.Interactions;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using System.Runtime.ExceptionServices;
using ChatGPT.Net.DTO;
using ChatGPT.Net;
using DSharpPlus.Lavalink;
using System.Net;
using DSharpPlus.Net;
using Lavalink4NET.DSharpPlus;
using Lavalink4NET.Tracking;
using Lavalink4NET;
using System.Numerics;
using Microsoft.Extensions.DependencyInjection;

public class Bot
{
    static void Main() => new Program().MainAsync().GetAwaiter().GetResult();
}

public class Program
{
    public static DiscordClient discord { get; private set; }
    public async Task MainAsync()
    {
        discord = new DiscordClient(new DiscordConfiguration()
        {
            Token = Resource1.Token2,
            TokenType = TokenType.Bot,
            Intents =
            DiscordIntents.AllUnprivileged
            | DiscordIntents.MessageContents
            | DiscordIntents.GuildMessages
            | DiscordIntents.GuildMembers,
            MinimumLogLevel = LogLevel.Debug
        });

    var discordWrapper = new DiscordClientWrapper(new DiscordClient(new DiscordConfiguration()
    {
        Token = Resource1.Token,
        TokenType = TokenType.Bot,
        Intents =
        DiscordIntents.AllUnprivileged
        | DiscordIntents.MessageContents
        | DiscordIntents.GuildMessages
        | DiscordIntents.GuildMembers,
        MinimumLogLevel = LogLevel.Debug
    }));
    discord.UseVoiceNext();

        var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
        {
            StringPrefixes = new[] { "-" }

        });


    var endpoint = new ConnectionEndpoint
    {
        Hostname = "127.0.0.1", // From your server configuration.
        Port = 4393 // From your server configuration
    };

    var lavalinkConfig = new LavalinkConfiguration
    {
        Password = "youshallnotpass", // From your server configuration.
        RestEndpoint = endpoint,
        SocketEndpoint = endpoint
    };

    var interactivity = discord.UseInteractivity(new InteractivityConfiguration
    {
        PollBehaviour = DSharpPlus.Interactivity.Enums.PollBehaviour.DeleteEmojis
    });
    discord.MessageCreated += LogHandler.MessageCreatedHandler;

        discord.MessageUpdated += LogHandler.MessageUpdatedHandler;

        discord.MessageDeleted += LogHandler.MessageDeletedHandler;

        discord.MessageReactionAdded += Tickets.MessageReactionAddedHandler;

        discord.ChannelDeleted += LogHandler.ChannelDeletedHandler;

        discord.GuildMemberAdded += LogHandler.MemberJoinedHandler;
        discord.MessageReactionAdded += LogHandler.MessageReactionAdded;

        var lavalink = discord.UseLavalink();

    commands.RegisterCommands<BasedCommands>();

        

        commands.RegisterCommands<VoiceCommands>();

        commands.RegisterCommands<Tickets>();

        commands.RegisterCommands<Quotes>();

        commands.RegisterCommands<ReactionRoles>();

        await discord.ConnectAsync();
    await lavalink.ConnectAsync(lavalinkConfig);
    await Task.Delay(-1);



    }
    
    
    
    

}