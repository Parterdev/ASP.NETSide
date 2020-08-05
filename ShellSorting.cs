using System;
using System.Collections.Generic;

namespace MyFirstUnitTest
{
    internal class ShellSorting
    {
        public static int[] ShellSort(int[] elementos)
        {

            /**
             * 1.- Definimos el dataset
             * 2.- Creamos el valor del primer salto K = n/2
             * 3.- Ejecutamos un loop para realizar los saltos y cambios hasta obtener el dataset ordenado
             * **/

            //Realizamos una asignacion de elementos a la variable array
            int[] array = elementos;
            int n = array.Length; //n sera igual a mi array de elementos
            int salto = n / 2;
            int aux;

            //Ejecutamos el loop mientras salto sea mayor que 0
            while (salto > 0)
            {
                //Primer ciclo
                for (int i = salto; i < n; i++)
                {
                    int j = i - salto;
                    //Entramos al ciclo interno
                    while (j >= 0)
                    {
                        //Movemos los elementos
                        int k = j + salto;
                        if (array[j] < array[k])
                        {
                            j = -1; //Salimos del ciclo
                        }
                        else
                        {
                            aux = array[j];
                            array[j] = array[k];
                            array[k] = aux;
                            j -= salto;
                        }
                    }
                }
                salto = salto / 2;
            }
            
            return array;
        }
    }
}