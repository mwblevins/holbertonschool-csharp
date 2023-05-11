using System;
using System.Collections.Generic;

class LList
{
    public static LinkedList<int> CreatePrint(int size)
    {
        LinkedList<int> list = new LinkedList<int>();
        if (size < 0)
        {
            return list;
        }
        for (int i = 0; i < size; i++)
        {
            list.AddLast(i);
            Console.WriteLine(i);
        }
        return list;
    }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> llist;
        int size = 10;

        llist = LList.CreatePrint(size);

        Console.WriteLine("Linked List Length: " + llist.Count);
    }
}
