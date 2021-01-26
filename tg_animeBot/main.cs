using System;
using tg_animeBot.Bot;

namespace tg_animeBot
{
    class main
    {
        static void Main(string[] args)
        {
            string token = "YOUR_TOKEN";
            while (true)
            {
                BotInstance bot = new BotInstance(token);
                Console.ReadLine();
            }
        }
    }
}
