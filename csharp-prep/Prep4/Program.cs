using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int number = -999;
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (number != 0){

            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            numbers.Add(number);

        }

        numbers.Remove(0);

        Console.WriteLine($"The sum is: {numbers.Sum()}");
        Console.WriteLine($"The average is: {numbers.Average()}");
        Console.WriteLine($"The largest is: {numbers.Max()}");
        Console.WriteLine($"The smallest positive number is: {positiveMin(numbers)}");

        numbers.Sort();
        Console.WriteLine($"The sorted list is: ");
        Display(numbers);
    }

    private static void Display(List<int> list)
    {
        foreach( int i in list )
        {
            Console.WriteLine(i);
        }
    }

    private static int positiveMin(List<int> list){
        List<int> positiveNumbers = new List<int>();
        foreach (int i in list)
        {
            if (i > 0){
                positiveNumbers.Add(i);
            }
            else{
                continue;
            }
        }
        return positiveNumbers.Min();
    }
}