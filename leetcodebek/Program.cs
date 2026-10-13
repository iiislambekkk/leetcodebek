using leetcodebek;

var arr = new[] {4, 2, 1, 6, 3};
Helpers.RunAndMeasureTime(() => Sorting.BubbleSort(arr));
Console.WriteLine(string.Join(", ", arr));
