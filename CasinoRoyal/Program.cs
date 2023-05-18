using System;

namespace CasinoRoyal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            double odds = .75;

            Player player = new Player() { Cash = 100, Name = "The player" };
            //Player Larry = new Player() { Cash = 100, Name = "Larry" };

            while (true)
            {
                if (player.Cash == 0)
                {
                    Console.WriteLine("The house always wins.\n");
                    return;
                }
                Console.WriteLine($"Welcome to the casino the odds are {odds}.");
                player.WriteMyInfo();

                Console.WriteLine("How much would you want to bet: ");
                string howMuch = Console.ReadLine();
                if (howMuch == "") return;
                if (int.TryParse(howMuch, out int amount))
                {
                    double chacne = random.NextDouble();
                    int pot = amount * 2;
                    if (chacne <= odds)
                    {
                        player.GiveCash(amount);
                        Console.WriteLine("Bad luck you lose.");

                    }
                    else
                    {
                        player.ReceiveCash(pot);
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
