namespace leetcodebek;

public static class Sorting
{
    public static void ExchangeSort<T>(IList<T> list, Comparison<T> comparison)
    {
        for (int i = 0; i < list.Count; i++)
        {
            for (int k = i + 1; k < list.Count; k++)
            {
                if (comparison(list[i], list[k]) > 0)
                {
                    (list[i], list[k]) = (list[k], list[i]);
                }
            }
        }
    }
    
    public static void BubbleSort<T>(IList<T> list, Comparison<T> comparison)
    {
        
        for (int i = 0; i < list.Count; i++)
        {
            bool swapped = false;
            
            for (int k = 0; k < list.Count - i - 1; k++)
            {
                if (comparison(list[k], list[k+1]) > 0)
                {
                    (list[k], list[k+1]) = (list[k+1], list[k]);
                    swapped = true;
                }
            }

            if (!swapped) break;
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
                if (temp.CompareTo(list[k]) >= 0) 
                    break;
                
                (list[k], list[k + 1]) = (temp, list[k]);
            }
        }
    }

    public static IList<T> MergeSort<T>(IList<T> list, Comparison<T> comparison)
    {
        if (list.Count <= 1) return list;

        int mid = list.Count / 2;

        var left = list.Take(mid).ToList();
        var right = list.Skip(mid).ToList();

        return Merge(MergeSort(left, comparison), MergeSort(right, comparison), comparison);
    }

    public static IList<T> Merge<T>(IList<T> left, IList<T> right, Comparison<T> comparison)
    {
        var res = new List<T>(left.Count + right.Count);
        
        int leftIndex = 0;
        int rightIndex = 0;
        
        while (leftIndex < left.Count || rightIndex < right.Count)
        {
            if (leftIndex >= left.Count)
            {
                res.Add(right[rightIndex++]);
                continue;
            }
            
            if (rightIndex >= right.Count)
            {
                res.Add(left[leftIndex++]);
                continue;
            }

            if (comparison(left[leftIndex], right[rightIndex]) <= 0)
                res.Add(left[leftIndex++]);
            else
                res.Add(right[rightIndex++]);
        }

        return res;
    }

    public static void QuickSort<T>(IList<T> list, Comparison<T> comparison)
    {
        if (list.Count == 0) return;
        
        int j = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (j == list.Count - 1)
            {
                (list[j], list[i]) = (list[i], list[j]);
            }
            else
            {
                if (comparison(list[j], list[^1]) < 0)
                {
                    (list[j], list[i]) = (list[i], list[j]);
                    i++;
                    j++;
                }
                else
                {
                    j++;
                }
            }
        }
    }
}