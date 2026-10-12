#!/usr/bin/env dotnet
#:include ./leetcodebek/Helpers.cs 

using System.Diagnostics;
using leetcodebek;

string[] strs =
[
    "listen", "silent", "enlist", "inlets", "tinsel",
    "evil", "vile", "veil", "live",
    "dusty", "study",
    "night", "thing",
    "brag", "grab",
    "save", "vase",
    "angel", "glean", "angle",
    "state", "taste", "teats",
    "below", "elbow",
    "stressed", "desserts",
    "drawer", "reward", "redraw", "warder",
    "players", "parsley", "replays",
    "secure", "rescue", "recuse",
    "finder", "friend",
    "cheaters", "hectares", "teachers",
    "master", "stream", "tamers",
    "least", "slate", "stale", "steal", "tales",
    "heart", "earth", "hater",
    "react", "trace", "crate", "cater", "caret",
    "alert", "alter", "later",
    "stone", "tones", "notes", "onset",
    "care", "race", "acre",
    "stop", "pots", "post", "spot", "tops", "opts",
    "eat", "tea", "ate",
    "bat", "tab",
    "cat", "act",
    "dog", "god",
    "rat", "tar", "art",
    "now", "won", "own",
    "flow", "wolf",
    "inch", "chin",
    "bored", "robed",
    "fired", "fried",
    "sadder", "dreads",
    "admirer", "married",
    "auctioned", "education",
    "conversation", "voicesranton",
    "astronomer", "moonstarer",
    "debitcard", "badcredit",
    "schoolmaster", "theclassroom",
    "funeral", "realfun",
    "theeyes", "theysee",
    "elevenplus", "twelveplus",
    "slotmachines", "cashlostinme",
    "dormitory", "dirtyroom",
    "punishments", "ninemustships",
    "presbyterian", "bestinprayer",
    "desperation", "aropeendsit",
    "theearthquakes", "thatqueershake",
    "a", "a", "a",
    "ab", "ba", "ab",
    "abc", "bca", "cab", "cba", "bac", "acb",
    "aabb", "abab", "baba", "abba", "baab",
    "aabc", "abac", "baca", "caba",
    "xyz", "zyx", "yxz", "xzy", "zxy", "yzx",
    "hello", "world", "computer", "science",
    "algorithm", "structure", "programming",
    "dictionary", "hashing", "sorting",
    "performance", "benchmark", "runtime",
    "memory", "compiler", "developer",
    "keyboard", "monitor", "processor",
    "database", "network", "internet",
    "software", "hardware", "application",
    "framework", "library", "function",
    "variable", "constant", "interface",
    "inheritance", "polymorphism", "encapsulation",
    "abstraction", "recursion", "iteration",
    "binary", "linear", "dynamic",
    "stack", "queue", "graph", "tree",
    "array", "list", "string", "integer",
    "boolean", "decimal", "double",
    "exception", "thread", "process",
    "parallel", "async", "await",
    "lambda", "delegate", "generic",
    "namespace", "assembly", "package",
    "solution", "project", "module"
];

var random = new Random(666);
string[] largeStrs = Enumerable.Range(0, 100)
    .SelectMany(_ => strs.OrderBy(_ => random.Next()))
    .ToArray();

Helpers.RunAndMeasureTime(() => Solution.Bruteforce(largeStrs), "Brute Force");
Helpers.RunAndMeasureTime(() => Solution.ViaHashing(largeStrs), "Via hashing sorted string");


public static class Solution {
    public static IList<IList<string>> Bruteforce(string[] strs) 
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
                else dict.Add(ch, 1);
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
            
                if (DictsEqual(dicts[i], dicts[k]))
                {
                    anagrams.Add(strs[k]);    
                    indexesToSkip.Add(k);
                }
            }
        
            result.Add(anagrams);
        }
        
        return result;
    }

    static bool DictsEqual<TKey, TVal>(Dictionary<TKey, TVal> dict1, Dictionary<TKey, TVal> dict2) where TKey : notnull
    {
        if (dict1.Count != dict2.Count) return false;

        return dict1.All(kvp => dict2.TryGetValue(kvp.Key, out var value) && EqualityComparer<TVal>.Default.Equals(kvp.Value, value));
    }


    public static IList<IList<string>> ViaHashing(IList<string> strs)
    {
        var dict = new Dictionary<string,  IList<string>>();

        for (int i = 0; i < strs.Count; i++)
        {
            var chars = strs[i].ToCharArray();
            Array.Sort(chars);
            var sortedString = new string(chars);
            
            if (!dict.ContainsKey(sortedString))
            {
                dict.Add(sortedString, new List<string>() { strs[i] });
            }
            else
            {
                dict[sortedString].Add(strs[i]);
            }
        }

        return dict.Values.ToList();
    }
}