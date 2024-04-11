using System.ComponentModel;
using Xunit;
using static UnsignedUnrealLongNumbers.UnsignedUnrealLongNumbers;

namespace UnsignedUnrealLongNumbers.tests
{
    public class UnsignedUnrealLongNumbersTest
    {
        [Fact]
        [Description("Test equal length numbers")]
        public void EqualLengthNumbersTest()
        {
            Assert.Equal("22", Add("11", "11"));
            Assert.Equal("44", Add("22", "22"));
            Assert.Equal("198", Add("99", "99"));
            Assert.Equal("18", Add("9", "9"));
        }

        [Fact]
        [Description("Test different length numbers")]
        public void DifferentLengthNumbersTest()
        {
            Assert.Equal("12", Add("1", "11"));
            Assert.Equal("24", Add("2", "22"));
            Assert.Equal("108", Add("9", "99"));
            Assert.Equal("100", Add("9", "91"));
        }

        [Fact]
        [Description("Test long numbers")]
        public void LongNumbersTest()
        {
            var longNumber = new string(Enumerable.Repeat('9', 100).ToArray());
            var longNumberResultArray = Enumerable.Repeat('9', 101).ToArray();
            longNumberResultArray[0] = '1';
            longNumberResultArray[longNumberResultArray.Length - 1] = '8';

            var longNumberResult = new string(longNumberResultArray);

            Assert.Equal(longNumberResult, Add(longNumber, longNumber));

            longNumber = new string(Enumerable.Repeat('1', 100).ToArray());
            longNumberResult = new string(Enumerable.Repeat('2', 100).ToArray());

            Assert.Equal(longNumberResult, Add(longNumber, longNumber));
        }
    }
}
