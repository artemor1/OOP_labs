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
            zgc.GraphPane.CurveList.Clear();
            var ppl = new PointPairList();
            for (int i = 0; i < source.Length; i++)
            {
                ppl.Add(i, source[i]);
            }
            switch (type)
            {
                case GraphType.line:
                    var pane = zgc.GraphPane.AddCurve("Signal", ppl, System.Drawing.Color.Red, SymbolType.None);
                    break;
                case GraphType.stick:
                    var bar = zgc.GraphPane.AddBar("Spectrum", ppl, System.Drawing.Color.Green);
                    break;
            }
            zgc.AxisChange();
            zgc.Invalidate();
        }
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
                    var pane = zgc.GraphPane.AddCurve("Signal", ppl, System.Drawing.Color.Red, SymbolType.None);
                    break;
                case GraphType.stick:
                    var bar = zgc.GraphPane.AddBar("Spectrum", ppl, System.Drawing.Color.Green);
                    break;
            }
            zgc.AxisChange();
            zgc.Invalidate();
        }
    }

}

