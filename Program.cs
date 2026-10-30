using System.Text.Json;

Outcome outcome = new Outcome();


static void BootAnimation()
{


    Console.Clear();
    Console.CursorVisible = false;
    List<int> sound1 = new List<int> { 523, 659, 784, 1046 };
    List<int> sound2 = new List<int> { 150, 150, 150, 300 };
    List<string> text = new List<string> { " ",
                                        """██████╗  ██████╗  ██████╗██╗  ██╗    ██████╗  █████╗ ██████╗  █████╗ ███████╗██████╗     ███████╗ ██████╗██╗███████╗███████╗ ██████╗ ██████╗ ███████╗""",
                                        """██╔══██╗██╔═══██╗██╔════╝██║ ██╔╝    ██╔══██╗██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔══██╗    ██╔════╝██╔════╝██║██╔════╝██╔════╝██╔═══██╗██╔══██╗██╔════╝""",
                                        """██████╔╝██║   ██║██║     █████╔╝     ██████╔╝███████║██████╔╝███████║█████╗  ██████╔╝    ███████╗██║     ██║███████╗███████╗██║   ██║██████╔╝███████╗""",
                                        """██╔══██╗██║   ██║██║     ██╔═██╗     ██╔═══╝ ██╔══██║██╔═══╝ ██╔══██║██╔══╝  ██╔══██╗    ╚════██║██║     ██║╚════██║╚════██║██║   ██║██╔══██╗╚════██║""",
                                        """██║  ██║╚██████╔╝╚██████╗██║  ██╗    ██║     ██║  ██║██║     ██║  ██║███████╗██║  ██║    ███████║╚██████╗██║███████║███████║╚██████╔╝██║  ██║███████║""",
                                        """╚═╝  ╚═╝ ╚═════╝  ╚═════╝╚═╝  ╚═╝    ╚═╝     ╚═╝  ╚═╝╚═╝     ╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝    ╚══════╝ ╚═════╝╚═╝╚══════╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝""",
                                        " " };






    for (int i = 0; i < sound1.Count; i++)
    {
        Console.WriteLine(text[i * 2]);
        Console.WriteLine(text[i * 2 + 1]);
        Console.Beep(sound1[i], sound2[i]);
    }
    Console.Beep(775, 800);
}

static int Mode()
{
    int pos = 0;
    string keypress = "";
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
            Rowcolor.Yellow("            > [ T3P ] <");
            Rowcolor.White("              [ T5P ] ");
            Rowcolor.White("           [ FREE PLAY ] ");
        }

        if (pos == 1)
        {
            Rowcolor.White("              [ T3P ] ");
            Rowcolor.Yellow("            > [ T5P ] <");
            Rowcolor.White("           [ FREE PLAY ] ");
        }

        if (pos == 2)
        {
            Rowcolor.White("              [ T3P ] ");
            Rowcolor.White("              [ T5P ] ");
            Rowcolor.Yellow("         > [ FREE PLAY ] <");
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
            if (pos > 2)
            {
                pos = 0;
            }

        }
        if (keypress == "UpArrow")
        {
            pos--;
            if (pos < 0)
            {
                pos = 2;
            }


        }

        if (keypress == "Enter")
        {
            return pos;
        }
    }
}

static async Task Loader()
{
    string[] tips =
    [
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


        ];
    string[] dots = [
        ".",
            "..",
            "...",
            "....",
            "....."
    ];
    int dotnum = 0;
    int mscounter = 0;
    int tipnum = Random.Shared.Next(0, tips.Length);
    int dottime = 300; // Must be divisible by 3000
    int loadtime = Random.Shared.Next(6000, 11000);

    while (true)
    {
        Console.Clear();
        dotnum++;
        if (dotnum > 4)
        {
            dotnum = 0;
        }
        Console.WriteLine($"Loading{dots[dotnum]}");
        if (mscounter % 3000 == 0)
        {
            tipnum = Random.Shared.Next(0, tips.Length);
        }
        Console.WriteLine(tips[tipnum]);
        mscounter += dottime;
        await Task.Delay(dottime);
        if (mscounter >= loadtime)
        {
            break;
        }


    }
}

void DataLogger(int modechoice, int bscore, int pscore)
{
    string whowon = "";
    if (bscore > pscore)
    {
        whowon = "Lost";
    }
    else
    {
        whowon = "Won";
    }
    string mode = "";
    if (modechoice == 0)
    {
        mode = "To 3 Points";
    }
    else if (modechoice == 1)
    {
        mode = "To 5 Points";
    }
    string result = $"[{DateTime.Now}] Mode: {mode} | Bot Score: {bscore} | Player Score: {pscore} | Result: {whowon}";
    outcome.Outcomes.Add(result);
}

async Task MainGame(int modechoice)
{


    string keypress = "";
    int intpos = 0;
    int botch;
    int bscore = 0;
    int pscore = 0;

    Console.Clear();
    List<string> elements = new List<string> { "Rock", "Paper", "Scissors" };
    while (true)
    {
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
            Rowcolor.Gray("Tie");
        }
        else if ((intpos == 0 && botch == 2) ||
                 (intpos == 1 && botch == 0) ||
                 (intpos == 2 && botch == 1))
        {
            Rowcolor.Green("You won");
            pscore++;
        }
        else
        {
            Rowcolor.Red("You lost");
            bscore++;
        }
        Console.WriteLine($"Bot choice: {elements[botch]}");
        Console.WriteLine($"Press any key to continue or Q to exit");
        char exit = Console.ReadKey(true).KeyChar;

        if (modechoice == 0 && (bscore == 3 || pscore == 3))
        {
            if (bscore == 3)
            {
                Console.Clear();
                Rowcolor.Red("You lost! The Bot reached 3 points first.");
                Console.Beep(587, 300);
                Console.Beep(554, 300);
                Console.Beep(523, 300);
                Console.Beep(494, 600);
            }
            else
            {
                Console.Clear();
                Rowcolor.Green("You won! You reached 3 points first.");
                Console.Beep(659, 120);
                Console.Beep(784, 120);
                Console.Beep(659, 120);
                Console.Beep(880, 180);
                Console.Beep(1046, 300);
            }
            DataLogger(modechoice, bscore, pscore);
            Console.WriteLine("Press any key to exit to main menu...");
            Console.ReadKey(true);
            Console.Beep(784, 150);
            break;
        }

        else if (modechoice == 1 && (bscore == 5 || pscore == 5))
        {
            if (bscore == 5)
            {
                Console.Clear();
                Rowcolor.Red("You lost! The Bot reached 5 points first.");
                Console.Beep(587, 300);
                Console.Beep(554, 300);
                Console.Beep(523, 300);
                Console.Beep(494, 600);
            }
            else
            {
                Console.Clear();
                Rowcolor.Green("You won! You reached 5 points first.");
                Console.Beep(659, 120);
                Console.Beep(784, 120);
                Console.Beep(659, 120);
                Console.Beep(880, 180);
                Console.Beep(1046, 300);
            }
            DataLogger(modechoice, bscore, pscore);
            Console.WriteLine("Press any key to exit to main menu...");
            Console.ReadKey(true);
            Console.Beep(784, 150);
            break;
        }



        if (char.ToLower(exit) == 'q')
        {
            Console.Beep(300, 150);
            break;
        }


    }
}

void stats()
{
    Console.Clear();
    if (outcome.Outcomes.Count == 0)
    {
        Rowcolor.Gray("No stats to show yet.");
        Console.WriteLine("Press any key to exit to main menu...");
        Console.ReadKey(true);
        Console.Beep(784, 150);
        return;
    }
    else
    {
        
    
    Console.WriteLine("Game results:");
    for (int i = 0; i < outcome.Outcomes.Count; i++)
    {
        Console.WriteLine(outcome.Outcomes[i]);
    }
    Console.WriteLine();
    Console.WriteLine("Press any key to exit to main menu or Delete to clear stats...");
    ConsoleKey key = Console.ReadKey(true).Key;
    if (key == ConsoleKey.Delete)
    {
        Console.Clear();
        Console.Beep(220, 400);
        Rowcolor.DarkRed("Don't run from your past!");
        Rowcolor.Red("[ Press 'Delete' to Accept Oblivion ]");
        Rowcolor.Gray("[ Press 'Any other button' to Face It ]");
        key = Console.ReadKey(true).Key;
        if (key == ConsoleKey.Delete)
        {
            outcome.Outcomes.Clear();
            File.WriteAllText("stats.json", JsonSerializer.Serialize(outcome));
            Console.Clear();
            Console.Beep(180, 400);
            Task.Delay(600).Wait();
            Console.Write("Now ");
            Task.Delay(600).Wait();
            Console.Write("go. ");
            Task.Delay(1000).Wait();
            Console.Write("Pretend, ");
            Task.Delay(600).Wait();
            Console.Write("it ");
            Task.Delay(600).Wait();
            Console.Write("never ");
            Task.Delay(600).Wait();
            Console.Write("happened.");
            Task.Delay(1500).Wait();
        }
        else
        {
            Console.Beep(523, 80);
            Console.Beep(659, 120);
        }
    }
    else
        {
            Console.Beep(784, 150);
        }
    }
}




void MainMenu()
{
    int pos = 0;
    string keypress = "";

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
            Rowcolor.Yellow("          > [ P L A Y ] < ");
            Rowcolor.White("           [ S T A T S ] ");
            Rowcolor.White("            [ E X I T ] ");
        }

        if (pos == 1)
        {
            Rowcolor.White("            [ P L A Y ] ");
            Rowcolor.Yellow("         > [ S T A T S ] <");
            Rowcolor.White("            [ E X I T ] ");
        }

        if (pos == 2)
        {
            Rowcolor.White("            [ P L A Y ] ");
            Rowcolor.White("           [ S T A T S ] ");
            Rowcolor.Yellow("          > [ E X I T ] <");
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
            if (pos > 2)
            {
                pos = 0;
            }

        }
        if (keypress == "UpArrow")
        {
            pos--;
            if (pos < 0)
            {
                pos = 2;
            }


        }

        if (pos == 0 && keypress == "Enter")
        {
            break;

        }
        if (pos == 1 && keypress == "Enter")
        {
            stats();
        }
        if (pos == 2 && keypress == "Enter")
        {
            Console.Clear();
            Console.Beep(350, 100);
            Console.Beep(250, 150);
            Environment.Exit(0);
        }
    }
}
Console.Title = "Rock Paper Scissors";

string statfilelocation = "stats.json";

if (File.Exists(statfilelocation))
{
    string json = File.ReadAllText(statfilelocation);
    outcome = JsonSerializer.Deserialize<Outcome>(json) ?? new Outcome();
}


int modechoice = 0;

Console.SetWindowSize(150, 30);
BootAnimation();
while (true)
{
    File.WriteAllText(statfilelocation, JsonSerializer.Serialize(outcome));
    MainMenu();
    modechoice = Mode();
    await Loader();
    while (Console.KeyAvailable)
    {
        Console.ReadKey(true);
    }
    await MainGame(modechoice);
}


public class Outcome
{
    public List<string> Outcomes { get; set; } = new();
}


