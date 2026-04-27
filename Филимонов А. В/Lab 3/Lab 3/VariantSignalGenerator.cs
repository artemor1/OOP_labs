using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab_3
{
    /// <summary>
    /// Генератор вариантных сигналов для задания 6.
    /// u = A(t) * cos(ω(t) * t + φ(t))
    /// </summary>
    public sealed class VariantSignalInfo
    {
        public int Variant { get; set; }
        public string Description { get; set; }
    }

    public static class VariantSignalGenerator
    {
        public static List<VariantSignalInfo> GetVariants()
        {
            return Enumerable.Range(1, 30)
                .Select(v => new VariantSignalInfo { Variant = v, Description = Describe(v) })
                .ToList();
        }

        public static string Describe(int variant)
        {
            switch (variant)
            {
                case 1: return "A(t)=5, w(t)=10^6, phi(t)=0";
                case 2: return "A(t)=cos(100*t), w(t)=10^4, phi(t)=0";
                case 3: return "A(t)=5, w(t)=10^4, phi(t)=piecewise(0, pi, 0)";
                case 4: return "A(t)=5, w(t)=10^4, phi(t)=pi/4";
                case 5: return "A(t)=cos(10*t), w(t)=10^6, phi(t)=pi/3";
                case 6: return "A(t)=5, w(t)=10*t, phi(t)=0";
                case 7: return "A(t)=cos(20*t), w(t)=30*t, phi(t)=pi/3";
                case 8: return "A(t)=cos(20*t), w(t)=30*t, phi(t)=0";
                case 9: return "A(t)=5, w(t)=10^4, phi(t)=piecewise(0, pi, 0)";
                case 10: return "A(t)=cos(20*t), w(t)=10^4, phi(t)=piecewise(0, pi, 0)";
                case 11: return "A(t)=cos(20*t), w(t)=10^4, phi(t)=piecewise(0, pi, 0) on [0,10), [10,20), [20,+inf)";
                case 12: return "A(t)=5, w(t)=10*t, phi(t)=pi/6";
                case 13: return "A(t)=cos(20*t), w(t)=50*t, phi(t)=0";
                case 14: return "A(t)=cos(10*t), w(t)=10^6, phi(t)=pi/3";
                case 15: return "A(t)=cos(30*t), w(t)=50*t, phi(t)=pi/3";
                case 16: return "A(t)=cos(100*t), w(t)=10*t, phi(t)=pi/3";
                case 17: return "A(t)=cos(100*t), w(t)=10*t, phi(t)=0";
                case 18: return "A(t)=5, w(t)=10^6, phi(t)=piecewise(0, pi, 0)";
                case 19: return "A(t)=5, w(t)=10*t, phi(t)=pi/3";
                case 20: return "A(t)=cos(100*t), w(t)=10^4, phi(t)=pi/3";
                case 21: return "A(t)=5, w(t)=10*t, phi(t)=pi/6";
                case 22: return "A(t)=cos(20*t), w(t)=30*t, phi(t)=pi/6";
                case 23: return "A(t)=5, w(t)=30*t, phi(t)=pi/6";
                case 24: return "A(t)=cos(100*t), w(t)=10^4, phi(t)=piecewise(0, pi, 0)";
                case 25: return "A(t)=cos(10*t), w(t)=10^4, phi(t)=piecewise(0, pi, 0)";
                case 26: return "A(t)=cos(10*t), w(t)=10^4, phi(t)=piecewise(0, pi, 0) on [0,10), [10,20), [20,+inf)";
                case 27: return "A(t)=cos(100*t), w(t)=10*t, phi(t)=0";
                case 28: return "A(t)=cos(20*t), w(t)=50*t, phi(t)=pi/6";
                case 29: return "A(t)=cos(30*t), w(t)=10^6, phi(t)=pi/3";
                case 30: return "A(t)=cos(30*t), w(t)=10^6, phi(t)=pi/6";
                default: return "Unsupported";
            }
        }

        public static double[] Generate(int variant, int samplingFrequency, double durationSeconds)
        {
            Debug.WriteLine($"[VariantSignalGenerator.Generate] Start. variant={variant}, samplingFrequency={samplingFrequency}, duration={durationSeconds}");
            if (samplingFrequency <= 0 || durationSeconds <= 0)
            {
                return new double[0];
            }

            int samples = (int)Math.Round(samplingFrequency * durationSeconds);
            var result = new double[samples];
            for (int i = 0; i < samples; i++)
            {
                double t = (double)i / samplingFrequency;
                result[i] = GetAmplitude(variant, t) * Math.Cos(GetOmega(variant, t) * t + GetPhi(variant, t));
            }

            Debug.WriteLine($"[VariantSignalGenerator.Generate] Completed. outputLength={result.Length}");
            return result;
        }

        private static double GetAmplitude(int variant, double t)
        {
            switch (variant)
            {
                case 1:
                case 3:
                case 4:
                case 6:
                case 9:
                case 12:
                case 18:
                case 19:
                case 21:
                case 23:
                    return 5;
                case 2:
                case 16:
                case 17:
                case 20:
                case 24:
                case 27:
                    return Math.Cos(100 * t);
                case 5:
                case 14:
                case 25:
                case 26:
                    return Math.Cos(10 * t);
                case 7:
                case 8:
                case 10:
                case 11:
                case 13:
                case 22:
                case 28:
                    return Math.Cos(20 * t);
                case 15:
                case 29:
                case 30:
                    return Math.Cos(30 * t);
                default:
                    throw new ArgumentOutOfRangeException(nameof(variant));
            }
        }

        private static double GetOmega(int variant, double t)
        {
            switch (variant)
            {
                case 1:
                case 5:
                case 14:
                case 18:
                case 29:
                case 30:
                    return 1000000;
                case 2:
                case 3:
                case 4:
                case 9:
                case 10:
                case 11:
                case 20:
                case 24:
                case 25:
                case 26:
                    return 10000;
                case 6:
                case 12:
                case 16:
                case 17:
                case 19:
                case 21:
                case 27:
                    return 10 * t;
                case 7:
                case 8:
                case 22:
                    return 30 * t;
                case 13:
                case 15:
                case 28:
                    return 50 * t;
                case 23:
                    return 30 * t;
                default:
                    throw new ArgumentOutOfRangeException(nameof(variant));
            }
        }

        private static double GetPhi(int variant, double t)
        {
            switch (variant)
            {
                case 1:
                case 2:
                case 6:
                case 8:
                case 13:
                case 17:
                case 27:
                    return 0;
                case 4:
                    return Math.PI / 4.0;
                case 5:
                case 7:
                case 14:
                case 15:
                case 16:
                case 19:
                case 20:
                case 29:
                    return Math.PI / 3.0;
                case 12:
                case 21:
                case 22:
                case 23:
                case 28:
                case 30:
                    return Math.PI / 6.0;
                case 3:
                case 9:
                case 10:
                case 18:
                case 24:
                case 25:
                    return PiecewisePhi(t, 1, 2);
                case 11:
                case 26:
                    return PiecewisePhi(t, 10, 20);
                default:
                    throw new ArgumentOutOfRangeException(nameof(variant));
            }
        }

        private static double PiecewisePhi(double t, double from, double to)
        {
            if (t >= 0 && t < from) return 0;
            if (t >= from && t < to) return Math.PI;
            return 0;
        }
    }
}
