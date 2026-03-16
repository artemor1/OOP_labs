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
            zgc.GraphPane.CurveList.Clear();
            var ppl = new PointPairList();
            for (int i = 0; i < source.Length; i++)
            {
                ppl.Add(i, source[i]);
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
        }

        /// <summary>
        /// Отрисовывает график по целочисленному массиву (например, гистограмме).
        /// </summary>
        /// <param name="zgc">Контрол для вывода графика.</param>
        /// <param name="source">Исходные целочисленные данные.</param>
        /// <param name="type">Тип визуализации.</param>
        public static void DrawGraph(ZedGraphControl zgc, int[] source, GraphType type)
        {
            zgc.GraphPane.CurveList.Clear();
            var ppl = new PointPairList();
            for (int i = 0; i < source.Length; i++)
            {
                ppl.Add(i, source[i]);
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
        }
    }
}
