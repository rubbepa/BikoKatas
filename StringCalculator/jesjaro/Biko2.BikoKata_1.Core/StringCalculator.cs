using System;
using System.Collections.Generic;

namespace Biko2.BikoKata_1.Core
{
    public class StringCalculator
    {
        private ChecksUtils _checkUtils;

        public StringCalculator()
        {
            _checkUtils = new ChecksUtils();
        }

        public int Add(string stringOfNumbers)
        {
            if (_checkUtils.IsEmptyString(stringOfNumbers))
            {
                return 0;
            }
            if(_checkUtils.IsOnlyOneNumber(stringOfNumbers))
            {
                return int.Parse(stringOfNumbers);
            }
            return NumberSum(stringOfNumbers);
        }

        private int NumberSum(string stringOfNumbers)
        {
            //if (NotCorrectString(stringOfNumbers))
            //{
            //    return 0;
            //}
            string[] numbersToSum = ExtractNumbersWithCommaSeparator(stringOfNumbers);

            return ResultSummatory(ExtractNumbersWithNewLineSeparator(numbersToSum));
        }

        //private bool NotCorrectString(string stringOfNumbers)
        //{
        //    if (!CheckExistsNumberAfterSeparator(",",stringOfNumbers))
        //    {
        //        return true;
        //    }

        //    if (!CheckExistsNumberAfterSeparator("\n", stringOfNumbers))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //private bool CheckExistsNumberAfterSeparator(string separator, string stringOfNumbers)
        //{
        //    th
        //    if (stringOfNumbers.Contains(separator))
        //    {
                
        //    }
        //}

        private int ResultSummatory(List<int> numbersToSum)
        {
            int result = 0;

            foreach (int number in numbersToSum)
            {
                result = result + number;
            }
            return result;
        }

        private List<int> ExtractNumbersWithNewLineSeparator(string[] numbersToSum)
        {
            List<int> resultString = new List<int>();

            foreach (string number in numbersToSum)
            {
                string[] numbersSeparated = number.Split('\n');

                foreach (string numberSeparated in numbersSeparated)
                {
                    resultString.Add(int.Parse(numberSeparated));
                }
            }

            return resultString;
        }

        private string[] ExtractNumbersWithCommaSeparator(string stringOfNumbers)
        {
            return stringOfNumbers.Split(',');
        }
    }
}
