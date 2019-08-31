using System;


namespace BisectionGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int s; //The users selected number
            int g; //The programs guess at the users number
            int x = 100; //The max
            int n = 1; //The min
            bool loop = true;

            Console.WriteLine("Welcome.");
            Console.WriteLine();
            Console.WriteLine("Please enter a number between 1-100.");

            string input = Console.ReadLine();
            s = int.Parse(input);

            g = (x + n) / 2;

            Console.WriteLine($"The computer's guess was {g}.");

            do
            {
                if (s == g)
                {
                    Console.Clear();
                    Console.WriteLine($"The computer found out that your number was {s}.");
                    Console.WriteLine("*****GAME OVER*****");

                    loop = false;
                }

                if (s != g)
                {

                    Console.Clear();
                    Console.WriteLine($"The computers guess was {g}.");
                    Console.WriteLine("Was the computers guess HIGH or LOW?");
                    Console.WriteLine("Enter 1 for HIGH.");
                    Console.WriteLine("Enter 2 for LOW.");

                    string highLow = Console.ReadLine();
                    int finalHighLow = int.Parse(highLow);
                    if (finalHighLow == 1) //HIGH
                    {
                        x = g;
                        g = (x + n) / 2;

                        if (s == g)
                        {
                            Console.Clear();
                            Console.WriteLine($"The computer found out that your number was {s}.");
                            Console.WriteLine("*****GAME OVER*****");

                            loop = false;
                        }

                    }

                    if (finalHighLow == 2) //LOW
                    {
                        n = g;
                        g = (x + n) / 2;

                        if (s == g)
                        {
                            Console.Clear();
                            Console.WriteLine($"The computer found out that your number was {s}.");
                            Console.WriteLine("*****GAME OVER*****");
                            loop = false;
                        }
                    }
                }
            } while (loop == true);
        }
    }
}

