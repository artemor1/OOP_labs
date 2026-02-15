using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using nsMycomplex;

namespace MyComplexCalculator
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = tbValueA.Text;
                MyComplex a = MyComplex.Parse(str);
                str = tbValueB.Text;
                MyComplex b = MyComplex.Parse(str);
                //Определение оператора 
                string op = (string)cbOperator.SelectedItem;
                MyComplex res = new MyComplex();
                switch (op)
                {
                    case "\t+":
                        res = a + b;
                        break;
                    case "\t-":
                        res = a - b;
                        break;
                    case "\t*":
                        res = a*b;
                        break;
                    case "\t|a|":
                        res.X = a.Abs();
                        break;
                    case "\t|b|":
                        res.X = b.Abs();
                        break;
                    case "\tscalar":
                        res.X=MyComplex.ScalarDot(a,b);
                        break;
                    default: break;
                }
                tbResult.Text = res.ToString();
            }
            catch
            {
                tbResult.Text = "";
                MessageBox.Show("Что-то пошло не так", "Ошибка");
            }
        

    }
        
        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
