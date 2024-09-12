// C# code​​​​​​‌​‌‌‌​‌‌​‌‌‌‌​‌‌​‌​‌​​​​‌ below
using System;
using System.Text;

// Write your answer here, and then test your code.

public class Answer {

    // Change these Boolean values to control whether you see 
    // the expected result and/or hints.
   public  static Boolean ShowExpectedResult = false;
   public  static Boolean ShowHints = false;

    // Determine whether a string is a Palindrome
    public static bool IsPalindrome(string thestr) {
        // Your code goes here.
        // Declare a string
        string tester;

        // Grab the input of thestr and declare it to tester, making it all upper 
        tester = thestr.ToUpper();

        // create a variable to create a StringBuilder
        var sb = new StringBuilder();

        // iterate through each character in tester
        foreach (char ch in tester){
            // if the character does NOT have a punctuation and does NOT have a white space
            if(!char.IsPunctuation(ch) && !char.IsWhiteSpace(ch)) {
                // then append the character to the string builder
                sb.Append(ch);
            }
        }
        // convert the string builder to a string and attach it to the variable tester
        tester = sb.ToString();

        // declare an index of 0 for i and give j the reverse of the length to start at the end
        int i = 0, j = tester.Length-1;

        // while i is less than j comparing the first letter to the last letter
        while (i <= j) {
            // if the first letter is not equal to the last letter
            if (tester[i] != tester[j]) {
                // return false
                return false;
            }
            // incriment i and subtract j
            i++;
            j--;
        }
        // if we reach this point then it must be a palindrome
        return true;
    }

    public
}

// This is how your code will be called.
// You can edit this code to try different testing cases.
string[] teststrings = { "Hello World!", "Race car!", "Rotor", "More cowbell!", "Madam, I'm Adam." };
int palcount = 0;
foreach (string str in teststrings) {
    bool learnerResult = Answer.IsPalindrome(str);
    if (learnerResult)
        palcount++;
}