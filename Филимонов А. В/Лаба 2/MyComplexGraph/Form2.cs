using nsMycomplex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Лаба_2;
using static Лаба_2.Form1;
namespace MyComplexCalculator
{
    public partial class Form2 : Form
    {
        private Form1 f1;
        MyComplex vector;



        public event Action<string> DataRequested;
        public event Action<List<string>> ListDataRequested;



        public Form2()
        {
            InitializeComponent();

        }

     

        public void DataGrid_GetData(List<string> data)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in data)
            {

                dataGridView1.Rows.Add(item);
            }
            dataGridView1.Refresh();
        }

        public List<string> DataGrid_PushData()
        {
    
            List<string> data = new List<string>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Skip the new empty row (if AllowUserToAddRows = true)
                if (!row.IsNewRow)
                {
                    data.Add(row.Cells[0].Value?.ToString());
                }

            }
            return data;
           
        }
        public void DataGrid_Clear()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            List<string> a = DataGrid_PushData();
            ListDataRequested?.Invoke(a);
        }

        public void DataGrid_AddData(string data)
        {
           
            dataGridView1.Rows.Add(data);
            dataGridView1.Refresh();
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


        private void button1_Click_2(object sender, EventArgs e)
        {

            PanelMod2.Enabled = true;
            PanelMod2.Visible = true;
            PanelMod2.BringToFront();
            PanelMod1.Enabled = false;
            PanelMod1.Visible = false;
        }







        bool isDrawing = false;
        bool hasLine = false;

        PointF start_point;
        PointF end_point;

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!isDrawing)
            {
                isDrawing = true;
                hasLine = false;
                start_point = e.Location;
            }
            else
            {
                isDrawing = false;
                hasLine = true;
                end_point = e.Location;
            }
            double x = end_point.X - start_point.X;
            double y = end_point.Y- start_point.Y;
       
            vector = new MyComplex(x,y*-1);
            #region normalize
            double norm = vector.Abs();
            vector.X /= norm;
            vector.Y /= norm;
            vector.X = Math.Round(vector.X,3);
            vector.Y = Math.Round(vector.Y,3);
            #endregion
            pictureBox1.Invalidate();
         
        }
        Pen pen = new Pen(Color.Red, 3);
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (isDrawing)
            {
                e.Graphics.DrawString("*", new Font("Arial", 16), Brushes.Red, start_point);
            }

            if (hasLine)
            {
                e.Graphics.DrawLine(pen, start_point, end_point);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DataGrid_AddData(vector.ToString());

            DataRequested?.Invoke(vector.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataGrid_Clear();
        }
    }

}
