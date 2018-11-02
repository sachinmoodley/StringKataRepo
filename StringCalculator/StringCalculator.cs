using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (input == string.Empty) return 0;
            ContainsNegativeNumbers(input);

            var delimiter = FetchDelimiters();
            input = ContainsNewDelimiters(input, ref delimiter);
            var splitInput = SplitInput(input, delimiter);
            return ValidateNumbers(splitInput).Sum();
        }
        private static IEnumerable<int> ConvertToNumber(IEnumerable<string> splitInput)
        {
            return splitInput.Select(int.Parse);
        }
        private static IEnumerable<int> ValidateNumbers(IEnumerable<string> splitInput)
        {
            return ConvertToNumber(splitInput).Where(num => num < 1000);
        }
        private static string[] SplitInput(string input, string[] delimiter)
        {
            return input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }
        private static void ContainsDelimitersOfAnyLength(ref string[] delimiter, string newDelimiter)
        {
            if (newDelimiter.Contains("["))
            {
                var squares = new[] { ']', '[' };
                delimiter = newDelimiter.Split(squares);
            }
        }
        private static string RemoveSlashes(string input)
        {
            return input.Remove(0, 2);
        }
        private static bool StartsWithDoubleSlashes(string input)
        {
            return input.StartsWith("//");
        }
        private static string ContainsNewDelimiters(string input, ref string[] delimiter)
        {
            if (StartsWithDoubleSlashes(input))
            {
                input = RemoveSlashes(input);
                var splitNewInput = SplitInput(input, delimiter);
                var newDelimiter = splitNewInput[0];
                delimiter = new[] { newDelimiter };
                ContainsDelimitersOfAnyLength(ref delimiter, newDelimiter);
                input = splitNewInput[1];
            }
            return input;
        }
        private static string[] FetchDelimiters()
        {
            return new[] { ",", "\n" };
        }

        private static void ContainsNegativeNumbers(string input)
        {
            if (input.Contains("-")) throw new Exception($"negatives not allowed: {input}");
        }
    }
}