using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public object Add(string input)
        {
            if (input == string.Empty)
            {
                return 0;
            }
            var delimiters = DefaultDelimiters();
            ThrowsExceptionForNegatives(input);
            ContainsNewDelimiters(ref input, ref delimiters);

            return ConvertValidNumbers(input, delimiters).Sum();
        }

        private static string[] DefaultDelimiters()
        {
            return new[] { ",", "\n" };
        }
        private static void ContainsNewDelimiters(ref string input, ref string[] delimiters)
        {
            if (StartsWithSlashes(input))
            {
                string[] splitInput = SplitInput(input);
                var getDelimiterInput = splitInput[0];
                if (InputContainsDelimitersWithMoreThanOneLenght(getDelimiterInput))
                {
                    delimiters = ReturnMUltipleDelimiters(getDelimiterInput);
                }
                else
                {
                    delimiters = ReturnSingleUnknownDelimiter(getDelimiterInput);
                }
                var getNewInput = splitInput[1];
                input = getNewInput;
            }
        }
        private static bool StartsWithSlashes(string input)
        {
            return input.StartsWith("//");
        }
        private static string[] SplitInput(string input)
        {
            return input.Split('\n');
        }
        private static bool InputContainsDelimitersWithMoreThanOneLenght(string getDelimiterInput)
        {
            return getDelimiterInput.Contains("[");
        }
        private static string[] ReturnMUltipleDelimiters(string getDelimiterInput)
        {
            var splitDelimiters = getDelimiterInput.Split(']', '[');
            var getMultipleDelimiters = splitDelimiters.Where(x => x != splitDelimiters[0]).ToArray();
            var delimiters = getMultipleDelimiters;
            return delimiters;
        }
        private static string[] ReturnSingleUnknownDelimiter(string getDelimiterInput)
        {
            var removeDoubleSlashes = getDelimiterInput.Remove(0, 2);
            var delimiters = new[] { removeDoubleSlashes };
            return delimiters;
        }
        private static IEnumerable<int> ConvertValidNumbers(string input, string[] delimiters)
        {

            return SplitNumbers(input, delimiters).Select(int.Parse).Where(x => x < 1000);
        }
        private static string[] SplitNumbers(string input, string[] delimiters)
        {
            return input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }
        private static void ThrowsExceptionForNegatives(string input)
        {
            if (input.Contains("-"))
            {
                throw new Exception($"negatives not allowed: {input}");
            }
        }
    }
}