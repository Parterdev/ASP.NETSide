using System;
using System.Collections.Generic;

namespace MyFirstUnitTest
{
    internal class HeapSorting
    {
        public static int[] HeapSort(int[] elementos)
        {
            /**
             * 1.- Definimos el dataset
             * 2.- Determinamos la posicion del ultimo elemento del dataset
             * 3.- Determinamos la posicion del ultimo nodo padre
             * 4.- Determinamos la posicion de los hijos de un nodo padre
             * 5.- Validar que un nodo padre sea el mayor de sus hijos
             * **/

            int[] array = elementos;
            int n = array.Length; //n sera igual a mi array de elementos

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                heapSorting(array, n, i);
            }

            //Extraemos los elementos del heap
            for (int i = n - 1; i > 0; i--)
            {
                //Movemos el actual valor al final
                int aux = array[0];
                array[0] = array[i];
                array[i] = aux;

                //Llamamos a la funcion heapSorting en el heap minimo
                heapSorting(array, i, 0);
            }

            return array;
        }

        //Ejecutamos la funcion heapSorting
        public static int[] heapSorting(int[] array, int n, int i)
        {
           
            int nodeFather = i; //Nodo padre
            //Posiciones de los nodos hijos
            int nodeLeft = 2 * i + 1; //Izquierdo
            int nodeRight = 2 * i + 2; //Derecho

            //Validamos si el nodo hijo izquierdo es mayor que el nodo padre
            if (nodeLeft < n && array[nodeLeft] > array[nodeFather])
            {
                nodeFather = nodeLeft; //El nodo hijo pasa a hacer el padre
            }

            //Validamos si el nodo hijo derecho es mas grande que el actual
            if (nodeRight < n && array[nodeRight] > array[nodeFather])
            {
                nodeFather = nodeRight;
            }

            //Validamos si el mas grande no es el nodo padre
            if (nodeFather != i)
            {
                //Hacemos un cambio
                int swap = array[i];
                array[i] = array[nodeFather];
                array[nodeFather] = swap;

                //Ejecutamos la funcion heapSorting recursivamente al sub-arbol
                heapSorting(array, n, nodeFather);
            }
            return array;
        }
    }
}
