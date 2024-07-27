using System;
using System.Collections.Generic;

public class Weighted_Strings
{
    public static List<string> Solve(string s, int[] queries)
    {
        HashSet<int> weights = new HashSet<int>();

        int i = 0;
        while (i < s.Length)
        {
            int weight = s[i] - 'a' + 1;
            weights.Add(weight);

            int j = i + 1;
            while (j < s.Length && s[j] == s[i])
            {
                weight += s[j] - 'a' + 1;
                weights.Add(weight);
                j++;
            }

            i = j;
        }

        List<string> result = new List<string>();
        foreach (int query in queries)
        {
            if (weights.Contains(query))
            {
                result.Add("Yes");
            }
            else
            {
                result.Add("No");
            }
        }

        return result;
    }

    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter the string:");
            string s = Console.ReadLine();

            Console.WriteLine("Enter the number of queries:");
            int numQueries = int.Parse(Console.ReadLine());

            int[] queries = new int[numQueries];
            Console.WriteLine("Enter the queries separated by spaces:");
            string[] queryStrings = Console.ReadLine().Split(' ');

            if (queryStrings.Length != numQueries)
            {
                throw new ArgumentException("The number of queries provided does not match the expected count.");
            }

            for (int i = 0; i < numQueries; i++)
            {
                queries[i] = int.Parse(queryStrings[i]);
            }

            List<string> result = Solve(s, queries);

            Console.WriteLine("Output:");
            Console.WriteLine(string.Join(", ", result));  // Output: Yes, Yes, Yes, No
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        // Keep the console window open
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
