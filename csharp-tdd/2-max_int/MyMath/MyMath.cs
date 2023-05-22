using System;
namespace MyMath
{
    /// <summary>
    /// Task 2 idk whats wrong 
    /// </summary>
    public class Operations
    {
        /// <summary>
        /// Max number in list, idk how much i need for it to pass or where to put it.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns>max</returns>
        public static int Max(List<int> nums)
        {
            if (nums.Count == 0)
                return 0;

            int max = nums[0];
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] > max)
                    max = nums[i];
            }

            return max;
        }
    }

}