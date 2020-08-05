using System;

namespace MyFirstUnitTest
{
    internal class BubbleSorting
    {
        //Metodo de seleccion sort
        public static int[] BubbleSort(int[] elementos)
        {
            /**
             * 1.- Comenzamos a realizar comparaciones de elementos adyacentes
             * 2.- Repetimos hasta tener una pasada completa del ciclo sin ningun swap (cambio)
             * **/

            //Realizamos una asignacion de elementos a la variable array
            int[] array = elementos;
            int n = array.Length;
            //El primer for va a recorrer todo nuestro set de elementos
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    //Cambiar elementos adyacentes
                    if (array[j] > array[j + 1])
                    {
                        //Declarar un auziliar
                        int aux = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = aux;

                    }
                }
            }

            return array;

        }


    }
}
