using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;
namespace Lab_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tbWindow.Text = "2";
            tbIterations.Text = "2";
            tbNoiseLvl.Text = "0,5";
        }

        #region Variables
        List<double> data;
        Generator generator = new Generator();
        double[] signalData = new double[1];
        Histogram histogram = new Histogram();
        int[] histogramData= new int[1];
        double[] processedSignalData = new double[1];
        #endregion

        #region Functions

        #region Data display methods
        //void ReplaceShownData(string data)
        //{

        //    richTextBox1.Text = data;
        //}

        //void AddShownData(string data)
        //{
        //    richTextBox1.Text += data;
        //}

        //void ClearShownData()
        //{
        //    richTextBox1.Text = "";
        //}
        #endregion

        #region Generation methods
        //public List<double> GenerateArray()
        //{
        //    try //Попытка выполнить инструкции функции 
        //    {
        //        List<double> res = new List<double>();
        //        int count = 0; //Переменная для хранения количества чисел 
        //        var strCount = tbCount.Text; //Переменная с текстовым переменной.
        //        var isGood = int.TryParse(strCount, out count); //Попытка сроки в значение
        //        if (!isGood) return null; //Возврат в случае ошибки пребразования 
        //        Random rnd = new Random(); //Создание генератора СЧ 
        //        for (int i = 0; i < count; i++)
        //        {
        //            var value = rnd.NextDouble(); //Генерация значения от 0 до 1 
        //            res.Add(value); //Добавление значения в список 
        //        }
        //        return res;
        //    }
            //catch (Exception ex) //Отлов исключений 
            //{
            //    MessageBox.Show(ex.ToString()); //Вывод окна с текстом ошибки 
            //    return null;
            //}
        //}
        #endregion

        #region Data transformation methods
        string DataToStirng(List<double> data)
        {
            if (data == null) return "NULL"; //Проверка на null 
            var str = "";
            for (int i = 0; i < data.Count; i++)
            {
                str += data[i].ToString() + "\n";
            }
            return str;
        }
        #endregion

        #region Save/Load
        void SaveData(string format)
        {
            #region debug
            Debug.WriteLine("Saving data...");
            #endregion
            var fd = new SaveFileDialog();
            if (format == "TXT" || format == "txt")
            {
                fd.Filter = "Txt files|*.txt";
                if (fd.ShowDialog() != DialogResult.OK) return; //Выход, если не OK 
                var d = File_IO_Methods.SaveDataToTxtFile(data, fd.FileName);
                Debug.WriteLine($"Saved {d} lines to txt file");
            }
            else if (format == "BIN" || format == "bin")
            {
                fd.Filter = "Bin files|*.bin";
                if (fd.ShowDialog() != DialogResult.OK) return; //Выход, если не OK 
                var d = File_IO_Methods.SaveDataToBinFile(data, fd.FileName);
                Debug.WriteLine($"Saved {d} lines to bin file");
            }
        }
        void LoadData()
        {
            var fd = new OpenFileDialog();
            fd.Filter = "Text and Bin files(*.txt;*.bin)|*.txt;*.bin";
            if (fd.ShowDialog() != DialogResult.OK) return; //Выход, если не OK 
            if (fd.FileName.Contains(".txt"))
            {
                var d = File_IO_Methods.LoadDataFromTxtFile(fd.FileName);
                if (d != null) data = d;
                var s = DataToStirng(data);

            }
            else if (fd.FileName.Contains(".bin"))
            {
                var d = File_IO_Methods.LoadDataFromBinFile(fd.FileName);
                if (d != null) data = d;
                var s = DataToStirng(data);
               
            }

        }
        #endregion

        #endregion

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var res = GenerateArray(); //Привязка метода к событию кнопки 
        //    if (res == null) return; //Сброс в случае неудачной генерации 
        //    this.data = res; //Присвоение полю значения 
        //    var str = DataToStirng(res);
        //    ReplaceShownData(str); //Вывод данных на экран
        //}

        private void totxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveData("txt");
        }


        private void tobinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveData("bin");
        }

        private void showPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = generator;
        }

        private void genSinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            signalData = generator.GenSin();
           MyGraphics.DrawGraph(zedGraphControl1,signalData,MyGraphics.GraphType.line);
        }


        private void loadSignalFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Text files|*.txt";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            var data = File_IO_Methods.LoadDataFromTxtFile(ofd.FileName);
            if (data == null) return;
            signalData = data.ToArray();
            MyGraphics.DrawGraph(zedGraphControl1,signalData,MyGraphics.GraphType.line);

        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = histogram;
        }

        private void calcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            histogramData = histogram.CalcHistogram(signalData);
            MyGraphics.DrawGraph(zedGraphControl2,histogramData, MyGraphics.GraphType.stick);
        }

        private void randomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            signalData = generator.GenRandomSignal();
            MyGraphics.DrawGraph(zedGraphControl1, signalData, MyGraphics.GraphType.line);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            signalData = generator.GenNormalSignal();
            MyGraphics.DrawGraph(zedGraphControl1, signalData, MyGraphics.GraphType.line);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked) 
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                propertyGrid1.SelectedObject = generator;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                propertyGrid1.SelectedObject = histogram;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                propertyGrid1.SelectedObject = null;
            }
        }

        private void sVDDenoiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processedSignalData = SignalHandler.DeNoise(signalData,int.Parse(tbWindow.Text),int.Parse(tbIterations.Text));
            MyGraphics.DrawGraph(zedGraphControl3,processedSignalData, MyGraphics.GraphType.line);
        }

        private void genNoisedSinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            signalData = generator.GenNoisedSin(double.Parse(tbNoiseLvl.Text));
            MyGraphics.DrawGraph(zedGraphControl1,signalData, MyGraphics.GraphType.line);
        }
    }
}

