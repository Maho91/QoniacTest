using System.Collections.Generic;

namespace Qoniac.TestData
{
    internal class ValidCurrencyNumericsToWordDictitoary
    {
        public static Dictionary<string, string> Dict => new Dictionary<string, string>
            {
                { "0", "Zero Dollars" },
                { "0,1", "Zero Dollars And One Cent" },
                { "1", "One Dollar" },
                { "10", "Ten Dollars" },
                { "15", "Fifteen Dollars" },
                { "125", "One Hundred Twenty-Five Dollars" },
                { "200 100,1", "Two Hundred Thousand One Hundred Dollars And One Cent" },
                { "111 001,0", "One Hundred Eleven Thousand One Dollars And Zero Cents" },
                { "400 200 455", "Four Hundred Million Two Hundred Thousand Four Hundred Fifty-Five Dollars" },
                { "0,0", "Zero Dollars And Zero Cents" },
                { "11 038,10", "Eleven Thousand Thirty-Eight Dollars And Ten Cents" },
            };
    }

    internal class InValidFormatCurrencyNumericsToWordDictitoary
    {
        public static ICollection<string> List => new List<string>
            {
                { "88 8866,001"},
                { "0, 01"},
                { "1111111,01"},
                { "H111111,01"},
            };
    }
}
