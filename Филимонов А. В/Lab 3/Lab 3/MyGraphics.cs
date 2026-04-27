using System.Diagnostics;
using ZedGraph;

namespace Lab_3
{
    /// <summary>
    /// Вспомогательный класс для отрисовки сигналов, спектров и гистограмм в <see cref="ZedGraphControl"/>.
    /// </summary>
    internal class MyGraphics
    {
        /// <summary>
        /// Тип представления графика: линия или столбцы.
        /// </summary>
        public enum GraphType
        {
            line,
            stick
        }

        /// <summary>
        /// Отрисовывает график по массиву вещественных отсчётов.
        /// </summary>
        /// <param name="zgc">Контрол для вывода графика.</param>
        /// <param name="source">Исходные данные сигнала/спектра.</param>
        /// <param name="type">Тип визуализации.</param>
        public static void DrawGraph(ZedGraphControl zgc, double[] source, GraphType type)
        {
            Debug.WriteLine($"[MyGraphics.DrawGraph<double>] Start. sourceLength={(source == null ? 0 : source.Length)}, type={type}");
            if (zgc == null)
            {
                Debug.WriteLine("[MyGraphics.DrawGraph<double>] zedGraphControl is NULL. Skip draw.");
                return;
            }

            if (source == null)
            {
                Debug.WriteLine("[MyGraphics.DrawGraph<double>] source is NULL. Clear graph and exit.");
                zgc.GraphPane.CurveList.Clear();
                zgc.AxisChange();
                zgc.Invalidate();
                return;
            }

            zgc.GraphPane.CurveList.Clear();
            var ppl = new PointPairList();
            for (int i = 0; i < source.Length; i++)
            {
                ppl.Add(i, source[i]);
                if (i < 3)
                {
                    Debug.WriteLine($"[MyGraphics.DrawGraph<double>] sample point i={i}, y={source[i]:F6}");
                }
            }

            switch (type)
            {
                case GraphType.line:
                    zgc.GraphPane.AddCurve("Signal", ppl, System.Drawing.Color.Red, SymbolType.None);
                    break;
                case GraphType.stick:
                    zgc.GraphPane.AddBar("Spectrum", ppl, System.Drawing.Color.Green);
                    break;
            }

            zgc.AxisChange();
            zgc.Invalidate();
            Debug.WriteLine($"[MyGraphics.DrawGraph<double>] Completed. points={ppl.Count}, type={type}");
        }

        /// <summary>
        /// Отрисовывает график с привязкой к частоте дискретизации.
        /// </summary>
        public static void DrawGraph(ZedGraphControl zgc, double[] source, GraphType type, int freqSampling)
        {
            Debug.WriteLine($"[MyGraphics.DrawGraph<double>] Start. sourceLength={(source == null ? 0 : source.Length)}, type={type}, freqSampling={freqSampling}");
            if (zgc == null)
            {
                Debug.WriteLine("[MyGraphics.DrawGraph<double>] zedGraphControl is NULL. Skip draw.");
                return;
            }

            if (source == null)
            {
                Debug.WriteLine("[MyGraphics.DrawGraph<double>] source is NULL. Clear graph and exit.");
                zgc.GraphPane.CurveList.Clear();
                zgc.AxisChange();
                zgc.Invalidate();
                return;
            }

            zgc.GraphPane.CurveList.Clear();
            var ppl = new PointPairList();
            switch (type)
            {
                case GraphType.line:
                    double stepTime = 1.0 / Math.Max(freqSampling, 1);
                    for (int i = 0; i < source.Length; i++)
                    {
                        ppl.Add(i * stepTime, source[i]);
                        if (i < 3)
                        {
                            Debug.WriteLine($"[MyGraphics.DrawGraph<double>] sample line point x={i * stepTime:F6}, y={source[i]:F6}");
                        }
                    }
                    zgc.GraphPane.AddCurve("Signal", ppl, System.Drawing.Color.Red, SymbolType.None);
                    break;
                case GraphType.stick:
                    double stepSpectrum = (double)Math.Max(freqSampling, 1) / Math.Max(source.Length, 1);
                    for (int i = 0; i < source.Length; i++)
                    {
                        ppl.Add(i * stepSpectrum, source[i]);
                        if (i < 3)
                        {
                            Debug.WriteLine($"[MyGraphics.DrawGraph<double>] sample stick point x={i * stepSpectrum:F6}, y={source[i]:F6}");
                        }
                    }
                    zgc.GraphPane.AddBar("Spectrum", ppl, System.Drawing.Color.Green);
                    break;
            }

            zgc.AxisChange();
            zgc.Invalidate();
            Debug.WriteLine($"[MyGraphics.DrawGraph<double>] Completed. points={ppl.Count}, type={type}");
        }

        /// <summary>
        /// Отрисовывает график по целочисленному массиву (например, гистограмме).
        /// </summary>
        /// <param name="zgc">Контрол для вывода графика.</param>
        /// <param name="source">Исходные целочисленные данные.</param>
        /// <param name="type">Тип визуализации.</param>
        public static void DrawGraph(ZedGraphControl zgc, int[] source, GraphType type)
        {
            Debug.WriteLine($"[MyGraphics.DrawGraph<int>] Start. sourceLength={(source == null ? 0 : source.Length)}, type={type}");
            if (zgc == null)
            {
                Debug.WriteLine("[MyGraphics.DrawGraph<int>] zedGraphControl is NULL. Skip draw.");
                return;
            }

            if (source == null)
            {
                Debug.WriteLine("[MyGraphics.DrawGraph<int>] source is NULL. Clear graph and exit.");
                zgc.GraphPane.CurveList.Clear();
                zgc.AxisChange();
                zgc.Invalidate();
                return;
            }

            zgc.GraphPane.CurveList.Clear();
            var ppl = new PointPairList();
            for (int i = 0; i < source.Length; i++)
            {
                ppl.Add(i, source[i]);
                if (i < 3)
                {
                    Debug.WriteLine($"[MyGraphics.DrawGraph<int>] sample point i={i}, y={source[i]}");
                }
            }

            switch (type)
            {
                case GraphType.line:
                    zgc.GraphPane.AddCurve("Signal", ppl, System.Drawing.Color.Red, SymbolType.None);
                    break;
                case GraphType.stick:
                    zgc.GraphPane.AddBar("Spectrum", ppl, System.Drawing.Color.Green);
                    break;
            }

            zgc.AxisChange();
            zgc.Invalidate();
            Debug.WriteLine($"[MyGraphics.DrawGraph<int>] Completed. points={ppl.Count}, type={type}");
        }
    }
}
