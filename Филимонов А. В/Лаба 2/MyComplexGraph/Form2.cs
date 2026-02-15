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


        public void DataGrid_FecthData(List<string> data)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in data)
            {   
                dataGridView1.Rows.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PanelMod1.Visible = true;
            PanelMod1.Enabled = true;
            PanelMod1.BringToFront();
            PanelMod2.Visible = false;
            PanelMod2.Enabled = false;
        }

        private void btnCalc_Click(object sender, EventArgs e)
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
                        res = a * b;
                        break;
                    case "\t|a|":
                        res.X = a.Abs();
                        break;
                    case "\t|b|":
                        res.X = b.Abs();
                        break;
                    case "\tscalar":
                        res.X = MyComplex.ScalarDot(a, b);
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

        private void PanelMod1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

            PanelMod2.Enabled = true;
            PanelMod2.Visible = true;
            PanelMod2.BringToFront();
            PanelMod1.Enabled = false;
            PanelMod1.Visible = false;
        }
    }
}
