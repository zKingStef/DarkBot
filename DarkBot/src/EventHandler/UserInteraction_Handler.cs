using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkBot.src.CommandHandler;
using DSharpPlus.Interactivity.Extensions;
using Microsoft.Extensions.Options;
using System.ComponentModel.Design;
using DarkBot.src.Common;
using System.Reflection;

namespace DarkBot.src.Handler
{
    public static class UserInteraction_Handler
    {
        public static async Task HandleInteraction(DiscordClient client, ComponentInteractionCreateEventArgs e)
        {
            var selectedOption = e.Interaction.Data.Values.FirstOrDefault();

            switch (selectedOption)
            {
                case "test":
                    break;

                default:
                    break;
            }

            switch (e.Interaction.Data.CustomId)
            {
                case "Button_UpdateTime":
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

                    var updateButton = new DiscordButtonComponent(ButtonStyle.Secondary, "Button_UpdateTime", "🕐 Update Time");

                    // Antworte mit einer Initialnachricht
                    await e.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder()
                        .WithContent(response)
                        .AddComponents(updateButton));

                    break;

                default:
                    Console.WriteLine(e.Message);
                    break;
            }
        }
    }
}