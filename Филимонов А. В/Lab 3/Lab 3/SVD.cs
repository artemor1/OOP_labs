using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Factorization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab_3
{
    internal class Denoiser
    {
        #region Fields
        /// <summary>
        /// Размер окна L Ганкелевой матрицы (Rows=L)
        /// </summary>
        public int window { get; set; } = 10;
        /// <summary>
        /// Максимальная разница между полезными коефицентами
        /// </summary>
        public double maxDropCoef { get; set; } = 0.5;
        /// <summary>
        /// Максимальный ранг восстановленной матрицы
        /// </summary>
        public int maxRank { get; set; } = 100;
        public int iterations { get; set; } = 1;
        #endregion

        #region Methods
        #region OptWindow
        public static int FindOptimalWindowLength(double[] signal)
        {
            if (signal == null || signal.Length < 2)
                throw new ArgumentException("Signal is too short.");

            int nOpt = -1;
            int N = signal.Length;
            double bestP = double.NegativeInfinity;
            int[] candidateWindows = { 2, 5, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100,150,200,250,300,450,500 };

            foreach (int n in candidateWindows)
            {
                if (n <= 1 || n >= signal.Length)
                    continue;

                double p = ComputeFrcmForWindow(signal,n);

                if (p > bestP)
                {
                    bestP = p;
                    nOpt = n;
                }
            }

            if (nOpt == -1)
                throw new ArgumentException("No valid window length found.");
            else
            {
                Debug.WriteLine($"[Denoiser.OptWindow] Optimal window is {nOpt}");
            }

            return nOpt;
        }

        public static double ComputeFrcmForWindow(double[] signal, int n)
        {
            int m = signal.Length - n + 1;
            Matrix<double> hankel = Hankel(signal, m, n);

            double[] singularValues = ComputeSingularValues(hankel);

            double mean = singularValues.Average();

            double sum = 0.0;
            for (int i = 0; i < singularValues.Length; i++)
            {
                double d = singularValues[i] - mean;
                sum += Math.Pow(d, 4);
            }

            return Math.Pow(sum / singularValues.Length, 0.25);
        }

     
        private static double[] ComputeSingularValues(Matrix<double> matrix)
        {
            var Svd = matrix.Svd();
            return Svd.S.ToArray();
        }

        #endregion

        public Denoiser() { }
        public Matrix<double> Hankel(double[] x)
        {
            Debug.WriteLine($"[Denoiser.Hankel] inputLength={x.Length}, window={window}");
            if (window <= 0)
            {
                Debug.WriteLine("[Denoiser.Hankel] Invalid window <= 0");
                throw new ArgumentException("window must be greater than 0");
            }

             int  rows = window;
             int cols = x.Length - rows + 1;

            Debug.WriteLine($"[Denoiser.Hankel] rows={rows}, cols={cols}");
            if (rows <= 0 || cols <= 0)
            {
                Debug.WriteLine("[Denoiser.Hankel] Invalid matrix dimensions");
                throw new ArgumentException("Invalid Hankel dimensions. Check window and signal length.");
            }

            var H = Matrix<double>.Build.Dense(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    H[i, j] = x[i + j];
                }
            }
            return H;
        }

        public static Matrix<double> Hankel(double[] x, int rows , int cols)
        {
            Debug.WriteLine($"[Denoiser.Hankel] inputLength={x.Length}");
            Debug.WriteLine($"[Denoiser.Hankel] rows={rows}, cols={cols}");
            if (rows <= 0 || cols <= 0)
            {
                Debug.WriteLine("[Denoiser.Hankel] Invalid matrix dimensions");
                throw new ArgumentException("Invalid Hankel dimensions. Check window and signal length.");
            }

            var H = Matrix<double>.Build.Dense(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    H[i, j] = x[i + j];
                }
            }
            return H;
        }

        private static double[] HankelToArray(Matrix<double> H)
        {
            int rows = H.RowCount;
            int cols = H.ColumnCount;

            int N = rows + cols - 1;   // длина восстановленного сигнала
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

        public double[] DeNoise(double[] data)
        {
            Debug.WriteLine($"[Denoiser.DeNoise] Start. dataLength={(data == null ? 0 : data.Length)}, window={window}, iterations={iterations}, maxDropCoef={maxDropCoef}");
            if (data == null || data.Length == 0)
            {
                Debug.WriteLine("[Denoiser.DeNoise] Empty input signal");
                return new double[0];
            }

            double[] signal = (double[])data.Clone();
            for (int it = 0; it < iterations; it++)
            {

               // window = FindOptimalWindowLength(data);
                Debug.WriteLine($"[Denoiser.DeNoise] iteration={it} inputLength={signal.Length}");
                var H = Hankel(signal);
                var svd = H.Svd();
                
                int m = H.RowCount;
                int n = H.ColumnCount;
                var R = Matrix<double>.Build.Dense(m, n);
                int i = 0;
                Debug.WriteLine($"[Denoiser.DeNoise] iteration={it}, S.Length={svd.S.Count}, U={svd.U.RowCount}x{svd.U.ColumnCount}, VT={svd.VT.RowCount}x{svd.VT.ColumnCount}");
                var sigPreviewCount = Math.Min(5, svd.S.Count);
             
                do
                {

                    var u = svd.U.Column(i).ToColumnMatrix();
                    var v = svd.VT.Row(i).ToColumnMatrix();
                    var s = svd.S;
                    R += s[i] * u * v.Transpose();

                    if (i > 0)
                    {
                        Debug.WriteLine($"[Denoiser.DeNoise] keep component i={i}. condition {svd.S[i]} > {svd.S[i - 1] * maxDropCoef}");
                    }

                    i++;

                }
                while (i < svd.S.Count && svd.S[i] > svd.S[i - 1] * maxDropCoef && i < maxRank); ;
                Debug.WriteLine($"[Denoiser.DeNoise] max kept index={i - 1}");
 
                signal = HankelToArray(R);
                Debug.WriteLine($"[Denoiser.DeNoise] iteration={it} restoredLength={signal.Length}");

                for (int j = 0; j < i+4 && j<svd.S.Count-1; j++)
                {
                    Debug.WriteLine($"[Denoiser.DeNoise] S[{j}]={svd.S[j]}");
                }

            }

            Debug.WriteLine("[Denoiser.DeNoise] Completed");
            return signal;
        }


        #endregion

    }
}
