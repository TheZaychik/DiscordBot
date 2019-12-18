using System;
using System.Timers;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace DiscordBotProj
{
    public class Program
    {
        // Create a mutex for a single instance.
        private static System.Threading.Mutex INSTANCE_MUTEX = new System.Threading.Mutex(true, "WhalesFargo_DiscordBot");
        private static DiscordBot BOT = new DiscordBot();
//        public static UI.Window UI = new UI.Window(BOT);
        private static string m_Token = "token";
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();
        public async Task MainAsync()
        {
            Console.WriteLine("Вставьте токен вашего бота:");
           // m_Token = Console.ReadLine();
            BOT.SetBotToken(m_Token);
            await BOT.RunAsync();
            await Task.Delay(-1);

        }
        // Connect to the bot, or cancel before the connection happens.
        public static void Run() => System.Threading.Tasks.Task.Run(() => BOT.RunAsync());
        public static void Cancel() => System.Threading.Tasks.Task.Run(() => BOT.CancelAsync());
        public static void Stop() => System.Threading.Tasks.Task.Run(() => BOT.StopAsync());
    }
}