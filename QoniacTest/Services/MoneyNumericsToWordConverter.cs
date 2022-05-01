using QoniacExercise.Domain.Dictionaries;
using QoniacExercise.Domain.Enums;
using QoniacExercise.Domain.Constants;
using QoniacExercise.IServices;
using System;
using System.Text;
using System.Text.RegularExpressions;
using WebApi.Helpers;

namespace QoniacExercise.Service
{
    public class MoneyNumericsToWordConverter : IMoneyNumericsToWordConverter
    {

        public string ConvertDollarsAndCentsNumberToText(string number)
        {
            string[] _ammount = number.Split(',');
            string[] _dollars = _ammount[0].Split(' ');

            // convert dollar section
            StringBuilder _result = ConvertCurrencyUnitToWords(_dollars, Currency.Dolar.ToString());

            // convert cent section
            if (_ammount.Length > 1)
            {
                string[] _cents = new string[] { _ammount[1] };
                _result.Append(" And " + ConvertCurrencyUnitToWords(_cents, Currency.Cent.ToString()));
            }

            return _result.ToString();
        }


        private StringBuilder ConvertCurrencyUnitToWords(string[] amount, string currency)
        {

            if (currency == Currency.Cent.ToString() && !Regex.IsMatch(string.Join("", amount), "^[0-9]{1,2}([,][0-9]{1,2})?$"))
            {
                throw new BadIntryException(string.Format(Predefined.Exceptions.NumericalToWord.BadIntry.InvalidRequestedCentsAmount, Predefined.DomainRules.NumericalToWord.DolarsMaxLimit));
            }

            if (!int.TryParse(Regex.Replace(string.Join("", amount), @"t\s+", ""), out int _amountAsInteger))
            {
                throw new BadIntryException(string.Format(Predefined.Exceptions.NumericalToWord.BadIntry.IncorrectRequestFormat));
            }

            if (currency == Currency.Dolar.ToString() && (_amountAsInteger <= 0  || _amountAsInteger >= Predefined.DomainRules.NumericalToWord.DolarsMaxLimit))
            {
                throw new BadIntryException(string.Format(Predefined.Exceptions.NumericalToWord.BadIntry.InvalidRequestedDollarsAmount, Predefined.DomainRules.NumericalToWord.DolarsMaxLimit));
            }

            StringBuilder _result = new StringBuilder();

            if (_amountAsInteger == 0)
            {
                return _result.Append(NumericalToWord.Dict[_amountAsInteger] + ' ' + currency + 's');
            }
            else if (_amountAsInteger == 1)
            {
                return _result.Append(NumericalToWord.Dict[_amountAsInteger] + ' ' + currency);
            }
            else
            {
                int length = amount.Length - 1;
                for (int i = length; i >= 0; i--)
                {
                    _result = _result.Insert(0, ConvertUnitBlocksToWords(amount[i], length - i));
                }

                return _result.Append(currency + 's');
            }
        }


        private StringBuilder ConvertUnitBlocksToWords(string block, int blockPosition)
        {
            if (!Regex.IsMatch(block, "^[0-9]{1,3}([ ][0-9]{1,3})?$"))
            {
                throw new BadIntryException(Predefined.Exceptions.NumericalToWord.BadIntry.InvalidNumberFormat);
            }

            StringBuilder _resultText = new StringBuilder();

            int _ittorations = block.Length - 1;
            for (int i = _ittorations; i >= 0; i--)
            {
                int actualNumber = int.Parse(block[i].ToString()) * (int)Math.Pow(10, _ittorations - i);

                if (actualNumber is 0)
                {
                    continue;
                }
                else if (actualNumber is 10)
                {
                    _resultText.Clear();
                    _resultText.Append(NumericalToWord.Dict[int.Parse(block.Substring(i, 2))].ToString() + ' ');
                }
                else if (actualNumber >= 20 && actualNumber <= 90)
                {
                    string _numberText = NumericalToWord.Dict[actualNumber];
                    _resultText.Insert(0, _numberText.PadRight(_numberText.Length + 1, '-'));
                }

                else
                {
                    _resultText.Insert(0, NumericalToWord.Dict[actualNumber].ToString() + ' ');
                }
            }

            switch (blockPosition)
            {
                case (int)NumericBlockPosition.Thousand:
                    return _resultText.Append(NumericBlockPosition.Thousand.ToString() + ' ');
                case (int)NumericBlockPosition.Million:
                    return _resultText.Append(NumericBlockPosition.Million.ToString() + ' ');
                default:
                    return _resultText;
            }
        }
    }
}
