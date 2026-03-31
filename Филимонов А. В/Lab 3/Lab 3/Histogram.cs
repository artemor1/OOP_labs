using System;
using System.Diagnostics;

namespace Lab_3
{
    /// <summary>
    /// Строит гистограмму значений сигнала по фиксированному числу интервалов.
    /// Используется для оценки распределения отсчётов и визуализации плотности значений.
    /// </summary>
    public class Histogram
    {
        #region Fields
        public int intervars { get; set; } = 100;
        public double step { get; set; } = 0.1;

        public double max { get; set; } = 0;
        public double min { get; set; } = 0;
        public int[] histArr = new int[1];
        #endregion

        #region Constructors
        public Histogram() { }
        #endregion

        #region Methods
        /// <summary>
        /// Вычисляет гистограмму для входного массива отсчётов сигнала.
        /// </summary>
        /// <param name="data">Массив отсчётов сигнала.</param>
        /// <returns>Массив частот попадания в каждый интервал гистограммы.</returns>
        public int[] CalcHistogram(double[] data)
        {
            Debug.WriteLine($"[Histogram.CalcHistogram] Start. dataLength={(data == null ? 0 : data.Length)}, intervars={intervars}");
            if (data == null)
            {
                Debug.WriteLine("[Histogram.CalcHistogram] data is NULL. Return empty histogram.");
                histArr = new int[0];
                return histArr;
            }

            if (intervars <= 0)
            {
                Debug.WriteLine($"[Histogram.CalcHistogram] Invalid intervars={intervars}. Return empty histogram.");
                histArr = new int[0];
                return histArr;
            }

            if (data.Length == 0)
            {
                Debug.WriteLine("[Histogram.CalcHistogram] data is empty. Return zero histogram by intervars.");
                histArr = new int[intervars];
                return histArr;
            }

            min = double.MaxValue;
            max = double.MinValue;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] > max) max = data[i];
                if (data[i] < min) min = data[i];

                if (i < 3)
                {
                    Debug.WriteLine($"[Histogram.CalcHistogram] sample data[{i}]={data[i]:F6}, min={min:F6}, max={max:F6}");
                }
            }

            step = (max - min) / intervars;
            var res = new int[intervars];
            double coeff = step != 0 ? 1 / step : 0;
            for (int i = 0; i < data.Length; i++)
            {
                double d = data[i];
                // Преобразуем значение в индекс интервала по нормированному смещению от минимума.
                int idx = (int)((d - min) * coeff);
                idx = (int)((d - min) * coeff);
                if (idx >= intervars) idx = intervars - 1;
                if (idx < 0) idx = 0;
                res[idx]++;

                if (i < 3)
                {
                    Debug.WriteLine($"[Histogram.CalcHistogram] sample binning i={i}, value={d:F6}, idx={idx}, binCount={res[idx]}");
                }
            }

            histArr = res;
            this.histArr = res;
            Debug.WriteLine($"[Histogram.CalcHistogram] Completed. outputLength={res.Length}, min={min:F6}, max={max:F6}, step={step:F6}");
            return res;
        }
        #endregion
    }
}
