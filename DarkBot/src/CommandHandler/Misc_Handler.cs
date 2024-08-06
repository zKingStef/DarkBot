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

        public static string GetClockMessage(
                    string kiribatiTime,
                    string aucklandTime,
                    string sydneyTime,
                    string tokyoTime,
                    string seoulTime,
                    string taipeiTime,
                    string hoChiMinhTime,
                    string dhakaTime,
                    string maleTime,
                    string dubaiTime,
                    string larissaTime,
                    string zaragozaTime,
                    string santaCruzTime,
                    string frankfurtTime,
                    string reykjavikTime,
                    string saoPauloTime,
                    string newYorkTime,
                    string sanFranciscoTime,
                    string bangkokTime,
                    string londonTime
)
        {
            return $"**World Timer:**\n" +
                   $"🇰🇮 Kiribati: {kiribatiTime}\n" +
                   $"🇳🇿 Neuseeland (Auckland): {aucklandTime}\n" +
                   $"🇦🇺 Australien (Sydney): {sydneyTime}\n" +
                   $"🇯🇵 Japan (Tokio): {tokyoTime}\n" +
                   $"🇰🇷 Südkorea (Seoul): {seoulTime}\n" +
                   $"🇹🇼 Taiwan (Taipei): {taipeiTime}\n" +
                   $"🇻🇳 Vietnam (Ho Chi Minh): {hoChiMinhTime}\n" +
                   $"🇹🇭 Thailand (Bangkok): {bangkokTime}\n" +
                   $"🇧🇩 Bangladesch (Dhaka): {dhakaTime}\n" +
                   $"🇲🇻 Malediven (Male): {maleTime}\n" +
                   $"🇦🇪 Vereinigte Arabische Emirate (Dubai): {dubaiTime}\n" +
                   $"🇬🇷 Griechenland (Larissa): {larissaTime}\n" +
                   $"🇪🇸 Spanien (Zaragoza): {zaragozaTime}\n" +
                   $"🇩🇪 Deutschland (Frankfurt): {frankfurtTime}\n" +
                   $"🇬🇧 Großbritannien (London): {londonTime}\n" +
                   $"🇪🇸 Spanien (Santa Cruz): {santaCruzTime}\n" +
                   $"🇮🇸 Island (Reykjavik): {reykjavikTime}\n" +
                   $"🇧🇷 Brasilien (São Paulo): {saoPauloTime}\n" +
                   $"🇺🇸 USA (New York): {newYorkTime}\n" +
                   $"🇺🇸 USA (San Francisco): {sanFranciscoTime}";
        }
    }
}
