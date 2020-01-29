using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (input == string.Empty) { return 0; }

            // TODO this block of code mixes responsibilities. It is building a list of delimiters
            //       and gets the number section.
            var delimiters = new[] { ",", "\n" };
            if (HasCustomDelimiters(input))
            {
                delimiters = GetCustomDelimiters(input);
                input = GetNumbersAfterCustomDelimiters(input);
            }

            return GetNumberSum(input, delimiters);
        }

        // TODO this method mixes responsibilities. It is parsing numbers and checking for negatives.
        private static void ContainsNegatives(string[] input)
        {
            var negativeNumbers = input.Select(int.Parse).Where(x => x < 0).ToList();
            if (negativeNumbers.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(",", negativeNumbers)}");
            }
        }

        private static bool HasCustomDelimiters(string input)
        {
            return input.StartsWith("//");
        }

        private static string GetNumbersAfterCustomDelimiters(string newInput)
        {
            var input = newInput.Split('\n');
            return input[1];
        }

        private static string[] GetCustomDelimiters(string input)
        {
            var newInput = input.Split('\n');
            return newInput.First()
                .Replace("//", "")
                .Split(new[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);
        }

        // TODO this method mixes responsibilities. It is parsing, filtering numbers under 1000,
        //       summing numbers and doing a bit of co-ordination (the co-ordination is the call to ContainsNegatives).
        private static int GetNumberSum(string input, string[] delimiters)
        {
            var numbers = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            ContainsNegatives(numbers);

            return numbers
                .Select(int.Parse)
                .Where(n => n < 1001)
                .Sum();
        }
    }
}