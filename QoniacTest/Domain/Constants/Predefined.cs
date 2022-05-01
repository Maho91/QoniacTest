namespace QoniacExercise.Domain.Constants
{
    /// <summary>
    /// Predefined values that are hardcoded and used throughout the system
    /// </summary>
    public static class Predefined
    {
        /// <summary>
        /// Predefined rules class. 
        /// </summary>
        /// 
        public static class DomainRules
        {
            /// <summary>
            /// Predefined rules for NumericalToWord
            /// </summary>
            public static class NumericalToWord
            {
                public const int DolarsMaxLimit = 999999999;
                public const int CentsLimit = 99;
            }
        }


        /// <summary>
        /// Predefined exception class. 
        /// </summary>
        public static class Exceptions
        {
            /// <summary>
            /// Predefined messages for the Numerical To Word Converter.
            /// </summary>
            public static class NumericalToWord
            {
                /// <summary>
                /// Predefined BadRequest Exception 
                /// </summary>
                public static class BadIntry
                {
                    public const string InvalidRequestedDollarsAmount = "Requested amount of dollars must be only numbers and between (0 - {0})";
                    public const string InvalidRequestedCentsAmount = "Requested amount of cents percentage must be between (0 -  {0})";
                    public const string IncorrectRequestFormat = "Incorrect format, the request must have no letters and be formatted like the following examples: (0) , (0,10), (10 111,10) or (1 210 177)";
                    public const string InvalidNumberFormat = "Numric blocks of the ammount must have maximum 3 digits";
                }
            }
        }
    }
}