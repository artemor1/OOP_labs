using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    internal class Correlation
    {
        public static double[] Akf_acycle(double[] s)
        {
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
            int N = h.Length;
            var res = new double[N];
            var coeff = 1.0 / N;
            for (int k = 0; k < N; k++)
            {
                var sum = 0.0;
                for (int i = 0; i < N; i++)
                {
                    sum += Convert.ToDouble(signal[i]) *
                           Convert.ToDouble(h[(i + k) % N]);
                }
                res[k] = sum * coeff;
            }
            return res;
        }


    }
}
