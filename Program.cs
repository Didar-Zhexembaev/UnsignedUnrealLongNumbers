using System.Text.RegularExpressions;
using static UnsignedUnrealLongNumbers.UnsignedUnrealLongNumbers;

var str1 = "554";
var str2 = "1444";

Console.WriteLine(Add(str1, str2));

namespace UnsignedUnrealLongNumbers
{
    public static class UnsignedUnrealLongNumbers
    {
        private const string ERROR_MESSAGE = "Provide correct numbers!";
        private const char ZEROCHAR = '0';
        private const int BASE = 10;

        public static string? Add(string str1, string str2)
        {
            ThrowIfArgumentsInvalid(str1, str2);

            var sum = new List<char>();
            var carry = 0;

            var i = str1.Length;
            var j = str2.Length;
            var length = i > j ? i : j;

            while (length > 0)
            {
                var firstNumber = 0;
                var secondNumber = 0;

                if (i > 0)
                {
                    firstNumber = (char)(str1[--i] - ZEROCHAR);
                }

                if (j > 0)
                {
                    secondNumber = (char)(str2[--j] - ZEROCHAR);
                }

                var result = firstNumber + secondNumber + carry;

                sum.Add((char)(result % BASE + ZEROCHAR));

                carry = result / BASE;

                length--;
            }

            if (carry > 0)
            {
                sum.Add((char)(carry + ZEROCHAR));
            }

            sum.Reverse();

            return new string(sum.ToArray());
        }

        private static void ThrowIfArgumentsInvalid(params string[] args)
        {
            foreach (var arg in args)
            {
                if (arg == null)
                {
                    throw new ArgumentNullException(ERROR_MESSAGE);
                }

                if (!IsNumber(arg))
                {
                    throw new ArgumentException(ERROR_MESSAGE);
                }
            }
        }

        private static bool IsNumber(string number)
            => Regex.IsMatch(number, @"^\d+$");
    }
}
