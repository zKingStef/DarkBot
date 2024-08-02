using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkBot.src.CommandHandler
{
    internal class Misc_Handler
    {
        public static string GetLocalTime(string timeZoneId)
        {
            try
            {
                // Zeitzone abrufen
                var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                var localTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);

                return localTime.ToString("HH:mm:ss");
            }
            catch (TimeZoneNotFoundException)
            {
                return "Zeitzone nicht gefunden.";
            }
            catch (InvalidTimeZoneException)
            {
                return "Ungültige Zeitzone.";
            }
        }
    }
}
