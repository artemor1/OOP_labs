using nsMycomplex;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Lab_3
{
    public class Generator
    {
        public enum SignalType
        {
            sinus, random, normal, AM, FM, PhM
        }

        private readonly Random rnd = new Random();

        #region Fields
        public double noiseLvl { get; set; } = 0.3;
        public double mean { get; set; } = 0;
        public double sigma { get; set; } = 1;
        public double ampl { get; set; } = 1;
        public double coeffModulation { get; set; } = 0.5;

        [Category("Параметры сигнала"), DisplayName("Частота дискретизации сигнала"), Description("В герцах")]
        public double samplingFrequency { get; set; } = 1000;

        [Category("Параметры сигнала"), DisplayName("Частота несущей"), Description("В герцах")]
        public double carrierFrequency { get; set; } = 100;

        [Category("Параметры сигнала"), DisplayName("Длина кодового интервала"), Description("в секундах")]
        public double codeIntervalLength { get; set; } = 0.1;



        public SignalType signalType { get; set; } = SignalType.sinus;
        #endregion

        #region Methods
        public double[] GenerateSignal(MyComplexSignal signal)
        {
            switch (signalType)
            {
                case SignalType.sinus: return GenSin();
                case SignalType.random: return GenRandomSignal();
                case SignalType.normal: return GenNormalSignal();
                case SignalType.AM: return GenAM(signal);
                case SignalType.FM: return GenFM(signal);
                case SignalType.PhM: return GenPhM(signal);
                default: return null;
            }
        }

        private int GetSamplesCount(MyComplexSignal signal)
        {
            return (int)(samplingFrequency * codeIntervalLength * (Math.Max(1, signal.data.Count)));
        }

        private int GetSamplesCount(int periods = 1)
        {
            return (int)(samplingFrequency * codeIntervalLength * periods);
        }

        public double[] GenSin(int periods = 1)
        {
            int samplesCount = GetSamplesCount(periods);
            double[] arr = new double[samplesCount];
            double dt = 1.0 / Math.Max(samplingFrequency, double.Epsilon);

            for (int i = 0; i < samplesCount; i++)
            {
                double t = i * dt;
                arr[i] = ampl * Math.Sin(2 * Math.PI * carrierFrequency * t);
            }

            return arr;
        }

        public double[] GenRandomSignal(int periods = 1)
        {
            int samplesCount = GetSamplesCount(periods);
            double[] arr = new double[samplesCount];
            for (int i = 0; i < samplesCount; i++)
            {
                arr[i] = rnd.NextDouble() * ampl;
            }
            return arr;
        }

        private static double RNorm(Random rnd, double mo, double sko)
        {
            double r = rnd.NextDouble() + double.Epsilon;
            double phi = rnd.NextDouble() + double.Epsilon;
            double alpha = 2 * Math.PI * phi;
            double coeff = Math.Sqrt(-2 * Math.Log(r)) * sko;
            return Math.Cos(alpha) * coeff + mo;
        }

        public double[] GenNormalSignal(int periods = 1)
        {
            int samplesCount = GetSamplesCount(periods);
            double[] arr = new double[samplesCount];
            for (int i = 0; i < samplesCount; i++)
            {
                arr[i] = RNorm(rnd, mean, sigma) * ampl;
            }
            return arr;
        }

        public double[] AddRNoise(double[] signal)
        {
            var noise = GenRandomSignal();
            double avg = 0.0;
            for (int i = 0; i < noise.Length; i++) avg += noise[i];
            avg /= noise.Length;

            for (int i = 0; i < signal.Length && i < noise.Length; i++)
            {
                signal[i] += (noise[i] - avg) * noiseLvl;
            }

            return signal;
        }

        public double[] AddNormNoise(double[] signal)
        {
            var noise = GenNormalSignal();
            for (int i = 0; i < signal.Length && i < noise.Length; i++)
            {
                signal[i] += (noise[i] - mean) * noiseLvl;
            }
            return signal;
        }

        public double[] GenAM(MyComplexSignal signal)
        {

            int samplesCount = GetSamplesCount(signal);
            double[] arr = new double[samplesCount];
            int TicksPerInterval = (int)Math.Round(samplingFrequency * codeIntervalLength);
            var carrier = GenSin();
            for (int i = 0; i < signal.data.Count; i++)
            {

                for (int j = 0; j < TicksPerInterval; j++)
                {

                    int t = i * TicksPerInterval + j;
                    arr[t] = carrier[t % TicksPerInterval] * signal.data[i].X;
                    Debug.WriteLine($"[Generator.GenAm] Signal[{t}={i}*{TicksPerInterval}+{j}] = {arr[t]}");

                }

            }
            Debug.WriteLine($"[Generator.GenAm] samples={samplesCount}, codeCount={signal?.data.Count ?? 0}\n");
            return arr;
        }

        public double[] GenFM(MyComplexSignal signal)
        {
            int samplesCount = GetSamplesCount(signal);
            double basefreq = carrierFrequency;
            double changefreq = 0;
            double dt = 1.0 / samplingFrequency;
            int TicksPerInterval = (int)Math.Round(samplingFrequency * codeIntervalLength);
            double[] arr = new double[samplesCount];
            double[] carrier = new double[samplesCount];
            for (int i = 0; i < signal.data.Count; i++)
            {
                changefreq = basefreq * signal.data[i].re;
                for (int j = 0; j < TicksPerInterval; j++)
                {
                    int t = i * TicksPerInterval + j;

                    arr[t] = ampl * Math.Sin(2 * Math.PI * changefreq * dt * t);
                }
            }
            return arr;
        }

        public double[] GenPhM(MyComplexSignal signal)
        {
            int samplesCount = GetSamplesCount(signal);

            double dt = 1.0 / samplingFrequency;
            int TicksPerInterval = (int)Math.Round(samplingFrequency * codeIntervalLength);
            double[] arr = new double[samplesCount];
            for (int i = 0; i < signal.data.Count; i++)
            {
                for (int j = 0; j < TicksPerInterval; j++)
                {

                    int t = i * TicksPerInterval + j;
                    double argument = t * dt * 2 * Math.PI * carrierFrequency;
                    double re = Math.Cos(argument) * signal.data[i].re;
                    double im = Math.Sin(argument) * signal.data[i].im;


                    arr[t] = re + im;
                    Debug.WriteLine($"[Generator.GenPhM] Signal[{t}={i}*{TicksPerInterval}+{j}] = {arr[t]} = re={re} + im = {im}");

                }


            }

            Debug.WriteLine($"[Generator.GenPhM] samples={samplesCount}, codeCount={signal?.data.Count ?? 0}");
            return arr;
        }
        #endregion
    }
}
