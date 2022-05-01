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
    public class CurrencyNumericsToWordConverter : ICurrencyNumericsToWordConverter
    {

        public string Convert(string number)
        {
            string[] _ammount = number.Split(',');
            string[] _dollars = _ammount[0].Split(' ');

            // convert dollar section
            StringBuilder _result = ConvertCurrencyUnitToWords(_dollars, Currency.Dollar.ToString());

            // convert cent section
            if (_ammount.Length > 1)
            {
                string[] _cents = new string[] { _ammount[1] };
                _result.Append(" And " + ConvertCurrencyUnitToWords(_cents, Currency.Cent.ToString()));
            }

            return _result.ToString();
        }


        #region HelperMehtods


        private StringBuilder ConvertCurrencyUnitToWords(string[] amount, string currency)
        {
            // validation 
            if (currency == Currency.Cent.ToString() && !Regex.IsMatch(string.Join("", amount), "^[0-9]{1,2}([,][0-9]{1,2})?$"))
            {
                throw new BadRequestException(string.Format(Predefined.Exceptions.NumericalToWord.BadEntry.InvalidRequestedCentsAmount, Predefined.DomainRules.NumericalToWord.DollarsMaxLimit));
            }

            if (!int.TryParse(Regex.Replace(string.Join("", amount), @"t\s+", ""), out int _amountAsInteger))
            {
                throw new BadRequestException(string.Format(Predefined.Exceptions.NumericalToWord.BadEntry.IncorrectRequestFormat));
            }

            if (currency == Currency.Dollar.ToString() && (_amountAsInteger < 0  || _amountAsInteger >= Predefined.DomainRules.NumericalToWord.DollarsMaxLimit))
            {
                throw new BadRequestException(string.Format(Predefined.Exceptions.NumericalToWord.BadEntry.InvalidRequestedDollarsAmount, Predefined.DomainRules.NumericalToWord.DollarsMaxLimit));
            }

            StringBuilder _result = new StringBuilder();

            if (_amountAsInteger == 0)
            {
                return _result.Append(CurrencyNumericsToWord.Dict[_amountAsInteger] + ' ' + currency + 's');
            }
            else if (_amountAsInteger == 1)
            {
                return _result.Append(CurrencyNumericsToWord.Dict[_amountAsInteger] + ' ' + currency);
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
            // validation 
            if (!Regex.IsMatch(block, "^[0-9]{1,3}([ ][0-9]{1,3})?$"))
            {
                throw new BadRequestException(Predefined.Exceptions.NumericalToWord.BadEntry.InvalidRequestedDollarNumberblocksCount);
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
                    _resultText.Append(CurrencyNumericsToWord.Dict[int.Parse(block.Substring(i, 2))].ToString() + ' ');
                }
                else if (actualNumber >= 20 && actualNumber <= 90)
                {
                    _resultText.Insert(0, CurrencyNumericsToWord.Dict[actualNumber] + '-');
                }
                else
                {
                    _resultText.Insert(0, CurrencyNumericsToWord.Dict[actualNumber].ToString() + ' ');
                }
            }

            return blockPosition switch
            {
                (int)NumericBlockPosition.Thousand => _resultText.Append(NumericBlockPosition.Thousand.ToString() + ' '),
                (int)NumericBlockPosition.Million => _resultText.Append(NumericBlockPosition.Million.ToString() + ' '),
                _ => _resultText,
            };
        }

        #endregion

    }
}
