
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;
using NAudio.Wave;

int pos = 0;
string keypress = "";


    static void MainGame()
    {
        string keypress = "";
        int intpos = 0;
        int botch;
        int bscore = 0;
        int pscore = 0;

        Console.Clear();
        List<string> elements = new List<string> { "Kő", "Papír", "Olló" };
        while (true)
        {
            int pos = 0;
            while (true)
            {
                Console.Clear();


                Console.WriteLine($"Kő papír olló...            [Bot: {bscore} || Te: {pscore}]");



                if (intpos == 0)
                {
                    Console.WriteLine("\x1b[1;45m|Kő|\x1b[0m |Papír| |Olló|");
                }
                else if (intpos == 1)
                {
                    Console.WriteLine("|Kő| \x1b[1;45m|Papír|\x1b[0m |Olló|");
                }
                else if (intpos == 2)
                {
                    Console.WriteLine("|Kő| |Papír| \x1b[1;45m|Olló|\x1b[0m");
                }
                ConsoleKey key = Console.ReadKey(true).Key;
                keypress = key.ToString();
                if (keypress == "LeftArrow")
                {
                    intpos--;
                    if (intpos < 0)
                    {
                        intpos = 0;
                    }
                }
                if (keypress == "RightArrow")
                {
                    intpos++;
                    if (intpos > 2)
                    {
                        intpos = 2;
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
            Console.WriteLine($"Bot választása: {elements[botch]}");
            Console.WriteLine($"Nyomj bármilyen gombot a folytatáshoz vay a Q -t a kilépéshez");
            char exit = Console.ReadKey(true).KeyChar;

            if (char.ToLower(exit) == 'q')
            {
                break;
            }


        }
    }

    while (true)
    {
        Console.WriteLine(keypress);
        Console.Clear();
        if (pos == 0)
        {
            Console.WriteLine("> játék");
            Console.WriteLine("  kilépés");
        }

        if (pos == 1)
        {
            Console.WriteLine("  játék");
            Console.WriteLine("> kilépés");
        }

        ConsoleKey key = Console.ReadKey(true).Key;
        keypress = key.ToString();

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
                pos = 0;
            }


        }

        if (pos == 0 && keypress == "Enter")
        {
            MainGame();
        }
        if (pos == 1 && keypress == "Enter")
        {
            break;
        }
    }



