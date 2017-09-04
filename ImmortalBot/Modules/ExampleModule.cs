using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace ImmortalBot.Modules
{

    [Name("Example")]
    public class ExampleModule : ModuleBase<SocketCommandContext>
    {
        [Command("say"), Alias("s")]
        [Summary("Make the bot say something")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public Task Say([Remainder]string text)
            => ReplyAsync(text);

        [Name("Moderator")]
        [RequireContext(ContextType.Guild)]
        public class ModeratorModule : ModuleBase<SocketCommandContext>
        {
            [Command("kick")]
            [Summary("Kick the specified user.")]
            [RequireUserPermission(GuildPermission.KickMembers)]
            public async Task Kick([Remainder]SocketGuildUser user)
            {
                await ReplyAsync($"cya {user.Mention} :wave:");
                await user.KickAsync();
            }
        }
    }
}
