#!/usr/bin/env dotnet
#:include ./leetcodebek/Helpers.cs 

using leetcodebek;

// Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.

var solution = new Solution();
Console.WriteLine(string.Join(", ", solution.TopKFrequent([1,1,1,2,2,3,5,5,5,5,5,5,5], 2)));
Helpers.RunAndMeasureTime(() => solution.TopKFrequent([1,1,1,2,2,3,5,5,5,5,5,5,5], 2));


public class Solution {
    public int[] TopKFrequent(int[] nums, int k)
    {
        var frequencyDict = new Dictionary<int, int>();

        foreach (var num in nums) 
        {
            if (!frequencyDict.TryAdd(num, 1))
            {
                frequencyDict[num] += 1;
            }
        }

        List<int>?[] buckets = new List<int>?[nums.Length + 1];

        foreach (var (key, value) in frequencyDict)
        {
            if (buckets[value] is null)
            {
                buckets[value] = new List<int>();
            } 
            
            buckets[value]!.Add(key);
        }

        var result = new int[k];
        int m = 0;
        for (int i = buckets.Length-1; i > 0; i--)
        {
            List<int>? bucketElem = buckets[i];
            if (bucketElem is null) continue;

            foreach (var num in bucketElem)
            {
                result[m++] = num;
                if (m == k) return result;
            }   
        }

        return result;
    }
}

