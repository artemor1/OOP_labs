using nsMycomplex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using ZedGraph;

namespace Lab_3
{
    public class Generator
    {

        //Переислитель для выбора типа сигнала
        public enum SignalType
        {
            sinus, random, normal, AM, FM, PhM
        }
        //Объявление экземпляра класса Random
        Random rnd = new Random();
        #region Fields
        public double noiseLvl { get; set; } = 0.3; // величина шума относительно исходного сигнала
        //Количество отсчетов
        public int samples { get; set; } = 1024;
        //Математическое ожидание
        public double mean { get; set; } = 0;
        //sigma
        public double sigma { get; set; } = 1;
        //Количество периодов на заданное количество отсчетов или частота
        [Category("Гармонические колебания"), DisplayName("Частота сигнала"), Description("")]
        public double freqSignal { get; set; } = 50;
        //Амплитуда
        [Category("Гармонические колебания"), DisplayName("Амплитуда сигнала"), Description("")]
        public double ampl { get; set; } = 1;
        //Модулированные сигналы
        //[Category("Модуляция"), DisplayName("Амплитуда модулирующего сигнала"), Description("")]
        //public double amplModulation { get; set; } = 1;
        [Category("Модуляция"), DisplayName("Частота модулирующего сигнала"), Description("АМ")]
        public double freqModulation { get; set; } = 5;
        [Category("Модуляция"), DisplayName("Коэффициент модуляции"), Description("АМ")]
        public double coeffModulation { get; set; } = 5;
        [Category("Модуляция"), DisplayName("Скорость изменения частоты"), Description("ЧМ")]
        public double freqSpeed { get; set; } = 0.001;
        [Category("Модуляция"), DisplayName("Кол-во периодов на кодовый интервал"), Description("ФМ, АМ")]
        public int periodsPerCodeInterval { get; set; } = 4;
        [Category("Модуляция"), DisplayName("Кодовая последовательность"), Description("ФМ, АМ")]
        public List<int> codeSequence { get; set; } = new List<int>();
        //Тип генерируемого сигнала
        public SignalType signalType { get; set; } = SignalType.sinus;
        #endregion

        #region Methods
        //Метод GenerateSignal дополним
        public double[] GenerateSignal(MyComplexSignal signal)
        {
            Debug.WriteLine($"[Generator.GenerateSignal] type={signalType}, samples={samples}, ampl={ampl}, codeCount={signal?.data?.Count ?? 0}");
            switch (signalType)
            {
                case SignalType.sinus: return GenSin();
                case SignalType.random: return GenRandomSignal();
                case SignalType.normal: return GenNormalSignal();
                case SignalType.AM: return GenAM();
                case SignalType.FM: return GenFM();
                case SignalType.PhM: return GenPhM(signal);
                default: return null;
            }
        }


      
        /// <summary>
        /// Функция генерирования синусоидального сигнала
        /// </summary>
        /// <returns></returns> 
        public double[] GenSin()
        {
            Debug.WriteLine($"[Generator.GenSin] samples={samples}, periodsPerCodeInterval={periodsPerCodeInterval}");
            double[] arr = new double[samples];
            double coeff = Math.PI * 2 / samples * periodsPerCodeInterval;
            for (int i = 0; i < samples; i++)
            {
                arr[i] = Math.Sin(coeff * i);
            }
            return arr;
        }
        /// <summary>
        /// Функция генерирования сигнала, состоящего из случайных чисел
        /// </summary>
        /// <returns></returns>
        public double[] GenRandomSignal()
        {
            Debug.WriteLine($"[Generator.GenRandomSignal] samples={samples}, ampl={ampl}");
            double[] arr = new double[samples];
            for (int i = 0; i < samples; i++)
            {

                arr[i] = rnd.NextDouble() * ampl;
            }
            return arr;
        }
        /// <summary>
        /// Функция генерирования случайного числа, соответствуюего нормальному закону распределения
        /// </summary>
        /// <param name="rnd"></param>
        /// <param name="mo"></param>
        /// <param name="sko"></param>
        /// <returns></returns>
        private static double RNorm(Random rnd, double mo, double sko)
        {
            double val = 0;
            double r, phi, alpha, coeff = 0;
            r = rnd.NextDouble() + double.Epsilon;
            phi = rnd.NextDouble() + double.Epsilon;
            alpha = 2 * Math.PI * phi;
            coeff = Math.Sqrt(-2 * Math.Log(r)) * sko;
            val = Math.Cos(alpha) * coeff + mo;
            return val;
        }
        /// <summary>
        /// Функ. генер. сигнала из случ. чисел, им. нормальное распределение
        /// </summary>
        /// <returns></returns>
        public double[] GenNormalSignal()
        {
            Debug.WriteLine($"[Generator.GenNormalSignal] samples={samples}, mean={mean}, sigma={sigma}, ampl={ampl}");
            double[] arr = new double[samples];
            for (int i = 0; i < samples; i++)
            {
                arr[i] = RNorm(rnd, mean, sigma) * ampl;
            }
            return arr;

        }

        /// <summary>
        /// Добавляет случайный шум к сигналу
        /// </summary>
        /// <param name="signal"></param>
        /// <returns></returns>
        public double[] AddRNoise(double[] signal)
        {
            Debug.WriteLine($"[Generator.AddRNoise] inputLength={(signal == null ? 0 : signal.Length)}, noiseLvl={noiseLvl}");
            var noise = GenRandomSignal();

            // compute mean
            double mean = 0.0;
            for (int i = 0; i < noise.Length; i++)
                mean += noise[i];

            mean /= noise.Length;

            // subtract mean and add noise
            for (int i = 0; i < signal.Length; i++)
                signal[i] += (noise[i] - mean) * noiseLvl;

            return signal;
        }

        public double[] AddNormNoise(double[] signal)
        {
            Debug.WriteLine($"[Generator.AddNormNoise] inputLength={(signal == null ? 0 : signal.Length)}, noiseLvl={noiseLvl}");
            var Noise = GenNormalSignal();
            for (int i = 0; i < signal.Length; i++)
            {
                signal[i] += (Noise[i] - mean )*noiseLvl;
            }
            return signal;
        }

        /// <summary>
        /// Амплитудно-модулированный сигнал
        /// </summary>
        /// <returns></returns>
        public double[] GenAM()
        {
            Debug.WriteLine($"[Generator.GenAM] samples={samples}, freqSignal={freqSignal}, freqModulation={freqModulation}, coeffModulation={coeffModulation}");
            double[] arr = new double[samples];
            double freqStep = Math.PI * 2 / samples * freqSignal;
            double freqMStep = Math.PI * 2 / samples * freqModulation;
            for (int i = 0; i < samples; i++)
            {
                arr[i] = ampl * (1 + coeffModulation * Math.Cos(freqMStep * i)) *
             Math.Cos(freqStep * i);
            }
            return arr;
        }

        /// <summary>
        /// Частотно-манипулированный сигнал
        /// </summary>
        /// <returns></returns>
        public double[] GenFM()
        {
            Debug.WriteLine($"[Generator.GenFM] samples={samples}, freqSignal={freqSignal}, freqModulation={freqModulation}, periodsPerCodeInterval={periodsPerCodeInterval}");
            double[] arr = new double[samples];
            double freqStep = Math.PI * 2 / samples;
            int itrvCount = (int)(freqSignal / periodsPerCodeInterval);
            int ticksCount = samples / itrvCount;
            double phase = 0;
            double curFreq = 1;
            for (int i = 0; i < samples; i++)
            {
                curFreq = ((i / ticksCount) & 1) == 1 ? freqSignal : freqModulation;
                arr[i] = ampl * Math.Cos(curFreq * i);
            }
            return arr;
        }



        public double[] GenPhM(MyComplexSignal signal)
        {
            #region Input diagnostics
            Debug.WriteLine($"[Generator.GenPhM] Start. samples={samples}, signalCount={signal?.data?.Count ?? 0}, freqSignal={freqSignal}, periodsPerCodeInterval={periodsPerCodeInterval}, ampl={ampl}");
            #endregion

            if (signal == null || signal.data == null || signal.data.Count == 0)
            {
                Debug.WriteLine("[Generator.GenPhM] Signal code is empty. Return zero array.");
                return new double[samples];
            }

            double[] arr = new double[samples];
            double freqStep = freqSignal * Math.PI * 2;
            double phase;

            for (int n = 0; n < signal.data.Count; n++)
            {
                Debug.WriteLine($"[Generator.GenPhM] Block n={n}, symbol={signal.data[n]}");
                for (int i = 0; i < samples; i++)
                {
                    phase = n * i;
                    var idx = (i * n) + i;

                    if (idx < 0 || idx >= arr.Length)
                    {
                        Debug.WriteLine($"[Generator.GenPhM] Index out of range. n={n}, i={i}, idx={idx}, arrLength={arr.Length}. Skip write.");
                        continue;
                    }

                    double realPart = (Math.Cos(freqStep * phase * periodsPerCodeInterval) * signal.data[n].re);
                    double imPart = (Math.Sin(freqStep * phase * periodsPerCodeInterval) * signal.data[n].im);
                    arr[idx] = ampl * (realPart + imPart);

                    if (i < 10 || i >= samples - 10)
                    {
                        Debug.WriteLine($"[Generator.GenPhM] n={n}, i={i}, idx={idx}, value={arr[idx]}");
                    }
                }
            }

            Debug.WriteLine($"[Generator.GenPhM] Completed. outputLength={arr.Length}");
            return arr;
        }





        #endregion
    }
}
