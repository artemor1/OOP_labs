
  //double x = 2.333;
  //double y = 0.969;
  //double z = -1.66;

Console.Write(" x = ");
double x = double.Parse(Console.ReadLine());
Console.Write(" y = ");
double y = double.Parse(Console.ReadLine());
Console.Write(" z = ");
double z = double.Parse(Console.ReadLine());

if (x == 0 || y == 0 || z == 0 || (1 + (x * Math.Abs(y - Math.Tan(z)))) == 0)
    {
        Console.WriteLine(" Не подходит по ОДЗ");
        return 0;
    }

    double a = (Math.Pow(x, y + 1) + Math.Exp(y - 1)) / (1 + (x * Math.Abs(y - Math.Tan(z))));
    double b = 1 + (Math.Abs(y - x) / (Math.Abs(x))) + ((Math.Pow(Math.Abs(y - x), 2)) / Math.Pow(Math.Abs(y), 2)) + ((Math.Pow(Math.Abs(y - x), 3)) / Math.Pow(Math.Abs(z), 3));

    Console.WriteLine(" a = " + a + "\n" + " b = " + b + "\n");
    return 1;
