using System;

namespace Lab_3
{
    internal class MLS
    {
        public static int[] MakeMSequence(int[] polinom)
        {
            int k = polinom.Length;
            int N = (int)Math.Pow(2, k) - 1;
            //Сопровождающая матрица
            var am = new int[k, k];
            am[0, k - 1] = polinom[0];
            for (int r = 1; r < k; r++)
            {
                am[r, r - 1] = 1;
                am[r, k - 1] = polinom[r];
            }
            //Формирование вектор-столбца
            int[] X = new int[k];
            X[0] = 1;
            //Выходная матрица
            int[,] C = new int[N, k];
            C[0, 0] = 1;
            int[] Xtmp = new int[k];
            int j = 1;
            while (j < N)
            {
                //Умножение матрицы на столбец
                for (int r = 0; r < k; r++)
                {
                    Xtmp[r] = 0;
                    for (int c = 0; c < k; c++)
                        Xtmp[r] += am[r, c] * X[c];
                }
                for (int r = 0; r < k; r++)
                {
                    X[r] = Xtmp[r] % 2;
                    C[j, r] = X[r];
                }
                j++;
            }
            int[] res = new int[N];
            for (int r = 0; r < N; r++)
                res[r] = C[r, 0] * 2 - 1;
            return res;
        }


    }
}
