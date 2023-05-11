using System;
using System.Collections.Generic;

class LList
{
    public static LinkedListNode<int> Insert(LinkedList<int> myLList, int n)
    {
        LinkedListNode<int> newNode = new LinkedListNode<int>(n);

        if (myLList.Count == 0 || n <= myLList.First.Value)
        {
            myLList.AddFirst(newNode);
            return newNode;
        }

        LinkedListNode<int> currentNode = myLList.First;

        while (currentNode.Next != null && currentNode.Next.Value < n)
        {
            currentNode = currentNode.Next;
        }

        myLList.AddAfter(currentNode, newNode);

        return newNode;
    }
}
