using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Lab_3
{
    /// <summary>
    /// Расчет спектра через оконное преобразование Фурье.
    /// </summary>
    public static class Spectrum
    {
        public static async Task<double[]> CalculateSpectrumWindow(double[] source, double[] window, int intersection, IProgress<int> progress)
        {
            Debug.WriteLine($"[Spectrum.CalculateSpectrumWindow] Start. sourceLength={(source == null ? 0 : source.Length)}, windowLength={(window == null ? 0 : window.Length)}, intersection={intersection}");
            if (source == null || window == null || source.Length == 0 || window.Length == 0 || intersection <= 0)
            {
                return new double[0];
            }

            int N = source.Length;
            int wN = window.Length;
            var res = new double[wN];
            int partsCount = Math.Max(1, intersection * N / wN);
            List<double[]> parts = new List<double[]>(partsCount);
            double pbStep = 100.0 / partsCount;

            Task task = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < partsCount; i++)
                {
                    var part = BuildWindowedPart(source, window, i * wN / intersection);
                    var tmp = FourierTransform.AmplSpectrum(part);
                    parts.Add(tmp);
                    progress?.Report((int)(pbStep * (i + 1)));
                }
            });

            await task;

            foreach (var a in parts)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    res[i] += a[i];
                }
            }

            double coeff = partsCount > 1 ? 1.0 / (partsCount * wN * intersection) : 1.0;
            for (int i = 0; i < res.Length; i++)
            {
                res[i] *= coeff;
            }

            Debug.WriteLine($"[Spectrum.CalculateSpectrumWindow] Completed. partsCount={partsCount}, outputLength={res.Length}");
            return res;
        }

        public static async Task<double[]> CalculateSpectrumWindowParallel(double[] source, double[] window, int intersection, IProgress<int> progress)
        {
            Debug.WriteLine($"[Spectrum.CalculateSpectrumWindowParallel] Start. sourceLength={(source == null ? 0 : source.Length)}, windowLength={(window == null ? 0 : window.Length)}, intersection={intersection}");
            if (source == null || window == null || source.Length == 0 || window.Length == 0 || intersection <= 0)
            {
                return new double[0];
            }

            int N = source.Length;
            int wN = window.Length;
            var res = new double[wN];
            int partsCount = Math.Max(1, intersection * N / wN);
            var parts = new ConcurrentBag<double[]>();

            double incrementStep = 100.0 / partsCount;
            int pbStep = 1;
            int inc = 0;
            if (incrementStep > 1)
            {
                inc = (int)Math.Round(1.0 / incrementStep);
            }
            else
            {
                pbStep = (int)Math.Max(1, Math.Truncate(1 / incrementStep));
                inc = 1;
            }

            Task task = Task.Factory.StartNew(() =>
            {
                Parallel.For(0, partsCount, i =>
                {
                    var part = BuildWindowedPart(source, window, i * wN / intersection);
                    var tmp = FourierTransform.AmplSpectrum(part);
                    parts.Add(tmp);

                    if (progress != null && (i % pbStep) == 0)
                    {
                        progress.Report(inc);
                    }
                });
            });

            await task;

            foreach (var a in parts)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    res[i] += a[i];
                }
            }

            Debug.WriteLine($"[Spectrum.CalculateSpectrumWindowParallel] Completed. partsCount={partsCount}, outputLength={res.Length}");
            return res;
        }

        public static double BinToFrequency(int index, int samplingFrequency, int windowSize)
        {
            if (windowSize <= 0) return 0;
            return (double)index * samplingFrequency / windowSize;
        }

        private static double[] BuildWindowedPart(double[] source, double[] window, int shift)
        {
            int N = source.Length;
            int wN = window.Length;
            var part = new double[wN];
            for (int j = 0; j < wN; j++)
            {
                if ((shift + j) >= N)
                {
                    break;
                }

                part[j] = source[shift + j] * window[j];
            }

            return part;
        }
    }
}
