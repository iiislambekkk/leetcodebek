#!/usr/bin/env dotnet


Console.WriteLine(string.Join("\n", Solution.GroupAnagrams(["alma", "amal", "koishi"]).Select(list => string.Join(", ", list))));


public static class Solution {
    public static IList<IList<string>> GroupAnagrams(string[] strs) 
    {
        var dicts = strs.Select(str =>
        {
            var dict = new Dictionary<char, int>();
            foreach (var ch in str)
            {
                if (dict.ContainsKey(ch))
                {
                    dict[ch] += 1;
                }
                else dict.Add(ch, 0);
            }
        
            return dict;
        }).ToList();

        var indexesToSkip = new HashSet<int>();
        var result = new List<IList<string>>();

        for (int i = 0; i < dicts.Count; i++)
        {
            if (indexesToSkip.Contains(i)) continue;
            var anagrams = new List<string>() { strs[i] };

            for (int k = i + 1; k < dicts.Count; k++)
            {
                if (indexesToSkip.Contains(k)) continue;
            
                if (DIctsEqual(dicts[i], dicts[k]))
                {
                    anagrams.Add(strs[k]);    
                    indexesToSkip.Add(k);
                }
            }
        
            result.Add(anagrams);
        }
    
        return result;
    }

    static bool DIctsEqual<TKey, TVal>(Dictionary<TKey, TVal> dict1, Dictionary<TKey, TVal> dict2) where TKey : notnull
    {
        if (dict1.Count != dict2.Count) return false;

        return dict1.All(kvp => dict2.TryGetValue(kvp.Key, out var value) && EqualityComparer<TVal>.Default.Equals(kvp.Value, value));
    }
}