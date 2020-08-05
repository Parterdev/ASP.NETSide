﻿namespace MyFirstUnitTest
{
  internal class Sorting
  {
    //Metodo de seleccion sort
    public static int[] SelectionSort(int[] elementos)
    {
      int n = elementos.Length;
      //Con el primer for iteramos sobre el array de elementos
      for (int i = 0; i < n - 1; i++)
      {
        //Buble para comparar mis elementos adyacentes
        //n= 5: 0,1,2,3,4,5 6 posiciciones
        //n-1: 0,1,2,3,4
        for (int j = 0; j < n - 1; j++)
        {
          //Cambiamos los elementos adyacentes comparadonlos
          if (elementos[j] > elementos[j + 1])
          {
            //Declaramos un auxiliar para mover los elementos
            int aux = elementos[j];
            elementos[j] = elementos[j + 1];
            elementos[j + 1] = aux;
          }
        }
      }
      return elementos;

    }

  }
}
