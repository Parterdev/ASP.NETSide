using System;
using System.Threading.Tasks;

namespace CalculadoraMatrices.Test
{
    internal class Calculadora
    {
        internal static int[,] CrearMatriz(int rows, int columns)
        {
            var generador = new Random();
            int[,] resultado = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < columns; j++)
                {
                    resultado[i, j] = generador.Next(10, 90);
                }
            }

            return resultado;
        }

        internal int[,] Multiplicar(int[,] a, int[,] b)
        {
            //Reasignacion
            int[,] matrizA = a;
            int[,] matrizB = b;

            int matACols = matrizA.GetLength(1);
            int matBCols = matrizB.GetLength(1);
            int matARows = matrizA.GetLength(0);
            int[,] resultado = new int[matARows, matBCols];

            for (int i = 0; i < matARows; i++)
            {
                for (int j = 0; j < matBCols; j++)
                {
                    int temp = 0;
                    for (int k = 0; k < matACols; k++)
                    {
                        temp += matrizA[i, k] * matrizB[k, j];
                    }
                    resultado[i, j] = temp;
                }
            }
            return resultado;
        }

        internal int[,] MultiplicarParalelo(int[,] a, int[,] b)
        {
            //Reasignacion
            int[,] matrizA = a;
            int[,] matrizB = b;

            int matACols = matrizA.GetLength(1);
            int matBCols = matrizB.GetLength(1);
            int matARows = matrizA.GetLength(0);
            int[,] resultado = new int[matARows, matBCols];

            Parallel.For(0, matARows, i =>
            // for (int i = 0; i < matARows; i++)
            {
                for (int j = 0; j < matBCols; j++)
                {
                    int temp = 0;
                    for (int k = 0; k < matACols; k++)
                    {
                        temp += matrizA[i, k] * matrizB[k, j];
                    }
                    resultado[i, j] = temp;
                }
            });

            return resultado;
        }
    }
}