using System;

namespace Bowling
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            Console.Clear();
            Console.WriteLine("Welcome to Bowling!");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Type number of pins you strake each round.");
            Console.WriteLine("-----------------------");

            bool endGame = false;
            int index = 1;
            while (!endGame)
            {
                Console.Write($"Roll {index} you strake: ");
                var input = Console.ReadLine();
                int.TryParse(input, out int pins);
                if(!game.Roll(pins))
                    endGame = true;
                index++;
            }
            var score = game.Score();
            Console.WriteLine($"You'r Score is:{score}");
            Console.WriteLine("GoodBye!");
            Console.Read();
        }
    }
}
