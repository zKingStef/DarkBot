using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext.Attributes;
using Newtonsoft.Json;
using DarkBot.src.Common;
using DarkBot.src.CommandHandler;

namespace DarkBot.src.SlashCommands
{
    public class Misc_SL : ApplicationCommandModule
    {
        [SlashCommand("ping", "Check Response Time of the Bot")]
        public async Task PingCommand(InteractionContext ctx)
        {
            var ping = ctx.Client.Ping;
            await ctx.CreateResponseAsync($"Pong! Response Time is {ping} ms.");
        }

        [SlashCommand("avatar", "Show User Avatar")]
        public static async Task Avatar(InteractionContext ctx,
                                [Option("User", "Choose any User to get their Avatar")] DiscordUser? user = null)
        {
            var targetUser = user ?? ctx.User;
        
            var avatarUrl = targetUser.AvatarUrl;
        
            var embed = new DiscordEmbedBuilder
            {
                Title = $"{targetUser.Username}'s Avatar",
                ImageUrl = avatarUrl,
                Color = DiscordColor.HotPink,
                Description = ctx.User.AvatarUrl,
            };
        
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().AddEmbed(embed.Build()));
        }

        [SlashCommand("server", "Show Server Informationss")]
        public async Task ServerEmbed(InteractionContext ctx)
        {
            string serverDescription = $"**Servername:** {ctx.Guild.Name}\n" +
                                        $"**Server ID:** {ctx.Guild.Id}\n" +
                                        $"**Creation Date:** {ctx.Guild.CreationTimestamp:dd/M/yyyy}\n" +
                                        $"**Owner:** {ctx.Guild.Owner.Mention}\n\n" +
                                        $"**Users:** {ctx.Guild.MemberCount}\n" +
                                        $"**Channels:** {ctx.Guild.Channels.Count}\n" +
                                        $"**Roles:** {ctx.Guild.Roles.Count}\n" +
                                        $"**Emojis:** {ctx.Guild.Emojis.Count}";

            var serverInformation = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Gold,
                Title = "Server Informationen",
                Description = serverDescription
            };

            var response = new DiscordInteractionResponseBuilder().AddEmbed(serverInformation.WithImageUrl(ctx.Guild.IconUrl));
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, response);
        }

        [SlashCommand("time", "Show Timezones")]
        public async Task Time(InteractionContext ctx)
        {
            // Uhrzeit für verschiedene Städte abrufen
            var frankfurtTime = Misc_Handler.GetLocalTime("Europe/Berlin");
            var tokyoTime = Misc_Handler.GetLocalTime("Asia/Tokyo");
            var aucklandTime = Misc_Handler.GetLocalTime("Pacific/Auckland");
            var sydneyTime = Misc_Handler.GetLocalTime("Australia/Sydney");
            var taipeiTime = Misc_Handler.GetLocalTime("Asia/Taipei");
            var hoChiMinhTime = Misc_Handler.GetLocalTime("Asia/Ho_Chi_Minh");
            var dhakaTime = Misc_Handler.GetLocalTime("Asia/Dhaka");
            var maleTime = Misc_Handler.GetLocalTime("Indian/Maldives");
            var dubaiTime = Misc_Handler.GetLocalTime("Asia/Dubai");
            var zaragozaTime = Misc_Handler.GetLocalTime("Europe/Madrid");
            var reykjavikTime = Misc_Handler.GetLocalTime("Atlantic/Reykjavik");
            var saoPauloTime = Misc_Handler.GetLocalTime("America/Sao_Paulo");
            var newYorkTime = Misc_Handler.GetLocalTime("America/New_York");

            // Nachricht erstellen
            var response = Misc_Handler.GetClockMessage(
                frankfurtTime,
                tokyoTime,
                aucklandTime,
                sydneyTime,
                taipeiTime,
                hoChiMinhTime,
                dhakaTime,
                maleTime,
                dubaiTime,
                zaragozaTime,
                reykjavikTime,
                saoPauloTime,
                newYorkTime
            );

            // Antworte mit einer Initialnachricht
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
                .WithContent(response)
            );

            // Warte kurz, bevor die erste Followup-Nachricht gesendet wird
            await Task.Delay(2000);

            // Nachricht alle 60 Sekunden aktualisieren
            while (true)
            {
                // Aktualisierte Zeiten abrufen
                frankfurtTime = Misc_Handler.GetLocalTime("Europe/Berlin");
                tokyoTime = Misc_Handler.GetLocalTime("Asia/Tokyo");
                aucklandTime = Misc_Handler.GetLocalTime("Pacific/Auckland");
                sydneyTime = Misc_Handler.GetLocalTime("Australia/Sydney");
                taipeiTime = Misc_Handler.GetLocalTime("Asia/Taipei");
                hoChiMinhTime = Misc_Handler.GetLocalTime("Asia/Ho_Chi_Minh");
                dhakaTime = Misc_Handler.GetLocalTime("Asia/Dhaka");
                maleTime = Misc_Handler.GetLocalTime("Indian/Maldives");
                dubaiTime = Misc_Handler.GetLocalTime("Asia/Dubai");
                zaragozaTime = Misc_Handler.GetLocalTime("Europe/Madrid");
                reykjavikTime = Misc_Handler.GetLocalTime("Atlantic/Reykjavik");
                saoPauloTime = Misc_Handler.GetLocalTime("America/Sao_Paulo");
                newYorkTime = Misc_Handler.GetLocalTime("America/New_York");

                // Aktualisierte Nachricht erstellen
                response = Misc_Handler.GetClockMessage(
                    frankfurtTime,
                    tokyoTime,
                    aucklandTime,
                    sydneyTime,
                    taipeiTime,
                    hoChiMinhTime,
                    dhakaTime,
                    maleTime,
                    dubaiTime,
                    zaragozaTime,
                    reykjavikTime,
                    saoPauloTime,
                    newYorkTime
                );

                // Sende eine Followup-Nachricht mit der aktualisierten Uhrzeit
                await ctx.FollowUpAsync(new DiscordFollowupMessageBuilder()
                    .WithContent(response)
                );

                // 60 Sekunden warten
                await Task.Delay(TimeSpan.FromSeconds(60));
            }
        }
    }
}
