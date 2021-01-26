using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace tg_animeBot.Bot.Utils
{
    class mainFuncs
    {
        public async static void start(Message mess)
        {
            ReplyKeyboardMarkup rk = new ReplyKeyboardMarkup(new KeyboardButton[][] { new KeyboardButton[] {new KeyboardButton("Anime"), new KeyboardButton("Yuri"), new KeyboardButton("Ecchi")},
                        new KeyboardButton[]{ new KeyboardButton("Yuri"), new KeyboardButton("Hentai"), new KeyboardButton("Wallpaper")}});
            string text = "Бот, написанный на BooruSharp, для работы с booru-сервисами!";
            await BotInstance.bot.SendTextMessageAsync(mess.Chat.Id, text, replyMarkup: rk);
        }
    }
}
