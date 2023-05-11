using System;
using System.Collections.Generic;

class LList
{
    public static int GetNode(LinkedList<int> myLList, int n)
    {
        if (n < 0 || n >= myLList.Count)
        {
            return 0;
        }

        int i = 0;
        foreach (int value in myLList)
        {
            if (i == n)
            {
                return value;
            }
            i++;
        }

        return 0;
    }
}
