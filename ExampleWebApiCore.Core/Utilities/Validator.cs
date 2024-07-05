using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExampleWebApiCore.Core.Utilities
{
    public static class Validator
    {
        public static bool IsPhoneNumberValidation(string phoneNumber)
        {
            var isSuccess = true;
            try
            {
                for (int i = 0; i < phoneNumber.Length; i++)
                {
                    if (!Char.IsDigit((char)phoneNumber[i]))
                        return false;
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
