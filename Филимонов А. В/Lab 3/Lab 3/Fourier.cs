using AForge.Math;
using System;
using System.Diagnostics;

namespace Lab_3
{
    public class FourierTransform
    {
        public static Complex[] Double2Complex(double[] data)
        {
            Debug.WriteLine($"[FourierTransform.Double2Complex] Start. dataLength={(data == null ? 0 : data.Length)}");
            if (data == null)
            {
                Debug.WriteLine("[FourierTransform.Double2Complex] data is NULL. Return empty array.");
                return new Complex[0];
            }

            Complex[] res = new Complex[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                res[i].Im = 0;
                res[i].Re = data[i];
                if (i < 3)
                {
                    Debug.WriteLine($"[FourierTransform.Double2Complex] sample i={i}, re={res[i].Re:F6}, im={res[i].Im:F6}");
                }
            }
            Debug.WriteLine($"[FourierTransform.Double2Complex] Completed. outputLength={res.Length}");
            return res;
        }
        /// <summary>
        /// Функция вычисления дискретного преобразования Фурье
        /// </summary>
        /// <param name="data">Входные данные</param>
        /// <param name="dir"> Направление преобразования. Прямое -1, обратное 1</param>
        /// <returns></returns>
        public static Complex[] FT(Complex[] data, int dir = -1)
        {
            Debug.WriteLine($"[FourierTransform.FT] Start. dataLength={(data == null ? 0 : data.Length)}, dir={dir}");
            if (data == null)
            {
                Debug.WriteLine("[FourierTransform.FT] data is NULL. Return empty array.");
                return new Complex[0];
            }

            if (dir != -1 && dir != 1)
            {
                Debug.WriteLine($"[FourierTransform.FT] Invalid dir={dir}. Expected -1 or 1.");
            }

            int N = data.Length;
            if (N == 0)
            {
                Debug.WriteLine("[FourierTransform.FT] data is empty. Return empty array.");
                return new Complex[0];
            }

            var res = new Complex[N];
            Complex sum = Complex.Zero;
            double cos = 0, sin = 0;
            double cf = 2 * Math.PI / N;
            for (int i = 0; i < N; i++)
            {
                sum = Complex.Zero;
                for (int j = 0; j < N; j++)
                {
                    cos = Math.Cos(cf * i * j);
                    sin = Math.Sin(cf * i * j);
                    sum.Re += (data[j].Re * cos) - dir * (data[j].Im * sin);
                    sum.Im += (data[j].Im * cos) + dir * (data[j].Re * sin);

                    if (i < 2 && j < 3)
                    {
                        Debug.WriteLine($"[FourierTransform.FT] sample i={i}, j={j}, cos={cos:F6}, sin={sin:F6}, partial=({sum.Re:F6}; {sum.Im:F6})");
                    }
                }
                //В случае обратного преобразования делить на N
                if (dir > 0) sum /= N;
                res[i] = sum;

                if (i < 3)
                {
                    Debug.WriteLine($"[FourierTransform.FT] sample result[{i}] = ({res[i].Re:F6}; {res[i].Im:F6})");
                }
            }
            Debug.WriteLine($"[FourierTransform.FT] Completed. outputLength={res.Length}");
            return res;
        }
        /// <summary>
        /// Функция вычисления амплитудного спектра
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double[] AmplSpectrum(Complex[] data)
        {
            Debug.WriteLine($"[FourierTransform.AmplSpectrum] Start. dataLength={(data == null ? 0 : data.Length)}");
            if (data == null)
            {
                Debug.WriteLine("[FourierTransform.AmplSpectrum] data is NULL. Return empty array.");
                return new double[0];
            }

            int N = data.Length;
            var res = new double[N];
            for (int i = 0; i < N; i++)
            {
                res[i] = Math.Sqrt(data[i].Re * data[i].Re + data[i].Im * data[i].Im);
                if (i < 3)
                {
                    Debug.WriteLine($"[FourierTransform.AmplSpectrum] sample i={i}, ampl={res[i]:F6}");
                }
            }
            Debug.WriteLine($"[FourierTransform.AmplSpectrum] Completed. outputLength={res.Length}");
            return res;
        }
        /// <summary>
        /// Реализация функции БПФурье из библиотеки AForge.
        /// Результат обратного преобразования базовой функции из AForge соответствует реальному результату прямого преобразования
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dir">Направление преобразования. Прямое -1, обратное 1</param>
        public static void FFT(Complex[] data, int dir = -1)
        {
            Debug.WriteLine($"[FourierTransform.FFT] Start. dataLength={(data == null ? 0 : data.Length)}, dir={dir}");
            if (data == null)
            {
                Debug.WriteLine("[FourierTransform.FFT] data is NULL. Skip transform.");
                return;
            }

            if (data.Length == 0)
            {
                Debug.WriteLine("[FourierTransform.FFT] data is empty. Skip transform.");
                return;
            }

            if (dir == -1)
                AForge.Math.FourierTransform.FFT(data, AForge.Math.FourierTransform.Direction.Backward);
            else
                AForge.Math.FourierTransform.FFT(data, AForge.Math.FourierTransform.Direction.Forward);

            var previewCount = Math.Min(3, data.Length);
            for (int i = 0; i < previewCount; i++)
            {
                Debug.WriteLine($"[FourierTransform.FFT] sample result[{i}] = ({data[i].Re:F6}; {data[i].Im:F6})");
            }
            Debug.WriteLine($"[FourierTransform.FFT] Completed. outputLength={data.Length}");
        }
    }

}
