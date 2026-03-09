using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;
using AForge;
using nsMycomplex;
namespace Lab_3
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Rows.Add("1+0i");
        }

        #region Variables
        List<double> data;
        Generator generator = new Generator();
        double[] signalData = new double[1];
        Histogram histogram = new Histogram();
        int[] histogramData = new int[1];
        double[] processedSignalData = new double[1];
        Denoiser denoiser = new Denoiser();
        MyComplexSignal SignalToCode = new MyComplexSignal();
        #endregion

        #region Functions

        #region Debug helpers
        private void LogSignalState(string context, double[] source)
        {
            if (source == null)
            {
                Debug.WriteLine($"[{context}] signal is NULL");
                return;
            }

            var preview = string.Empty;
            var countToShow = Math.Min(3, source.Length);
            for (int i = 0; i < countToShow; i++)
            {
                preview += $"[{i}]={source[i]:F4} ";
            }

            Debug.WriteLine($"[{context}] signal length={source.Length}. preview: {preview}");
        }

        private void LogHistogramState(string context, int[] source)
        {
            if (source == null)
            {
                Debug.WriteLine($"[{context}] histogram is NULL");
                return;
            }

            Debug.WriteLine($"[{context}] histogram length={source.Length}");
        }
        #endregion

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
            Debug.WriteLine($"[SaveData] Start. format={format}, dataCount={(data == null ? 0 : data.Count)}");
            var fd = new SaveFileDialog();
            if (format == "TXT" || format == "txt")
            {
                fd.Filter = "Txt files|*.txt";
                if (fd.ShowDialog() != DialogResult.OK)
                {
                    Debug.WriteLine("[SaveData] TXT save canceled by user");
                    return;
                }
                var d = File_IO_Methods.SaveDataToTxtFile(data, fd.FileName);
                Debug.WriteLine($"[SaveData] Saved {d} lines to txt file: {fd.FileName}");
            }
            else if (format == "BIN" || format == "bin")
            {
                fd.Filter = "Bin files|*.bin";
                if (fd.ShowDialog() != DialogResult.OK)
                {
                    Debug.WriteLine("[SaveData] BIN save canceled by user");
                    return;
                }
                var d = File_IO_Methods.SaveDataToBinFile(data, fd.FileName);
                Debug.WriteLine($"[SaveData] Saved {d} lines to bin file: {fd.FileName}");
            }
        }
        void LoadData()
        {
            Debug.WriteLine("[LoadData] Start");
            var fd = new OpenFileDialog();
            fd.Filter = "Text and Bin files(*.txt;*.bin)|*.txt;*.bin";
            if (fd.ShowDialog() != DialogResult.OK)
            {
                Debug.WriteLine("[LoadData] File open canceled by user");
                return;
            }

            Debug.WriteLine($"[LoadData] Selected file: {fd.FileName}");
            if (fd.FileName.Contains(".txt"))
            {
                var d = File_IO_Methods.LoadDataFromTxtFile(fd.FileName);
                if (d != null) data = d;
                var s = DataToStirng(data);
                Debug.WriteLine($"[LoadData] Loaded TXT lines={data?.Count ?? 0}. data string length={s.Length}");

            }
            else if (fd.FileName.Contains(".bin"))
            {
                var d = File_IO_Methods.LoadDataFromBinFile(fd.FileName);
                if (d != null) data = d;
                var s = DataToStirng(data);
                Debug.WriteLine($"[LoadData] Loaded BIN values={data?.Count ?? 0}. data string length={s.Length}");
               
            }

        }
        #endregion

        #endregion

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

       

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
            Debug.WriteLine("[UI] genSinToolStripMenuItem_Click");
            signalData = generator.GenSin();
            LogSignalState("GenSin", signalData);
            MyGraphics.DrawGraph(zedGraphControl1,signalData,MyGraphics.GraphType.line);
        }


        private void loadSignalFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[UI] loadSignalFromFileToolStripMenuItem_Click");
            var ofd = new OpenFileDialog();
            ofd.Filter = "Text files|*.txt";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                Debug.WriteLine("[UI] load signal canceled by user");
                return;
            }
            Debug.WriteLine($"[UI] signal file selected: {ofd.FileName}");
            var data = File_IO_Methods.LoadDataFromTxtFile(ofd.FileName);
            if (data == null)
            {
                Debug.WriteLine("[UI] Loaded signal is NULL");
                return;
            }
            signalData = data.ToArray();
            LogSignalState("LoadSignalFromFile", signalData);
            MyGraphics.DrawGraph(zedGraphControl1,signalData,MyGraphics.GraphType.line);

        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = histogram;
        }

        private void calcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogSignalState("CalcHistogram input", signalData);
            histogramData = histogram.CalcHistogram(signalData);
            LogHistogramState("CalcHistogram output", histogramData);
            MyGraphics.DrawGraph(zedGraphControl2,histogramData, MyGraphics.GraphType.stick);
        }

        private void randomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[UI] randomToolStripMenuItem_Click");
            signalData = generator.GenRandomSignal();
            LogSignalState("GenRandomSignal", signalData);
            MyGraphics.DrawGraph(zedGraphControl1, signalData, MyGraphics.GraphType.line);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[UI] toolStripMenuItem1_Click (normal signal)");
            signalData = generator.GenNormalSignal();
            LogSignalState("GenNormalSignal", signalData);
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
                propertyGrid1.SelectedObject = denoiser;
                Debug.WriteLine("cB3 switched");
            }
        }

        private void sVDDenoiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogSignalState("SVDDeNoise input", signalData);
            processedSignalData = denoiser.DeNoise(signalData);
            LogSignalState("SVDDeNoise output", processedSignalData);
            MyGraphics.DrawGraph(zedGraphControl3,processedSignalData, MyGraphics.GraphType.line);
        }

       

        private void label1_Click(object sender, EventArgs e)
        {
                    }

        private void fFTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogSignalState("FFT input", signalData);
            Debug.WriteLine("[FFT] Process started");
            var signal = FourierTransform.Double2Complex(signalData);
            Debug.WriteLine($"[FFT] Signal parsed. length={signal.Length}");
            var sp = FourierTransform.FT(signal, -1);
            Debug.WriteLine($"[FFT] Fourier transformed. length={sp.Length}");
            var dataToShow = FourierTransform.AmplSpectrum(sp);
            LogSignalState("FFT amplitude spectrum", dataToShow);
            MyGraphics.DrawGraph(zedGraphControl2, dataToShow, MyGraphics.GraphType.stick);
            Debug.WriteLine("[FFT] Spectrum shown");

        }

        private void randomNoiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogSignalState("AddRNoise input", signalData);
            signalData = generator.AddRNoise(signalData);
            LogSignalState("AddRNoise output", signalData);
            MyGraphics.DrawGraph(zedGraphControl1, signalData, MyGraphics.GraphType.line);
        }

        private void normalNoiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogSignalState("AddNormNoise input", signalData);
            signalData = generator.AddNormNoise(signalData);
            LogSignalState("AddNormNoise output", signalData);
            MyGraphics.DrawGraph(zedGraphControl1, signalData, MyGraphics.GraphType.line);
        }

        private void aKFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogSignalState("AKF input", signalData);
            processedSignalData=Correlation.Akf(signalData);
            LogSignalState("AKF output", processedSignalData);
            MyGraphics.DrawGraph(zedGraphControl3, processedSignalData, MyGraphics.GraphType.line);
        }

        private void aKFAcycleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogSignalState("AKF acycle input", signalData);
            processedSignalData = Correlation.Akf_acycle(signalData);
            LogSignalState("AKF acycle output", processedSignalData);
            MyGraphics.DrawGraph(zedGraphControl3, processedSignalData, MyGraphics.GraphType.line);
        }

        private void vKFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogSignalState("VKF input", signalData);
            processedSignalData = Correlation.VKF(signalData,denoiser.DeNoise(signalData));
            LogSignalState("VKF output", processedSignalData);
            MyGraphics.DrawGraph(zedGraphControl3, processedSignalData, MyGraphics.GraphType.line);
        }

        #region Signal generation mode actions

        private void sinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generator.signalType=Generator.SignalType.sinus;
            Debug.WriteLine($"[Generator] Type={generator.signalType}, codeCount={SignalToCode.data.Count}");
            signalData = generator.GenerateSignal(SignalToCode);
            LogSignalState("Generate sinus", signalData);
            MyGraphics.DrawGraph(zedGraphControl1, signalData, MyGraphics.GraphType.line);

        }

        private void amToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generator.signalType = Generator.SignalType.AM;
            Debug.WriteLine($"[Generator] Type={generator.signalType}, codeCount={SignalToCode.data.Count}");
            signalData = generator.GenerateSignal(SignalToCode);
            LogSignalState("Generate AM", signalData);
            MyGraphics.DrawGraph(zedGraphControl1, signalData, MyGraphics.GraphType.line);
        }

        private void phMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generator.signalType = Generator.SignalType.FM;
            Debug.WriteLine($"[Generator] Type={generator.signalType}, codeCount={SignalToCode.data.Count}");
            signalData = generator.GenerateSignal(SignalToCode);
            LogSignalState("Generate FM", signalData);
            MyGraphics.DrawGraph(zedGraphControl1, signalData, MyGraphics.GraphType.line);

        }

        private void phmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            generator.signalType = Generator.SignalType.PhM;
            Debug.WriteLine($"[Generator] Type={generator.signalType}, codeCount={SignalToCode.data.Count}");
            signalData = generator.GenerateSignal(SignalToCode);
            LogSignalState("Generate PhM", signalData);
            MyGraphics.DrawGraph(zedGraphControl1, signalData, MyGraphics.GraphType.line);
        }
        #endregion

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                Debug.WriteLine("[DataGrid] Ignored change event with negative indexes");
                return;
            }

            var raw = dataGridView1.Rows[e.RowIndex].Cells[0].Value?.ToString();
            Debug.WriteLine($"[DataGrid] Cell changed row={e.RowIndex}, col={e.ColumnIndex}, raw='{raw}', beforeCount={SignalToCode.data.Count}");

            if (string.IsNullOrWhiteSpace(raw))
            {
                Debug.WriteLine("[DataGrid] Empty value. Skip parsing");
                return;
            }

            try
            {
                var parsed = MyComplex.Parse(raw);
                SignalToCode.data.Add(parsed);
                Debug.WriteLine($"[DataGrid] Parsed and appended '{parsed}'. afterCount={SignalToCode.data.Count}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[DataGrid] Parse error for '{raw}'. {ex}");
            }
        }
    }
}
