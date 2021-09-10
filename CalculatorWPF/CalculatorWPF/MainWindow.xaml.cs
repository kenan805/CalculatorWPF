using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double number = 0;
        string operation = "";
        bool isOperationCh = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Result.Text == "0" || isOperationCh)
            {
                tb_Result.Text = tb_Result.Text.Remove(0);
            }
            if (sender is Button btn)
            {
                tb_Result.Text += btn.Content;
                isOperationCh = false;

            }
        }

        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                if (tb_Result.Text == "0")
                    tb_Result.Text = "0";
                else
                    tb_Result.Text += btn.Content;
            }
        }

        private void Button_ClearAll(object sender, RoutedEventArgs e)
        {
            tb_Result.Text = "0";
            number = 0;
            operation = "";
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            if (tb_Result.Text == "0")
                tb_Result.Text = "0";
            else
            {
                if (tb_Result.Text.Length == 1)
                    tb_Result.Text = "0";
                else if (tb_Result.Text.Length >= 10)
                    tb_Result.Text = tb_Result.Text.Remove(9);
                else
                    tb_Result.Text = tb_Result.Text.Remove(tb_Result.Text.Length - 1);
            }
        }

        private void Btn_Pos_Neg_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Result.Text == "0")
            {
                tb_Result.Text = "0";
            }
            else
            {
                if (tb_Result.Text.Length < 10 && tb_Result.Text[0] != '-')
                {
                    tb_Result.Text = "-" + tb_Result.Text;
                }
                else if (tb_Result.Text.Length < 10 && tb_Result.Text[0] == '-')
                {
                    tb_Result.Text = tb_Result.Text.Remove(0, 1);
                }
            }
        }

        private void Button_Comma_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Result.Text.Count(c => c == ',') != 1)
            {
                tb_Result.Text += ",";
            }
        }

        private void Button_Operation_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                operation = btn.Content.ToString();
                number = double.Parse(tb_Result.Text);
                isOperationCh = true;
            }
        }
        private void Button_Equal_Click(object sender, RoutedEventArgs e)
        {
            isOperationCh = true;
            switch (operation)
            {
                case "+":
                    {
                        tb_Result.Text = (number + double.Parse(tb_Result.Text)).ToString();
                        break;
                    }
                case "−":
                    {
                        tb_Result.Text = (number - double.Parse(tb_Result.Text)).ToString();
                        break;
                    }
                case "×":
                    {
                        tb_Result.Text = (number * double.Parse(tb_Result.Text)).ToString();
                        break;
                    }
                case "÷":
                    {
                        tb_Result.Text = (number / double.Parse(tb_Result.Text)).ToString();
                        break;
                    }
                default:
                    break;
            }
            number = double.Parse(tb_Result.Text);
        }

        private void Button_Power_Click(object sender, RoutedEventArgs e) => tb_Result.Text = Math.Pow(double.Parse(tb_Result.Text), 2).ToString();

        private void Button_Sqrt_Click(object sender, RoutedEventArgs e) => tb_Result.Text = Math.Sqrt(double.Parse(tb_Result.Text)).ToString();

        private void Button_1DivideNum_Click(object sender, RoutedEventArgs e) => tb_Result.Text = (1 / double.Parse(tb_Result.Text)).ToString();

    }
}
