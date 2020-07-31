using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyFirstUnitTest
{
    [TestClass]
    public class BubbleSort
    {

        [TestMethod]
        //Primer caso del ejercicio
        public void BubbleSortNumbers()
        {
            //Arrange
            var elementos = new int[] { 1, -5, 4, 10, -9, 1, 0, 20, -8, 100, 1 };
            var elementosEsperados = new int[] { -9, -8, -5, 0, 1, 1, 1, 4, 10, 20, 100 };

            //Act
            var elementosOrdenados = Sorting.SelectionSort(elementos);

            //Assert
            CollectionAssert.AreEqual(elementosOrdenados, elementosEsperados);
        }
      
    }
}
