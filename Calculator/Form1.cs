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
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
           
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
        private string[] getElements()
        {
            string[] element = this.resultBox.Text.Split(operandChar);
            return element;

        }
        private void amendForm(string str, bool amend = true)
        {
            if (amend)
            {
                this.resultBox.Text = str;
            }
            else this.resultBox.Text += str;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.resultBox.Text += "0";

           
            divideButton.TabStop = false;
            increaseButton.TabStop = false;
            multiplyButton.TabStop = false;
            decreaseButton.TabStop = false;
            zeroButton.TabStop = false;
            oneButton.TabStop = false;
            twoButton.TabStop = false;
            threeButton.TabStop = false;
            fourButton.TabStop = false;
            fiveButton.TabStop = false;
            sixButton.TabStop = false;
            sevenButton.TabStop = false;
            eightButton.TabStop = false;
            nineButton.TabStop = false;
            sqrtButton.TabStop = false;
            equalSign.TabStop = false;
            percentButton.TabStop = false;
            decimalPoint.TabStop = false;
            resultBox.TabStop = false;
            backSpaceButton.TabStop = false;
            clearButton.TabStop = false;
            sqrtButton.TabStop = false;
            changeSign.TabStop = false;



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
                    //string[] elements = this.resultBox.Text.Split(operandChar);
                    int offset = 0;
                    string multiplier = "";
                    getElementSign(ref offset, ref multiplier, getElements().Length);
                    double left = double.Parse(multiplier + getElements()[0 + offset]);
                    double right = double.Parse(getElements()[1 + offset]);
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

            if (!zero1 && (this.resultBox.Text[0] != '0'))
            {
                amendForm("0", false);
            }


        }



        //detects if key is pressed and amends form

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.NumPad0)
            {
                zeroButton.PerformClick();
            }
            if (e.KeyCode == Keys.NumPad1)
            {
                oneButton.PerformClick();
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                twoButton.PerformClick();
            }
            if (e.KeyCode == Keys.NumPad3)
            {
                threeButton.PerformClick();
            }
            if (e.KeyCode == Keys.NumPad4)
            {
                fourButton.PerformClick();
            }
            if (e.KeyCode == Keys.NumPad5)
            {
                fiveButton.PerformClick();
            }
            if (e.KeyCode == Keys.NumPad6)
            {
                sixButton.PerformClick();
            }
            if (e.KeyCode == Keys.NumPad7)
            {
                sevenButton.PerformClick();
            }
            if (e.KeyCode == Keys.NumPad8)
            {
                eightButton.PerformClick();
            }
            if (e.KeyCode == Keys.NumPad9)
            {
                nineButton.PerformClick();
            }
            if (e.KeyCode == Keys.Multiply)
            {
                multiplyButton.PerformClick();
            }
            if (e.KeyCode == Keys.Divide)
            {
                divideButton.PerformClick();
            }
            if (e.KeyCode == Keys.Add)
            {
                increaseButton.PerformClick();
            }
            if (e.KeyCode == Keys.Subtract)
            {
                decreaseButton.PerformClick();
            }
            if (e.KeyCode == Keys.Enter)
            {
               equalSign.PerformClick();
            }
            if (e.KeyCode == Keys.Delete)
            {
                clearButton.PerformClick();
            }
            if (e.KeyCode == Keys.Decimal)
            {
                decimalPoint.PerformClick();
            }
            if (e.KeyCode == Keys.Back)
            {
                backSpaceButton.PerformClick();
            }

        }

            private void oneButton_Click(object sender, EventArgs e)
        {
            if (this.resultBox.Text.StartsWith("0") && this.resultBox.Text.Length == 1)
            {
                amendForm("1");
                decimal1 = true;
                //decimal2 = false;
            }
            else
            {
                decimal1 = true;
                //decimal2 = false;
                amendForm("1", false);
            }
            //zero1 = true;
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            if (this.resultBox.Text.StartsWith("0") && this.resultBox.Text.Length == 1)
            {
                amendForm("2");
            }
            else amendForm("2", false);
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            if (this.resultBox.Text.StartsWith("0") && this.resultBox.Text.Length == 1)
            {
                amendForm("3");
            }
            else amendForm("3", false);
        }

        private void FourButton_Click_1(object sender, EventArgs e)
        {
            if (this.resultBox.Text.StartsWith("0") && this.resultBox.Text.Length == 1)
            {
                amendForm("4");
            }
            else amendForm("4", false);
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            if (this.resultBox.Text.StartsWith("0") && this.resultBox.Text.Length == 1)
            {
                amendForm("5");
            }
            else amendForm("5", false);
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            if (this.resultBox.Text.StartsWith("0") && this.resultBox.Text.Length == 1)
            {
                amendForm("6");
            }
            else amendForm("6", false);
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            if (this.resultBox.Text.StartsWith("0") && this.resultBox.Text.Length == 1)
            {
                amendForm("7");
            }
            else amendForm("7", false);
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            if (this.resultBox.Text.StartsWith("0") && this.resultBox.Text.Length == 1)
            {
                amendForm("8");
            }
            else amendForm("8", false);
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            if (this.resultBox.Text.StartsWith("0") && this.resultBox.Text.Length == 1)
            {
                amendForm("9");
            }
            else amendForm("9", false);
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
                amendForm("0", false);
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
            if (canSetBool) amendForm(".", false);


        }

        private void percentButton_Click(object sender, EventArgs e)
        {
            double percent = 0;
            string[] element = this.resultBox.Text.Split(operandChar);
            if (getElements().Length == 1)
            {
                /*
                As normal calculator (MS calculator) is preventing as calculate % from 1 number and return is 0
                we will implement the same feature here.
                If we in future want to change that option. Function bellow is working properly - x%=x/100
                */
                
                percent = (((double.Parse(element[0]) / 100)));
                this.resultBox.Text = percent.ToString();
               

                amendForm("0", false);
            }
            if (getElements().Length > 1)
            {
                /*
                When calculation with % is done for last element in field we want 
                that calculator showing as full result what will be
                Like: 2+200%=4
                */
                percent = double.Parse(getElements()[getElements().Length - 1]) / 100;
                amendForm(this.resultBox.Text.Substring(0, this.resultBox.Text.LastIndexOf(operandChar) + 1), false);
                amendForm(percent.ToString(), true);
                getResult();
            }
        }

        private void sqrtButton_Click(object sender, EventArgs e)
        {
            double sqrt = 0;
            //string[] element = this.resultBox.Text.Split(operandChar);
            if (getElements().Length == 1)
            {
                sqrt = Math.Sqrt(double.Parse(getElements()[0]));
                amendForm(sqrt.ToString(), true);
                // this.resultBox.Text = sqrt.ToString();
            }
            if (getElements().Length > 1)
            {
                sqrt = Math.Sqrt(double.Parse(getElements()[getElements().Length - 1]));
                amendForm(this.resultBox.Text.Substring(0, this.resultBox.Text.LastIndexOf(operandChar) + 1), true);

                amendForm(sqrt.ToString(), false);
                //this.resultBox.Text += sqrt.ToString();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            resetForm();
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            insertOperand('/');
            zero1 = true;
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
            //string[] element = this.resultBox.Text.Split(operandChar);
            if (getElements().Length == 1)
            {
                double convertedNum = double.Parse(getElements()[0]) * -1;
                amendForm(convertedNum.ToString(), true);

                //  this.resultBox.Text = convertedNum.ToString();
            }
            else return;
        }

    }
}
