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
using System.Data;

namespace WPF_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly string CLEAR = "C";
        readonly string RESULT = "=";
        readonly string ZERO = "0";

        public MainWindow()
        {
            InitializeComponent();
            btnNumZero.Click += InputButton_Click;
            btnNumOne.Click += InputButton_Click;
            btnNumTwo.Click += InputButton_Click;
            btnNumThree.Click += InputButton_Click;
            btnNumFour.Click += InputButton_Click;
            btnNumFive.Click += InputButton_Click;
            btnNumSix.Click += InputButton_Click;
            btnNumSeven.Click += InputButton_Click;
            btnNumEight.Click += InputButton_Click;
            btnNumNine.Click += InputButton_Click;
            btn0pMinus.Click += InputButton_Click;
            btn0pPlus.Click += InputButton_Click;
            btn0pDivi.Click += InputButton_Click;
            btn0pMulti.Click += InputButton_Click;
        }
        private void InputButton_Click(object sender, RoutedEventArgs e)
        {
            Button pressedButton = (Button)sender;
            string buttonContent = pressedButton.Content.ToString();

            if(buttonContent.Equals(CLEAR))
            {
                textblockContent.Text = ZERO;
                return;
            }
            else if(buttonContent.Equals(RESULT))
            {
                DataTable dataTable = new DataTable();
                try
                {
                    string result = dataTable
                        .Compute(textblockContent.Text, null)
                        .ToString();
                    textblockContent.Text = result;
                }
                catch(SyntaxErrorException exc)
                {
                    MessageBox.Show(exc.Message);
                    textblockContent.Text = ZERO;
                }
                return;
            }
            string calculatorString = textblockContent.Text;

            calculatorString = calculatorString.TrimStart('0');
            calculatorString += buttonContent;
            textblockContent.Text = calculatorString;
        } 
    }
}
