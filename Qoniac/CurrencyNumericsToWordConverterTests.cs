using NUnit.Framework;
using Qoniac.TestData;
using QoniacExercise.IServices;
using QoniacExercise.Service;
using System.Collections.Generic;
using WebApi.Helpers;
using static QoniacExercise.Domain.Constants.Predefined.Exceptions.NumericalToWord;

namespace Qoniac
{
    public class CurrencyNumericsToWordConverterTests
    {

        private readonly ICurrencyNumericsToWordConverter _currencyNumericsToWordConverter;

        public CurrencyNumericsToWordConverterTests()
        {
            _currencyNumericsToWordConverter = new CurrencyNumericsToWordConverter();
        }

        [Test]
        public void TestSuccessfulconversionOfDifferentTestSamples()
        {
            foreach (KeyValuePair<string, string> item in ValidCurrencyNumericsToWordDictitoary.Dict)
            {
                Assert.AreEqual(item.Value, _currencyNumericsToWordConverter.Convert(item.Key));
            }

        }

        [Test]
        public void TestInvalidFormattedTestSamples()
        {
            foreach (string item in InValidFormatCurrencyNumericsToWordDictitoary.List)
            {
                Assert.Throws<BadEntryException>(() => _currencyNumericsToWordConverter.Convert(item), BadEntry.IncorrectRequestFormat);
            }
        }

        [Test]
        public void TestInvalidRequestedDollarsAmount()
        {
            Assert.Throws<BadEntryException>(() => _currencyNumericsToWordConverter.Convert("1 000 000 000"), BadEntry.InvalidRequestedDollarsAmount);
        }

        [Test]
        public void TestInvalidRequestedCentAmountBetweenOneAndNinetyNine()
        {
            Assert.Throws<BadEntryException>(() => _currencyNumericsToWordConverter.Convert("1,111"), BadEntry.InvalidRequestedCentsAmount);
        }

        [Test]
        public void TestInvalidRequestedDollarNumberblocksCount()
        {
            Assert.Throws<BadEntryException>(() => _currencyNumericsToWordConverter.Convert("1111 1,1"), BadEntry.InvalidRequestedDollarNumberblocksCount);
        }

    }
}