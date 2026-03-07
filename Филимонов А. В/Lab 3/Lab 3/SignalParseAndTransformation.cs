using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using nsMycomplex;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    internal class SignalHandler
    {
        #region fields
       private MyComplexSignal SignalData = new MyComplexSignal();
        private double[] TransformedSignal = new double[1];
        /// <summary>
        /// Тип кодирования
        /// </summary>
        public enum EncodeType
        {
            Ampl,Freq,Phase
        }
        /// <summary>
        ///  Длина кодового интервала в отсчётах 
        /// </summary>
        public double CodeLenght { get; set; }

        #endregion

        #region Methods

        public SignalHandler() { }
        public SignalHandler(double[] SignalData, double CodeLenght = 10 )
        {
        }

       private static Matrix<double> Hankel(double[] x,int window)
             {
        int rows = x.Length / window;
        int cols = x.Length - rows + 1;

        var H = Matrix<double>.Build.Dense(rows, cols);

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                H[i, j] = x[i + j];

        return H;
          }

        private static double[] HankelToArray(Matrix<double> H)
        {
            int rows = H.RowCount;
            int cols = H.ColumnCount;

            int N = rows + cols - 1; // длина восстановленного сигнала
            double[] x = new double[N];
            int[] counts = new int[N]; // количество элементов на каждой диагонали

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    x[i + j] += H[i, j];
                    counts[i + j]++;
                }
            }

            for (int k = 0; k < N; k++)
            {
                x[k] /= counts[k]; // среднее по диагонали
            }

            return x;
        }





        public static double[] DeNoise(double[] data, int winow, int iterations = 1)
        {
            double[] signal = (double[])data.Clone();
            double maxDropCoef = 0.5;
            for (int it = 0; it < iterations; it++)
            {
                var H = Hankel(signal,winow);  // строим Hankel матрицу
                var svd = H.Svd();
                int m = H.RowCount;
                int n = H.ColumnCount;
                var R = Matrix<double>.Build.Dense(m, n);
                int i = 0;
                Debug.WriteLine($"S.Lenght = {svd.S.Count}\niteration = {it}\n");
                do
                {
                  
                    var u = svd.U.Column(i).ToColumnMatrix();
                    var v = svd.VT.Row(i).ToColumnMatrix();
                    var s = svd.S;
                    R += s[i] * u * v.Transpose();
                    
                    i++;
                    
                }
                while (i < svd.S.Count && svd.S[i] > svd.S[i - 1] * maxDropCoef);
                Debug.WriteLine($"max i = {i}");
                for (int j = 0; j < svd.S.Count; j++)
                {
                    Debug.WriteLine($"s[{j}] = {svd.S[j]}\n");
                }
                // Диагональное усреднение: восстановление сигнала из матрицы
                signal = HankelToArray(R);
            }

            return signal;
        }

        //public void Parse(double[] data, Generator gen)
        //{
        //    double discredfreq = 1 / gen.pediodsCount;
        //}

        #endregion

    }
}
