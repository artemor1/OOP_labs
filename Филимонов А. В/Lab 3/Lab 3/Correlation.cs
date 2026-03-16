using System;
using System.Diagnostics;

namespace Lab_3
{
    internal class Correlation
    {
        public static double[] Akf_acycle(double[] s)
        {
            Debug.WriteLine($"[Correlation.Akf_acycle] inputLength={(s == null ? 0 : s.Length)}");
            int N = s.Length;
            var res = new double[N];
            var coeff = 1.0 / N;
            for (int k = 0; k < N; k++)
            {
                var sum = 0.0;
                for (int i = 0; i < N; i++)
                {
                    if ((i + k) > N - 1) continue;
                    sum += s[i] * s[(i + k)];
                }
                res[k] = sum * coeff;
            }
            return res;
        }
        public static double[] Akf(double[] s)
        {
            Debug.WriteLine($"[Correlation.Akf] inputLength={(s == null ? 0 : s.Length)}");
            int N = s.Length;
            var res = new double[N];
            var coeff = 1.0 / N;
            for (int k = 0; k < N; k++)
            {
                var sum = 0.0;
                for (int i = 0; i < N; i++)
                {
                    sum += s[i] * s[(i + k) % N];
                }
                res[k] = sum * coeff;
            }
            return res;
        }
        public static double[] VKF<T>(T[] signal, T[] h)
        {
            #region Input validation and diagnostics
            if (signal == null || h == null)
            {
                Debug.WriteLine("[Correlation.VKF] signal or h is NULL. Return empty array.");
                return new double[0];
            }

            int N = h.Length;
            Debug.WriteLine($"[Correlation.VKF] signalLength={signal.Length}, hLength={h.Length}, N={N}");
            if (signal.Length != h.Length)
            {
                Debug.WriteLine("[Correlation.VKF] WARNING: signal and h lengths differ. Potential index issues.");
            }
            #endregion

            var res = new double[N];
            var coeff = 1.0 / N;
            for (int k = 0; k < N; k++)
            {
                var sum = 0.0;
                for (int i = 0; i < N; i++)
                {
                    if (i >= signal.Length)
                    {
                        Debug.WriteLine($"[Correlation.VKF] i={i} out of signal length={signal.Length}. Break inner loop.");
                        break;
                    }

                    if (k < 2 && i < 3)
                    {
                        Debug.WriteLine($"[Correlation.VKF] sample k={k}, i={i}, signal={signal[i]}, h={h[(i + k) % N]}");
                    }

                    sum += Convert.ToDouble(signal[i]) *
                           Convert.ToDouble(h[(i + k) % N]);
                }
                res[k] = sum * coeff;
            }

            var previewLength = Math.Min(5, res.Length);
            var preview = string.Empty;
            for (int i = 0; i < previewLength; i++)
            {
                preview += $"[{i}]={res[i]:F4} ";
            }
            Debug.WriteLine($"[Correlation.VKF] Completed. outputLength={res.Length}. preview: {preview}");
            return res;
        }


    }
}
