using AForge.Math;
using System;
using System.Diagnostics;

namespace Lab_3
{
    /// <summary>
    /// Предоставляет операции дискретного преобразования Фурье и расчёта амплитудного спектра.
    /// Используется для частотного анализа сигналов и сравнения с реализацией FFT из AForge.
    /// </summary>
    public class FourierTransform
    {
        /// <summary>
        /// Преобразует вещественный сигнал в комплексную форму для последующего Фурье-анализа.
        /// </summary>
        /// <param name="data">Вещественные отсчёты сигнала.</param>
        /// <returns>Комплексный массив с нулевой мнимой частью.</returns>
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
        /// Вычисляет дискретное преобразование Фурье (ДПФ) для комплексного сигнала.
        /// </summary>
        /// <param name="data">Входные комплексные отсчёты.</param>
        /// <param name="dir">Направление преобразования: прямое <c>-1</c>, обратное <c>1</c>.</param>
        /// <returns>Результат ДПФ в комплексной форме.</returns>
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
            double cf = 2 * Math.PI / N;
            for (int i = 0; i < N; i++)
            {
                Complex sum = Complex.Zero;
                for (int j = 0; j < N; j++)
                {
                    double cos = Math.Cos(cf * i * j);
                    double sin = Math.Sin(cf * i * j);
                    sum.Re += (data[j].Re * cos) - dir * (data[j].Im * sin);
                    sum.Im += (data[j].Im * cos) + dir * (data[j].Re * sin);

                    if (i < 2 && j < 3)
                    {
                        Debug.WriteLine($"[FourierTransform.FT] sample i={i}, j={j}, cos={cos:F6}, sin={sin:F6}, partial=({sum.Re:F6}; {sum.Im:F6})");
                    }
                }

                // Для обратного преобразования применяется нормировка 1/N.
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
        /// Вычисляет амплитудный спектр комплексного сигнала.
        /// </summary>
        /// <param name="data">Комплексные спектральные отсчёты.</param>
        /// <returns>Модуль каждого комплексного отсчёта спектра.</returns>
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
        /// Запускает быстрое преобразование Фурье (FFT) из библиотеки AForge.
        /// </summary>
        /// <param name="data">Массив комплексных отсчётов, изменяется на месте.</param>
        /// <param name="dir">Направление преобразования: прямое <c>-1</c>, обратное <c>1</c>.</param>
        /// <remarks>
        /// В данной работе соглашение по направлениям в AForge инвертировано относительно локального API,
        /// поэтому прямое преобразование (<c>-1</c>) вызывает <see cref="AForge.Math.FourierTransform.Direction.Backward"/>.
        /// </remarks>
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
