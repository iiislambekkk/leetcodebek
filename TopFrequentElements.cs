#!/usr/bin/env dotnet

// Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.

Console.WriteLine(string.Join(", ", Solution.TopKFrequent([1,1,1,2,2,3,5,5,5,5,5,5,5], 2)));


public class Solution {
    public static int[] TopKFrequent(int[] nums, int k)
    {
        var frequencyDict = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (!frequencyDict.TryAdd(num, 1))
            {
                frequencyDict[num] += 1;
            }
        }
        

        List<int>[] buckets = new List<int>[nums.Length + 1];
        for (int b = 0; b < buckets.Length; b++)
        {
            buckets[b] = new List<int>();
        }

        foreach (var (key, val) in frequencyDict)
        {
            buckets[val].Add(key);
        }

        var result = new List<int>(k);

        
        int i = buckets.Length - 1;
        while (i >= 0)
        {
            var bucketElem = buckets[i];

            foreach (var num in bucketElem)
            {
                result.Add(num);
                if (result.Count == k) return result.ToArray();
            }

            i--;
        }

        return result.ToArray();
    }
}

