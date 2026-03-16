using AForge.Math;
using System;

namespace Lab_3
{
    public class FourierTransform
    {
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
        /// Функция вычисления дискретного преобразования Фурье
        /// </summary>
        /// <param name="data">Входные данные</param>
        /// <param name="dir"> Направление преобразования. Прямое -1, обратное 1</param>
        /// <returns></returns>
        public static Complex[] FT(Complex[] data, int dir = -1)
        {
            int N = data.Length;
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
                }
                //В случае обратного преобразования делить на N
                if (dir > 0) sum /= N;
                res[i] = sum;
            }
            return res;
        }
        /// <summary>
        /// Функция вычисления амплитудного спектра
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
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
        /// Реализация функции БПФурье из библиотеки AForge.
        /// Результат обратного преобразования базовой функции из AForge соответствует реальному результату прямого преобразования
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dir">Направление преобразования. Прямое -1, обратное 1</param>
        public static void FFT(Complex[] data, int dir = -1)
        {
            if (dir == -1)
                AForge.Math.FourierTransform.FFT(data, AForge.Math.FourierTransform.Direction.Backward);
            else
                AForge.Math.FourierTransform.FFT(data, AForge.Math.FourierTransform.Direction.Forward);
        }
    }

}
