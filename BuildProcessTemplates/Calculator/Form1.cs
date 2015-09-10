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
        bool zero2;
        bool operand;
        char operandChar;
        bool canSetBool; //false --> ignores line  --> if (canSetBool) this.resultBox.Text += "."; <---

        public Form1()
        {
            /*
            disables oportunity for End-User to resize windows form
            */
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // this.resultBox.Text.PadLeft(1);


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

        private string getElementSign(ref string str)
        {
            string el = "";
            if (this.resultBox.Text[0] == '-')
            {
                el = "-";
                str = str.Substring(1);

            }


            return el;

        }

        private void getResult()
        {
            if (this.resultBox.Text.Length == 0) return;

            char lastElement = this.resultBox.Text[this.resultBox.Text.Length - 1];

            if ((operand) && (lastElement != '*') && (lastElement != '+') && (lastElement != '/') && (lastElement != '-'))
            {
                //split string in array by operand sign + - * /

                string x = this.resultBox.Text;
                string sign = getElementSign(ref x);
                string[] elements = this.resultBox.Text.Split(operandChar);

                // MessageBox.Show(Convert.ToString(double.Parse(sign + elements[0])).ToString());

                string newResult = "";

                try
                {
                    switch (operandChar)
                    {

                        case '+':
                            newResult = Convert.ToString(double.Parse(elements[0]) + double.Parse(elements[1]));
                            break;
                        case '*':
                            newResult = Convert.ToString(double.Parse(elements[0]) * double.Parse(elements[1]));
                            break;
                        case '/':
                            newResult = Convert.ToString(double.Parse(elements[0]) / double.Parse(elements[1]));
                            break;
                        case '-':
                            newResult = Convert.ToString(double.Parse(elements[0]) - double.Parse(elements[1]));
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {

                    //newResult = "error";

                    //MessageBox.Show(newResult.Length.ToString());
                     MessageBox.Show(ex.ToString());
                   
                    //Console.WriteLine(e);
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

            // MessageBox.Show("Result");
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

        //check if numpad key is pressed 

           private void KeyPress(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.NumPad0)
            {
                this.resultBox.Text = "0";

            }
        }

        private void equalSign_Click(object sender, EventArgs e)
        {
            getResult();

            // MessageBox.Show("This function is not implemented yet!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            // MessageBox.Show(this.resultBox.Text.Last().ToString());
            if ((this.resultBox.Text.Last() == '/'))
            {
                this.resultBox.Text += "0.";
                zero1 = false;
                // zero2 = false;
            }


            // canSet(canSetBool);
            //  if (canSetBool) this.resultBox.Text += ".";
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


                this.resultBox.Text = this.resultBox.Text.Substring(0, this.resultBox.Text.Length - 1);


            }
            //MessageBox.Show(canSet.ToString());

            if (this.resultBox.Text.Length == 0)
            {
                this.resultBox.Text = "0";
                zero1 = true;
                decimal1 = false;
                decimal2 = false;
                canSetBool = true;


            }



            //MessageBox.Show("This function is not implemented yet!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            MessageBox.Show("This function is not implemented yet!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sqrtButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This function is not implemented yet!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            //this.resultBox.Text = "0";
            resetForm();
            // MessageBox.Show("This function is not implemented yet!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            insertOperand('/');
            // MessageBox.Show("This function is not implemented yet!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            insertOperand('*');
            // MessageBox.Show("This function is not implemented yet!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void decreaseButton_Click(object sender, EventArgs e)
        {
            insertOperand('-');
            //MessageBox.Show("This function is not implemented yet!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void increaseButton_Click(object sender, EventArgs e)
        {
            insertOperand('+');
            //MessageBox.Show("This function is not implemented yet!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
