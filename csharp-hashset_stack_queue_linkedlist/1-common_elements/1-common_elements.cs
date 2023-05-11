using System.Collections.Generic;

public class List
{
    public static List<int> CommonElements(List<int> list1, List<int> list2)
    {
        // Create a HashSet to store unique elements in the first list
        HashSet<int> set1 = new HashSet<int>(list1);

        // Create a List to store common elements
        List<int> common = new List<int>();

        // Loop through the second list and add any common elements to the common list
        foreach (int num in list2)
        {
            if (set1.Contains(num))
            {
                common.Add(num);
            }
        }

        // Sort the common list using bubble sort
        for (int i = 0; i < common.Count - 1; i++)
        {
            for (int j = 0; j < common.Count - i - 1; j++)
            {
                if (common[j] > common[j + 1])
                {
                    int temp = common[j];
                    common[j] = common[j + 1];
                    common[j + 1] = temp;
                }
            }
        }

        return common;
    }
}
