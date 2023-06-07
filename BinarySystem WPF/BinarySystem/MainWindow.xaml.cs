using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace BinarySystem
{
    public partial class MainWindow : Window
    {
        private bool _isDecimalToBinary = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RequestTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            Regex fromZeroToOne = new Regex("^[0-1]+");

            if (!Char.IsDigit(e.Text, 0) && _isDecimalToBinary)
                e.Handled = true;
            else if (!_isDecimalToBinary && !fromZeroToOne.IsMatch(e.Text))
                e.Handled = true;
        }

        private void ChangeConvertButton_Click(object sender, RoutedEventArgs e)
        {
            _isDecimalToBinary = !_isDecimalToBinary;

            if (!_isDecimalToBinary)
            {
                FirstTextBox.Text = "From binary";
                SecondTextBox.Text = "to decimal";
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResponseTextBox.Clear();
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(ResponseTextBox.Text);
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isDecimalToBinary)
            {
                if (long.TryParse(RequestTextBox.Text, out var number))
                    ResponseTextBox.Text = Convert.ToString(number, 2);
            }
            else
            {
                string binNum = RequestTextBox.Text;
                var exponent = 0;
                var result = 0u;
                for (var i = binNum.Length - 1; i >= 0; i--)
                {
                    if (binNum[i] == '1')
                        result += Convert.ToUInt32(Math.Pow(2, exponent));
                    exponent++;
                }
                ResponseTextBox.Text = result.ToString();
            }
        }
    }
}