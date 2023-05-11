using System;
using System.Collections.Generic;

public class MyStack
{
    public static Stack<string> Info(Stack<string> aStack, string newItem, string search)
    {
        Console.WriteLine("Number of items: " + aStack.Count);
        if (aStack.Count > 0)
        {
            Console.WriteLine("Top item: " + aStack.Peek());
        }
        else
        {
            Console.WriteLine("Stack is empty");
        }
    bool containsSearch = false;
        Stack<string> tempStack = new Stack<string>();
        // Search for the item to remove
        while (aStack.Count > 0)
        {
            string item = aStack.Pop();
            if (item == search)
            {
                containsSearch = true;
                break;
            }
            tempStack.Push(item);
        }

        // Put the remaining items back on the stack
        while (tempStack.Count > 0)
        {
            aStack.Push(tempStack.Pop());
        }

        // Add the new item to the stack
        aStack.Push(newItem);

        Console.WriteLine("Stack contains " + search + ": " + containsSearch);

        if (containsSearch)
        {
            // Remove the item and all items above it
            tempStack = new Stack<string>();

            while (aStack.Peek() != search)
            {
                tempStack.Push(aStack.Pop());
            }

            aStack.Pop(); // Remove the search item

            // Put the remaining items back on the stack
            while (tempStack.Count > 0)
            {
                aStack.Push(tempStack.Pop());
            }
        }

        return aStack;
    }
}
