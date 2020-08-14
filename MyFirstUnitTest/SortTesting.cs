using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyFirstUnitTest
{
    [TestClass]
    public class SortTesting
    {

        [TestMethod]
        //Metodo de prueba BubbleSort
        public void BubbleSortNumbers()
        {
            //Arrange: Organizar
            var elementos = new int[] { 1, -5, 4, 10, -9, 1, 0, 20, -8, 100, 1 };
            var elementosEsperados = new[] { -9, -8, -5, 0, 1, 1, 1, 4, 10, 20, 100 };

            //Act: Actuar
            var elementosOrdenados = BubbleSorting.BubbleSort(elementos);

            //Assert: Afirmar
            CollectionAssert.AreEqual(elementosOrdenados, elementosEsperados);

        }

        //Metodo de prueba ShellSort
        [TestMethod]
        public void ShellSortNumbers()
        {
            //Arrange: Organizar
            var elementos = new int[] { 1, -5, 4, 10, -9, 1, 0, 20, -8, 100, 1 };
            var elementosEsperados = new[] { -9, -8, -5, 0, 1, 1, 1, 4, 10, 20, 100 };

            //Act: Actuar
            var elementosOrdenados = ShellSorting.ShellSort(elementos);

            //Assert: Afirmar
            CollectionAssert.AreEqual(elementosOrdenados, elementosEsperados);

        }

        //Metodo de prueba HeapSort
        [TestMethod]
        public void HeapSortNumbers()
        {
            //Arrange: Organizar
            var elementos = new int[] { 1, -5, 4, 10, -9, 1, 0, 20, -8, 100, 1 };
            var elementosEsperados = new[] { -9, -8, -5, 0, 1, 1, 1, 4, 10, 20, 100 };

            //Act: Actuar
            var elementosOrdenados = HeapSorting.HeapSort(elementos);

            //Assert: Afirmar
            CollectionAssert.AreEqual(elementosOrdenados, elementosEsperados);

        }

        //Metodo de prueba QuickSort
        [TestMethod]
        public void QuickSortNumbers()
        {
            //Arrange: Organizar
            var elementos = new int[] { 1, -5, 4, 10, -9, 1, 0, 20, -8, 100, 1 };
            var elementosEsperados = new[] { -9, -8, -5, 0, 1, 1, 1, 4, 10, 20, 100 };

            int n = elementos.Length;

            //Act: Actuar
            var elementosOrdenados = QuickSorting.QuickSort(elementos, 0, n-1);

            //Assert: Afirmar
            CollectionAssert.AreEqual(elementosOrdenados, elementosEsperados);

        }
    }
}
