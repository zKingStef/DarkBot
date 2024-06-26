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
                // Cases for Ticket Buttons
                case "Button_Test":
                    
                    break;

                default:
                    Console.WriteLine(e.Message);
                    break;
            }
        }
    }
}