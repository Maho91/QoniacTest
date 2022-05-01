using System;
using System.Globalization;

namespace WebApi.Helpers
{
    // custom exception class for throwing application specific exceptions 
    // that can be caught and handled within the application
    public class BadEntryException : Exception
    {
        public BadEntryException() : base() { }

        public BadEntryException(string message) : base(message) { }

    }
}