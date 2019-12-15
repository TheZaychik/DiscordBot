using System;
using System.Linq;
using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using DiscordBotProj.Services;

namespace DiscordBotProj.Modules
{
    /**
     * ChatModule
     * Class that handles the Chat response portion of the program.
     * A chat module is created here with commands that interact with the ChatService.
     */
    [Name("Chat")]
    [Summary("Chat module to interact with text chat.")]
    public class ChatModule : CustomModule
    {
        // Private variables
        private readonly ChatService m_Service;

        // Dependencies are automatically injected via this constructor.
        // Remember to add an instance of the service.
        // to your IServiceCollection when you initialize your bot!
        public ChatModule(ChatService service)
        {
            m_Service = service;
            m_Service.SetParentModule(this); // Reference to this from the service.
        }

        [Command("botStatus")]
        [Alias("botstatus")]
        [Remarks("!botstatus [status]")]
        [Summary("Allows admins to set the bot's current game to [status]")]
        [RequireUserPermission(GuildPermission.ManageRoles)]
        public async Task SetBotStatus([Remainder] string botStatus)
        {
            m_Service.SetStatus(botStatus);
            await Task.Delay(0);
        }
        
        [Command("haircut")]
        public Task Haircut(IGuildUser user1, IGuildUser user2)
        {
            return ReplyAsync($"{user1.Nickname} сделал классную прическу {user2.Nickname} ");
        }

        [Command("haircut")]
        public Task Haircut(IGuildUser user1)
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

        [Command("say")]
        [Alias("say")]
        [Remarks("!say [msg]")]
        [Summary("The bot will respond in the same channel with the message said.")]
        public async Task Say([Remainder] string usr_msg = "")
        {
            m_Service.SayMessage(usr_msg);
            await Task.Delay(0);
        }

        [Command("Clear")]
        [Remarks("!clear [num]")]
        [Summary("Allows admins to clear [num] amount of messages from current channel")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task ClearMessages([Remainder] int num = 0)
        {
            await m_Service.ClearMessagesAsync(Context.Guild, Context.Channel, Context.User, num);
        }

        [Command("usr")]
        [Remarks("!usr [arg]")]
        [Summary("Roulette of the users. arg = whoisbad")]
        public Task User(string arg)
        {

            var users =  Context.Guild.GetUsersAsync().GetAwaiter().GetResult().ToArray();
            if (arg == "whoisbad")
            { 
                Random rnd = new Random();
                IGuildUser usr = users[rnd.Next(0, users.Length)];
                if (usr.Nickname == null)
                {
                    ReplyAsync("***" + usr.Username + "*** - bad boi");
                }
                else
                {
                    ReplyAsync("***" + usr.Nickname + "*** - bad boi");
                }
        
            }

            return Task.CompletedTask;
        }
        
    }
}