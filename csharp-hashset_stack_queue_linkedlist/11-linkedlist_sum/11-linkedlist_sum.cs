using System;
using System.Collections.Generic;

class LList
{
    public static int Sum(LinkedList<int> myLList)
    {
        int sum = 0;
        LinkedListNode<int> currentNode = myLList.First;

        while (currentNode != null)
        {
            sum += currentNode.Value;
            currentNode = currentNode.Next;
        }

        return sum;
    }
}
