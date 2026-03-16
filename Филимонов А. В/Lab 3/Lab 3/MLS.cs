using System;
using System.Diagnostics;

namespace Lab_3
{
    internal class MLS
    {
        public static int[] MakeMSequence(int[] polinom)
        {
            Debug.WriteLine($"[MLS.MakeMSequence] Start. polinomLength={(polinom == null ? 0 : polinom.Length)}");
            if (polinom == null)
            {
                Debug.WriteLine("[MLS.MakeMSequence] polinom is NULL. Return empty array.");
                return new int[0];
            }

            int k = polinom.Length;
            if (k == 0)
            {
                Debug.WriteLine("[MLS.MakeMSequence] polinom is empty. Return empty array.");
                return new int[0];
            }

            int N = (int)Math.Pow(2, k) - 1;
            Debug.WriteLine($"[MLS.MakeMSequence] Derived params: k={k}, N={N}");
            //Сопровождающая матрица
            var am = new int[k, k];
            am[0, k - 1] = polinom[0];
            for (int r = 1; r < k; r++)
            {
                am[r, r - 1] = 1;
                am[r, k - 1] = polinom[r];
                if (r < 3)
                {
                    Debug.WriteLine($"[MLS.MakeMSequence] sample am row={r}, am[{r},{r - 1}]={am[r, r - 1]}, am[{r},{k - 1}]={am[r, k - 1]}");
                }
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
                    {
                        Xtmp[r] += am[r, c] * X[c];
                    }
                }
                for (int r = 0; r < k; r++)
                {
                    X[r] = Xtmp[r] % 2;
                    C[j, r] = X[r];
                }

                if (j <= 3)
                {
                    Debug.WriteLine($"[MLS.MakeMSequence] sample iteration j={j}, X0={X[0]}");
                }
                j++;
            }
            int[] res = new int[N];
            for (int r = 0; r < N; r++)
            {
                res[r] = C[r, 0] * 2 - 1;
                if (r < 3)
                {
                    Debug.WriteLine($"[MLS.MakeMSequence] sample result[{r}]={res[r]}");
                }
            }

            Debug.WriteLine($"[MLS.MakeMSequence] Completed. outputLength={res.Length}");
            return res;
        }


    }
}
