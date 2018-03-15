using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{

    public class StringCalculator
    {
        public int Add(string numbers)
        {
            var splitNumbers = numbers.Split(new[] { ",", "\n", "/", "*", "%" }, StringSplitOptions.RemoveEmptyEntries);

            var values = new List<int>();

            for (var i = 0; i < splitNumbers.Length; i++)
            {
                if (numbers.Contains("-"))
                {
                    throw new Exception("negatives not allowed" + numbers);
                }

                values.Add(int.Parse(splitNumbers[i]));

                if (int.Parse(splitNumbers[i]) > 1000)
                {
                    values.Remove(int.Parse(splitNumbers[i]));
                }
            }

            var sum = 0;
            for (var i = 0; i < values.Count; i++)
            {
                sum += values[i];
            }
            return sum;
        }
    }
}
