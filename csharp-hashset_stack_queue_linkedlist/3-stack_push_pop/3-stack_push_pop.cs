using System;
using System.Collections.Generic;

class MyStack
{
    public static Stack<string> Info(Stack<string> aStack, string newItem, string search)
    {
        int numItems = aStack.Count;
        Console.WriteLine("Number of items: " + numItems);

        if (numItems == 0)
        {
            Console.WriteLine("Stack is empty");
            return aStack;
        }

        string topItem = aStack.Peek();
        Console.WriteLine("Top item: " + topItem);

        bool containsSearch = false;
        Stack<string> tempStack = new Stack<string>();

        foreach (string item in aStack)
        {
            if (item == search)
            {
                containsSearch = true;
                break;
            }
            tempStack.Push(item);
        }

        Console.WriteLine("Stack contains \"" + search + "\": " + containsSearch);

        if (containsSearch)
        {
            aStack = new Stack<string>();

            while (tempStack.Count > 0)
            {
                aStack.Push(tempStack.Pop());
            }

            aStack.Push(newItem);
        }
        else
        {
            aStack.Push(newItem);
        }

        return aStack;
    }
}
