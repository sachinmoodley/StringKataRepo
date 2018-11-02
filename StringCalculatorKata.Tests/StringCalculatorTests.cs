using System;
using NUnit.Framework;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
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

        [Test]
        public void Add_GivenMultipleNegativeNumbers_ShouldThrow()
        {
            //arrange 
            var input = "-1,-4,-3,-7";
            var expected = $"negatives not allowed: {input}";
            var sut = CreateCalculator();
            //act
            var actual = Assert.Throws<Exception>(() => sut.Add(input));
            //assert
            Assert.AreEqual(expected, actual.Message);
        }

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
        private static StringCalculator.StringCalculator CreateCalculator()
        {
            return new StringCalculator.StringCalculator();
        }
    }
}