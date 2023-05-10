using System;

class Program
{
    static void Main(string[] args)
    {
        int[,] array = new int[5, 5];

        // initialize all indices to 0
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                array[i, j] = 0;
            }
        }

        // set index [2,2] to 1
        array[2, 2] = 1;

        // print the array
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write("{0} ", array[i, j]);
            }
            Console.WriteLine();
        }
    }
}
