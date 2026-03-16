using AForge.Math;
using System;

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
            Complex[] res = new Complex[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                res[i].Im = 0;
                res[i].Re = data[i];
            }
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
            int N = data.Length;
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
                }

                // Для обратного преобразования применяется нормировка 1/N.
                if (dir > 0) sum /= N;
                res[i] = sum;
            }
            return res;
        }

        /// <summary>
        /// Вычисляет амплитудный спектр комплексного сигнала.
        /// </summary>
        /// <param name="data">Комплексные спектральные отсчёты.</param>
        /// <returns>Модуль каждого комплексного отсчёта спектра.</returns>
        public static double[] AmplSpectrum(Complex[] data)
        {
            int N = data.Length;
            var res = new double[N];
            for (int i = 0; i < N; i++)
            {
                res[i] = Math.Sqrt(data[i].Re * data[i].Re + data[i].Im * data[i].Im);
            }
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
            if (dir == -1)
                AForge.Math.FourierTransform.FFT(data, AForge.Math.FourierTransform.Direction.Backward);
            else
                AForge.Math.FourierTransform.FFT(data, AForge.Math.FourierTransform.Direction.Forward);
        }
    }
}
