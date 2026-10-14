using leetcodebek;

int[] arr = [1, 10, 5];
Sorting.QuickSort(arr, (a, b) => a.CompareTo(b));
Console.WriteLine(string.Join(", ", arr));
