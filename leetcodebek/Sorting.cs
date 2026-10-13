namespace leetcodebek;

public static class Sorting
{
    public static void BubbleSort<T>(IList<T> list) where T : IComparable<T>
    {
        for (int i = 0; i < list.Count; i++)
        {
            for (int k = i + 1; k < list.Count; k++)
            {
                if (list[i].CompareTo(list[k]) > 0)
                {
                    (list[i], list[k]) = (list[k], list[i]);
                }
            }
        }
    }

    public static void SelectionSort<T>(IList<T> list) where T : IComparable<T>
    {
        for (int i = 0; i < list.Count-1; i++)
        {
            var minIndex = i;
            
            for (int k = i+1; k < list.Count; k++)
            {
                if (list[minIndex].CompareTo(list[k]) > 0)
                {
                    minIndex = k;
                }
            }

            if (minIndex != i) (list[i], list[minIndex]) = (list[minIndex], list[i]);
        }
    }

    public static void InsertionSort<T>(IList<T> list) where T : IComparable<T>
    {
        
        Console.WriteLine(string.Join(", ", list));
        
        for (int i = 1; i < list.Count; i++)
        {
            var temp = list[i];
            for (int k = i - 1; k >= 0; k--)
            {
                if (temp.CompareTo(list[k]) < 0)
                {
                    (list[k], list[k + 1]) = (temp, list[k]);
                }
            }
        }
    }
}