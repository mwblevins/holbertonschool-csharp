using System;

class Program
{
    static void Main(string[] args)
    {
        Random rndm = new Random();
        int number = rndm.Next(-10, 10);
        Console.Write(number);
        if (number > 0)
        {
            Console.Write(" is positive");
        }
        else if (number == 0)
        {
            Console.Write(" is zero");
        }
        else
        {
            Console.Write(" is negative");
        }
        Console.WriteLine();
    }
}