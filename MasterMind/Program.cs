using System;
using System.Collections.Generic;

namespace MasterMind
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                string[] Colors = new string[] { "Blau", "Grün", "Rot", "Lila", "Schwarz", "Organge" };

                List<string> ResultColors = Result(Colors);
                bool Win = PlayGame(Colors, ResultColors);

                if (Win)
                {
                    Console.WriteLine("Du hast gewonnen!\nZum beenden tippe: Stop\nZum weiter spielen: Play");
                }
                else
                {
                    Console.WriteLine("Du hast verloren!\nZum beenden tippe: Stop");
                }
                if (Console.ReadLine() == "Stop" || Console.ReadLine() == "stop")
                {
                    run = false;
                }
                else if (Console.ReadLine() == "Play" || Console.ReadLine() == "play")
                {
                    PlayGame(Colors, ResultColors);
                }
            }   
        }

        private static List<string> Result(string[] Colors)
        {
            List<string> ResultColors = new List<string>();

            Random rdm = new Random();
            for (int i = 0; i < 4; i++)
            {
                int Zahl = rdm.Next(0, 6);
                if (ResultColors.Contains(Colors[Zahl]))
                {
                    i--;
                }
                else
                {
                    ResultColors.Add(Colors[Zahl]);
                }
            }
            return ResultColors;
        }

        private static bool PlayGame(string[] Colors, List<string> ResultColors)
        {
            Console.WriteLine("Write four Colors\n");
            foreach (string i in Colors)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n");

            for (int i = 0; i < 10; i++)
            {
                string SpielerEingabe = Console.ReadLine();
                string[] colorsPlayerChoice = SpielerEingabe.Split(' ');
                int WhitePoint = 0;
                int BlackPoint = 0;

                if (colorsPlayerChoice.Length == 4)
                {
                    foreach (string k in colorsPlayerChoice)
                    {
                        if (ResultColors.Contains(k))
                        {
                            WhitePoint++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Zu wenige Farben oder zu viel!");
                }

                for (int b = 0; b < 4; b++)
                {
                    if (ResultColors[b].Equals(colorsPlayerChoice[b]))
                    {
                        BlackPoint++;
                        WhitePoint--;
                    }
                }
                GameAusgabe(WhitePoint, BlackPoint);

                if (BlackPoint == 4)
                {
                    return true;
                }
            }
            return false;
        }

        private static void GameAusgabe(int WhitePoint, int BlackPoint)
        {
            Console.WriteLine(WhitePoint + " Weiße Punkte\n" + BlackPoint + " Schwarze Punkte\n");

            return;
        }
    }
}