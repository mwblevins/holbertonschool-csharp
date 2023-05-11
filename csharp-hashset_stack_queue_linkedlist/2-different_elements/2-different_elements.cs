using System.Collections.Generic;

public class List
{
    public static List<int> DifferentElements(List<int> list1, List<int> list2)
    {
        // Create a HashSet to store unique elements in both lists
        HashSet<int> set = new HashSet<int>(list1);

        // Loop through the second list and add any new elements to the set
        foreach (int num in list2)
        {
            if (!set.Contains(num))
            {
                set.Add(num);
            }
            else
            {
                set.Remove(num); // remove the elements that are present in both lists
            }
        }

        // Convert the set to a sorted list using bubble sort
        List<int> different = new List<int>(set);
        for (int i = 0; i < different.Count - 1; i++)
        {
            for (int j = 0; j < different.Count - i - 1; j++)
            {
                if (different[j] > different[j + 1])
                {
                    int temp = different[j];
                    different[j] = different[j + 1];
                    different[j + 1] = temp;
                }
            }
        }

        return different;
    }
}
