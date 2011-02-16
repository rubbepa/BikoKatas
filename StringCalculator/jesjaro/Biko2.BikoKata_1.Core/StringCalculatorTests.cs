using Xunit;

namespace Biko2.BikoKata_1.Core
{
    public class StringCalculatorTests
    {
        private int _result;
        private StringCalculator _stringCalculator;

        public StringCalculatorTests()
        {
            _stringCalculator = new StringCalculator();
        }

        [Fact]
        public void ReturnZero()
        {
            _result = _stringCalculator.Add("");

            Assert.Equal(0,_result);
        }

        [Fact]
        public void ReturnSameNumberWithOneNumber()
        {
            _result = _stringCalculator.Add("1");

            Assert.Equal(1,_result);
        }

        [Fact]
        public void ReturnSumOfTwoNumbers()
        {
            _result = _stringCalculator.Add("1,2");

            Assert.Equal(3,_result);
        }

        [Fact]
        public void ReturnSumOfThreeNumbers()
        {
            _result = _stringCalculator.Add("1,2,3");

            Assert.Equal(6,_result);
        }

        [Fact]
        public void ReturnSumOfFiveNumbers()
        {
            _result = _stringCalculator.Add("2,4,8,16,32");

            Assert.Equal(62,_result);
        }

        [Fact]
        public void ReturnSumOfThreeNumbersWithNewLineSymbol()
        {
            _result = _stringCalculator.Add("1,2\n4");

            Assert.Equal(7,_result);
        }

        [Fact]
        public void ReturnSumOfFourNumbersWithNewLineWithoutFinishNumberReturnsNull()
        {
            _result = _stringCalculator.Add("1,2\n3,");

            Assert.Equal(0,_result);
        }

    }
}
