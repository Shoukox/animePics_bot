using BooruSharp.Booru;
using System;
using System.Linq;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using tg_animeBot.Bot.Logs;

namespace tg_animeBot.Bot.Utils
{
    class Pictures
    {
        public async static void SendPicture(Message mess, string search)
        {
            try
            {
                string type = mess.Text;

                DanbooruDonmai booru = new DanbooruDonmai();
                BooruSharp.Search.Post.SearchResult result = await booru.GetRandomPostAsync(search);

                InlineKeyboardMarkup ik = null;
                if (BotInstance.admins.Contains(mess.From.Id)) ik = new InlineKeyboardMarkup(new InlineKeyboardButton { Text = "Send to the channel", CallbackData = $"send {type}" });

                await BotInstance.bot.SendPhotoAsync(mess.Chat.Id, new InputOnlineFile(result.FileUrl), $"Want More? Join {BotInstance.channels.First(m=>m[0] == type)[2]}\n\nSource: {result.FileUrl}", replyMarkup: ik);
            }
            catch (Exception e)
            {
                LogsLevels.LogError(e.ToString());
                SendPicture(mess, search);
            }
        }
    }
}
