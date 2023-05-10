using System;

class Array
{
    public static void Reverse(int[] array)
    {
        int x = (array?.Length).GetValueOrDefault(0);
        for (int i = x - 1; i != -1; i--)
        {
            Console.Write("{0}{1}", array[i], i == 0 ? "" : " ");
        }
        Console.WriteLine();
    }
}