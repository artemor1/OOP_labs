using System;
using System.Diagnostics;
using System.Numerics;
namespace Mycomplex
{
    public class MyComplex
    {
        #region Fields 

        public double re = 0; //Real 
        public double im = 0; //Image 

        #endregion
        #region Constructors 

        //Конструктор по-умолчанию 
        public MyComplex() { }

        //Конструктор для двух входных значений 
        public MyComplex(double a, double b)
        {
            this.re = a;
            this.im = b;
        }

        #endregion
        #region Methods 

        public double Abs()
        {
            return Math.Sqrt(re * re + im * im);
        }

        public override string ToString()
        {
            if (im < 0) return string.Format($"{re} – {-im} i");
            return string.Format($"{re} + {im} i");
        }

        #endregion
        #region Static methods 

        //Метод сложения 
        public static MyComplex Add(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.re + b.re, a.im + b.im);
        }

        //Оператор сложения с вызовом через оператор + 
        public static MyComplex operator +(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.re + b.re, a.im + b.im);
        }

        public static MyComplex Sub(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.re - b.re, a.im - b.im);
        }

        public static MyComplex operator -(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.re - b.re, a.im - b.im);
        }

        //Оператор умножения 
        // 
        public static MyComplex operator *(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.re * b.re - a.im * b.im, a.re * b.im + a.im * b.re);
        }


        //Сложение с double 
        public static MyComplex operator *(MyComplex a, double b)
        {
            return new MyComplex(a.re * b, a.im * b);
        }

        //Скалярное произведение
        public double ScalarDot(MyComplex a, MyComplex b)
        {
            return a.X * b.X + a.Y * b.Y;
        }


        #endregion
        #region Properties 

        public double X
        {
            get { return re; }
            set { this.re = value; }
        }

        public double Y
        {
            get => im; set => this.im = value;
        }

        #endregion
        #region Parsing

        //Метод для парсинга строки в комплексное число
        public static MyComplex strParse(string s)
        {
            // Удаляем пробелы из строки
            s = s.Replace(" ", "");
            s = s.Replace('.', ','); // Заменяем точку на запятую для корректного парсинга чисел с плавающей точкой
            // Находим позицию знака '+' или '-' для разделения реальной и мнимой части
            int plusIndex = s.IndexOf('+', 1); // Ищем '+' начиная со второго символа
            int minusIndex = s.IndexOf('-', 1); // Ищем '-' начиная со второго символа
            int splitIndex = plusIndex > 0 ? plusIndex : minusIndex; // Выбираем индекс для разделения


            string realPart,imaginaryPart;
            // Если ни '+' ни '-' не найдены, то мнимая или реальная часть отсутствует
            if (splitIndex < 0)
            {   if(s.EndsWith("i")) // Проверяем, заканчивается ли строка на 'i'
                {
                    splitIndex = s.Length - 1; // Устанавливаем индекс разделения на последний символ
                   imaginaryPart = s.Substring(0, splitIndex); // мнимая часть
                    realPart = "0"; // Реальная часть равна 0, если нет реальной части
                }
                else
                {
                    splitIndex = s.Length; // Если нет 'i', то вся строка - это реальная часть
                    imaginaryPart = "0"; // Мнимая часть равна 0
                    realPart = s.Substring(0, splitIndex);
                }
     
            }
            // Разделяем строку на реальную и мнимую части
            else
            {
                realPart = s.Substring(0, splitIndex);
                imaginaryPart = s.Substring(splitIndex, s.Length - splitIndex - 1); // Убираем 'i' в конце
            }

            try
            {
                double re = double.Parse(realPart);
                double im = double.Parse(imaginaryPart);
                return new MyComplex(re, im);
            }
            catch(Exception er)
            {
                Debug.WriteLine($"error={er.ToString()}\n" +
                    $"re ={realPart} im = {imaginaryPart}\n" +
                    $"string={s}\n" +
                    $"splitIndex={splitIndex}");
                return null; // Некорректный формат чисел
            }
       
        }


        #endregion

    }
}
