using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        int guess, count = 0;
        string playAgain = "Y";

        do{
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            count++;

            if (guess > magicNumber){
                Console.WriteLine("Lower");
            }
            else if (guess < magicNumber){
                Console.WriteLine("Higher");
            }
            else{
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"You have made {count} guesses.");
                Console.WriteLine("Do you want to play again? [Y or N] ");
                playAgain = Console.ReadLine();
                count = 0;
            }

        } while(playAgain.ToUpper() == "Y");
    }
}