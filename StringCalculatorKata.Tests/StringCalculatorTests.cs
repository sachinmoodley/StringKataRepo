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
            //------Arrange-------
            var input = "";
            var expected = 0;
            var sut = new StringCalculator();

            //--------Act---------
            var actual = sut.Add(input);
            //------Assert--------
            Assert.AreEqual(expected , actual);
        }

        [Test]
        public void Add_GivenNumber1_ShouldReturnNumber1()
        {
            //------Arrange-------
            var input = "1";
            var expected = 1;
            var sut = new StringCalculator();

            //--------Act---------
            var actual = sut.Add(input);
            //------Assert--------
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Add_GivenNumber2_ShouldReturnNumber2()
        {
            //------Arrange-------
            var input = "2";
            var expected = 2;
            var sut = new StringCalculator();

            //--------Act---------
            var actual = sut.Add(input);
            //------Assert--------
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Add_GivenCommaDilimitedNumber_ShouldReturnSum()
        {
            //------Arrange-------
            var input = "1,2";
            var expected = 3;
            var sut = new StringCalculator();

            //--------Act---------
            var actual = sut.Add(input);
            //------Assert--------
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Add_GivenMultipleCommaDelimitedNumbers_ShouldReturnSum()
        {
            //------Arrange-------
            var input = "1,2,45,23,4,56,3,2";
            var expected = 136;
            var sut = new StringCalculator();

            //--------Act---------
            var actual = sut.Add(input);
            //------Assert--------
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Add_GivenNewLineDelimitedNumber_ShouldReturnSum()
        {
            //------Arrange-------
            var input = "1\n2,3";
            var expected = 6;
            var sut = new StringCalculator();

            //--------Act---------
            var actual = sut.Add(input);
            //------Assert--------
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Add_GivenUnknownDelimiters_ShouldReturnSum()
        {
            //------Arrange-------
            var input = "//;\n1;2";
            var expected = 3;
            var sut = new StringCalculator();

            //--------Act---------
            var actual = sut.Add(input);
            //------Assert--------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNegativeNumber_ShouldThrowException()
        {
            //------Arrange-------
            var input = "-1";
            var expected = "negatives not allowed: -1";
            var sut = new StringCalculator();

            //--------Act---------
            var actual = Assert.Throws<Exception>(() => sut.Add(input));

            //------Assert--------
            Assert.AreEqual(expected, actual.Message);
        }
        
        [Test]
        public void Add_GivenMultipleNegativeNumbers_ShouldThrowException()
        {
            //------Arrange-------
            var input = "-1,-4,-2,-6";
            var expected = $"negatives not allowed: {input}";
            var sut = new StringCalculator();

            //--------Act---------
            var actual = Assert.Throws<Exception>(() => sut.Add(input));

            //------Assert--------
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Add_GivenNumbersGreaterThan1000_ShouldIgnoreTheseNumbers()
        {
            //------Arrange-------
            var input = "2,1001";
            var expected = 2;
            var sut = new StringCalculator();

            //--------Act---------
            var actual = sut.Add(input);
            //------Assert--------
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Add_GivenUnknownDelimitersWithAnyLength_ShouldReturnSum()
        {
            //------Arrange-------
            var input = "//[***]\n1***2***3";
            var expected = 6;
            var sut = new StringCalculator();

            //--------Act---------
            var actual = sut.Add(input);
            //------Assert--------
            Assert.AreEqual(expected, actual); 

        }

        [Test]
        public void Add_GivenMultipleUnknownDelimiters_ShouldReturnSum()
        {
            //------Arrange-------
            var input = "//[*][%]\n1*2%3";
            var expected = 6;
            var sut = new StringCalculator();

            //--------Act---------
            var actual = sut.Add(input);
            //------Assert--------
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Add_GivenMultipleUnknownDelimitersWithAnyLength_ShouldReturnSum()
        {
            //------Arrange-------
            var input = "//[***][%%%]\n1***2%%%3";
            var expected = 6;
            var sut = new StringCalculator();

            //--------Act---------
            var actual = sut.Add(input);
            //------Assert--------
            Assert.AreEqual(expected, actual);

        }
    }
}
//------Arrange-------
//--------Act---------
//------Assert--------