using System;
using System.Collections.Generic;

class LList
{
    public static int Length(LinkedList<int> myLList)
    {
        int count = 0;
        LinkedListNode<int> currentNode = myLList.First;
        while (currentNode != null)
        {
            count++;
            currentNode = currentNode.Next;
        }
        return count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> llist = new LinkedList<int>();
        llist.AddLast(1);
        llist.AddLast(2);
        llist.AddLast(3);

        int length = LList.Length(llist);

        Console.WriteLine("Linked List Length: " + length);
    }
}
