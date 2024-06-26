using DarkBot.src.CommandHandler;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus;
using DSharpPlus.Interactivity;
using Microsoft.VisualBasic;

namespace DarkBot.src.Common
{
    public class Modals
    {
        public static async Task HandleModal(DiscordClient client, ModalSubmitEventArgs e)
        {
            if (e.Interaction.Type == InteractionType.ModalSubmit
             && e.Interaction.Data.CustomId == "modalTest")
            {
                
            }


        }
    }
}
