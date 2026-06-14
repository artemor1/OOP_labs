using System;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Math;

namespace ImageProcessingLab
{
    public static class ImageActions
    {
        // ВСПОМОГАТЕЛЬНЫЙ МЕТОД - ПРИВЕДЕНИЕ К РАЗМЕРУ 
        private static Bitmap ResizeTo(Bitmap source, int targetWidth, int targetHeight)
        {
            if (source.Width == targetWidth && source.Height == targetHeight)
                return source;
            return new Bitmap(source, new Size(targetWidth, targetHeight));
        }

        // ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ДЛЯ СТЕПЕНИ ДВОЙКИ 
        private static int GetNextPowerOfTwo(int x)
        {
            int power = 1;
            while (power < x)
                power <<= 1;
            return power;
        }

        private static Bitmap ResizeToPowerOfTwo(Bitmap source)
        {
            int newW = GetNextPowerOfTwo(source.Width);
            int newH = GetNextPowerOfTwo(source.Height);
            if (newW == source.Width && newH == source.Height)
                return source;
            return new Bitmap(source, new Size(newW, newH));
        }

        // ПРЕОБРАЗОВАНИЕ В ОТТЕНКИ СЕРОГО 
        public static Bitmap Color2Grey_Unsafe(Bitmap source)
        {
            int originalW = source.Width;
            int originalH = source.Height;

            int W = source.Width;
            int H = source.Height;
            Bitmap dest = new Bitmap(W, H, PixelFormat.Format24bppRgb);

            var bmd = source.LockBits(new Rectangle(0, 0, W, H),
                ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            var bmdDest = dest.LockBits(new Rectangle(0, 0, W, H),
                ImageLockMode.ReadWrite, dest.PixelFormat);

            unsafe
            {
                for (int h = 0; h < H; h++)
                {
                    byte* row = (byte*)bmd.Scan0 + h * bmd.Stride;
                    byte* rowDest = (byte*)bmdDest.Scan0 + h * bmdDest.Stride;
                    for (int w = 0; w < W; w++)
                    {
                        byte grey = (byte)(0.2126 * row[w * 3 + 2] + 0.7152 * row[w * 3 + 1] + 0.0722 * row[w * 3]);
                        rowDest[w * 3 + 2] = grey;
                        rowDest[w * 3 + 1] = grey;
                        rowDest[w * 3] = grey;
                    }
                }
            }

            source.UnlockBits(bmd);
            dest.UnlockBits(bmdDest);

            // Возвращаем исходный размер
            return ResizeTo(dest, originalW, originalH);
        }

        // BITMAP В МАССИВ КОМПЛЕКСНЫХ ЧИСЕЛ
        public static Complex[,] Bitmap2ComplexArray(Bitmap source)
        {
            int W = source.Width;
            int H = source.Height;
            var dest = new Complex[H, W];

            var bmd = source.LockBits(new Rectangle(0, 0, W, H),
                ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            unsafe
            {
                for (int h = 0; h < H; h++)
                {
                    byte* row = (byte*)bmd.Scan0 + h * bmd.Stride;
                    for (int w = 0; w < W; w++)
                    {
                        double grey = 0.2126 * row[w * 3 + 2] + 0.7152 * row[w * 3 + 1] + 0.0722 * row[w * 3];
                        dest[h, w] = new Complex(grey, 0);
                    }
                }
            }

            source.UnlockBits(bmd);
            return dest;
        }

        // МАССИВ КОМПЛЕКСНЫХ ЧИСЕЛ В BITMAP 
        public static Bitmap ComplexArray2Bitmap(Complex[,] source)
        {
            int W = source.GetLength(1);
            int H = source.GetLength(0);
            Bitmap dest = new Bitmap(W, H, PixelFormat.Format24bppRgb);

            var bmdDest = dest.LockBits(new Rectangle(0, 0, W, H),
                ImageLockMode.ReadWrite, dest.PixelFormat);

            unsafe
            {
                for (int h = 0; h < H; h++)
                {
                    byte* rowDest = (byte*)bmdDest.Scan0 + h * bmdDest.Stride;
                    for (int w = 0; w < W; w++)
                    {
                        byte grey = (byte)Math.Max(0, Math.Min(255, source[h, w].Re));
                        rowDest[w * 3 + 2] = grey;
                        rowDest[w * 3 + 1] = grey;
                        rowDest[w * 3] = grey;
                    }
                }
            }

            dest.UnlockBits(bmdDest);
            return dest;
        }

        // ВЫЧИСЛЕНИЕ СПЕКТРА (БПФ) 
        public static Bitmap FFT2(Bitmap source)
        {
            int originalW = source.Width;
            int originalH = source.Height;

            Bitmap working = ResizeToPowerOfTwo(source);
            int W = working.Width;
            int H = working.Height;

            var data = Bitmap2ComplexArray(working);

            for (int h = 0; h < H; h++)
                for (int w = 0; w < W; w++)
                {
                    int c = ((h + w) & 1) * (-2) + 1;
                    data[h, w].Re *= c;
                }

            FourierTransform.FFT2(data, FourierTransform.Direction.Backward);

            double maxValue = 0;
            for (int h = 0; h < H; h++)
                for (int w = 0; w < W; w++)
                {
                    data[h, w].Re = Math.Log(1 + data[h, w].Magnitude);
                    data[h, w].Im = 0;
                    if (data[h, w].Re > maxValue) maxValue = data[h, w].Re;
                }

            double coeff = maxValue > 0 ? 255 / maxValue : 0;
            for (int h = 0; h < H; h++)
                for (int w = 0; w < W; w++)
                    data[h, w].Re *= coeff;

            Bitmap result = ComplexArray2Bitmap(data);

            // Возвращаем исходный размер
            return ResizeTo(result, originalW, originalH);
        }

        // НИЗКОЧАСТОТНЫЙ ФИЛЬТР ГАУССА
        public static Complex[,] CreateGaussFilterLF(int W, int H, double sigma)
        {
            var filter = new Complex[H, W];
            if (sigma == 0) return filter;

            double coeff = 1 / (2 * sigma * sigma);
            double halfW = W / 2;
            double halfH = H / 2;

            for (int h = 0; h < H; h++)
                for (int w = 0; w < W; w++)
                {
                    double value = ((h - halfH) * (h - halfH) + (w - halfW) * (w - halfW)) * coeff;
                    filter[h, w].Re = Math.Exp(-value);
                }
            return filter;
        }

        // ВЫСОКОЧАСТОТНЫЙ ФИЛЬТР ГАУССА 
        public static Complex[,] CreateGaussFilterHF(int W, int H, double sigma)
        {
            var filter = new Complex[H, W];
            if (sigma == 0) return filter;

            double coeff = 1 / (2 * sigma * sigma);
            double halfW = W / 2;
            double halfH = H / 2;

            for (int h = 0; h < H; h++)
                for (int w = 0; w < W; w++)
                {
                    double value = ((h - halfH) * (h - halfH) + (w - halfW) * (w - halfW)) * coeff;
                    filter[h, w].Re = 1 - Math.Exp(-value);
                }
            return filter;
        }

        // ФИЛЬТРАЦИЯ В ЧАСТОТНОЙ ОБЛАСТИ 
        public static Bitmap FrequencyFilter(Bitmap source, double sigma, bool isLowPass)
        {
            int originalW = source.Width;
            int originalH = source.Height;

            Bitmap working = ResizeToPowerOfTwo(source);
            int W = working.Width;
            int H = working.Height;

            Complex[,] filter = isLowPass ? CreateGaussFilterLF(W, H, sigma) : CreateGaussFilterHF(W, H, sigma);
            var data = Bitmap2ComplexArray(working);

            for (int h = 0; h < H; h++)
                for (int w = 0; w < W; w++)
                {
                    int c = ((h + w) & 1) * (-2) + 1;
                    data[h, w].Re *= c;
                }

            FourierTransform.FFT2(data, FourierTransform.Direction.Backward);

            for (int h = 0; h < H; h++)
                for (int w = 0; w < W; w++)
                    data[h, w] = data[h, w] * filter[h, w];

            FourierTransform.FFT2(data, FourierTransform.Direction.Forward);

            for (int h = 0; h < H; h++)
                for (int w = 0; w < W; w++)
                {
                    int c = ((h + w) & 1) * (-2) + 1;
                    data[h, w].Re *= c;
                    data[h, w].Im = 0;
                }

            Bitmap result = ComplexArray2Bitmap(data);

            // Возвращаем исходный размер
            return ResizeTo(result, originalW, originalH);
        }

        // ВСПОМОГАТЕЛЬНАЯ ФУНКЦИЯ SHOWFILTER 
        public static Bitmap ShowFilter(Complex[,] source)
        {
            int W = source.GetLength(1);
            int H = source.GetLength(0);
            var temp = new Complex[H, W];
            for (int h = 0; h < H; h++)
                for (int w = 0; w < W; w++)
                    temp[h, w].Re = source[h, w].Re * 255;
            return ComplexArray2Bitmap(temp);
        }

        // ПРОСТРАНСТВЕННАЯ ФИЛЬТРАЦИЯ 
        public static Bitmap DoGaussSpatialFilterViaFourier(Bitmap source, bool isLowPass)
        {
            int originalW = source.Width;
            int originalH = source.Height;

            int W = source.Width;
            int H = source.Height;

            double[,] filter;
            if (isLowPass)
            {
                filter = new double[,]
                {
                    { 1.0/25, 1.0/25, 1.0/25, 1.0/25, 1.0/25 },
                    { 1.0/25, 1.0/25, 1.0/25, 1.0/25, 1.0/25 },
                    { 1.0/25, 1.0/25, 1.0/25, 1.0/25, 1.0/25 },
                    { 1.0/25, 1.0/25, 1.0/25, 1.0/25, 1.0/25 },
                    { 1.0/25, 1.0/25, 1.0/25, 1.0/25, 1.0/25 }
                };
            }
            else
            {
                filter = new double[,] { { -1, -1, -1 },
                                          { -1,  8, -1 },
                                          { -1, -1, -1 } };
            }

            var sarr = Bitmap2ComplexArray(source);
            var destArr = new Complex[H, W];

            int filterSize = isLowPass ? 5 : 3;
            int offset = filterSize / 2;

            for (int h = offset; h < H - offset; h++)
                for (int w = offset; w < W - offset; w++)
                {
                    double sum = 0;
                    for (int y = 0; y < filterSize; y++)
                        for (int x = 0; x < filterSize; x++)
                            sum += sarr[h + y - offset, w + x - offset].Re * filter[y, x];

                    if (isLowPass)
                        destArr[h, w].Re = sum;
                    else
                        destArr[h, w].Re = Math.Max(0, Math.Min(255, sum + 128));
                }

            for (int h = 0; h < H; h++)
                for (int w = 0; w < W; w++)
                    if (h < offset || h >= H - offset || w < offset || w >= W - offset)
                        destArr[h, w].Re = sarr[h, w].Re;

            Bitmap result = ComplexArray2Bitmap(destArr);

            // Возвращаем исходный размер
            return ResizeTo(result, originalW, originalH);
        }

        // ПРОСТРАНСТВЕННЫЙ НИЗКОЧАСТОТНЫЙ ФИЛЬТР 
        public static Bitmap SpatialLowpassFilter(Bitmap source)
        {
            return DoGaussSpatialFilterViaFourier(source, true);
        }

        // ПРОСТРАНСТВЕННЫЙ ВЫСОКОЧАСТОТНЫЙ ФИЛЬТР 
        public static Bitmap SpatialHighpassFilter(Bitmap source)
        {
            return DoGaussSpatialFilterViaFourier(source, false);
        }

        // ПОИСК ФРАГМЕНТА В ПРОСТРАНСТВЕННОЙ ОБЛАСТИ
        public static (Bitmap bmp, Point p) FindPositionSpatial(Bitmap source, Bitmap filter)
        {
            int originalW = source.Width;
            int originalH = source.Height;

            var sarr = Bitmap2ComplexArray(source);
            int H = sarr.GetLength(0);
            int W = sarr.GetLength(1);

            var farr = Bitmap2ComplexArray(filter);
            int fH = farr.GetLength(0);
            int fW = farr.GetLength(1);

            var darr = new Complex[H, W];
            int rangeH = H - fH;
            int rangeW = W - fW;
            double sum = 0;
            var max = new Point();

            for (int h = 0; h < rangeH; h++)
            {
                for (int w = 0; w < rangeW; w++)
                {
                    sum = 0;
                    for (int y = 0; y < fH; y++)
                        for (int x = 0; x < fW; x++)
                            sum += sarr[h + y, w + x].Re * farr[y, x].Re;

                    darr[h, w].Re = sum;
                    if (sum > darr[max.Y, max.X].Re)
                    {
                        max.Y = h;
                        max.X = w;
                    }
                }
            }

            double coeff = darr[max.Y, max.X].Re > 0 ? 255 / darr[max.Y, max.X].Re : 0;
            for (int h = 0; h < rangeH; h++)
                for (int w = 0; w < rangeW; w++)
                    darr[h, w].Re *= coeff;

            Bitmap result = ComplexArray2Bitmap(darr);

            // Возвращаем исходный размер
            return (ResizeTo(result, originalW, originalH), max);
        }

        // ПОИСК ФРАГМЕНТА В ЧАСТОТНОЙ ОБЛАСТИ 
        private static Complex[,] AddZeroValues(Complex[,] source, int newW, int newH)
        {
            var result = new Complex[newH, newW];
            int oldH = source.GetLength(0);
            int oldW = source.GetLength(1);
            for (int h = 0; h < oldH; h++)
                for (int w = 0; w < oldW; w++)
                    result[h, w] = source[h, w];
            return result;
        }

        public static (Bitmap bmp, Point p) FindPosition(Bitmap source, Bitmap filter)
        {
            int originalW = source.Width;
            int originalH = source.Height;

            // Приводим оба изображения к одинаковому размеру (степень двойки)
            int size = 512;

            Bitmap sourceResized = new Bitmap(source, new Size(size, size));
            Bitmap filterResized = new Bitmap(filter, new Size(size, size));

            var sarr = Bitmap2ComplexArray(sourceResized);
            var farr = Bitmap2ComplexArray(filterResized);

            // Вычисление спектров
            FourierTransform.FFT2(sarr, FourierTransform.Direction.Backward);
            FourierTransform.FFT2(farr, FourierTransform.Direction.Backward);

            // Перемножение спектров
            for (int h = 0; h < size; h++)
            {
                for (int w = 0; w < size; w++)
                {
                    var cc = sarr[h, w];
                    sarr[h, w].Re = (cc.Re * farr[h, w].Re + cc.Im * farr[h, w].Im);
                    sarr[h, w].Im = (cc.Im * farr[h, w].Re - cc.Re * farr[h, w].Im);
                }
            }

            // Обратное БПФ
            FourierTransform.FFT2(sarr, FourierTransform.Direction.Forward);

            // Поиск максимума
            Point max = new Point();
            for (int h = 0; h < size; h++)
            {
                for (int w = 0; w < size; w++)
                {
                    if (sarr[h, w].Re > sarr[max.Y, max.X].Re)
                    {
                        max.X = w;
                        max.Y = h;
                    }
                }
            }

            // Масштабируем координаты обратно к исходному размеру
            float scaleX = (float)originalW / size;
            float scaleY = (float)originalH / size;
            int originalX = (int)(max.X * scaleX);
            int originalY = (int)(max.Y * scaleY);

            // Нормализация для отображения
            double maxVal = sarr[max.Y, max.X].Re;
            double coeff = maxVal > 0 ? 255 / maxVal : 0;
            for (int h = 0; h < size; h++)
                for (int w = 0; w < size; w++)
                    sarr[h, w].Re *= coeff;

            Bitmap result = ComplexArray2Bitmap(sarr);

            // Рисуем рамку в месте найденного фрагмента
            using (Graphics g = Graphics.FromImage(result))
            {
                int fW = (int)(filter.Width * scaleX);
                int fH = (int)(filter.Height * scaleY);
                g.DrawRectangle(new Pen(Color.Red, 3), originalX, originalY, fW, fH);
            }

            // Возвращаем исходный размер
            return (ResizeTo(result, originalW, originalH), new Point(originalX, originalY));
        }
    }
}