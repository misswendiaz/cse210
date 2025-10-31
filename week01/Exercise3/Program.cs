using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Console.WriteLine();

        Console.WriteLine("Welcome to the Number Guessing Game! \n");

        Console.Write("Start? (Y/N) ");

        string start = Console.ReadLine();

        // Makes sure that the response is in upper case
        string play = start.ToUpper();

        while (play =="Y")
        {
            // Generates the magic number
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            // Asks for the guess
            Console.Write("Guess: ");
            string response = Console.ReadLine();

            // Converts the response to an int
            int guess = int.Parse(response);

            // Counts the number of guesses
            int count = 1;

            // Checks the guess
            while (guess != magicNumber)
            {
                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower \n");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher \n");
                }
                else
                {
                    Console.WriteLine("Please enter an integer.\n");
                }

                // Asks for the guess
                Console.Write("Guess: ");
                response = Console.ReadLine();

                // Converts the response to an int
                guess = int.Parse(response);

                // Counts the guesess
                count++;
            }

            Console.WriteLine($"Congratulations! You got it after {count} guesses! \n");

            Console.Write("Play again? (Y/N) ");

            start = Console.ReadLine();
            // Makes sure that the response is in upper case
            play = start.ToUpper();
        }

        

    }
}