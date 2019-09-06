using System;
using System.Threading.Tasks;
using Discord;

namespace DiscordBotProj
{
    public class Program
    {
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            Console.WriteLine("In method!");
        }
    }
}