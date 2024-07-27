# HITOPIA---ProblemSolvingTests

Soal nomor 2

# Pemeriksa Tanda Kurung Seimbang

Program C# ini menentukan apakah string yang diberikan berisi tanda kurung yang seimbang. Program ini mendukung tiga jenis tanda kurung: tanda kurung bulat `()`, tanda kurung siku `[]`, dan tanda kurung kurawal `{}`.

## Fungsi

Fungsi `IsBalanced` akan memeriksa apakah string tanda kurung yang diberikan seimbang atau tidak.

```csharp
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
