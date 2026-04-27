using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab_3
{
    /// <summary>
    /// Оконные функции для спектрального анализа.
    /// </summary>
    public static class WindowFunction
    {
        /// <summary>
        /// Функция генерирования окна Хэмминга.
        /// </summary>
        public static double[] GenHammingWindow(int size = 16384)
        {
            Debug.WriteLine($"[WindowFunction.GenHammingWindow] Start. size={size}");
            if (size <= 0) return new double[0];

            double[] arr = new double[size];
            double cf = 2 * Math.PI / size;
            for (int i = 0; i < size; i++)
            {
                arr[i] = 0.54 - 0.46 * Math.Cos(cf * i);
            }

            Debug.WriteLine($"[WindowFunction.GenHammingWindow] Completed. size={arr.Length}");
            return arr;
        }

        /// <summary>
        /// Универсальная форма окна Blackman/Blackman-Harris/Nuttall.
        /// </summary>
        public static double[] GenBlackmanWindow(int size = 16384, List<double> a = null)
        {
            Debug.WriteLine($"[WindowFunction.GenBlackmanWindow] Start. size={size}, coeffCount={(a == null ? 0 : a.Count)}");
            if (size <= 0) return new double[0];

            if (a == null)
            {
                a = new List<double> { 0.35875, 0.48829, 0.14128, 0.01168 };
            }

            if (a.Count < 2)
            {
                throw new ArgumentException("Coefficient count less than 2");
            }

            double[] arr = new double[size];
            double cf = 2 * Math.PI / size;
            for (int i = 0; i < size; i++)
            {
                double sum = a.First();
                for (int j = 1; j < a.Count; j++)
                {
                    int sign = (j % 2 == 1) ? -1 : 1;
                    sum += sign * a[j] * Math.Cos(cf * j * i);
                }

                arr[i] = sum;
            }

            Debug.WriteLine($"[WindowFunction.GenBlackmanWindow] Completed. size={arr.Length}");
            return arr;
        }
    }
}
