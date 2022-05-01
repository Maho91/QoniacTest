using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Models;

namespace WpfUI.IServices
{
    public interface IMoneyNumericsToWordConverterServices
    {
        Task<NumericToWordConverterResponseModel> GetNumericToWord(string amount);
    }
}
