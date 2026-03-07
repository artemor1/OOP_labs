using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using nsMycomplex;
using System;
using System.Collections.Generic;
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

       private static Matrix<double> Hankel(double[] x)
             {
            int rows = x.Length / 2;
        int cols = x.Length - rows + 1;

        var H = Matrix<double>.Build.Dense(rows, cols);

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                H[i, j] = x[i + j];

        return H;
          }

        private static int[] BuildDiagonalCounts(int rows, int cols)
        {
            int N = rows + cols - 1;
            int[] counts = new int[N];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    counts[i + j]++;
                }
            }

            return counts;
        }

        private static int ResolveRankComponents(int rankPercent, int singularValuesCount)
        {
            int clampedRankPercent = Math.Max(0, Math.Min(100, rankPercent));

            // Требование: использовать S.Length * (rank)% вместо i < rank
            int components = (int)Math.Ceiling(singularValuesCount * clampedRankPercent / 100.0);

            return Math.Max(1, Math.Min(singularValuesCount, components));
        }

        private static double[] ReconstructSignalFromSvd(MathNet.Numerics.LinearAlgebra.Factorization.Svd<double> svd, int rows, int cols, int rankPercent)
        {
            int N = rows + cols - 1;
            double[] signal = new double[N];
            int[] diagonalCounts = BuildDiagonalCounts(rows, cols);

            int components = ResolveRankComponents(rankPercent, svd.S.Count);

            // Восстанавливаем сигнал сразу по диагоналям, без промежуточной матрицы R
            for (int i = 0; i < components; i++)
            {
                double sigma = svd.S[i];

                for (int r = 0; r < rows; r++)
                {
                    double uSigma = svd.U[r, i] * sigma;
                    for (int c = 0; c < cols; c++)
                    {
                        signal[r + c] += uSigma * svd.VT[i, c];
                    }
                }
            }

            for (int k = 0; k < N; k++)
            {
                signal[k] /= diagonalCounts[k];
            }

            return signal;
        }
        public static double[] DeNoise(double[] data, int rank = 3, int iterations = 1)
        {
            double[] signal = (double[])data.Clone();

            for (int it = 0; it < iterations; it++)
            {
                var H = Hankel(signal);  // строим Hankel матрицу
                var svd = H.Svd();
                int m = H.RowCount;
                int n = H.ColumnCount;

                // Диагональное усреднение: восстановление сигнала из SVD без промежуточной Hankel-матрицы
                signal = ReconstructSignalFromSvd(svd, m, n, rank);
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
