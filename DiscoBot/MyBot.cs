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
                    await e.Channel.SendMessage("!debug - sends hello world\n!fish - sends an image of a fish\n!dissapointed - sends an image of a dissapointed man\n!angry - sends an angry face\n!bored - sends and image of pure boredom\n!dood - dood!\n!retarded - sends the dumbest image known to man\n!hype - sends the most hype image\n!ok - sends Lucoa from the other world just to agree with you\n!nut - sends the nuttiest nut ever nutted\n!translatejp (your text) - translates given text into japanese IT DOESN'T WORK YET RIIIIP\n!slurp - brings you to the slurp zone\n!help - no\n!jai - sums up Jai in one video\n!sam - sums up Sam in one video\n!hunter - forbidden command\n!david - sums up David in one gif\n!trent - Removed as per request of Trent\n!matt - kill me...\n!lucas - 360 views...");
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

            commands.CreateCommand("slurp")
                .Do(async (e) =>
                {
                    Random randy = new Random();
                    int randomNum = randy.Next(0, 66);
                    if(randomNum == 0)
                    {
                        await e.Channel.SendFile("slurp/slurp (0).gif");
                    }else
                    await e.Channel.SendFile("slurp/slurp ("+randomNum+").jpg");
                });

            commands.CreateCommand("help")
                .Do(async (e) =>
                {
                   await e.Channel.SendFile("emotes/help.png");
                });

            commands.CreateCommand("jai")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("https://www.youtube.com/watch?v=PiF80QA5a8w");
                });

            commands.CreateCommand("sam")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("https://www.youtube.com/watch?v=Lzbr6fPDmkE&feature=youtu.be");
                });

            commands.CreateCommand("hunter")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("emotes/sexy-pokemon-ditto.jpg");
                });

            commands.CreateCommand("david")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("emotes/david.gif");
                });

            commands.CreateCommand("trent")
                .Do(async (e) =>
                {
                    //Random randy = new Random();
                    //int randomNum = randy.Next(0, 3);
                    //if (randomNum == 0)
                    //{
                    //await e.Channel.SendMessage("https://www.youtube.com/watch?v=Z-IMUidnU9o");
                    //}
                    //else if(randomNum == 1)
                    //{
                    //await e.Channel.SendMessage("https://www.youtube.com/watch?v=ZWHtLCHc-Po");
                    //}
                    //else
                    //await e.Channel.SendFile("emotes/trant.png");
                    await e.Channel.SendMessage("Removed as per request of Trent");
                });

            commands.CreateCommand("matt")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("https://www.youtube.com/watch?v=D8DnQFwpGNI");
                });

            commands.CreateCommand("lucas")
                .Do(async (e) =>
                {
                    Random randy = new Random();
                    int randomNum = randy.Next(0, 3);
                    if (randomNum == 0)
                    {
                        await e.Channel.SendMessage("https://www.youtube.com/watch?v=IbF8wemTKAw");
                    }
                    else if (randomNum == 1)
                    {
                        await e.Channel.SendMessage("https://www.youtube.com/watch?v=v76OtlwNCns");
                    }
                    else
                        await e.Channel.SendMessage("https://www.youtube.com/watch?v=AjqEu5eJK7Q");
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
