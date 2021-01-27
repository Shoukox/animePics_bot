using System;
using tg_animeBot.Bot;

namespace tg_animeBot
{
    class main
    {
        static void Main(string[] args)
        {
            string token = "1328219094:AAFjFsz80--0N_hT1K1-FRXVpkQvyQdGAWA";
            while (true)
            {
                BotInstance bot = new BotInstance(token);
                Console.ReadLine();
            }
        }
    }
}
