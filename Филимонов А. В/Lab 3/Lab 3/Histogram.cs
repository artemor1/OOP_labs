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
            min = double.MaxValue;
            max = double.MinValue;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] > max) max = data[i];
                if (data[i] < min) min = data[i];
            }

            step = (max - min) / intervars;
            var res = new int[intervars];
            double coeff = step != 0 ? 1 / step : 0;
            foreach (double d in data)
            {
                // Преобразуем значение в индекс интервала по нормированному смещению от минимума.
                int idx = (int)((d - min) * coeff);
                if (idx >= intervars) idx = intervars - 1;
                res[idx]++;
            }

            histArr = res;
            return res;
        }
        #endregion
    }
}
