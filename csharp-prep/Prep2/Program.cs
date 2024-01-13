using System;

class Program
{
    static void Main(string[] args)
    {
        string letter, sPercentage;
        const string PLUS = "+";
        const string MINUS = "-";
        string sign = null;

        Console.Write("What's your grade percentage? ");
        sPercentage = Console.ReadLine();

        int percentage = int.Parse(sPercentage);

        if (percentage >= 90){
            letter = "A";
        }
        else if (percentage >= 80){
            letter = "B";
        }
        else if (percentage >= 70){
            letter = "C";
        }
        else if (percentage >= 60){
            letter = "D";
        }
        else{
            letter = "F";
        }

        if (percentage < 97 && percentage >= 60){
            if (percentage %10 >= 7){
                sign = PLUS;
            }
            else if (percentage %10 < 3){
                sign = MINUS;
            }
            else{
                sign = "";
            }
        }

        Console.WriteLine($"Your grade is {letter}{sign}.");

        if (percentage >= 70){
            Console.WriteLine("Congratulations, you've passed the class.");
        }
        else{
            Console.WriteLine("Sorry, you did not pass the class.");
        }
    }
}