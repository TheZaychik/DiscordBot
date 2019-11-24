using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace DiscordBotProj
{
    public class Program
    {
        private DiscordSocketClient _client;
        private CommandHandler _cmdHandler;
        

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
            _cmdHandler = new CommandHandler(_client, new CommandService());
            await _cmdHandler.InstallCommandsAsync();
            _client.Log += Log;
            await _client.LoginAsync(TokenType.Bot, "NjE5NTA4ODIxNzA2MTQ1ODAz.Xdc2ag.vFWD6Bwt6zSt9Omf7NitQT-v5DA");
            await _client.StartAsync();
            await Task.Delay(-1);
        }
    }
}