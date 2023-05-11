using System;
using System.Collections.Generic;
using System.Linq;

public class List
{
    public static int Sum(List<int> myList)
    {
        // Create a dictionary to keep track of the number of occurrences of each integer
        Dictionary<int, int> counts = new Dictionary<int, int>();

        // Loop through each integer in the list and increment its count in the dictionary
        foreach (int num in myList)
        {
            if (counts.ContainsKey(num))
            {
                counts[num]++;
            }
            else
            {
                counts[num] = 1;
            }
        }

        // Calculate the sum of unique integers by adding up the integers that occur only once
        int sum = 0;
        foreach (KeyValuePair<int, int> kvp in counts)
        {
            if (kvp.Value == 1)
            {
                sum += kvp.Key;
            }
        }

        return sum;
    }
}
