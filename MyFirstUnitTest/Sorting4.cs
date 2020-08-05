using Microsoft.Win32.SafeHandles;
using System;

namespace MyFirstUnitTest
{
    internal class Sorting4
    {
        //Metodo de seleccion sort
        public static int[] QuickSort(int[] elementos, int low, int high)
        {
            /**
             * 1.- Creamos una funcion que toma el ultimo elemento como pivote
             * 2.- Colocamos el elemento pivote en su posicion correcta (data set ordenado)
             * 3.- Colocamos los valores menores o pequeños a la izquierda
             * 4.- Colocamos los valoreres mayores a la derecha
             * **/

            int[] array = elementos;
            int n = array.Length; //n sera igual a mi array de elementos
            int pivot = array[high];

            for (var i = 0; i < array.Length; i++)
            {
                var minIndex = i;
                var minValue = array[minIndex];
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < minValue)
                    {
                        minIndex = j;
                        minValue = array[j];
                    }
                }
                //Llamamos a la funcion de intercambio
                Swap(array, i, minIndex);
            }

            return array;
        }

        private static void Swap(int[] array, int firstIndex, int secondIndex)
        {
            if (array[firstIndex] != array[secondIndex])
            {
                array[firstIndex] = array[firstIndex] + array[secondIndex];
                array[secondIndex] = array[firstIndex] - array[secondIndex];
                array[firstIndex] = array[firstIndex] - array[secondIndex];
            }
        }

    }
}
