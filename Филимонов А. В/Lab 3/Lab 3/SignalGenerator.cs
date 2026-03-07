using System;
using ZedGraph;

namespace Lab_3
{
    public class Generator
    {
        //Переислитель для выбора типа сигнала
        public enum SignalType
        {
            sinus, random, normal
        }
        //Объявление экземпляра класса Random
        Random rnd = new Random();
        #region Fields
        public int samples { get; set; } = 500; //Количество отсчетов

        //Количество периодов на заданное количество отсчетов
        public double pediodsCount { get; set; } = 1;
        public double ampl { get; set; } = 1; //Амплитуда
        public double mean { get; set; } = 0; //Математическое ожидание
        public double sigma { get; set; } = 1; //sigma
                                               //Тип генерируемого сигнала
        public SignalType signalType { get; set; } = SignalType.sinus;
        #endregion
        #region Constructors
        public Generator() { }//Конструктор по-умолчанию
        #endregion
        #region Methods
        /// <summary>
        /// Функция генерирования сигн. в соотв. с установленным типом сигнала
        /// </summary>
        /// <returns></returns>
        public double[] GenerateSignal()
        {
            switch (signalType)
            {
                case SignalType.sinus: return GenSin();
                case SignalType.random: return GenRandomSignal();
                case SignalType.normal: return GenNormalSignal();
                default: return null;
            }
        }
        /// <summary>
        /// Функция генерирования синусоидального сигнала
        /// </summary>
        /// <returns></returns> 
        public double[] GenSin()
        {
            double[] arr = new double[samples];
            double coeff = Math.PI * 2 / samples * pediodsCount;
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
            double[] arr = new double[samples];
            for (int i = 0; i < samples; i++)
            {
                arr[i] = RNorm(rnd, mean, sigma) * ampl;
            }
            return arr;

        }


        public double[] GenNoisedSin(double noiselvl=0.5)
        {
            double[] arr = new double[samples];
            var sin = GenSin();
            var noise = GenRandomSignal();
            for (int i = 0;i < samples; i++)
            {
                arr[i] = sin[i] + noise[i]*noiselvl;
            }
            return arr;
        }


        #endregion
    }
}
