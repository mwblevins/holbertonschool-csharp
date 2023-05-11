using System;
using System.Collections.Generic;


public class List
{
    public static int Sum(List<int> myList)
    {
        HashSet<int> unique = new HashSet<int>();
        int sum = 0;

        foreach (int i in myList)
        {
            if (!unique.Contains(i))
            {
                unique.Add(i);
                sum += i;
            }
        }
        return sum;
    }
}