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
using Microsoft.Win32.SafeHandles;

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
                    var kiribatiTime = Misc_Handler.GetLocalTime("Pacific/Kiritimati");
                    var aucklandTime = Misc_Handler.GetLocalTime("Pacific/Auckland");
                    var sydneyTime = Misc_Handler.GetLocalTime("Australia/Sydney");
                    var tokyoTime = Misc_Handler.GetLocalTime("Asia/Tokyo");
                    var seoulTime = Misc_Handler.GetLocalTime("Asia/Seoul");
                    var taipeiTime = Misc_Handler.GetLocalTime("Asia/Taipei");
                    var hoChiMinhTime = Misc_Handler.GetLocalTime("Asia/Ho_Chi_Minh");
                    var dhakaTime = Misc_Handler.GetLocalTime("Asia/Dhaka");
                    var maleTime = Misc_Handler.GetLocalTime("Indian/Maldives");
                    var dubaiTime = Misc_Handler.GetLocalTime("Asia/Dubai");
                    var larissaTime = Misc_Handler.GetLocalTime("Europe/Athens");
                    var zaragozaTime = Misc_Handler.GetLocalTime("Europe/Madrid");
                    var santaCruzTime = Misc_Handler.GetLocalTime("Atlantic/Canary");
                    var frankfurtTime = Misc_Handler.GetLocalTime("Europe/Berlin");
                    var reykjavikTime = Misc_Handler.GetLocalTime("Atlantic/Reykjavik");
                    var saoPauloTime = Misc_Handler.GetLocalTime("America/Sao_Paulo");
                    var newYorkTime = Misc_Handler.GetLocalTime("America/New_York");
                    var sanFranciscoTime = Misc_Handler.GetLocalTime("America/Los_Angeles");
                    var bangkokTime = Misc_Handler.GetLocalTime("Asia/Bangkok");
                    var londonTime = Misc_Handler.GetLocalTime("Europe/London");

                    // Nachricht erstellen
                    var response = Misc_Handler.GetClockMessage(
                        kiribatiTime,
                        aucklandTime,
                        sydneyTime,
                        tokyoTime,
                        seoulTime,
                        taipeiTime,
                        hoChiMinhTime,
                        dhakaTime,
                        maleTime,
                        dubaiTime,
                        larissaTime,
                        zaragozaTime,
                        santaCruzTime,
                        frankfurtTime,
                        reykjavikTime,
                        saoPauloTime,
                        newYorkTime,
                        sanFranciscoTime,
                        bangkokTime,
                        londonTime
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