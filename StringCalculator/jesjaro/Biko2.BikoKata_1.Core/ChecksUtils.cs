using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biko2.BikoKata_1.Core
{
    public class ChecksUtils
    {
        public bool IsOnlyOneNumber(string stringOfNumbers)
        {
            if (stringOfNumbers.Contains(","))
            {
                return false;
            }
            return true;
        }

        public bool IsEmptyString(string stringOfNumbers)
        {
            return stringOfNumbers == string.Empty;
        }
    }
}
