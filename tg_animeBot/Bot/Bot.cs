using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using tg_animeBot.Bot.Logs;
using tg_animeBot.Bot.Utils;

namespace tg_animeBot.Bot
{
    class BotInstance
    {
        public static TelegramBotClient bot { get; set; }
        public static List<long> admins = new List<long>() { 1022738667 };
        public static List<string[]> channels = new List<string[]>()
        {
            new string[]{"Anime", "-1001394641961", "@shoukko"},    //Пиши здесь id и username каналов, к которым будут отсылаться фотки.
            new string[]{"Ecchi", "-1001394641961", "@shoukko"},
            new string[]{"Neko", "-1001394641961", "@shoukko"},
            new string[]{"Yuri", "-1001394641961", "@shoukko"},
            new string[]{"Hentai", "-1001394641961", "@shoukko"},
            new string[]{"Uncensored", "-1001394641961", "@shoukko"},
            new string[]{"Wallpaper", "-1001394641961", "@shoukko"},
        };
        public static Dictionary<string, string> commands = new Dictionary<string, string>() { { "Anime", "rating:s" }, { "Ecchi", "rating:q" },
                                                            { "Yuri", "yuri" }, { "Hentai","rating:e" }, {"Neko", "cat_ears"}, {"Uncensored", "uncensored"}, { "Wallpaper", "wallpaper"} };

        public BotInstance(string token)
        {
            bot = new TelegramBotClient(token);
            bot.GetUpdatesAsync(-1);
            bot.StartReceiving();
            onEvents();
        }
        public void onEvents()
        {
            bot.OnMessage += (s, e) => onMessage(e.Message);
            bot.OnCallbackQuery += (s, e) => onCallbackQuery(e.CallbackQuery);
        }
        private async void onCallbackQuery(CallbackQuery callback)
        {
            string[] ab = callback.Data.Split(" ");
            if (ab[0] == "send")
            {
                string fileId = callback.Message.Photo[0].FileId;
                string text = callback.Message.Caption;
                await bot.SendPhotoAsync(long.Parse(channels.First(m=>m[0] == ab[1])[1]), new InputOnlineFile(fileId), text);
            }
        }
        private void onMessage(Message mess)
        {
            try
            {
                if (mess != null)
                {
                    char chr = mess.Text[0];
                    string[] ab = mess.Text.Split(" ");
                    LogsLevels.LogMessage(mess.Chat.Title, $"@{mess.From.Username}", mess.Text);
                    if (chr == '/')
                    {
                        if (ab[0] == "/start" || ab[0] == "/help") mainFuncs.start(mess);
                    }
                    else
                    {
                        if (commands.ContainsKey(mess.Text)) Pictures.SendPicture(mess, commands[mess.Text]);
                    }
                }
            }
            catch (Exception e)
            {
                LogsLevels.LogError(e.ToString());
            }

        }
    }
}
