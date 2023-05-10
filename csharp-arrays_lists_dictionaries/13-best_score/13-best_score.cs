using System;
using System.Collections.Generic;

class Dictionary
{
    public static string BestScore(Dictionary<string, int> myList)
    {
        int maxScore = -1;
        string bestStudent = "None";

        foreach (KeyValuePair<string, int> kvp in myList)
        {
            if (kvp.Value > maxScore)
            {
                maxScore = kvp.Value;
                bestStudent = kvp.Key;
            }
        }

        return bestStudent;
    }
}
