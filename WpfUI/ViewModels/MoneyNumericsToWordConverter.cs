using System;
using System.Windows;
using System.Windows.Input;
using WpfUI.Models;
using WpfUI.MVVMBase;
using WpfUI.Services;

namespace WpfUI.ViewModels
{
    internal class MoneyNumericsToWordConverter : ViewModelBase
    {
        public string Amount { get; set; }
        public ICommand ConvertCommand { get; set; }
        public string Result { get; set; }


        public MoneyNumericsToWordConverter()
        {
            ConvertCommand = new RelayCommand<string>(SelectedStudentDetails);
        }

        private async void SelectedStudentDetails(string numericToWord)
        {
            if (!string.IsNullOrWhiteSpace(numericToWord))
            {
                MoneyNumericsToWordConverterServices _numericsToWordConverterServices = new MoneyNumericsToWordConverterServices();
                try
                {
                    NumericToWordConverterResponseModel ss = await _numericsToWordConverterServices.GetNumericToWord(numericToWord);
                    Result = ss.Result;
                    RaisePropertyChanged("Result");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
