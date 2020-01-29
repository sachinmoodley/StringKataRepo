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
        // TODO please also handle empty strings that only contain white space e.g." " and "    "
        [Test]
        public void Add_GivenEmptyString_ShouldReturnZero()
        {
            //arrange 
            var input = "";
            var expected = 0;
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        // TODO triangulate, refer to TODO comment on class
        [Test]
        public void Add_GivenSingleNumber_ShouldReturnThatNumber()
        {
            //arrange 
            var input = "1";
            var expected = 1;
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        // TODO triangulate, refer to TODO comment on class
        [Test]
        public void Add_GivenTwoCommaDelimitedNumbers_ShouldReturnSum()
        {
            //arrange 
            var input = "1,2";
            var expected = 3;
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        // TODO triangulate, refer to TODO comment on class
        [Test]
        public void Add_GivenMultipleCommaDelimitedNumbers_ShouldReturnSum()
        {
            //arrange 
            var input = "1,2,6,4,6,4,6,4";
            var expected = 33;
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        // TODO triangulate, refer to TODO comment on class
        [Test]
        public void Add_GivenNumbers_WithNewLineDelimiter_ShouldReturnSum()
        {
            //arrange 
            var input = "1\n2,3";
            var expected = 6;
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        // TODO triangulate, refer to TODO comment on class
        [Test]
        public void Add_GivenNumbers_WithDifferentDelimiters_ShouldReturnSum()
        {
            //arrange 
            var input = "//;\n1;2";
            var expected = 3;
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        // TODO triangulate, refer to TODO comment on class, you already have 2 tests, you just need one more
        [Test]
        public void Add_GivenNegativeNumber_ShouldThrow()
        {
            //arrange 
            var input = "-1";
            var expected = $"negatives not allowed: {input}";
            var sut = CreateCalculator();
            //act
            var actual = Assert.Throws<Exception>(() => sut.Add(input));
            //assert
            Assert.AreEqual(expected, actual.Message);
        }

        // TODO triangulate, refer to TODO comment on class
        [Test]
        public void Add_GivenMultipleNegativeNumbers_ShouldThrow()
        {
            //arrange 
            var input = "-1,4,-3,7";
            var expected = $"negatives not allowed: -1,-3";
            var sut = CreateCalculator();
            //act
            var actual = Assert.Throws<Exception>(() => sut.Add(input));
            //assert
            Assert.AreEqual(expected, actual.Message);
        }

        // TODO triangulate, refer to TODO comment on class
        [Test]
        public void Add_GivenNumbersGreaterThan1000_ShouldIgnore()
        {
            //arrange 
            var input = "2,1001";
            var expected = 2;
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        // TODO triangulate, refer to TODO comment on class
        [Test]
        public void Add_GivenDelimiterOfAnyLength_ShouldReturnSum()
        {
            //arrange 
            var input = "//[***]\n1***2***3";
            var expected = 6;
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        // TODO triangulate, refer to TODO comment on class
        [Test]
        public void Add_GivenMultipleDelimiters_ShouldReturnSum()
        {
            //arrange 
            var input = "//[*][%]\n1*2%3";
            var expected = 6;
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        // TODO triangulate, refer to TODO comment on class, you already have 2 tests, you just need one more
        [Test]
        public void Add_GivenMultipleDelimitersOfAnyLength_ShouldReturnSum()
        {
            //arrange 
            var input = "//[**][%%%]\n1**2%%%3";
            var expected = 6;
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenManyUnknownDelimiters_WithAnyNumbers_ShouldReturnSum()
        {

            //arrange 
            var input = "//[***][#####][!][*]\n45***733*838#####1!";
            var expected = 1617;
            var sut = CreateCalculator();
            //act
            var actual = sut.Add(input);
            //assert
            Assert.AreEqual(expected, actual);
        }
        private static StringCalculator.StringCalculator CreateCalculator() // TODO, space blindness, there should be new line above this method.
        {
            return new StringCalculator.StringCalculator();
        }
    }
}