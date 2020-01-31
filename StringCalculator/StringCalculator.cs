using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) { return 0; }

            var delimiters = new[] { ",", "\n" };

            // TODO this block of code mixes responsibilities. It is building a list of delimiters
            //       and gets the number section.
            if (HasCustomDelimiters(input))
            {
                var newInput = input.Split('\n');
                delimiters = GetCustomDelimiters(newInput.First());
                input = newInput[1];
            }

            var splitNumber = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var convertedNumbers = splitNumber.Select(int.Parse).ToList();

            ContainsNegatives(convertedNumbers);

            var validNumbers = AcceptNumbersUnder1000(convertedNumbers);
            return validNumbers.Sum();
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