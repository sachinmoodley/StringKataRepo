using NUnit.Framework;
using System;
using System.ComponentModel.Design;

namespace StringCalculator.Tests
{ 
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void GivenEmptyNumber_ReturnNull()
        {
            var input = "";
            var expected = 0;
            var sut = new StringCalculator();

            var actual = sut.Add(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenOneNumber_ReturnOne()
        {
            var input = "1";
            var expected = 1;
            var sut = new StringCalculator();

            var actual = sut.Add(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenTwoNumbers_ReturnSum()
        {
            var input = "1,2";
            var expected = 3;

            var sut = new StringCalculator();

            var actual = sut.Add(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenMultipleNumbers_ReturnSum()
        {
            var input = "1,2,3,4,5,6,7,8,9,10,11,12,13,145,15,";
            var expected = 251;

            var sut = new StringCalculator();

            var actual = sut.Add(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenMultipleNumbersWithDifferentDelimeters_ReturnSum()
        {
            var input = "1\n2,3,4,5\n6,7,8,9,10,11,12,13,145,15,";
            var expected = 251;

            var sut = new StringCalculator();

            var actual = sut.Add(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNegativeNumbers_ReturnException()
        {
            var input = "-1";

            var sut = new StringCalculator();

            Assert.Throws<Exception>(() => sut.Add(input));
        }

        [Test]
        public void GivenMultipleNegativeNumbers_ReturnException()
        {
            var input = "-1\n-2;-3//";
            var sut = new StringCalculator();
            Assert.Throws<Exception>(() => sut.Add(input));
        }

        [Test]
        public void GivenNumberGreaterThan1000_ReturnTwo()
        {
            var input = "2,1001";
            var expected = 2;
            var sut = new StringCalculator();

            var actual = sut.Add(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNumbersGreaterThan1000_ReturnIgnoreGreaterNumbersThan1000()
        {
            var input = "2,1001,5,2000,5,1800";
            var expected = 12;
            var sut = new StringCalculator();

            var actual = sut.Add(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenDelimetersOfAnyLength_ReturnSum()
        {
            var input = "//\n1***2***3";
            var expected = 6;
            var sut = new StringCalculator();

            var actual = sut.Add(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenMultipleDelimetersOfAnyLength_ReturnSum()
        {
            var input = "//\n1*2%3";
            var expected = 6;
            var sut = new StringCalculator();

            var actual = sut.Add(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenMultipleDelimetersWithLongerChar_ReturnSum()
        {
            var input = "////1\n\n****2%%%%";
            var expected = 3;
            var sut = new StringCalculator();

            var actual = sut.Add(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
