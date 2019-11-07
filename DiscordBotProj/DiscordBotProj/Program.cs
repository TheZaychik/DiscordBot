using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace DiscordBotProj
{
    public class Program
    {
        private DiscordSocketClient _client;

        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.Log += Log;
            await _client.LoginAsync(TokenType.Bot, "NjE5NTA4ODIxNzA2MTQ1ODAz.XcLeaQ.V7lSnMyey8T8j0-bm8lUOJI9lN4");
            await _client.StartAsync();
            await Task.Delay(-1);
        }
    }
}