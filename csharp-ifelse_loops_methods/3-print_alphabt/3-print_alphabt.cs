using System;

class Program
{
    static void Main(string[] args)
    {
        for (char x = 'a'; x <= 'z'; x++)
        {
            if (x != 'q' && x != 'e')
            {
                Console.Write(x);
            }
        }
    }
}