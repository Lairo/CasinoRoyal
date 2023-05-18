using System;
using System.Collections.Generic;

namespace CasinoRoyal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            double odds = .75;

            Player player = new Player() { Cash = 100, Name = "Player #1" };
            Player playerTwo = new Player() { Cash = 400, Name = "Player #2" };
            Player playerThree = new Player() { Cash = 2000, Name = "Player #3" };

            Player[] list = new Player[] { player, playerTwo, playerThree };
            int selectedPlayer = 0;

            //Console.WriteLine(list[1].Cash);

            while (true)
            {
                foreach (var value in list)
                {
                    value.WriteMyInfo();
                }

                Console.WriteLine("Choose a player please 1,2 or 3");
                string playerChoice = Console.ReadLine();
                if (int.TryParse(playerChoice, out int choice)){
                    selectedPlayer = choice - 1;
                    break;
                }
            }
            

            while (true)
            {
                if (list[selectedPlayer].Cash == 0)
                {
                    Console.WriteLine("The house always wins.\n");
                    return;
                }
                Console.WriteLine($"Welcome to the casino the odds are {odds}.");
                list[selectedPlayer].WriteMyInfo();

                Console.WriteLine("How much would you want to bet: ");
                string howMuch = Console.ReadLine();
                if (howMuch == "") return;
                if (int.TryParse(howMuch, out int amount))
                {
                    double chacne = random.NextDouble();
                    int pot = amount * 2;
                    if (chacne <= odds)
                    {
                        list[selectedPlayer].GiveCash(amount);
                        Console.WriteLine("Bad luck you lose.");

                    }
                    else
                    {
                        list[selectedPlayer].ReceiveCash(pot);
                        Console.WriteLine($"You win {pot}");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number");
                }
            }
        }
    }
}
