using System;
using NUnit.Framework;

namespace StringCalculatorKata.Tests
{
    // TODO feedback a lot of the cases being tested below only have one example input/output.
    //       It's a good idea to triangulate (have 3 examples) for each case. This helps us prevent off by 1
    //       errors, build trust in our tests, when in low gear helps grow the algorithm, and finally reduces
    //       the likelihood of optimizations or refactoring breaking code without tests failing.
    //
    //       Examples:
    //         In the single number scenario, the production code could be modified with the short circuit:
    //            if(input.Length == 1) return 1;
    //         And no test would fail!
    //         
    //         In the ignore numbers greater than 1000 scenario:
    //           - There is currently an off by one issue:
    //               Currently the input "2,1000" will return 2 when it should return 1002.
    //           - The production code could be modified to:
    //               return numbers
    //                 .Select(int.Parse)
    //                 .Where(n => n < 900)
    //                 .Sum();  
    //             And not test would fail!
    //
    //       You are more than welcome to use the [TestCase] attribute.
    //
    // TODO the files in the Bin & Obj folder have unfortunately become tracked in this repository
    //       please research how to untrack them and then action that research.
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("", 0)]
        [TestCase(" ", 0)]
        [TestCase("  ", 0)]
        public void Add_GivenEmptyString_ShouldReturnZero(string input, int expected)
        {
            //arrange 
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("0",0)]
        [TestCase("1",1)]
        [TestCase("2",2)]
        public void Add_GivenSingleNumber_ShouldReturnThatNumber(string input, int expected)
        {
            //arrange 
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("0,1", 1)]
        [TestCase("1,1", 2)]
        [TestCase("1,2", 3)]
        public void Add_GivenTwoCommaDelimitedNumbers_ShouldReturnSum(string input, int expected)
        {
            //arrange 
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2,6,4,6,4,6,4", 33)]
        [TestCase("1,45,234,43", 323)]
        [TestCase("1,122,33,43,12,12", 223)]
        public void Add_GivenMultipleCommaDelimitedNumbers_ShouldReturnSum(string input, int expected)
        {
            //arrange 
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("1,3\n2,3", 9)]
        [TestCase("\n2,3", 5)]
        public void Add_GivenNumbers_WithNewLineDelimiter_ShouldReturnSum(string input, int expected)
        {
            //arrange 
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//;\n1;2;4", 7)]
        [TestCase("//;\n1;24;3;5", 33)]
        public void Add_GivenNumbers_WithDifferentDelimiters_ShouldReturnSum(string input, int expected)
        {
            //arrange
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("-1", "negatives not allowed: -1")]
        [TestCase("-1,4,-3,7", "negatives not allowed: -1,-3")]
        [TestCase("-1,-1,-1", "negatives not allowed: -1,-1,-1")]
        public void Add_GivenNegativeNumbers_ShouldThrow(string input, string expected)
        {
            //arrange 
            var sut = CreateCalculator();
            //act
            var actual = Assert.Throws<Exception>(() => sut.Add(input));
            //assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("2,1000", 2)]
        [TestCase("2,999", 1001)]
        [TestCase("2,1001", 2)]
        public void Add_GivenNumbersGreaterThan1000_ShouldIgnore(string input, int expected)
        {
            //arrange 
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[??]\n3??12??10", 25)]
        [TestCase("//[####]\n69####22####30", 121)]
        [Test]
        public void Add_GivenCustomDelimiterOfAnyLength_ShouldReturnSum(string input, int expected)
        {
            //arrange 
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[*][%]\n1*2%3",6)]
        [TestCase("//[$][#]\n1#2$9",12)]
        [TestCase("//[&][!]\n5!1&7",13)]
        public void Add_GivenMultipleCustomDelimiters_ShouldReturnSum(string input, int expected)
        {
            //arrange 
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[**][%%%]\n1**2%%%3", 6)]
        [TestCase("//[***][#####][!][*]\n45***733*838#####1!", 1617)]
        [TestCase("//[!!][#][!][**]\n4**2!8#1!!1", 16)]
        public void Add_GivenMultipleDelimitersOfAnyLength_ShouldReturnSum(string input, int expected)
        {
            //arrange 
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        private static StringCalculator.StringCalculator CreateCalculator()
        {
            return new StringCalculator.StringCalculator();
        }
    }
}