using System;
using System.Diagnostics;
using System.Linq;

namespace Lab_3
{
    /// <summary>
    /// Статистики сигнала для задания 2 из раздела 3.
    /// </summary>
    public sealed class SignalStatisticsResult
    {
        public int Count { get; set; }
        public double Mean { get; set; }
        public double Variance { get; set; }
        public double StandardDeviation { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Range => Max - Min;
    }

    public static class SignalStatistics
    {
        public static SignalStatisticsResult Calculate(double[] source)
        {
            Debug.WriteLine($"[SignalStatistics.Calculate<double>] Start. sourceLength={(source == null ? 0 : source.Length)}");
            if (source == null || source.Length == 0)
            {
                return new SignalStatisticsResult();
            }

            double mean = source.Average();
            double variance = source.Select(x => (x - mean) * (x - mean)).Average();
            double std = Math.Sqrt(variance);

            var result = new SignalStatisticsResult
            {
                Count = source.Length,
                Mean = mean,
                Variance = variance,
                StandardDeviation = std,
                Min = source.Min(),
                Max = source.Max()
            };

            Debug.WriteLine($"[SignalStatistics.Calculate<double>] Completed. mean={result.Mean:F6}, variance={result.Variance:F6}, std={result.StandardDeviation:F6}");
            return result;
        }

        public static SignalStatisticsResult Calculate(System.Collections.Generic.IEnumerable<double> source)
        {
            return Calculate(source?.ToArray());
        }
    }
}
