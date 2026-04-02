using nsMycomplex;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
namespace Lab_3
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        #region Variables
       public List<double> data;
        public Generator generator = new Generator();
        public double[] signalData = new double[1];
       public Histogram histogram = new Histogram();
        public int[] histogramData = new int[1];
       public double[] processedSignalData = new double[1];
             Denoiser denoiser = new Denoiser();
     public MyComplexSignal SignalToCode = new MyComplexSignal();
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

        #region Data grid

        #region Add Data
        void DataGrid_Add<T>(IEnumerable<T> data, DataGridView grid)
        {
            if (data == null || grid == null) return;

            foreach (var value in data)
            {
                DataGrid_Add(value, grid);
            }
        }

        void DataGrid_Add<T>(T data, DataGridView grid)
        {
            if (data == null || grid == null) return;

            var rowIndex = grid.Rows.Add();
            grid.Rows[rowIndex].Cells[0].Value = data;
        }

        #endregion

        #region Replace Data

        void DataGrid_Replace<T>(IEnumerable<T> data, DataGridView grid)
        {
            if (grid == null) return;

            if (data == null)
            {
                Debug.WriteLine($"\n[GridAction] Replace skipped for {grid.Name}: source is null");
                grid.Rows.Clear();
                return;
            }

            var values = data.ToList();
            Debug.WriteLine($"\n[GridAction] Start replace in {grid.Name} by {values.Count} elements type:{data.GetType()}");

            grid.Rows.Clear();
            foreach (var value in values)
            {
                DataGrid_Add(value, grid);
            }
        }


        #endregion



        #endregion

        #region UI action methods

        #region Property actions
        private void ShowGeneratorProperties()
        {
            Debug.WriteLine("[Action] ShowGeneratorProperties");
            propertyGrid1.SelectedObject = generator;
        }

        private void ShowHistogramProperties()
        {
            Debug.WriteLine("[Action] ShowHistogramProperties");
            propertyGrid1.SelectedObject = histogram;
        }

        private void ShowDenoiserProperties()
        {
            Debug.WriteLine("[Action] ShowDenoiserProperties");
            propertyGrid1.SelectedObject = denoiser;
        }
        #endregion

        #region Signal source actions
        private void GenerateSinSignal()
        {
            Debug.WriteLine("[Action] GenerateSinSignal");
            signalData = generator.GenSin();
            LogSignalState("GenSin", signalData);
            MyGraphics.DrawGraph(zedGraphControl1, signalData, MyGraphics.GraphType.line);
        }

        private void GenerateRandomSignal()
        {
            Debug.WriteLine("[Action] GenerateRandomSignal");
            signalData = generator.GenRandomSignal();
            LogSignalState("GenRandomSignal", signalData);
            MyGraphics.DrawGraph(zedGraphControl1, signalData, MyGraphics.GraphType.line);
        }

        private void GenerateNormalSignal()
        {
            Debug.WriteLine("[Action] GenerateNormalSignal");
            signalData = generator.GenNormalSignal();
            LogSignalState("GenNormalSignal", signalData);
            MyGraphics.DrawGraph(zedGraphControl1, signalData, MyGraphics.GraphType.line);
        }

        private void LoadSignalFromFile()
        {
            Debug.WriteLine("[Action] LoadSignalFromFile");
            var ofd = new OpenFileDialog();
            ofd.Filter = "Text files|*.txt";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                Debug.WriteLine("[Action] Load signal canceled by user");
                return;
            }

            Debug.WriteLine($"[Action] Signal file selected: {ofd.FileName}");
            var loadedData = File_IO_Methods.LoadDataFromTxtFile(ofd.FileName);
            if (loadedData == null)
            {
                Debug.WriteLine("[Action] Loaded signal is NULL");
                return;
            }

            signalData = loadedData.ToArray();
            LogSignalState("LoadSignalFromFile", signalData);
            MyGraphics.DrawGraph(zedGraphControl1, signalData, MyGraphics.GraphType.line);
        }
        #endregion

        #region Processing actions
        private void CalculateHistogram()
        {
            Debug.WriteLine("[Action] CalculateHistogram");
            LogSignalState("CalcHistogram input", signalData);
            histogramData = histogram.CalcHistogram(signalData);
            LogHistogramState("CalcHistogram output", histogramData);
            MyGraphics.DrawGraph(zedGraphControl2, histogramData, MyGraphics.GraphType.stick);
        }

        private void ApplySvdDenoise()
        {
            Debug.WriteLine("[Action] ApplySvdDenoise");
            LogSignalState("SVDDeNoise input", signalData);
            processedSignalData = denoiser.DeNoise(signalData);
            LogSignalState("SVDDeNoise output", processedSignalData);
            MyGraphics.DrawGraph(zedGraphControl3, processedSignalData, MyGraphics.GraphType.line);


            //выводим получившиеся матрицы разложения

            var H = denoiser.Hankel(signalData);
            var svd = H.Svd();
            GridHelper.PutMatrixInGrid(dgvPreProcU, svd.U);
            DataGrid_Replace(svd.S, dgvPreProcS);
            GridHelper.PutMatrixInGrid(dgvPreProcVT, svd.VT);

            var Hp = denoiser.Hankel(processedSignalData);
            var svdP = H.Svd();
            GridHelper.PutMatrixInGrid(dgvPostProcU, svdP.U);
            DataGrid_Replace(svdP.S, dgvPostProcS);
            GridHelper.PutMatrixInGrid(dgvPostProcVT, svdP.VT);

        }

        private void ShowFftSpectrum()
        {
            Debug.WriteLine("[Action] ShowFftSpectrum");
            LogSignalState("FFT input", signalData);
            var signal = FourierTransform.Double2Complex(signalData);
            Debug.WriteLine($"[FFT] Signal parsed. length={signal.Length}");
            var sp = FourierTransform.FT(signal, -1);
            Debug.WriteLine($"[FFT] Fourier transformed. length={sp.Length}");
            var dataToShow = FourierTransform.AmplSpectrum(sp);
            LogSignalState("FFT amplitude spectrum", dataToShow);
            MyGraphics.DrawGraph(zedGraphControl2, dataToShow, MyGraphics.GraphType.stick);
        }

        private void AddRandomNoise()
        {
            Debug.WriteLine("[Action] AddRandomNoise");
            LogSignalState("AddRNoise input", signalData);
            signalData = generator.AddRNoise(signalData);
            LogSignalState("AddRNoise output", signalData);
            MyGraphics.DrawGraph(zedGraphControl1, signalData, MyGraphics.GraphType.line);
        }

        private void AddNormalNoise()
        {
            Debug.WriteLine("[Action] AddNormalNoise");
            LogSignalState("AddNormNoise input", signalData);
            signalData = generator.AddNormNoise(signalData);
            LogSignalState("AddNormNoise output", signalData);
            MyGraphics.DrawGraph(zedGraphControl1, signalData, MyGraphics.GraphType.line);
        }

        private void CalculateAkf()
        {
            Debug.WriteLine("[Action] CalculateAkf");
            LogSignalState("AKF input", signalData);
            processedSignalData = Correlation.Akf(signalData);
            LogSignalState("AKF output", processedSignalData);
            MyGraphics.DrawGraph(zedGraphControl3, processedSignalData, MyGraphics.GraphType.line);
        }

        private void CalculateAkfAcycle()
        {
            Debug.WriteLine("[Action] CalculateAkfAcycle");
            LogSignalState("AKF acycle input", signalData);
            processedSignalData = Correlation.Akf_acycle(signalData);
            LogSignalState("AKF acycle output", processedSignalData);
            MyGraphics.DrawGraph(zedGraphControl3, processedSignalData, MyGraphics.GraphType.line);
        }

        private void CalculateVkf()
        {
            Debug.WriteLine("[Action] CalculateVkf");
            LogSignalState("VKF input", signalData);
            processedSignalData = Correlation.VKF(signalData, denoiser.DeNoise(signalData));
            LogSignalState("VKF output", processedSignalData);
            MyGraphics.DrawGraph(zedGraphControl3, processedSignalData, MyGraphics.GraphType.line);
        }
        #endregion

        #region Modulation actions
        private void GenerateModulatedSignal(Generator.SignalType signalType, string context)
        {
            Debug.WriteLine($"[Action] GenerateModulatedSignal type={signalType}");
            generator.signalType = signalType;
            Debug.WriteLine($"[Generator] Type={generator.signalType}, codeCount={SignalToCode.data.Count}");
            signalData = generator.GenerateSignal(SignalToCode);
            LogSignalState(context, signalData);
            MyGraphics.DrawGraph(zedGraphControl1, signalData, MyGraphics.GraphType.line);
        }
        #endregion

        #region Decode actions
        private void ParseSignalByType()
        {
            var signal = ChProcessed.Checked ? processedSignalData : signalData;
            var signalfreq = generator.carrierFrequency;
            var sreq = generator.samplingFrequency;
            var T = generator.codeIntervalLength;
            MyComplexSignal decoded = new MyComplexSignal();
            List<string> data = new List<string>();
            Debug.WriteLine($"[Action] ParseSignalByType type={type}");
            switch (type)
            {
                case 0:
                    decoded = MyComplexSignal.ParseFromAm(signal, sreq, T);
                    data = MyComplexSignal.ToString(decoded);
                    DataGrid_Replace(data, dataGridView2);

                    Debug.WriteLine("[Action] Parse Am completed");
                    break;
                case 1:
                    Debug.WriteLine("[Action] Parse FM is not implemented yet");
                    break;
                case 2:

                    decoded = MyComplexSignal.ParseFromPhm(signal, signalfreq, sreq, T);
                    data = MyComplexSignal.ToString(decoded);
                    DataGrid_Replace(data, dataGridView2);

                    Debug.WriteLine("[Action] Parse PhM completed");
                    break;
            }
        }
        #endregion

        #endregion

        #endregion

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {


            LoadData();
            DataGrid_Replace(data, dataGridView1);

        }



        private void totxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data = new List<double>(signalData.Length);
            foreach (var item in signalData)
            {
                data.Add(item);
            }
            SaveData("txt");
            data.Clear();
        }


        private void tobinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data = new List<double>(signalData.Length);
            foreach (var item in signalData)
            {
                data.Add(item);
            }
            SaveData("bin");
            data.Clear();
        }

        private void showPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowGeneratorProperties();
        }

        private void genSinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateSinSignal();
        }


        private void loadSignalFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSignalFromFile();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHistogramProperties();
        }

        private void calcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalculateHistogram();
        }

        private void randomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateRandomSignal();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GenerateNormalSignal();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                ShowGeneratorProperties();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                ShowHistogramProperties();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                ShowDenoiserProperties();
                Debug.WriteLine("cB3 switched");
            }
        }

        private void sVDDenoiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplySvdDenoise();
        }



        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void fFTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFftSpectrum();
        }

        private void randomNoiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRandomNoise();
        }

        private void normalNoiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNormalNoise();
        }

        private void aKFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalculateAkf();
        }

        private void aKFAcycleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalculateAkfAcycle();
        }

        private void vKFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalculateVkf();
        }

        #region Signal generation mode actions

        private void sinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateModulatedSignal(Generator.SignalType.sinus, "Generate sinus");
        }

        private void amToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateModulatedSignal(Generator.SignalType.AM, "Generate AM");
        }

        private void phMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateModulatedSignal(Generator.SignalType.FM, "Generate FM");
        }

        private void phmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GenerateModulatedSignal(Generator.SignalType.PhM, "Generate PhM");
        }
        #endregion
        bool _internalChange = false;
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_internalChange) return;

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
                if (SignalToCode.data.Count > e.RowIndex)
                {
                    SignalToCode.data[e.RowIndex] = parsed;
                }
                else
                {
                    SignalToCode.data.Add(parsed);
                }

                _internalChange = true;
                DataGrid_Replace(SignalToCode.data, dataGridView1);
                _internalChange = false;
                Debug.WriteLine($"[DataGrid] Parsed and stored '{parsed}'. afterCount={SignalToCode.data.Count}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[DataGrid] Parse error for '{raw}'. {ex}");
            }
        }



        int type = 0;
        private void chBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    type = 0;
                    GenerateModulatedSignal(Generator.SignalType.AM, "Generate AM");
                    break;
                case 1:
                    type = 1;
                    GenerateModulatedSignal(Generator.SignalType.FM, "Generate FM");
                    break;
                case 2:
                    type = 2;
                    GenerateModulatedSignal(Generator.SignalType.PhM, "Generate PhM");

                    break;

                default:
                    break;
            }
        }

        private void bParse_Click(object sender, EventArgs e)
        {
            ParseSignalByType();
        }

    
    }
}
