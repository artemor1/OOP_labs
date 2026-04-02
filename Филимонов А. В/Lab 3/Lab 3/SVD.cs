using MathNet.Numerics.LinearAlgebra;
using System;
using System.Diagnostics;

namespace Lab_3
{
    internal class Denoiser
    {
        #region Fields
        /// <summary>
        /// Размер окна L Ганкелевой матрицы (Rows=N\L)
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

        public Denoiser() { }
        public Matrix<double> Hankel(double[] x)
        {
            Debug.WriteLine($"[Denoiser.Hankel] inputLength={x.Length}, window={window}");
            if (window <= 0)
            {
                Debug.WriteLine("[Denoiser.Hankel] Invalid window <= 0");
                throw new ArgumentException("window must be greater than 0");
            }

            int rows = x.Length / window;
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
