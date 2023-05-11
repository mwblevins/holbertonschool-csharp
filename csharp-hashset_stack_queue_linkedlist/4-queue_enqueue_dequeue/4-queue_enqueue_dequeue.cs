using System;
using System.Collections.Generic;

class MyQueue
{
    public static Queue<string> Info(Queue<string> aQueue, string newItem, string search)
    {
        int numItems = aQueue.Count;
        Console.WriteLine("Number of items: " + numItems);

        if (numItems == 0)
        {
            Console.WriteLine("Queue is empty");
        }
        else
        {
            string firstItem = aQueue.Peek();
            Console.WriteLine("First item: " + firstItem);
        }

        aQueue.Enqueue(newItem);

        bool containsSearch = false;
        Queue<string> tempQueue = new Queue<string>();

        foreach (string item in aQueue)
        {
            if (item == search)
            {
                containsSearch = true;
                break;
            }
            tempQueue.Enqueue(item);
        }

        Console.WriteLine("Queue contains \"" + search + "\": " + containsSearch);

        if (containsSearch)
        {
            aQueue = new Queue<string>(tempQueue);
        }

        return aQueue;
    }
}
