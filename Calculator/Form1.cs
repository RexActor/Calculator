using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        //bool implemented;
        bool decimal1; //true -> blocks you to add decimal point
        bool decimal2; //true -> blocks you to add decimal point
        bool zero1;
        bool zero2; //TODO:need to implement
        bool operand;
        char operandChar;
        bool canSetBool; //false --> ignores line  --> if (canSetBool) this.resultBox.Text += "."; <---

        public Form1()
        {
            /*
            disables oportunity for End-User to resize windows form
            */
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            /*
            Adding start position for form when launched.
            Hate to move it from Mon1 to Mon2

            */
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void resetForm()
        {
            this.resultBox.Text = "0";
            decimal1 = false;
            decimal2 = false;
            operand = false;
            zero1 = false;
            zero2 = false;
            operandChar = '\0';
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.resultBox.Text += "0";

        }

        private void getElementSign(ref int offset, ref string multiplier, int getElementLength)
        {
            multiplier = "";
            offset = 0;
            if ((this.resultBox.Text[0] == '-') && (getElementLength == 3))
            {
                offset = 1;
                multiplier = "-";
            }
        }

        private void getResult()
        {
            if (this.resultBox.Text.Length == 0) return;
            char lastElement = this.resultBox.Text[this.resultBox.Text.Length - 1];
            if ((operand) && (lastElement != '*') && (lastElement != '+') && (lastElement != '/') && (lastElement != '-'))
            {
                string newResult = "";
                try
                {
                    /*
                    TODO: 
                    */
                    string[] elements = this.resultBox.Text.Split(operandChar);
                    int offset = 0;
                    string multiplier = "";
                    getElementSign(ref offset, ref multiplier, elements.Length);
                    double left = double.Parse(multiplier + elements[0 + offset]);
                    double right = double.Parse(elements[1 + offset]);
                    switch (operandChar)
                    {
                        case '+':
                            newResult = Convert.ToString(left + right);
                            break;
                        case '*':
                            newResult = Convert.ToString(left * right);
                            break;
                        case '/':
                            newResult = Convert.ToString(left / right);
                            break;
                        case '-':
                            newResult = Convert.ToString(left - right);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                resetForm();
                this.resultBox.Text = newResult;
                decimal1 = false;
                if (newResult.Contains("."))
                {
                    decimal1 = true;
                    decimal2 = true;
                }
            }
        }

        private void insertOperand(char whichOperand)
        {
            if (operand) getResult();
            if (this.resultBox.Text.Length > 0)
            {
                switch (this.resultBox.Text[this.resultBox.Text.Length - 1])
                {
                    //case '.':
                    //  break;
                    case '+':
                    case '*':
                    case '-':
                    case '/':
                        operand = true;
                        decimal1 = true;
                        decimal2 = false;
                        operandChar = whichOperand;
                        this.resultBox.Text = this.resultBox.Text.Substring(0, this.resultBox.Text.Length - 1) + operandChar;
                        break;
                    default:
                        operand = true;
                        decimal1 = true;
                        decimal2 = false;
                        operandChar = whichOperand;
                        this.resultBox.Text += whichOperand;
                        break;
                }
            }
        }

        private void equalSign_Click(object sender, EventArgs e)
        {
            getResult();
        }

        private void zero_Click(object sender, EventArgs e)
        {
            zero1 = false;
            zero2 = true;
            /*
            */
            if (!zero1 && (this.resultBox.Text[0] != '0') || (this.resultBox.Text.Contains('.')))
            {
                this.resultBox.Text += "0";
                zero1 = true;
                zero2 = true;
            }

            if ((this.resultBox.Text.Last() == '/'))
            {
                this.resultBox.Text += "0.";
                zero1 = false;
                // zero2 = false;
            }

        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            if (this.resultBox.Text.StartsWith("0") && this.resultBox.Text.Length == 1)
            {
                this.resultBox.Text = "1";
                decimal1 = true;
                //decimal2 = false;
            }
            else
            {
                decimal1 = true;
                //decimal2 = false;
                this.resultBox.Text += "1";
            }
            //zero1 = true;
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            if (this.resultBox.Text.StartsWith("0") && this.resultBox.Text.Length == 1)
            {
                this.resultBox.Text = "2";
            }
            else this.resultBox.Text += "2";
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            if (this.resultBox.Text.StartsWith("0") && this.resultBox.Text.Length == 1)
            {
                this.resultBox.Text = "3";
            }

            else this.resultBox.Text += "3";
        }

        private void FourButton_Click_1(object sender, EventArgs e)
        {
            if (this.resultBox.Text.StartsWith("0") && this.resultBox.Text.Length == 1)
            {
                this.resultBox.Text = "4";
            }

            else this.resultBox.Text += "4";
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            if (this.resultBox.Text.StartsWith("0") && this.resultBox.Text.Length == 1)
            {
                this.resultBox.Text = "5";
            }

            else this.resultBox.Text += "5";
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            if (this.resultBox.Text.StartsWith("0") && this.resultBox.Text.Length == 1)
            {
                this.resultBox.Text = "6";
            }

            else this.resultBox.Text += "6";
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            if (this.resultBox.Text.StartsWith("0") && this.resultBox.Text.Length == 1)
            {
                this.resultBox.Text = "7";
            }
            else this.resultBox.Text += "7";
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            if (this.resultBox.Text.StartsWith("0") && this.resultBox.Text.Length == 1)
            {
                this.resultBox.Text = "8";
            }
            else this.resultBox.Text += "8";
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            if (this.resultBox.Text.StartsWith("0") && this.resultBox.Text.Length == 1)
            {
                this.resultBox.Text = "9";
            }
            else this.resultBox.Text += "9";
        }

        private void backSpaceButton_Click(object sender, EventArgs e)
        {

            if (this.resultBox.Text.Length > 0)
            {
                // MessageBox.Show(this.resultBox.Text[this.resultBox.Text.Length - 1].ToString());
                if (this.resultBox.Text[this.resultBox.Text.Length - 1] == '.')
                {
                    decimal1 = false;
                    decimal2 = false;
                }
                if (this.resultBox.Text[this.resultBox.Text.Length - 1] == operandChar)
                {
                    return;
                }
                this.resultBox.Text = this.resultBox.Text.Substring(0, this.resultBox.Text.Length - 1);
            }

            if (this.resultBox.Text.Length == 0)
            {
                this.resultBox.Text = "0";
                zero1 = true;
                decimal1 = false;
                decimal2 = false;
                canSetBool = true;
            }
        }

        private void decimalPoint_Click(object sender, EventArgs e)
        {
            canSetBool = false;


            if (!decimal1)
            {

                decimal1 = true;
                decimal2 = true;
                canSetBool = true;
            }
            if (!decimal2)
            {

                decimal1 = true;
                decimal2 = true;
                canSetBool = true;
            }


            // canSet(canSetBool);
            if (canSetBool) this.resultBox.Text += ".";


        }

        private void percentButton_Click(object sender, EventArgs e)
        {
            double percent = 0;
            string[] element = this.resultBox.Text.Split(operandChar);
            if (element.Length == 1)
            {
                /*
                As normal calculator (MS calculator) is preventing as calculate % from 1 number and return is 0
                we will implement the same feature here.
                If we in future want to change that option. Function bellow is working properly - x%=x/100
                */
                /*
                percent = (((double.Parse(element[0]) / 100)));
                this.resultBox.Text = percent.ToString();
                */

                this.resultBox.Text = "0";
            }
            if (element.Length > 1)
            {
                /*
                When calculation with % is done for last element in field we want 
                that calculator showing as full result what will be
                Like: 2+200%=4
                */
                percent = double.Parse(element[element.Length - 1]) / 100;
                this.resultBox.Text = this.resultBox.Text.Substring(0, this.resultBox.Text.LastIndexOf(operandChar) + 1);
                this.resultBox.Text += percent.ToString();
                getResult();
            }
        }

        private void sqrtButton_Click(object sender, EventArgs e)
        {
            double sqrt = 0;
            string[] element = this.resultBox.Text.Split(operandChar);
            if (element.Length == 1)
            {
                sqrt = Math.Sqrt(double.Parse(element[0]));
                this.resultBox.Text = sqrt.ToString();
            }
            if (element.Length > 1)
            {
                sqrt = Math.Sqrt(double.Parse(element[element.Length - 1]));
                this.resultBox.Text = this.resultBox.Text.Substring(0, this.resultBox.Text.LastIndexOf(operandChar) + 1);
                this.resultBox.Text += sqrt.ToString();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            resetForm();
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            insertOperand('/');
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            insertOperand('*');
        }

        private void decreaseButton_Click(object sender, EventArgs e)
        {
            insertOperand('-');
        }

        private void increaseButton_Click(object sender, EventArgs e)
        {
            insertOperand('+');
        }

        private void changeSign_Click(object sender, EventArgs e)
        {
            /*
            change sign on oposit in front of the element
            */
            string[] element = this.resultBox.Text.Split(operandChar);

            if ((element.Length == 1) && !this.resultBox.Text.StartsWith("-"))
            {
                this.resultBox.Text = this.resultBox.Text.Replace(this.resultBox.Text[0], '-') + element[0];

            }
            else if (element.Length == 1 && this.resultBox.Text.StartsWith("-"))
            {
                this.resultBox.Text = this.resultBox.Text.Replace(this.resultBox.Text[0], '+');

            }



        }
    }
}
