using LibMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LibMatrix
{
    public static class ExtensionMatrix
    {
        /// <summary>
        /// Èíèöèàëèçàöèÿ ìàòðèöû
        /// </summary>
        /// <param name="matrix">Ìàòðèöà</param>
        /// <param name="min">Ìèíèìàëíîå çíà÷åíèå</param>
        /// <param name="max">Ìàêñèìàëüíîå çíà÷åíèå</param>
        public static void Init(this Matrix<double> matrix, int min = -10, int max = 11)
        {
            Random rnd = new Random();

            for (int i = 0; i < matrix.Column; i++)
            {
                for (int j = 0; j < matrix.Row; j++)
                {
                    matrix[i, j] = (rnd.Next(min, max));
                }
            }
        }

        /// <summary>
        /// Âû÷èñëåíèå ïî çàäàíèþ
        /// </summary>
        /// <param name="matrix">Ìàòðèöà</param>
        public static int Calculate(this Matrix<double> matrix)
        {
            double[] tempMas = new double[matrix.Row];
            int kol = 0;

            for (int i = 0; i < matrix.Column; i++)
            {
                for (int j = 0; j < matrix.Row; j++)
                {
                    tempMas[j] = matrix[i, j];
                }

                var arrat = tempMas.Distinct();
                int x = arrat.Count();
                if (x == matrix.Row)
                    kol++;
            }
            return kol;
        }
    }
}
