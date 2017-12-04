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

namespace Calculator
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

        private const string ERR_MESSAGE = "Error!";

        private void GridButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            string value = btn.Content.ToString();
            switch (value)
            {
                case "C":
                    ExpressionTextBox.Text = "0";
                    break;

                case "=":
                    string curExpression = ExpressionTextBox.Text;
                    try
                    {
                        NCalc.Expression expression = new NCalc.Expression(ExpressionTextBox.Text);
                        string expressionValue = expression.Evaluate().ToString();
                        ExpressionTextBox.Text = expressionValue;
                        if (!curExpression.Equals(expressionValue))
                        {
                            HistoryTextBox.AppendText(curExpression + "=" + expressionValue + "\n");
                        }
                    }
                    catch
                    {
                        ExpressionTextBox.Text = ERR_MESSAGE;
                    }
                    break;

                case "Clear history":
                    HistoryTextBox.Text = "";
                    break;
         
                default:
                    if (ExpressionTextBox.Text.Equals(ERR_MESSAGE))
                        ExpressionTextBox.Text = "0";
                    ExpressionTextBox.Text = ExpressionTextBox.Text.TrimStart('0') + value;
                    break;
            }

        }
    }
}
