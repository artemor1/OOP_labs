using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Reflection;
namespace nsMycomplex
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

        public MyComplex Copy(MyComplex a)
        {
            return new MyComplex(a.X, a.Y);
        }

        public PointF ToPointF()
        {
            return new PointF((float)X, (float)Y);
        }

        public static MyComplex FromPointF(PointF a)
        {
            return new MyComplex((double)(a.X), (double)(a.Y));
        }
        #endregion
        #region Static methods 

        #region summ
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
        #endregion
        #region sub
        public static MyComplex Sub(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.re - b.re, a.im - b.im);
        }

        public static MyComplex operator -(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.re - b.re, a.im - b.im);
        }
        #endregion
        #region mult
        //Оператор умножения 

        public static MyComplex operator *(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.re * b.re - a.im * b.im, a.re * b.im + a.im * b.re);
        }


        //Умножение на double 
        public static MyComplex operator *(MyComplex a, double b)
        {
            return new MyComplex(a.re * b, a.im * b);
        }
        #endregion
        #region div
        
        //Деление на double

        public static MyComplex operator/(MyComplex a, double b)
        {
            return new MyComplex(a.X/ b, a.Y / b);
        }
        #endregion
        #region other
        //Скалярное произведение
        public static double ScalarDot(MyComplex a, MyComplex b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        //Получить противоположный вектор

        public void aReverse()
        {
            re = -re;
            im = -im;
        }

        //Поворот вектора на определённое кол-во радиан
        public void Rotate(double radian)
        {   double oldre = re;
            double oldim = im;
            Debug.WriteLine($"Before rotation: re={re}; im={im}");
            re = (oldre * Math.Cos(radian)) - (oldim * Math.Sin(radian));
            im = (oldim * Math.Cos(radian)) + (oldre* Math.Sin(radian));
            Debug.WriteLine($"after rotation: re={re}; im={im}");
        }
        #endregion

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
        public static MyComplex Parse(string s)
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



    public class MyComplexSignal
    {
        #region Fields 
        public List<MyComplex> data = new List<MyComplex>();
        public double norm = 0;
        #endregion
        #region Constructors
        public MyComplexSignal()
        { }
        public MyComplexSignal(double[] X, double[] Y)
        {
            data = new List<MyComplex>(X.Length);
            for (int i = 0; i < X.Length; i++)
            {
                data.Add(new MyComplex(X[i], Y[i]));
            }
            GetNorm();
        }

        #endregion

        #region Methods 

        public double GetNorm()
        {
            double norm = 0;

            foreach (var v in data)
            {
                norm += v.Abs();
            }
            norm = data.Count > 0 ? norm / data.Count : 0;
            this.norm = norm;
            return norm;
        }
        public int Normalize()
        {
            if (data.Count == 0) return 1;
            double coeff = GetNorm();

            coeff = coeff == 0 ? 0 : 1 / coeff;
            for (int i = 0; i < data.Count; i++)
            {
                data[i] = data[i] * coeff;
            }
            return 0;
        }
        public static MyComplexSignal Scale(MyComplexSignal a, double scale)
        {
            var res = new MyComplexSignal();
            int count = a.data.Count;
            res.data = new List<MyComplex>(count);
            for (int i = 0; i < count; i++)
            {
                res.data.Add(new MyComplex(a.data[i].X * scale, a.data[i].Y * scale));
            }
            res.GetNorm();
            return res;
        }
        //Rotate 
        public static MyComplexSignal Rotate(MyComplexSignal a, double angle)
        {

            var res = new MyComplexSignal();
            foreach (MyComplex item in a.data)
            {
                item.Rotate(angle);
                res.data.Add(item);
            }
            return res;

            /*
             var res = new mycomplexsignal();
            int count = a.data.count;
            mycomplex r = new mycomplex(math.cos(angle), math.sin(angle));
            res.data = new list<mycomplex>(count);
            for (int i = 0; i < count; i++)
            {
                res.data.add(a.data[i] * r);
            }
            res.getnorm();

            return res;*/
        }
        public static MyComplexSignal Move(MyComplexSignal a, MyComplex shift)
        {
            var res = new MyComplexSignal();
            int count = a.data.Count;
            res.data = new List<MyComplex>(count);
            for (int i = 0; i < count; i++)
            {
                res.data.Add(a.data[i] + shift);
            }
            res.GetNorm();
            return res;
        }
        public static MyComplexSignal Conjugate(MyComplexSignal a)
        {
            var res = new MyComplexSignal();
            int count = a.data.Count;
            res.data = new List<MyComplex>(count);
            for (int i = 0; i < count; i++)
            {
                res.data.Add(new MyComplex(a.data[i].X, -a.data[i].Y));
            }
            res.GetNorm();
            return res;
        }

        public static MyComplexSignal MathAction(MyComplexSignal a, MyComplexSignal b, Func<MyComplex, MyComplex, MyComplex> func)
        {
            var res = new MyComplexSignal();
            int count = a.data.Count < b.data.Count ? a.data.Count : b.data.Count;
            res.data = new List<MyComplex>(count);
            for (int i = 0; i < count; i++)
            {
                var tmp = func(a.data[i], b.data[i]);
                res.data.Add(tmp);
            }
            res.GetNorm();
            return res;
        }

        public static double Scalar(MyComplexSignal a, MyComplexSignal b)
        {
            int count = Math.Min(a.data.Count, b.data.Count);
            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += MyComplex.ScalarDot(a.data[i], b.data[i]);
            }

            return sum;

            /*
           var temp = MathAction(a, b,(x,y) => MyComplex.ScalarDot(x,y));
           var sum = new MyComplex(0, 0);
           foreach (var t in temp.data)
           {
               sum = sum + t;
           }
           return sum;
           */
        }

        public static MyComplexSignal Mult(MyComplexSignal a, MyComplexSignal b)
        {
            return MathAction(a, b, (x, y) => x * y);
        }
        public static MyComplexSignal Sum(MyComplexSignal a, MyComplexSignal b)
        {
            return MathAction(a, b, (x, y) => x + y);
        }
        public static MyComplexSignal Sub(MyComplexSignal a, MyComplexSignal b)
        {
            return MathAction(a, b, (x, y) => x - y);
        }



      


        public List<PointF> ToPointF()
        {    
            var res = new List<PointF>(data.Count);
            foreach (var item in data)
            {
                res.Add(item.ToPointF());
            }
            return res;
        }
        public static MyComplexSignal FromPointF(List<PointF> a)
        {
            var res = new MyComplexSignal();  
            foreach(var item in a)
            {
                res.data.Add(MyComplex.FromPointF(item));
            }
            return res;
        }


        public static List<string> ToString(MyComplexSignal a)
        {
            List<string> res = new List<string>(a.data.Count);

            foreach (var item in a.data)
            {
                res.Add(item.ToString());
            }
            return res;
        }
        #endregion
    }
}
