using System;

class Program
{
    static void Main(string[] args)
    {
        string output = "";
        for (int i = 0; i < 100; i++)
        {
            if (i < 10)
            {
                output += "0";
            }
            output += $"{i}";
            if (i < 99)
            {
                output += ", ";
            }
        }
        Console.Write(output + "\n");
    }
}