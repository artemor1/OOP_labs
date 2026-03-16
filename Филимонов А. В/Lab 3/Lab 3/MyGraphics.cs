using System.Diagnostics;
using ZedGraph;

namespace Lab_3
{
    internal class MyGraphics
    {
        public enum GraphType
        {
            line, stick
        }

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
