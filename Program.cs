
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;


int pos = 0;
string keypress = "";

    static async Task Loader(CancellationToken cancellationToken)
    {
        string[] tips = new string[]
        {
            "TIP: 100% of players who choose Paper fear scissors.",
            "TIP: If you keep losing, try picking a different option.",
            "TIP: Scissors is technically two knives fastened together.",
            "TIP: Winning gives you a higher win count than losing.",
            "TIP: Paper is made from trees. Trees beat rock in nature (eventually).",
            "TIP: If you keep losing, blame the garbage collector.",
            "TIP: Paper covers Rock, but nobody knows how that actually damages the Rock.",
            "TIP: Remember to drink water while waiting as long as 10 seconds for this loading screen to finish.",
            "TIP: Maybe it's not your fault, have you tried buying a better gaming chair?",
            "TIP: Cigánygyerek isnt a valid option",
            "TIP: Compared to Csokonai, you are nothing",
            "TIP: This is an Easter Egg",
            

        };
        while (true)
        {
        Console.Clear();
        Console.WriteLine("Loading...");
        Console.WriteLine(tips[Random.Shared.Next(0, tips.Length)]);
        await Task.Delay(2000);
        cancellationToken.ThrowIfCancellationRequested();

        await Task.Delay(1000, cancellationToken);
        }
    }

    static async Task MainGame()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(Random.Shared.Next(5, 11)));

    try 
    {
        await Loader(cts.Token);
    }
    catch (OperationCanceledException)
    {
        Console.Clear();
    }

        string keypress = "";
        int intpos = 0;
        int botch;
        int bscore = 0;
        int pscore = 0;

        Console.Clear();
        List<string> elements = new List<string> { "Rock", "Paper", "Scissors" };
        while (true)
        {
            int pos = 0;
            while (true)
            {
                Console.Clear();


                Console.WriteLine($"Rock Paper Scissors...            [Bot: {bscore} || You: {pscore}]");



                if (intpos == 0)
                {
                    Console.WriteLine("\x1b[1;45m|Rock|\x1b[0m |Paper| |Scissors|");
                }
                else if (intpos == 1)
                {
                    Console.WriteLine("|Rock| \x1b[1;45m|Paper|\x1b[0m |Scissors|");
                }
                else if (intpos == 2)
                {
                    Console.WriteLine("|Rock| |Paper| \x1b[1;45m|Scissors|\x1b[0m");
                }
                ConsoleKey key = Console.ReadKey(true).Key;
                keypress = key.ToString();
                        if (keypress != "Enter")
                            {
                                Console.Beep(400, 50); 
                            }
                        else
                            {
                                Console.Beep(784, 150); 
                            }
                if (keypress == "LeftArrow")
                {
                    intpos--;
                    if (intpos < 0)
                    {
                        intpos = 2;
                    }
                }
                if (keypress == "RightArrow")
                {
                    intpos++;
                    if (intpos > 2)
                    {
                        intpos = 0;
                    }
                }
                if (keypress == "Enter")
                {
                    break;
                }
            }



            botch = Random.Shared.Next(3);




            if (botch == intpos)
            {
                Console.WriteLine("Döntetlen");
            }
            else if ((intpos == 0 && botch == 2) ||
                     (intpos == 1 && botch == 0) ||
                     (intpos == 2 && botch == 1))
            {
                Console.WriteLine("Nyertél");
                pscore++;
            }
            else
            {
                Console.WriteLine("Vesztettél");
                bscore++;
            }
            Console.WriteLine($"Bot choice: {elements[botch]}");
            Console.WriteLine($"Press any key to continue or Q to exit");
            char exit = Console.ReadKey(true).KeyChar;

            if (char.ToLower(exit) == 'q')
            {
                break;
            }


        }
    }

        // Console.Beep(523, 150); 
        // Console.Beep(659, 150); 
        // Console.Beep(784, 150); 
        // Console.Beep(1046, 300); 
    while (true)
    {
        
        Console.Clear();
        Console.WriteLine("""                                                                                                                          
┌──────────────────────────────────┐
│     ROCK - PAPER - SCISSORS      │
└──────────────────────────────────┘

""");
        if (pos == 0)
        {
            Console.WriteLine("         > [ P L A Y ] <");
            Console.WriteLine("           [ E X I T ] ");
        }

        if (pos == 1)
        {
            Console.WriteLine("           [ P L A Y ] ");
            Console.WriteLine("         > [ E X I T ] <");
        }

        ConsoleKey key = Console.ReadKey(true).Key;
        keypress = key.ToString();
        if (keypress != "Enter")
        {
            Console.Beep(400, 50); 
        }
        else
        {
            Console.Beep(784, 150); 
        }

        if (keypress == "DownArrow")
        {
            pos++;
            if (pos > 1)
            {
                pos = 0;
            }

        }
        if (keypress == "UpArrow")
        {
            pos--;
            if (pos < 0)
            {
                pos = 1;
            }


        }

        if (pos == 0 && keypress == "Enter")
        {
            await MainGame();
            
        }
        if (pos == 1 && keypress == "Enter")
        {
            break;
        }
    }





