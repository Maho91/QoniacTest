namespace QoniacExercise.IServices
{
    public interface ICurrencyNumericsToWordConverter
    {
        /// <summary>
        /// This method Converts Currency Numerical values to Word representation
        /// </summary>
        /// <param name="Amount"> Curreny amount need to be converted</param>
        /// <returns></returns>
        public string Convert(string amount);
    }
}
