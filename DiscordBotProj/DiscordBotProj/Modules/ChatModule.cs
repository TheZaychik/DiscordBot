using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace DiscordBotProj
{
    public class ChatModule : ModuleBase<SocketCommandContext>
    {
        [Command("say")]
        public Task SayAsync(string echo)
        {
            return ReplyAsync(echo);
        }

        [Command("haircut")]
        public Task Haircut(SocketGuildUser user1, SocketGuildUser user2)
        {
            return ReplyAsync($"{user1.Nickname} сделал классную прическу {user2.Nickname} ");
        }

        [Command("haircut")]
        public Task Haircut(SocketGuildUser user1)
        {
            return ReplyAsync($"{user1.Nickname} постригся налысо ");
        }

        [Command("rnd")]
        public Task Random(int a, int b)
        {
            b++;
            Random rnd = new Random();
            return ReplyAsync($"Рандомное число от {a} до {b} - {rnd.Next(a, b)}");
        }

        [Command("usr")]
        public Task User(string arg)
        {
            SocketGuildUser[] users = Context.Guild.Users.ToArray();
            if (arg == "whoispidor")
            { 
                Random rnd = new Random();
                SocketGuildUser usr = users[rnd.Next(0, users.Length)];
                ReplyAsync("***" + usr.Nickname + "*** - пидор");
            }

            return Task.CompletedTask;
        }
    }
}