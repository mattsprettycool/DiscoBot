using Discord;
using Discord.Commands;
using Google.Apis.Translate.v2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoBot
{
    class MyBot
    {
        DiscordClient discord;
        public MyBot()
        {
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            var commands = discord.GetService<CommandService>();

            commands.CreateCommand("commands")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("!debug - sends hello world\n!fish - sends an image of a fish\n!dissapointed - sends an image of a dissapointed man\n!angry - sends an angry face\n!bored - sends and image of pure boredom\n!dood - dood!\n!retarded - sends the dumbest image known to man\n!hype - sends the most hype image\n!ok - sends Lucoa from the other world just to agree with you\n!nut - sends the nuttiest nut ever nutted\n!translatejp (your text) - translates given text into japanese IT DOESN'T WORK YET RIIIIP");
                });

            commands.CreateCommand("debug")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Hello, world!");
                });

            commands.CreateCommand("fish")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("emotes/fish.png");
                });

            commands.CreateCommand("objection")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("emotes/objection.png");
                });

            commands.CreateCommand("dissapointed")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("emotes/dissapointed.png");
                });

            commands.CreateCommand("angry")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("emotes/anger.png");
                });

            commands.CreateCommand("bored")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("emotes/bored.png");
                });

            commands.CreateCommand("dood")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("emotes/dood.png");
                });

            commands.CreateCommand("retarded")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("emotes/Dumb_Denki.png");
                });

            commands.CreateCommand("hype")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("emotes/hypeFull.png");
                });

            commands.CreateCommand("ok")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("emotes/ok.png");
                });

            commands.CreateCommand("nut")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("emotes/psiNut.png");
                });

            commands.CreateCommand("translatejp")
                .Parameter("text", ParameterType.Required)
                .Do(async (e) =>
                {
                    Google.Apis.Translate.v2.Data.TranslateTextRequest trq = new Google.Apis.Translate.v2.Data.TranslateTextRequest();
                    List<string> myText = new List<string>();
                    myText.Add(e.GetArg("text"));
                    trq.Q = myText;
                    trq.Source = "en";
                    trq.Target = "jn";
                    trq.Format = "text";
                    TranslationsResource.TranslateRequest tr = new TranslationsResource.TranslateRequest(new TranslateService(), trq);

                    Google.Apis.Translate.v2.TranslationsResource tres = new Google.Apis.Translate.v2.TranslationsResource(new TranslateService());
                    
                    await e.Channel.SendMessage(tres.Translate(trq).ToString());
                });

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MzgwODg5OTE4NjgwODU4NjI3.DO_NTA.Ydye58G3mCAVTVBtTd9DgNyCCVM", TokenType.Bot);
            });
        }
        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
