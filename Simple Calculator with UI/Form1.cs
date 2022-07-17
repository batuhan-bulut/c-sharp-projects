using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Calculator_with_UI
{

    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }
       
        int result;
        int job;
        int number1;
        private bool isJobDone = false;
        private void Num1_Click(object sender, EventArgs e)
        {
            NumberBox1.Text = NumberBox1.Text + Num1.Text;
            if (isJobDone)
            {
                NumberBox1.Text = null;
            }
        }
        private void Num2_Click(object sender, EventArgs e)
        {
            NumberBox1.Text = NumberBox1.Text + Num2.Text;
        }
        private void Num3_Click(object sender, EventArgs e)
        {
            NumberBox1.Text = NumberBox1.Text + Num3.Text;
        }
        private void Num4_Click(object sender, EventArgs e)
        {
            NumberBox1.Text = NumberBox1.Text + Num4.Text;
        }
        private void Num5_Click(object sender, EventArgs e)
        {
            NumberBox1.Text = NumberBox1.Text + Num5.Text;
        }
        private void Num6_Click(object sender, EventArgs e)
        {
            NumberBox1.Text = NumberBox1.Text + Num6.Text;
        }
        private void Num7_Click(object sender, EventArgs e)
        {
            NumberBox1.Text = NumberBox1.Text + Num7.Text;
        }
        private void Num8_Click(object sender, EventArgs e)
        {
            NumberBox1.Text = NumberBox1.Text + Num8.Text;
        }
        private void Num9_Click(object sender, EventArgs e)
        {
            NumberBox1.Text = NumberBox1.Text + Num9.Text;
        }
        private void Num0_Click(object sender, EventArgs e)
        {
            NumberBox1.Text = NumberBox1.Text + Num0.Text;
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            job = 0;
            jobLabel.Text = "It's Plus";
            if (!(NumberBox1.Text == "")) { number1 = Convert.ToInt32(NumberBox1.Text); }
            textBoxNumber.Text = Convert.ToString(number1);
            NumberBox1.Text = null;
            if (job == 0)
            {
                Plus.BackColor = Color.Aqua;
                Minus.BackColor = Color.DimGray;
                Multiply.BackColor = Color.DimGray;
                Divide.BackColor = Color.DimGray;
            }
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            job = 1;
            jobLabel.Text = "It's Minus";
            if (!(NumberBox1.Text == "")) { number1 = Convert.ToInt32(NumberBox1.Text); }
            textBoxNumber.Text = Convert.ToString(number1);
            NumberBox1.Text = null;
            if (job == 1)
            {
                Plus.BackColor = Color.DimGray;
                Minus.BackColor = Color.Aqua;
                Multiply.BackColor = Color.DimGray;
                Divide.BackColor = Color.DimGray;
            }
        }

        private void Multiply_Click(object sender, EventArgs e)
        {
            job = 2;
            jobLabel.Text = "It's Multiply";
            if (!(NumberBox1.Text == "")) { number1 = Convert.ToInt32(NumberBox1.Text);
            }
            else { }
            textBoxNumber.Text = Convert.ToString(number1);
            NumberBox1.Text = null;
            if (job == 2)
            {
                Plus.BackColor = Color.DimGray;
                Minus.BackColor = Color.DimGray;
                Multiply.BackColor = Color.Aqua;
                Divide.BackColor = Color.DimGray;
            }
        }

        private void Divide_Click(object sender, EventArgs e)
        {
            job = 3;
            jobLabel.Text = "It's Divide";
            if (!(NumberBox1.Text == "")) { number1 = Convert.ToInt32(NumberBox1.Text); }
            textBoxNumber.Text = Convert.ToString(number1);
            NumberBox1.Text = null;
            if (job == 3)
            {
                Plus.BackColor = Color.DimGray;
                Minus.BackColor = Color.DimGray;
                Multiply.BackColor = Color.DimGray;
                Divide.BackColor = Color.Aqua;
            }
        }
        public void Calc()
        {
            switch (job)
            {
                case 0:
                    Calc_Plus();
                    break;
                case 1:
                    Calc_Minus();
                    break;
                case 2:
                    Calc_Multiply();
                    break;
                case 3:
                    Calc_Divide();
                    break;
            }
        }
        private void Equal_Click(object sender, EventArgs e)
        {
            try
            {
                Calc();
                textBoxNumber.Text = Convert.ToString(result);
                if (textBoxNumber.Text == "")
                {
                    isJobDone = true;
                };
            }
            catch (Exception)
            {
            }
            
        }
        public void Calc_Plus()
        {
            int x = Convert.ToInt32(NumberBox1.Text);
            textBoxNumber.Text = Convert.ToString(number1);
            result = x + number1;
            NumberBox1.Text = Convert.ToString(result);
        }
        public void Calc_Minus()
        {
            textBoxNumber.Text = Convert.ToString(number1);
            int x = Convert.ToInt32(NumberBox1.Text);
            result = number1 - x;
            NumberBox1.Text = Convert.ToString(result);
        }
        public void Calc_Multiply()
        {
            textBoxNumber.Text = Convert.ToString(number1);
            int x = Convert.ToInt32(NumberBox1.Text);
            result = x * number1;
            NumberBox1.Text = Convert.ToString(result);
        }
        public void Calc_Divide()
        {
            textBoxNumber.Text = Convert.ToString(number1);
            int x = Convert.ToInt32(NumberBox1.Text);
            result = x / number1;
            NumberBox1.Text = Convert.ToString(result);
        }
    }
}