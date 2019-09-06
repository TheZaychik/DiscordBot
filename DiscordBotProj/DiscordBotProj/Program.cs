using System;
using System.Threading.Tasks;

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