using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            min = double.MaxValue;
            max = double.MinValue;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] > max) max = data[i];
                if (data[i] < min) min = data[i];
            }
            step = (max - min) / intervars;
            var res = new int[intervars];
            int idx = 0;
            double coeff = step != 0 ? 1 / step : 0;
            foreach (double d in data)
            {
                idx = (int)((d - min) * coeff);
                if (idx >= intervars) idx = intervars - 1;
                res[idx]++;
            }
            this.histArr = res;
            return res;
        }
        #endregion
    }

}
