using System;
using System.Collections.Generic;

public class BalancedBrackets
{
    public static string IsBalanced(string input)
    {
        // Define matching pairs
        Dictionary<char, char> matchingBrackets = new Dictionary<char, char>
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

        // Stack to keep track of opening brackets
        Stack<char> stack = new Stack<char>();

        foreach (char c in input)
        {
            // Ignore whitespace
            if (char.IsWhiteSpace(c))
            {
                continue;
            }

            // If it's an opening bracket, push to stack
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            // If it's a closing bracket
            else if (c == ')' || c == ']' || c == '}')
            {
                // If stack is empty or top of stack is not the matching opening bracket, return NO
                if (stack.Count == 0 || stack.Pop() != matchingBrackets[c])
                {
                    return "NO";
                }
            }
        }

        // If stack is empty, all brackets were balanced
        return stack.Count == 0 ? "YES" : "NO";
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the string of brackets:");
        string input = Console.ReadLine();

        // Output the result
        string result = IsBalanced(input);
        Console.WriteLine(result);
        Console.ReadLine();
    }
}
