using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace CalculadoraMatrices.Test
{
    [TestClass]
    public class CuandoMultiplicoDosMatrices
    {
        [TestMethod]
        public void SiMatrizA3X2YMatrizB2X4EntoncesMatrizAXB3X4()
        {
            int rows = 3;
            int columns = 4;

            int[,] a = new int[3, 2];
            int[,] b = new int[2, 4];

            Calculadora calculadora = new Calculadora();

            int[,] matrizAXB = calculadora.Multiplicar(a, b);

            Assert.AreEqual(rows, matrizAXB.GetLength(0));
            Assert.AreEqual(columns, matrizAXB.GetLength(1));
        }

        [TestMethod]
        public void EnParaleloEsMasRapidoQueEnSecuencia()
        {
            int rows = 1000;
            int columns = 1000;
            int inters = 500;

            int[,] a = Calculadora.CrearMatriz(rows, inters);
            int[,] b = Calculadora.CrearMatriz(inters, columns);

            Calculadora calculadora = new Calculadora();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //Todo: Your code here
            calculadora.Multiplicar(a, b);

            stopwatch.Stop();
            var secuencial = stopwatch.ElapsedTicks;

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();

            calculadora.MultiplicarParalelo(a, b);
            stopwatch1.Stop();
            var paralelo = stopwatch1.ElapsedTicks;

            Assert.IsTrue(secuencial > paralelo);
        }
    }
}
