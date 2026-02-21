using MyComplexCalculator;
using nsMycomplex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Лаба_2
{
    public partial class Form1 : Form
    {
       
        List<PointF> contour;
        public MyComplexSignal signal;
        Graphics gr;
        Canvas cnv;
        PointF loc;
        Form2 f2 = new Form2();
        
        public Form1()
        {
            InitializeComponent();
            pbCanvas.Image = new Bitmap(pbCanvas.Width, pbCanvas.Height);
            cnv = new Canvas(pbCanvas.Image.Size);
            gr = Graphics.FromImage(pbCanvas.Image);
            cnv.DrawGrid(gr);
            
            loc = new PointF(5, 5);
            if (signal == null)
            {
                var a = new List<PointF>();
                a.Add(new PointF(0, 0));

                signal = MyComplexSignal.FromPointF(a);
            }
            f2.DataRequested += GetSignalFromData;
            f2.ListDataRequested += GetSignalFromData;
            f2.Show();
          
        }


        public class Canvas
        {
            #region Fields 
            Size sourceSize = new Size(100, 100);
            Size size = new Size(100, 100);
            Point location = new Point(10, 10);
            double borderPercent = 0.1;
            Point max = new Point(10, 10);
            Point min = new Point(0, 0);
            int stepPxl = 10;
            float lineGridWidth = 1;
            float axisWidth = 5;
            #endregion
            #region Constructors 
            public Canvas() { }
            public Canvas(Size sourceSize)
            {
                this.sourceSize = sourceSize;
                this.size = new Size((int)(sourceSize.Width * (1 - borderPercent)),
                (int)(sourceSize.Height * (1 - borderPercent)));
                location.X = (sourceSize.Width - size.Width) / 2;
                location.Y = (sourceSize.Height - size.Height) / 2;
                stepPxl = size.Width / max.X;
                if ((size.Height / max.Y) < stepPxl) stepPxl = size.Height / max.Y;
            }
            #endregion
            #region Methods 
            public void DrawGrid(Graphics gr)
            {
                gr.Clear(Color.White);
                int wLines = size.Width / stepPxl;
                int hLines = size.Height / stepPxl;
                var pen = new Pen(Color.Black, lineGridWidth);
                int shift = 0;
                //Вертикальные линии 
                for (int w = 1; w < wLines; w++)
                {
                    shift = w * stepPxl;
                    gr.DrawLine(pen, shift + location.X, location.Y, shift + location.X, size.Height
              + location.Y);
                }
                //Горизонтальные линии 
                for (int h = 1; h < hLines; h++)
                {
                    shift = h * stepPxl;
                    gr.DrawLine(pen, location.X, sourceSize.Height - (shift + location.Y),
                    size.Width + location.X, sourceSize.Height - (shift + location.Y));
                }
                //Рисование осей 
                pen.Width = axisWidth;
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                gr.DrawLine(pen, location.X, size.Height + location.Y, location.X, location.Y);
                pen.StartCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                gr.DrawLine(pen, location.X, sourceSize.Height - (location.Y),
                size.Width + location.X, sourceSize.Height - (location.Y));
            }
            #endregion
            public void DrawContour(Graphics gr, List<PointF> source, PointF shift)
            {
                try
                {
                    var pen = new Pen(Color.Red, 3);
                    pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    PointF lastPoint = new PointF(shift.X * stepPxl + location.X,
                    sourceSize.Height - (shift.Y * stepPxl) - location.Y);
                    PointF currentPoint = new PointF(lastPoint.X + source.First().X * stepPxl,
                      lastPoint.Y - (source.First().Y * stepPxl));
                    // Первый вектор с точкой в начале 
                    pen.StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
                    gr.DrawLine(pen, lastPoint, currentPoint);
                    lastPoint = currentPoint;
                    // Остальные — только стрелка 
                    pen.StartCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                    for (int i = 1; i < source.Count; i++)
                    {
                        currentPoint.X = lastPoint.X + source[i].X * stepPxl;
                        currentPoint.Y = lastPoint.Y - (source[i].Y * stepPxl);
                        gr.DrawLine(pen, lastPoint, currentPoint);
                        lastPoint = currentPoint;
                    }
                }
            
                    catch (Exception er)
                {
                    Debug.WriteLine($"{er.ToString()}\n");
                    for (int i = 0; i < source.Count; i++)
                    {
                        Debug.WriteLine($"i = {i};" +
                            $"{source[i].ToString()}\n");
                    }
                }
            }
            }
        

        private void DrawSignal()
        {
           
                cnv.DrawGrid(gr);
                contour = signal.ToPointF();
                signal.data.Remove(new MyComplex(0, 0));
                cnv.DrawContour(gr, contour, loc);
                pbCanvas.Refresh();

               
            
            
        }


        private void drawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawSignal();

        }


        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region risunok
            ////Создание временного изображения 
            //var bmp = new Bitmap(pbCanvas.Width, pbCanvas.Height);
            //var canvas = Graphics.FromImage(bmp);
            //canvas.Clear(Color.White);
            //SizeF size1 = new SizeF(100, 100);
            //PointF location1 = new PointF((float)bmp.Width / 2, (float)bmp.Height / 2);
            //location1.X -= (size1.Width / 2)- 100;
            //location1.Y -= (size1.Height / 2) - 100;
            //canvas.DrawEllipse(Pens.Red, new RectangleF(location1, size1));


            //SizeF size2 = new SizeF(100, 100);
            //PointF location2 = new PointF((float)bmp.Width / 2, (float)bmp.Height / 2);
            //location2.X -= (size2.Width / 2);
            //location2.Y -= (size2.Height / 2)-100;
            //canvas.DrawEllipse(Pens.Red, new RectangleF(location2, size2));



            //SizeF size3 = new SizeF(100, 200);
            //PointF location3 = new PointF((float)bmp.Width / 2, (float)bmp.Height / 2);
            //location3.X -= (size2.Width / 2)-50;
            //location3.Y -= (size2.Height / 2) +85;
            //canvas.DrawEllipse(Pens.Red, new RectangleF(location3, size3));

            //pbCanvas.Image = bmp;
            //pbCanvas.Refresh();
            #endregion
        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            signal = MyComplexSignal.Rotate(signal, 45 * Math.PI / 180);
            DrawSignal();
            List<string> grid_data = MyComplexSignal.ToString(signal);
            f2.DataGrid_GetData(grid_data);
        }


        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {

            loc = new PointF(loc.X, loc.Y + 1);
            DrawSignal();
            List<string> grid_data = MyComplexSignal.ToString(signal);
            f2.DataGrid_GetData(grid_data);
        }

        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {

            loc = new PointF(loc.X, loc.Y - 1);
            DrawSignal();
            List<string> grid_data = MyComplexSignal.ToString(signal);
            f2.DataGrid_GetData(grid_data);
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {

            loc = new PointF(loc.X - 1, loc.Y);
            DrawSignal();
            List<string> grid_data = MyComplexSignal.ToString(signal);
            f2.DataGrid_GetData(grid_data);

        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {

            loc = new PointF(loc.X + 1, loc.Y);
            DrawSignal();
            List<string> grid_data = MyComplexSignal.ToString(signal);
            f2.DataGrid_GetData(grid_data);

        }

        private void upToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            signal = MyComplexSignal.Scale(signal, 2);
            DrawSignal(); 
            List<string> grid_data = MyComplexSignal.ToString(signal);
            f2.DataGrid_GetData(grid_data);
        }

        private void downToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            signal = MyComplexSignal.Scale(signal, 0.5);
            DrawSignal();
            List<string> grid_data = MyComplexSignal.ToString(signal);
            f2.DataGrid_GetData(grid_data);
        }


        public void GetSignalFromData(List<string> data)
        {

            signal = MyComplexSignal.Parse(data);
            DrawSignal();
     
        }
        public void GetSignalFromData(string data)
        {

            signal.data.Add(MyComplex.Parse(data));
            DrawSignal();
         
        }

        private void getDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> data = f2.DataGrid_PushData();
            GetSignalFromData(data);

        }


      

        private void dFTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            signal = MyComplexSignal.DFT(signal);
            DrawSignal();
            List<string> grid_data = MyComplexSignal.ToString(signal);
            f2.DataGrid_GetData(grid_data);
        }

        private void iDFTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            signal =MyComplexSignal.IDFT(signal);
            DrawSignal();
            List<string> grid_data = MyComplexSignal.ToString(signal);
            f2.DataGrid_GetData(grid_data);
        }

        private void normalizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            signal.GetNorm();
            signal.Normalize();
            DrawSignal();
            List<string> grid_data = MyComplexSignal.ToString(signal);
            f2.DataGrid_GetData(grid_data);
        }

        //private void rotationTestToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    signal.data.Clear();
        //    signal.data.Add(new MyComplex(0, 1));
        //    for (int i = 0; i < 11; i++)
        //    {
        //        signal.data[i].Rotate(-30 * Math.PI / 180);
        //        var temp = MyComplex.Copy(signal.data[i]);
        //        signal.data.Add(temp);
        //    }
        //    DrawSignal();
        //    List<string> grid_data = MyComplexSignal.ToString(signal);
        //    f2.DataGrid_GetData(grid_data);
        //}

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pbCanvas.Image.Save(sfd.FileName);
            }

        }

        private void pbCanvas_Click(object sender, EventArgs e)
        {

        }
    }
    }
