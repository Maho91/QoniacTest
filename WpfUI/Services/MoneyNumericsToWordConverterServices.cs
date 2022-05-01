using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WpfUI.IServices;
using WpfUI.Models;

namespace WpfUI.Services
{
    public class MoneyNumericsToWordConverterServices : IMoneyNumericsToWordConverterServices
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string BackendURI = ConfigurationManager.AppSettings["ConverterBackendURI"];

        public async Task<NumericToWordConverterResponseModel> GetNumericToWord(string amount)
        {
            var httpResponseMessage = await client.GetAsync(BackendURI + amount);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<NumericToWordConverterResponseModel>(await httpResponseMessage.Content.ReadAsStringAsync());
            }
            else
            {
                ErrorModel error = JsonConvert.DeserializeObject<ErrorModel>(await httpResponseMessage.Content.ReadAsStringAsync());
                throw new Exception(error.Message);
            }
        }
    }
}
