using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DiscordBotProj
{
    public class ChatModule : ModuleBase<SocketCommandContext>
    {
        [Command("say")]
        public Task SayAsync(string echo)
        {
            return ReplyAsync(echo);
        }

        [Command("oskorbit")]
        public Task Oskorbit(IUser user)
        {
            return ReplyAsync(user.Username + " petooh");
        }
        
        [Command("chlen")]
        public Task Сhlen(IUser user, int r)
        {
            return ReplyAsync(user.Username + " имеет член длинной в " + r + " сантиметров ");
        }
    }
}