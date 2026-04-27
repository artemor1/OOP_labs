using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab_3
{
    /// <summary>
    /// Алгоритмы согласованной фильтрации из раздела 3.4.3 методички.
    /// </summary>
    public static class Filtering
    {
        public static int[] GenTestSignal(int[] polinom, List<int> shifts)
        {
            Debug.WriteLine($"[Filtering.GenTestSignal] Start. polinomLength={(polinom == null ? 0 : polinom.Length)}, shiftsCount={(shifts == null ? 0 : shifts.Count)}");
            if (polinom == null || shifts == null || shifts.Count == 0)
            {
                Debug.WriteLine("[Filtering.GenTestSignal] Invalid input. Return empty signal.");
                return new int[0];
            }

            var mSeq = MLS.MakeMSequence(polinom);
            int lenSeq = mSeq.Length;
            int signalLen = (int)((shifts.Max() + lenSeq) * 1.1);

            int[] signal = new int[signalLen];
            foreach (var s in shifts)
            {
                for (int i = 0; i < lenSeq; i++)
                {
                    signal[s + i] += mSeq[i];
                }
            }

            Debug.WriteLine($"[Filtering.GenTestSignal] Completed. mSeqLength={lenSeq}, signalLength={signal.Length}");
            return signal;
        }

        public static double[] MatchedFilter(int[] signal, int[] seq)
        {
            Debug.WriteLine($"[Filtering.MatchedFilter] Start. signalLength={(signal == null ? 0 : signal.Length)}, seqLength={(seq == null ? 0 : seq.Length)}");
            if (signal == null || seq == null || signal.Length == 0 || seq.Length == 0)
            {
                Debug.WriteLine("[Filtering.MatchedFilter] Invalid input. Return empty array.");
                return new double[0];
            }

            int lenSeq = seq.Length;
            int lenSign = signal.Length - lenSeq;
            if (lenSign <= 0)
            {
                Debug.WriteLine("[Filtering.MatchedFilter] Signal is shorter than sequence. Return empty array.");
                return new double[0];
            }

            double[] res = new double[signal.Length];
            for (int s = 0; s < lenSign; s++)
            {
                double sum = 0;
                for (int i = 0; i < lenSeq; i++)
                {
                    sum += signal[s + i] * seq[i];
                }

                res[s] = sum;
                if (s < 3)
                {
                    Debug.WriteLine($"[Filtering.MatchedFilter] sample shift={s}, value={sum:F4}");
                }
            }

            Debug.WriteLine($"[Filtering.MatchedFilter] Completed. outputLength={res.Length}");
            return res;
        }

        public static List<int> FindMax(double[] signal, double threshold)
        {
            Debug.WriteLine($"[Filtering.FindMax] Start. signalLength={(signal == null ? 0 : signal.Length)}, threshold={threshold}");
            var shifts = new List<int>();
            if (signal == null || signal.Length == 0)
            {
                Debug.WriteLine("[Filtering.FindMax] Empty input.");
                return shifts;
            }

            var working = (double[])signal.Clone();
            double max = working.Max();
            int idx = Array.FindIndex(working, i => i == max);
            while (idx >= 0 && max > threshold)
            {
                shifts.Add(idx);
                working[idx] = 0;

                idx = -1;
                max = 0;
                for (int i = 0; i < working.Length; i++)
                {
                    if (working[i] > max)
                    {
                        max = working[i];
                        idx = i;
                    }
                }
            }

            shifts.Sort();
            Debug.WriteLine($"[Filtering.FindMax] Completed. peakCount={shifts.Count}, peaks={string.Join(",", shifts)}");
            return shifts;
        }
    }
}
