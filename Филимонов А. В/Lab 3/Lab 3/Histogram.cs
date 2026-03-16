using System;
using System.Diagnostics;

namespace Lab_3
{
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
            int idx = 0;
            double coeff = step != 0 ? 1 / step : 0;
            for (int i = 0; i < data.Length; i++)
            {
                double d = data[i];
                idx = (int)((d - min) * coeff);
                if (idx >= intervars) idx = intervars - 1;
                if (idx < 0) idx = 0;
                res[idx]++;

                if (i < 3)
                {
                    Debug.WriteLine($"[Histogram.CalcHistogram] sample binning i={i}, value={d:F6}, idx={idx}, binCount={res[idx]}");
                }
            }

            this.histArr = res;
            Debug.WriteLine($"[Histogram.CalcHistogram] Completed. outputLength={res.Length}, min={min:F6}, max={max:F6}, step={step:F6}");
            return res;
        }
        #endregion
    }

}
