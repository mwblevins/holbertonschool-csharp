using System;
using System.Collections.Generic;

class Dictionary
{
    public static Dictionary<string, string> AddKeyValue(Dictionary<string, string> myDict, string key, string value)
    {
        // Check if key exists in the dictionary
        if (myDict.ContainsKey(key))
        {
            // Replace the value of the key
            myDict[key] = value;
        }
        else
        {
            // Add a new key-value pair
            myDict.Add(key, value);
        }

        return myDict;
    }
}
