using System;


namespace BisectionGame
{
    class Program
    {
        static void Main(string[] args)
        {
            new App().Run();
        }
    }

    public class App
    {
        public void Run()
        {
            Console.WriteLine("*****WELCOME*****");
            Console.WriteLine();
            Console.WriteLine("Which game would you like to play?");
            Console.WriteLine();
            Console.WriteLine("MAIN GAME: You choose a number between 1-100 and the computer will guess until it finds your number.");
            Console.WriteLine();
            Console.WriteLine("Side Game: You try to choose the number between 1-100 that the computer has selected.");
            Console.WriteLine();
            Console.WriteLine("Enter 1 for the Main Game.");
            Console.WriteLine("Enter 2 for the Side Game.");
            Console.WriteLine();
            string menuInput = Console.ReadLine();
            int finalInput = int.Parse(menuInput);
            switch (finalInput)
            {
                case 1:
                    new MainGame().Run();
                    break;
                case 2:
                    new SideGame().Run();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("ERROR: Please enter a valid number.");
                    Console.WriteLine();
                    new App().Run();
                    break;
            }
        }
    }

    public class MainGame
    {
        public void Run()
        {
            int s; //The users selected number
            int g; //The programs guess at the users number
            int x = 100; //The max
            int n = 1; //The min
            bool loop = true; //Used to keep the "do" loop running

            Console.Clear();
            Console.WriteLine("***Main Game***");
            Console.WriteLine();
            Console.WriteLine("Please enter a number between 1-100.");
            Console.WriteLine();
            string input = Console.ReadLine();
            s = int.Parse(input);

            if (1 > s || s > 100) //Exception handler
            {
                new MainGame().Run();
            }

            g = (x + n) / 2; //Bisects

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
                    Console.WriteLine($"Your number is {s}.");
                    Console.WriteLine($"The computer guessed {g}.");
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

                    else if (finalHighLow == 2) //LOW
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

    public class SideGame
    {
        public void Run()
        {
            int s; //The users attempt to guess the computers number
            int g; //The programs selected number
            bool loop = true; //Used to keep the "do" loop running
            Random random = new Random();
            g = random.Next(1, 101);

            Console.Clear();
            Console.WriteLine("***Side Game***");
            Console.WriteLine();
            Console.WriteLine("The computer has chosen a number between 1-100.");
            Console.WriteLine();
            Console.WriteLine("Enter the number that you think the computer has chosen.");
            Console.WriteLine();
            string input = Console.ReadLine();
            s = int.Parse(input);

            if (1 > s || s > 100) //Exception handler
            {
                new SideGame().Run();
            }

            do
            {

                if (s == g) //You WIN
                {
                    Console.Clear();
                    Console.WriteLine($"Congratulations! You have selected the computers number, {g}!");
                    Console.WriteLine();
                    Console.WriteLine("*****GAME OVER*****");
                    loop = false;
                }

                if (s != g)
                {
                    Console.Clear();
                    Console.WriteLine($"Your guess of {s} was wrong!");
                    Console.WriteLine();
                    
                    if (s < g) //The user guessed LOW
                    {

                        Console.WriteLine("Your guess was too low. Please try again.");
                        Console.WriteLine();
                        string inputAgain = Console.ReadLine();
                        s = int.Parse(inputAgain);
                        continue;
                    }

                    else if (s > g) //The user guessed HIGH
                    {
                        Console.WriteLine("Your guess was too high. Please try again.");
                        Console.WriteLine();
                        string inputAgain = Console.ReadLine();
                        s = int.Parse(inputAgain);
                        continue;
                    }
                }
            } while (loop == true);
        }
    }
}

