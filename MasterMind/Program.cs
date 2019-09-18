using System;
using System.Collections.Generic;

namespace MasterMind
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] Colors = new string[] { "Blau", "Grün", "Rot", "Lila", "Schwarz", "Organge" };
            List<string> PlayerList = new List<string>();

            List<string> ResultColors = Result(Colors);
            PlayerEingabe(Colors, ResultColors);
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

        private static void PlayerEingabe(string[] Colors, List<string> ResultColors)
        {
            Console.WriteLine("Write four Colors\n");
            foreach (string i in Colors)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n");

            string SpielerEingabe = Console.ReadLine();
            string[] colorsPlayerChoice = SpielerEingabe.Split(' ');
            int WhitePoint = 0;

            if (colorsPlayerChoice.Length == 4)
            {
                foreach (string i in colorsPlayerChoice)
                {
                    if (ResultColors.Contains(i))
                    {
                        WhitePoint++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Zu wenige Farben oder zu viel!");
            }
            return;
        }
    }
}