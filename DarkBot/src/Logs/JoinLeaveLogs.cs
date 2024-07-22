using DarkBot.src.Common;
using DSharpPlus;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkBot.src.Logs
{
    public class JoinLeaveLogs
    {
        public static async Task UserJoin(DiscordClient sender, DSharpPlus.EventArgs.GuildMemberAddEventArgs e)
        {

            //if (!e.Member.IsBot)
            //{
            //    var role = e.Guild.GetRole(1222923387937226875);
            //
            //    if (role != null)
            //    {
            //        await e.Member.GrantRoleAsync(role);
            //    }
            //}
            var welcomeChannel = e.Guild.GetChannel(978350400216399932);

            var welcomeEmbed = new DiscordEmbedBuilder()
            {
                Color = DiscordColor.Magenta,
                Title = $"User joined!",
                Description = $"{e.Member.Nickname} - {e.Member.Mention} joined the Discord",
                Timestamp = DateTimeOffset.Now,
                Footer = new DiscordEmbedBuilder.EmbedFooter
                {
                    Text = e.Guild.Name
                },
                Author = new DiscordEmbedBuilder.EmbedAuthor
                {
                    IconUrl = e.Member.AvatarUrl,
                    Name = e.Member.Username
                }
            };

            await welcomeChannel.SendMessageAsync(embed: welcomeEmbed);
        }

        public static async Task UserLeave(DiscordClient sender, DSharpPlus.EventArgs.GuildMemberRemoveEventArgs e)
        {
            var logChannel = e.Guild.GetChannel(978350423482191924);

            var welcomeEmbed = new DiscordEmbedBuilder()
            {
                Color = DiscordColor.Magenta,
                Title = $"User left!",
                Description = $"{e.Member.Nickname} - {e.Member.Mention} left the Discord!",
                Timestamp = DateTimeOffset.Now,
                Footer = new DiscordEmbedBuilder.EmbedFooter
                {
                    Text = e.Guild.Name
                },
                Author = new DiscordEmbedBuilder.EmbedAuthor
                {
                    IconUrl = e.Member.AvatarUrl,
                    Name = e.Member.Username
                }
            };

            await logChannel.SendMessageAsync(embed: welcomeEmbed);
        }
    }
}
