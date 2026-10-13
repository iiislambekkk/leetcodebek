namespace leetcodebek;

public static class Sorting
{
    public static void BubbleSort<T>(IList<T> nums) where T : IComparable<T>
    {
        for (int i = 0; i < nums.Count; i++)
        {
            for (int k = i + 1; k < nums.Count; k++)
            {
                if (nums[i].CompareTo(nums[k]) > 0)
                {
                    (nums[i], nums[k]) = (nums[k], nums[i]);
                }
            }
        }
    }
}