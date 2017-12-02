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
                    await e.Channel.SendMessage("!debug - sends hello world\n!fish - sends an image of a fish\n!dissapointed - sends an image of a dissapointed man\n!angry - sends an angry face\n!bored - sends and image of pure boredom\n!dood - dood!\n!retarded - sends the dumbest image known to man\n!hype - sends the most hype image\n!ok - sends Lucoa from the other world just to agree with you\n!nut - sends the nuttiest nut ever nutted\n!translatejp (your text) - translates given text into japanese IT DOESN'T WORK YET RIIIIP\n!slurp - brings you to the slurp zone\n!help - no\n!jai - sums up Jai in one video\n!sam - sums up Sam in one video\n!hunter - forbidden command\n!david - sums up David in one gif\n!trent - Removed as per request of Trent\n!matt - kill me...\n!lucas - 360 views...\n!d (ammount of sides) (ammount of rolls) - rolls a dice of the specified sides the specified ammount of times");
                });

            commands.CreateCommand("debug")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Hello, world!");
                });

            commands.CreateCommand("fish")
                .Do(async (e) =>
                {
                    Random randy = new Random();
                    int rnd = randy.Next(1, 3);
                    Console.WriteLine("DEGBUG: The rnd is " + rnd);
                    if (rnd == 1)
                    {
                        await e.Channel.SendFile("emotes/fishreal.png");
                    }
                    else if (rnd == 2)
                    {
                        await e.Channel.SendFile("emotes/fish.png");
                    }
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
            commands.CreateCommand("d")
                .Parameter("sides", ParameterType.Required)
                .Parameter("rolls", ParameterType.Required)
                .Do(async (e) =>
                {
                    Random randy = new Random();
                    string s = "Your dice rolls are:\n";
                    for(int i = 1; i <= this.GetFullNumFromText(e.GetArg("rolls")); i++)
                    {
                        s += randy.Next(1, GetFullNumFromText(e.GetArg("sides")) + 1) + "\n";
                    }
                    await e.Channel.SendMessage(s);
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
        private int GetFullNumFromText(string s)
        {
            int finalNum = 0;
            string startingNum = "";
            for(int i = 0; i < s.Length; i++)
            {
                for(int k = 0; k < 10; k++)
                {
                    //Console.WriteLine(s.ElementAt(i)+" equals "+ GetTextFromNum(k)+"\n"+(s.ElementAt(i).Equals(GetTextFromNum(k))));
                    if (s.ElementAt(i).Equals(GetTextFromNum(k).ElementAt(0)))
                    {
                        startingNum += s.ElementAt(i);
                        break;
                    }
                        
                }
            }
            //Console.WriteLine(startingNum);
            int zerosAtFront = 0;
            for(int i = 0; i < startingNum.Length; i++)
            {
                if (startingNum.ElementAt(i).Equals("0"))
                {
                    zerosAtFront++;
                }
                else
                    break;
            }
            for(int i = 0; i < startingNum.Length; i++)
            {
                if(i >= zerosAtFront)
                {
                    finalNum += GetNumFromChar(startingNum.ElementAt(i)) * (int)(Math.Pow(10.0, startingNum.Length - i - 1));
                }
            }
            //Console.WriteLine("Starting Num is: " + startingNum + " Final Num is: " + finalNum);
            return finalNum;
        }
        private string GetTextFromNum(int num)
        {
            if (num == 0)
            {
                return "0";
            }else if (num == 1)
            {
                return "1";
            }
            else if (num == 2)
            {
                return "2";
            }
            else if (num == 3)
            {
                return "3";
            }
            else if (num == 4)
            {
                return "4";
            }
            else if (num == 5)
            {
                return "5";
            }
            else if (num == 6)
            {
                return "6";
            }
            else if (num == 7)
            {
                return "7";
            }
            else if (num == 8)
            {
                return "8";
            }
            else if (num == 9)
            {
                return "9";
            }
            return null;
        }
        private int GetNumFromChar(char s)
        {
            if (s.Equals('0'))
            {
                return 0;
            }
            else if (s.Equals('1'))
            {
                return 1;
            }
            else if (s.Equals('2'))
            {
                return 2;
            }
            else if (s.Equals('3'))
            {
                return 3;
            }
            else if (s.Equals('4'))
            {
                return 4;
            }
            else if (s.Equals('5'))
            {
                return 5;
            }
            else if (s.Equals('6'))
            {
                return 6;
            }
            else if (s.Equals('7'))
            {
                return 7;
            }
            else if (s.Equals('8'))
            {
                return 8;
            }
            else if (s.Equals('9'))
            {
                return 9;
            }
            return 0;
        }
    }
}
