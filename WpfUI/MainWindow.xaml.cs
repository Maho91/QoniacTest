using System;
using System.Windows;
using WpfUI.Services;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Convert_Click(object sender, RoutedEventArgs e)
        {

            MoneyNumericsToWordConverterServices _numericsToWordConverterServices = new MoneyNumericsToWordConverterServices();
            try
            {
                Models.NumericToWordConverterResponseModel ss = await _numericsToWordConverterServices.GetNumericToWord(Amount.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
