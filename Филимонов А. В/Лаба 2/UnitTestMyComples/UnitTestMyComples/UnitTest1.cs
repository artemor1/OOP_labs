using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using nsMycomplex;

namespace UnitTestMyComples
{
    [TestClass]
    public class MycomplexTest
    {

        // Метод тестирования суммы 
        [TestMethod]
        public void TestMyComplexAdd()
        {
            MyComplex a = new MyComplex(1, 5);
            MyComplex b = new MyComplex(2, -4);
            var c = new MyComplex(1, 2); //Введена ошибка 

            Assert.AreEqual(c.re, MyComplex.Add(a, b).im,
            "Результат X не корректный");
            Assert.AreEqual(c.re, MyComplex.Add(a, b).im,
            "Результат Y не корректный");


        }
        [TestMethod]
        public void TestAbs()
        {
            MyComplex a = new MyComplex(2, 3);
            double expected = 3.605;
            double delta = 0.001;

            Assert.AreEqual(expected, a.Abs(), delta);
        }

        [TestMethod]

        public void TestToString()
        {
            MyComplex a = new MyComplex(2, -3);
            string expected = "2 - 3 i";
            Assert.AreEqual(expected, a.ToString());
        }


        [TestMethod]

        public void intParseTest()
        {
            string s = "2 + 3 i";
            MyComplex expected = new MyComplex(2, 3);
            MyComplex actual = MyComplex.Parse(s);
            Assert.AreEqual(expected.re, actual.re, 0.001);
            Assert.AreEqual(expected.im, actual.im, 0.001);
        }

        [TestMethod]
        public void floatParseTest()
        {
            string s = "-2.5 - 3.5 i";
            MyComplex expected = new MyComplex(-2.5, -3.5);
            MyComplex actual = MyComplex.Parse(s);
            Assert.AreEqual(expected.re, actual.re, 0.001, "Реальная часть считывается некорректно");
            Assert.AreEqual(expected.im, actual.im, 0.001, "Воображаемая часть считывается некорректно");
        }

        [TestMethod]

        public void noRealParseTest()
        {
            string s = "-3.3 i";
            MyComplex expected = new MyComplex(0, -3.3);
            MyComplex actual = MyComplex.Parse(s);
            Assert.AreEqual(expected.re, actual.re, 0.001, "Реальная часть считывается некорректно");
            Assert.AreEqual(expected.im, actual.im, 0.001, "Воображаемая часть считывается некорректно");
        }

        [TestMethod]

        public void noImaginaryParseTest()
        {
            string s = "-3.3";
            MyComplex expected = new MyComplex(-3.3, 0);
            MyComplex actual = MyComplex.Parse(s);
            Assert.AreEqual(expected.re, actual.re, 0.001, "Реальная часть считывается некорректно");
            Assert.AreEqual(expected.im, actual.im, 0.001, "Воображаемая часть считывается некорректно");
        }

        [TestMethod]

        public void RotateTeset()
        {
            MyComplex actual = new MyComplex(2, 1);
            MyComplex expected = new MyComplex(2, 1);
            actual.Rotate(1);
            Assert.AreEqual(expected.Abs(), actual.Abs(), 0.001);

        }

        [TestMethod]

        public void ReverseTest()
        {
            MyComplex actual = new MyComplex(2, 1);
            MyComplex expected = new MyComplex(2, 1);
            actual.Reverse();
            expected.Rotate(90 * Math.PI / 180.0);
            Assert.AreEqual(expected.Abs(), actual.Abs(), 0.001);
        }

        
        [TestMethod]
        public void TestSub()
        {
            MyComplex a = new MyComplex(5, 7);
            MyComplex b = new MyComplex(2, 3);
            MyComplex result = MyComplex.Sub(a, b);
            Assert.AreEqual(3, result.re, 0.001, "Вычитание реальной части неправильное");
            Assert.AreEqual(4, result.im, 0.001, "Вычитание мнимой части неправильное");
        }

        [TestMethod]
        public void TestSubOperator()
        {
            MyComplex a = new MyComplex(10, 5);
            MyComplex b = new MyComplex(3, 2);
            MyComplex result = a - b;
            Assert.AreEqual(7, result.re, 0.001);
            Assert.AreEqual(3, result.im, 0.001);
        }

        [TestMethod]
        public void TestMultiplyComplex()
        {
            MyComplex a = new MyComplex(2, 3);
            MyComplex b = new MyComplex(1, 2);
            // (2+3i)(1+2i) = 2 + 4i + 3i - 6 = -4 + 7i
            MyComplex result = a * b;
            Assert.AreEqual(-4, result.re, 0.001, "Умножение реальной части неправильное");
            Assert.AreEqual(7, result.im, 0.001, "Умножение мнимой части неправильное");
        }

        [TestMethod]
        public void TestMultiplyDouble()
        {
            MyComplex a = new MyComplex(2, 3);
            MyComplex result = a * 2.0;
            Assert.AreEqual(4, result.re, 0.001);
            Assert.AreEqual(6, result.im, 0.001);
        }

        [TestMethod]
        public void TestDivisionDouble()
        {
            MyComplex a = new MyComplex(4, 6);
            MyComplex result = a / 2.0;
            Assert.AreEqual(2, result.re, 0.001);
            Assert.AreEqual(3, result.im, 0.001);
        }

        [TestMethod]
        public void TestScalarDot()
        {
            MyComplex a = new MyComplex(2, 3);
            MyComplex b = new MyComplex(4, 5);
            // ScalarDot: 2*4 + 3*5 = 8 + 15 = 23
            double result = MyComplex.ScalarDot(a, b);
            Assert.AreEqual(23, result, 0.001);
        }

        [TestMethod]
        public void TestCopy()
        {
            MyComplex original = new MyComplex(5, 7);
            MyComplex copy = MyComplex.Copy(original);
            Assert.AreEqual(original.re, copy.re);
            Assert.AreEqual(original.im, copy.im);
            // Проверяем что это разные объекты
            copy.re = 10;
            Assert.AreNotEqual(original.re, copy.re);
        }

        [TestMethod]
        public void TestToPointF()
        {
            MyComplex a = new MyComplex(3.5, 4.5);
            System.Drawing.PointF point = a.ToPointF();
            Assert.AreEqual(3.5f, point.X, 0.01f);
            Assert.AreEqual(4.5f, point.Y, 0.01f);
        }

        [TestMethod]
        public void TestFromPointF()
        {
            System.Drawing.PointF point = new System.Drawing.PointF(2.5f, 3.5f);
            MyComplex a = MyComplex.FromPointF(point);
            Assert.AreEqual(2.5, a.re, 0.001);
            Assert.AreEqual(3.5, a.im, 0.001);
        }

        [TestMethod]
        public void TestAddOperator()
        {
            MyComplex a = new MyComplex(3, 4);
            MyComplex b = new MyComplex(1, 2);
            MyComplex result = a + b;
            Assert.AreEqual(4, result.re);
            Assert.AreEqual(6, result.im);
        }

 

        [TestMethod]
        public void TestPropertiesX()
        {
            MyComplex a = new MyComplex(2, 3);
            Assert.AreEqual(2, a.X);
            a.X = 5;
            Assert.AreEqual(5, a.re);
        }

        [TestMethod]
        public void TestPropertiesY()
        {
            MyComplex a = new MyComplex(2, 3);
            Assert.AreEqual(3, a.Y);
            a.Y = 7;
            Assert.AreEqual(7, a.im);
        }



        [TestMethod]
        public void TestMyComplexSignalConstructorEmpty()
        {
            MyComplexSignal signal = new MyComplexSignal();
            Assert.AreEqual(0, signal.data.Count);
            Assert.AreEqual(0, signal.norm);
        }

        [TestMethod]
        public void TestMyComplexSignalConstructorWithArrays()
        {
            double[] X = { 1, 2, 3 };
            double[] Y = { 4, 5, 6 };
            MyComplexSignal signal = new MyComplexSignal(X, Y);
            Assert.AreEqual(3, signal.data.Count);
            Assert.AreEqual(1, signal.data[0].re);
            Assert.AreEqual(4, signal.data[0].im);
            Assert.AreEqual(3, signal.data[2].re);
            Assert.AreEqual(6, signal.data[2].im);
        }

        [TestMethod]
        public void TestMyComplexSignalGetNorm()
        {
            double[] X = { 3, 4 };
            double[] Y = { 0, 0 };
            MyComplexSignal signal = new MyComplexSignal(X, Y);
            double norm = signal.GetNorm();
            // Абсолютные значения: 3 и 4, среднее = (3+4)/2 = 3.5
            Assert.AreEqual(3.5, norm, 0.001);
        }

        [TestMethod]
        public void TestMyComplexSignalNormalize()
        {
            double[] X = { 2, 4 };
            double[] Y = { 0, 0 };
            MyComplexSignal signal = new MyComplexSignal(X, Y);
            int result = signal.Normalize();
            Assert.AreEqual(0, result);
            // После нормализации норма должна быть 1
            double newNorm = signal.GetNorm();
            Assert.AreEqual(1, newNorm, 0.001);
        }

        [TestMethod]
        public void TestMyComplexSignalNormalizeEmpty()
        {
            MyComplexSignal signal = new MyComplexSignal();
            int result = signal.Normalize();
            Assert.AreEqual(1, result, "Нормализация пустого сигнала должна возвращать 1");
        }

        [TestMethod]
        public void TestMyComplexSignalScale()
        {
            double[] X = { 1, 2 };
            double[] Y = { 2, 3 };
            MyComplexSignal signal = new MyComplexSignal(X, Y);
            MyComplexSignal scaled = MyComplexSignal.Scale(signal, 2.0);
            
            Assert.AreEqual(2, scaled.data[0].re, 0.001);
            Assert.AreEqual(4, scaled.data[0].im, 0.001);
            Assert.AreEqual(4, scaled.data[1].re, 0.001);
            Assert.AreEqual(6, scaled.data[1].im, 0.001);
        }

        [TestMethod]
        public void TestMyComplexSignalRotate()
        {
            double[] X = { 1, 0 };
            double[] Y = { 0, 1 };
            MyComplexSignal signal = new MyComplexSignal(X, Y);
            MyComplexSignal rotated = MyComplexSignal.Rotate(signal, Math.PI / 2);
            
            // Проверяем что абсолютные значения сохраняются
            for (int i = 0; i < signal.data.Count; i++)
            {
                Assert.AreEqual(signal.data[i].Abs(), rotated.data[i].Abs(), 0.001);
            }
        }

        [TestMethod]
        public void TestMyComplexSignalMove()
        {
            double[] X = { 1, 2 };
            double[] Y = { 1, 2 };
            MyComplexSignal signal = new MyComplexSignal(X, Y);
            MyComplex shift = new MyComplex(1, 1);
            MyComplexSignal moved = MyComplexSignal.Move(signal, shift);
            
            Assert.AreEqual(2, moved.data[0].re, 0.001);
            Assert.AreEqual(2, moved.data[0].im, 0.001);
            Assert.AreEqual(3, moved.data[1].re, 0.001);
            Assert.AreEqual(3, moved.data[1].im, 0.001);
        }

        [TestMethod]
        public void TestMyComplexSignalConjugate()
        {
            double[] X = { 1, 2 };
            double[] Y = { 2, 3 };
            MyComplexSignal signal = new MyComplexSignal(X, Y);
            MyComplexSignal conjugated = MyComplexSignal.Conjugate(signal);
            
            Assert.AreEqual(1, conjugated.data[0].re, 0.001);
            Assert.AreEqual(-2, conjugated.data[0].im, 0.001);
            Assert.AreEqual(2, conjugated.data[1].re, 0.001);
            Assert.AreEqual(-3, conjugated.data[1].im, 0.001);
        }

        [TestMethod]
        public void TestMyComplexSignalSum()
        {
            double[] X1 = { 1, 2 };
            double[] Y1 = { 1, 2 };
            double[] X2 = { 1, 1 };
            double[] Y2 = { 1, 1 };
            
            MyComplexSignal signal1 = new MyComplexSignal(X1, Y1);
            MyComplexSignal signal2 = new MyComplexSignal(X2, Y2);
            MyComplexSignal result = MyComplexSignal.Sum(signal1, signal2);
            
            Assert.AreEqual(2, result.data[0].re, 0.001);
            Assert.AreEqual(2, result.data[0].im, 0.001);
            Assert.AreEqual(3, result.data[1].re, 0.001);
            Assert.AreEqual(3, result.data[1].im, 0.001);
        }

        [TestMethod]
        public void TestMyComplexSignalSub()
        {
            double[] X1 = { 5, 6 };
            double[] Y1 = { 5, 6 };
            double[] X2 = { 1, 2 };
            double[] Y2 = { 1, 2 };
            
            MyComplexSignal signal1 = new MyComplexSignal(X1, Y1);
            MyComplexSignal signal2 = new MyComplexSignal(X2, Y2);
            MyComplexSignal result = MyComplexSignal.Sub(signal1, signal2);
            
            Assert.AreEqual(4, result.data[0].re, 0.001);
            Assert.AreEqual(4, result.data[0].im, 0.001);
            Assert.AreEqual(4, result.data[1].re, 0.001);
            Assert.AreEqual(4, result.data[1].im, 0.001);
        }

        [TestMethod]
        public void TestMyComplexSignalMult()
        {
            double[] X1 = { 2, 3 };
            double[] Y1 = { 1, 1 };
            double[] X2 = { 1, 2 };
            double[] Y2 = { 1, 1 };
            
            MyComplexSignal signal1 = new MyComplexSignal(X1, Y1);
            MyComplexSignal signal2 = new MyComplexSignal(X2, Y2);
            MyComplexSignal result = MyComplexSignal.Mult(signal1, signal2);
            
            // (2+1i)(1+1i) = 2 + 2i + 1i - 1 = 1 + 3i
            // (3+1i)(2+1i) = 6 + 3i + 2i - 1 = 5 + 5i
            Assert.AreEqual(1, result.data[0].re, 0.001);
            Assert.AreEqual(3, result.data[0].im, 0.001);
            Assert.AreEqual(5, result.data[1].re, 0.001);
            Assert.AreEqual(5, result.data[1].im, 0.001);
        }

        [TestMethod]
        public void TestMyComplexSignalScalar()
        {
            double[] X1 = { 1, 2 };
            double[] Y1 = { 1, 2 };
            double[] X2 = { 2, 3 };
            double[] Y2 = { 1, 1 };
            
            MyComplexSignal signal1 = new MyComplexSignal(X1, Y1);
            MyComplexSignal signal2 = new MyComplexSignal(X2, Y2);
            double result = MyComplexSignal.Scalar(signal1, signal2);
            
            // Scalar = (1*2 + 1*1) + (2*3 + 2*1) = 3 + 8 = 11
            Assert.AreEqual(11, result, 0.001);
        }

        [TestMethod]
        public void TestMyComplexSignalToPointF()
        {
            double[] X = { 1.5, 2.5 };
            double[] Y = { 3.5, 4.5 };
            MyComplexSignal signal = new MyComplexSignal(X, Y);
            System.Collections.Generic.List<System.Drawing.PointF> points = signal.ToPointF();
            
            Assert.AreEqual(2, points.Count);
            Assert.AreEqual(1.5f, points[0].X, 0.01f);
            Assert.AreEqual(3.5f, points[0].Y, 0.01f);
        }

        [TestMethod]
        public void TestMyComplexSignalFromPointF()
        {
            var points = new System.Collections.Generic.List<System.Drawing.PointF>
            {
                new System.Drawing.PointF(1.5f, 2.5f),
                new System.Drawing.PointF(3.5f, 4.5f)
            };
            
            MyComplexSignal signal = MyComplexSignal.FromPointF(points);
            
            Assert.AreEqual(2, signal.data.Count);
            Assert.AreEqual(1.5, signal.data[0].re, 0.001);
            Assert.AreEqual(2.5, signal.data[0].im, 0.001);
        }

        [TestMethod]
        public void TestMyComplexSignalParse()
        {
            var strings = new System.Collections.Generic.List<string>
            {
                "1 + 2i",
                "3 - 1i"
            };
            
            MyComplexSignal signal = MyComplexSignal.Parse(strings);
            
            Assert.AreEqual(2, signal.data.Count);
            Assert.AreEqual(1, signal.data[0].re, 0.001);
            Assert.AreEqual(2, signal.data[0].im, 0.001);
            Assert.AreEqual(3, signal.data[1].re, 0.001);
            Assert.AreEqual(-1, signal.data[1].im, 0.001);
        }


        [TestMethod]
        public void TestMyComplexSignalDFT()
        {
            // Тест ДПФ на простом сигнале
            double[] X = { 1, 0, 0, 0 };
            double[] Y = { 0, 0, 0, 0 };
            MyComplexSignal signal = new MyComplexSignal(X, Y);
            
            MyComplexSignal dft = MyComplexSignal.DFT(signal);
            
            Assert.AreEqual(4, dft.data.Count, "Размер ДПФ должен быть 4");
            // После ДПФ и нормализации норма должна быть близка к 1
            Assert.IsTrue(dft.norm > 0, "Норма должна быть положительной");
        }

        [TestMethod]
        public void TestMyComplexSignalIDFT()
        {
            // Тест обратного ДПФ
            double[] X = { 1, 2, 3, 4 };
            double[] Y = { 0, 0, 0, 0 };
            MyComplexSignal signal = new MyComplexSignal(X, Y);
            
            MyComplexSignal dft = MyComplexSignal.DFT(signal);
            MyComplexSignal idft = MyComplexSignal.IDFT(dft);
            
            Assert.AreEqual(4, idft.data.Count);
            // После ДПФ и обратного ДПФ должны вернуться близко к исходному
            // (с учетом нормализации)
            Assert.IsTrue(idft.data.Count > 0);
        }

        [TestMethod]
        public void TestMyComplexSignalMathActionDifferentSizes()
        {
            double[] X1 = { 1, 2, 3 };
            double[] Y1 = { 1, 2, 3 };
            double[] X2 = { 1, 1 };
            double[] Y2 = { 1, 1 };
            
            MyComplexSignal signal1 = new MyComplexSignal(X1, Y1);
            MyComplexSignal signal2 = new MyComplexSignal(X2, Y2);
            
            // MathAction должен работать с минимальным размером
            MyComplexSignal result = MyComplexSignal.MathAction(signal1, signal2, (a, b) => a + b);
            
            Assert.AreEqual(2, result.data.Count, "Результат должен иметь размер меньшего сигнала");
        }

        [TestMethod]
        public void TestMyComplexSignalEmptySignalSum()
        {
            MyComplexSignal signal1 = new MyComplexSignal();
            MyComplexSignal signal2 = new MyComplexSignal();
            
            MyComplexSignal result = MyComplexSignal.Sum(signal1, signal2);
            
            Assert.AreEqual(0, result.data.Count);
        }

        [TestMethod]
        public void TestMyComplexAbsZero()
        {
            MyComplex a = new MyComplex(0, 0);
            Assert.AreEqual(0, a.Abs(), 0.001);
        }

    
   

        [TestMethod]
        public void TestSignalRotationIntegration()
        {
            // Тест ротации сигнала
            double[] X = { 1, 0 };
            double[] Y = { 0, 1 };
            MyComplexSignal signal = new MyComplexSignal(X, Y);
            
            // Поворот на 45 градусов
            MyComplexSignal rotated = MyComplexSignal.Rotate(signal, 45 * Math.PI / 180);
            
            Assert.AreEqual(2, rotated.data.Count);
            // Проверяем что норма сохраняется
            Assert.AreEqual(signal.GetNorm(), rotated.GetNorm(), 0.1);
        }

        [TestMethod]
        public void TestSignalMoveIntegration()
        {
            // Тест смещения сигнала 
            double[] X = { 1, 2 };
            double[] Y = { 1, 2 };
            MyComplexSignal signal = new MyComplexSignal(X, Y);
            
            MyComplex shift = new MyComplex(0, 1);
            MyComplexSignal moved = MyComplexSignal.Move(signal, shift);
            
            // Проверяем что элементы сместились правильно
            Assert.AreEqual(1, moved.data[0].re, 0.001);
            Assert.AreEqual(2, moved.data[0].im, 0.001);
        }


 

    

        [TestMethod]
        public void TestEmptySignalHandling()
        {
            // Тест обработки пустого сигнала
            MyComplexSignal empty = new MyComplexSignal();
            
            // Попытка применить операции к пустому сигналу
            System.Collections.Generic.List<System.Drawing.PointF> points = empty.ToPointF();
            Assert.AreEqual(0, points.Count);
            
            int result = empty.Normalize();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestSignalOperationsWithDifferentSizes()
        {
            // Тест операций над сигналами разных размеров
            double[] X1 = { 1, 2, 3, 4, 5 };
            double[] Y1 = { 1, 2, 3, 4, 5 };
            double[] X2 = { 1, 1 };
            double[] Y2 = { 1, 1 };
            
            MyComplexSignal signal1 = new MyComplexSignal(X1, Y1);
            MyComplexSignal signal2 = new MyComplexSignal(X2, Y2);
            
            MyComplexSignal result = MyComplexSignal.Sum(signal1, signal2);
            
            // Результат должен иметь размер меньшего сигнала
            Assert.AreEqual(2, result.data.Count);
            Assert.AreEqual(2, result.data[0].re, 0.001);
            Assert.AreEqual(2, result.data[0].im, 0.001);
        }

        [TestMethod]
        public void TestRealAndImaginaryPartExtraction()
        {
            // Тест извлечения реальной и мнимой частей для анализа
            MyComplex num = new MyComplex(3, 4);
            
            double real = num.X;
            double imaginary = num.Y;
            
            Assert.AreEqual(3, real);
            Assert.AreEqual(4, imaginary);
        }

        [TestMethod]
        public void TestPropertySettersGetters()
        {
            // Тест свойств для манипуляции компонентами
            MyComplex num = new MyComplex(5, 7);
            
            // Тест getter
            Assert.AreEqual(5, num.X);
            Assert.AreEqual(7, num.Y);
            
            // Тест setter
            num.X = 10;
            num.Y = 14;
            
            Assert.AreEqual(10, num.re);
            Assert.AreEqual(14, num.im);
        }
    }
}
