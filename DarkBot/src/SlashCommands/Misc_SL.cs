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
            // Uhrzeit für Frankfurt
            var frankfurtTime = Misc_Handler.GetLocalTime("Europe/Berlin");
            // Uhrzeit für Tokio
            var tokyoTime = Misc_Handler.GetLocalTime("Asia/Tokyo");
            // Uhrzeit für Auckland
            var aucklandTime = Misc_Handler.GetLocalTime("Pacific/Auckland");
            // Uhrzeit für Sydney
            var sydneyTime = Misc_Handler.GetLocalTime("Australia/Sydney");
            // Uhrzeit für Taipei
            var taipeiTime = Misc_Handler.GetLocalTime("Asia/Taipei");
            // Uhrzeit für Ho Chi Minh
            var hoChiMinhTime = Misc_Handler.GetLocalTime("Asia/Ho_Chi_Minh");
            // Uhrzeit für Dhaka
            var dhakaTime = Misc_Handler.GetLocalTime("Asia/Dhaka");
            // Uhrzeit für Male
            var maleTime = Misc_Handler.GetLocalTime("Indian/Maldives");
            // Uhrzeit für Dubai
            var dubaiTime = Misc_Handler.GetLocalTime("Asia/Dubai");
            // Uhrzeit für Zaragoza
            var zaragozaTime = Misc_Handler.GetLocalTime("Europe/Madrid");
            // Uhrzeit für Reykjavik
            var reykjavikTime = Misc_Handler.GetLocalTime("Atlantic/Reykjavik");
            // Uhrzeit für São Paulo
            var saoPauloTime = Misc_Handler.GetLocalTime("America/Sao_Paulo");
            // Uhrzeit für New York
            var newYorkTime = Misc_Handler.GetLocalTime("America/New_York");

            // Nachricht erstellen
            var response = $"**Aktuelle Uhrzeit:**\n" +
                           $"🇳🇿 Neuseeland (Auckland): {aucklandTime}\n" +
                           $"🇦🇺 Australien (Sydney): {sydneyTime}\n" +
                           $"🇯🇵 Japan (Tokio): {tokyoTime}\n" +
                           $"🇹🇼 Taiwan (Taipei): {taipeiTime}\n" +
                           $"🇻🇳 Vietnam (Ho Chi Minh): {hoChiMinhTime}\n" +
                           $"🇧🇩 Bangladesch (Dhaka): {dhakaTime}\n" +
                           $"🇲🇻 Malediven (Male): {maleTime}\n" +
                           $"🇦🇪 Vereinigte Arabische Emirate (Dubai): {dubaiTime}\n" +
                           $"🇪🇸 Spanien (Zaragoza): {zaragozaTime}\n" +
                           $"🇩🇪 Deutschland (Frankfurt): {frankfurtTime}\n" +
                           $"🇮🇸 Island (Reykjavik): {reykjavikTime}\n" +
                           $"🇧🇷 Brasilien (São Paulo): {saoPauloTime}\n" +
                           $"🇺🇸 USA (New York): {newYorkTime}";

            await ctx.CreateResponseAsync(response);
        }
    }
}
