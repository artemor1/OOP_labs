using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Mycomplex;

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
            string expected = "2 – 3 i";
            Assert.AreEqual(expected, a.ToString());
        }


        [TestMethod]

        public void intParseTest()
        {
            string s = "2 + 3 i";
            MyComplex expected = new MyComplex(2, 3);
            MyComplex actual = MyComplex.strParse(s);
            Assert.AreEqual(expected.re, actual.re, 0.001);
            Assert.AreEqual(expected.im, actual.im, 0.001);
        }

        [TestMethod]
        public void floatParseTest()
        {
            string s = "-2.5 - 3.5 i";
            MyComplex expected = new MyComplex(-2.5, -3.5);
            MyComplex actual = MyComplex.strParse(s);
            Assert.AreEqual(expected.re, actual.re, 0.001, "Реальная часть считывается некорректно");
            Assert.AreEqual(expected.im, actual.im, 0.001, "Воображаемая часть считывается некорректно");
        }

        [TestMethod]

        public void noRealParseTest()
        {
            string s = "-3.3 i";
            MyComplex expected = new MyComplex(0, -3.3);
            MyComplex actual = MyComplex.strParse(s);
            Assert.AreEqual(expected.re, actual.re, 0.001, "Реальная часть считывается некорректно");
            Assert.AreEqual(expected.im, actual.im, 0.001, "Воображаемая часть считывается некорректно");
        }

        [TestMethod]

       public void noImaginaryParseTest()
        {
            string s = "-3.3";
            MyComplex expected = new MyComplex(-3.3, 0);
            MyComplex actual = MyComplex.strParse(s);
            Assert.AreEqual(expected.re, actual.re, 0.001, "Реальная часть считывается некорректно");
            Assert.AreEqual(expected.im, actual.im, 0.001, "Воображаемая часть считывается некорректно");
        }
    }
}
