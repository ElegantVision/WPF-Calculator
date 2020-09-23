using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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

namespace NewCalCulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Properties
        public string ValueText { get; set; }
        public string FullExpression { get; set; }
        public string FullExpressionValue { get; set; }
        public long TotalValue { get; set; }

        //used for storing the entered expression (allows for complexed computation)
        DataTable expressiontotaltostring = new DataTable();
        

        //Fields
        long number1 = 0;
        long number2 = 0;
        long newvalue = 0;
        int byamount = 1;
        string operation = "";

        
        public MainWindow()
        {
            InitializeComponent();
        }


        #region ButtonEvents
        #region NumberButtonEvents
        private void btn1_Click(object sender, RoutedEventArgs e)
        {//gets method's name :: Name<>Value<:>String<>Int
            FullExpression += GetValueFromMethodName(MethodInfo.GetCurrentMethod().Name) * byamount + int.Parse(ValueText);
            UpdateExpressionText();
        }


        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            //gets method's name :: Name<>Value<:>String<>Long
            FullExpression += GetValueFromMethodName(MethodInfo.GetCurrentMethod().Name) * byamount + int.Parse(ValueText);
            UpdateExpressionText();

        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {//gets method's name :: Name<>Value<:>String<>Int
            FullExpression += GetValueFromMethodName(MethodInfo.GetCurrentMethod().Name) * byamount + int.Parse(ValueText);
            UpdateExpressionText();

        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {//gets method's name :: Name<>Value<:>String<>Int
            FullExpression += GetValueFromMethodName(MethodInfo.GetCurrentMethod().Name) * byamount + int.Parse(ValueText);
            UpdateExpressionText();

        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {//gets method's name :: Name<>Value<:>String<>Int
            FullExpression += GetValueFromMethodName(MethodInfo.GetCurrentMethod().Name) * byamount + int.Parse(ValueText);
            UpdateExpressionText();

        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {//gets method's name :: Name<>Value<:>String<>Int
            FullExpression += GetValueFromMethodName(MethodInfo.GetCurrentMethod().Name) * byamount + int.Parse(ValueText);
            UpdateExpressionText();

        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {//gets method's name :: Name<>Value<:>String<>Int
            FullExpression += GetValueFromMethodName(MethodInfo.GetCurrentMethod().Name) * byamount + int.Parse(ValueText);
            UpdateExpressionText();

        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {//gets method's name :: Name<>Value<:>String<>Int
            FullExpression += GetValueFromMethodName(MethodInfo.GetCurrentMethod().Name) * byamount + int.Parse(ValueText);
            UpdateExpressionText();

        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {//gets method's name :: Name<>Value<:>String<>Int
            FullExpression += GetValueFromMethodName(MethodInfo.GetCurrentMethod().Name) * byamount + int.Parse(ValueText);
            UpdateExpressionText();

        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {//gets method's name :: Name<>Value<:>String<>Int
            FullExpression += GetValueFromMethodName(MethodInfo.GetCurrentMethod().Name) * byamount + int.Parse(ValueText);
            UpdateExpressionText();

        }
        #endregion

        #region OperationButtonEvents
        private void btnplus_Click(object sender, RoutedEventArgs e)
        {
            FullExpression += " + ";
            UpdateExpressionText();
        }

        private void btnminus_Click(object sender, RoutedEventArgs e)
        {
            FullExpression += " - ";
            UpdateExpressionText();
        }

        private void btnmultiply_Click(object sender, RoutedEventArgs e)
        {
            FullExpression += " * ";
            UpdateExpressionText();
        }

        private void btndivide_Click(object sender, RoutedEventArgs e)
        {
            FullExpression += " / ";
            UpdateExpressionText();
        }

        private void btnequal_Click(object sender, RoutedEventArgs e)
        {//begin process of expression making sure digits are at end of string :: and computing is correct
            if (CalculateFullExpression())
            {
                FullExpression = "";
            }
            
            UpdateExpressionText();
        }

        private void btnclearentry_Click(object sender, RoutedEventArgs e)
        {//removes the last digit (entry)
            if (FullExpression.Length > 0)
            {
                switch (CheckFullExpressionPattern(FullExpression))
                {//digit is at end
                    case 1:
                        {
                            FullExpression = FullExpression.Remove(FullExpression.Length - 1);
                            UpdateExpressionText();
                        }
                        break;

                    case 2:
                        {//symbol is at the end
                            FullExpression = FullExpression.Remove(FullExpression.Length - 3, 3);
                            UpdateExpressionText();
                        }
                        break;
                }
            }
            

        }

        private void btnclear_Click(object sender, RoutedEventArgs e)
        {//clears full expression
            FullExpression = FullExpression.Remove(0, FullExpression.Length);
            UpdateExpressionText();
        }

        private void btndecimal_Click(object sender, RoutedEventArgs e)
        {
            FullExpression += ".";
            UpdateExpressionText();
        }
        #endregion
        #endregion



        #region Methods

        //adding comma
        private void CheckForAddingComma()
        {//checking if we can place a comma into the expression

            Debug.WriteLine(FullExpression[0]);
        }


        private string ComputeUserInputValues(string tocompute)
        {//calculate user's expression into total then return string of value
            return expressiontotaltostring.Compute(tocompute, string.Empty).ToString();            
        }

        private bool CalculateFullExpression()
        {
            bool Computed = false;
            switch (CheckFullExpressionPattern(FullExpression))
            {
                case 1:
                    {
                        //expression can compute :: ends with digit (add the allowing of close bracket at end)
                        Debug.WriteLine("digits at end");
                        txtdisplayvalue.Text = ComputeUserInputValues(FullExpression);
                        Computed = true;
                        
                    }
                    break;

                case 2:
                    {
                        //operator is at the end of expression :: can not compute
                        Debug.WriteLine("operator at end");
                        Computed = false;
                    }
                    break;

                default:
                    {

                    }break;
            }

            return Computed;
        }

        private int CheckFullExpressionPattern(string ExpressionToMatch)
        {
            int matchresult = -1;//an error is somewhere

            if (Regex.IsMatch(ExpressionToMatch, @"[0-9]+$"))
            {
                matchresult = 1;//ends with value (digit)
            }
            else if (Regex.IsMatch(ExpressionToMatch, @"[/*\-+.]\s+$"))
            {
                matchresult = 2;//ends with space_symbol_space
            }

            return matchresult;
        }

        private void UpdateExpressionText()
        {
            TxtDisplay.Text = FullExpression;
            Debug.WriteLine(FullExpression);
        }

        //used for getting the value of button pressed from the name        
        private long GetValueFromMethodName(string methodname)
        {
            
            //pulling the digit from method's name
            var result = from mn in methodname
                         where mn == '9' || mn == '8' || mn == '7' ||
                               mn == '6' || mn == '5' || mn == '4' ||
                               mn == '3' || mn == '2' || mn == '1' || mn == '0'
                         select mn;

            //setting value text's value
            foreach (char str in result)
            {
                ValueText = str.ToString();
            }

            //this is returning the value of newvalue and continuing the expression * 10 + button's name to value
            return newvalue;
        }





        #endregion

        
    }

    
}
