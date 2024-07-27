using System;

class HighestPalindrome
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number string:");
        string s = Console.ReadLine();

        Console.WriteLine("Enter the maximum number of changes allowed (k):");
        int k;
        while (!int.TryParse(Console.ReadLine(), out k))
        {
            Console.WriteLine("Invalid input. Please enter an integer for k:");
        }

        string result = MakeHighestPalindrome(s, k);
        Console.WriteLine("The highest palindrome that can be formed: " + result);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    public static string MakeHighestPalindrome(string s, int k)
    {
        // Check if it is possible to make the string a palindrome
        int n = s.Length;
        char[] arr = s.ToCharArray();
        int[] changes = new int[n];

        int l = 0, r = n - 1;
        while (l < r)
        {
            if (arr[l] != arr[r])
            {
                if (k == 0)
                {
                    return "-1"; // Not enough changes to make it a palindrome
                }
                changes[l] = changes[r] = 1; // Marking the positions that are changed
                k--;
                char maxChar = arr[l] > arr[r] ? arr[l] : arr[r];
                arr[l] = arr[r] = maxChar; // Make the characters same and maximal
            }
            l++;
            r--;
        }

        // If there are changes left, maximize the palindrome
        l = 0; r = n - 1;
        while (l <= r && k > 0)
        {
            if (l == r)
            {
                if (k > 0 && arr[l] != '9')
                {
                    arr[l] = '9'; // Maximize the middle character if possible
                }
            }
            else
            {
                if (arr[l] != '9')
                {
                    if (changes[l] == 1 || changes[r] == 1)
                    {
                        arr[l] = arr[r] = '9'; // Use the existing change
                        k--;
                    }
                    else if (k > 1)
                    {
                        arr[l] = arr[r] = '9'; // Use two changes to maximize both ends
                        k -= 2;
                    }
                }
            }
            l++;
            r--;
        }

        return new string(arr);
    }
}
