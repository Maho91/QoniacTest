using System.Collections.Generic;

namespace QoniacTest.Domain.Dictionaries
{
    /// <summary>
    /// Dictionary of Numeric Representation in Words
    /// </summary>
    public class NumericalToWord
    {
        public static Dictionary<int, string> Dict
        {
            get => new Dictionary<int, string>
            {
                { 0, "Zero" },
                { 1, "One" },
                { 2, "Two" },
                { 3, "Three" },
                { 4, "Four" },
                { 5, "Five" },
                { 6, "Six" },
                { 7, "Seven" },
                { 8, "Eight" },
                { 9, "Nine" },
                { 10, "Ten" },
                { 11, "Eleven" },
                { 12, "Twelve" },
                { 13, "Thirteen" },
                { 14, "Fourteen" },
                { 15, "Fifteen" },
                { 16, "Sixteen" },
                { 17, "Seventeen" },
                { 18, "Eighteen" },
                { 19, "Nineteen" },
                { 20, "Twenty" },
                { 30, "Thirty" },
                { 40, "Forty" },
                { 50, "Fifty" },
                { 60, "Sixty" },
                { 70, "Seventy" },
                { 80, "Eighty" },
                { 90, "Ninety" },
                { 100, "One Hundred" },
                { 200, "Tow Hundred" },
                { 300, "Three Hundred" },
                { 400, "Foar Hundred" },
                { 500, "Five Hundred" },
                { 600, "Six Hundred" },
                { 700, "Seven Hundred" },
                { 800, "Eight Hundred" },
                { 900, "Nine Hundred" }
            };
        }
    }

}