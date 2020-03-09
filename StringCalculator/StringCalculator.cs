using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0;

            var delimiters = new[] { ",", "\n" };

            var newInput = GetInputAfterCustomDelimiters(input);
            delimiters = GetCustomDelimiters(input, delimiters, newInput);
            input = GetInputForCustomDelimiters(input, newInput);

            var splitNumber = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var convertedNumbers = splitNumber.Select(int.Parse).ToList();

            ContainsNegatives(convertedNumbers);

            var validNumbers = AcceptNumbersUnder1000(convertedNumbers);
            return validNumbers.Sum();
        }

        private static string GetInputForCustomDelimiters(string input, string[] newInput)
        {
            if (!HasCustomDelimiters(input)) return input;
            return newInput[1];
        }

        private static string[] GetCustomDelimiters(string input, string[] delimiters, string[] newInput)
        {
            if (!HasCustomDelimiters(input)) return delimiters;
            return GetCustomDelimiters(newInput.First());
        }

        private static string[] GetInputAfterCustomDelimiters(string input)
        {
            if (!HasCustomDelimiters(input)) return null;
            return input.Split('\n');
        }

        private static void ContainsNegatives(IEnumerable<int> numbers)
        {
            var negativeNumbers = numbers.Where(x => x < 0).ToList();
            if (negativeNumbers.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(",", negativeNumbers)}");
            }
        }

        private static bool HasCustomDelimiters(string input)
        {
            return input.StartsWith("//");
        }

        private static string[] GetCustomDelimiters(string input)
        {
            return input
                .Replace("//", "")
                .Split(new[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static IEnumerable<int> AcceptNumbersUnder1000(IEnumerable<int> numbers)
        {
            return numbers
                .Where(n => n <= 999);
        }
    }
}