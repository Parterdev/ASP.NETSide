using System;
using System.Threading;

namespace Hilos.Consola.App
{
    class EjemploHilos
    {
        public static void ProcesoHilo()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Hilo sencundario: Iteración: {0}", i);
                Thread.Sleep(0);
            }
        }

        //Metodo main
        public static void Main()
        {
            Console.WriteLine("Hilo principal: Inicia un segundo hilo");

            //Nuevo objeto tipo hilo
            Thread t = new Thread(new ThreadStart(ProcesoHilo));

            //Ejecutamos la funcion
            t.Start();

            //Hilo principal a dormir
            Thread.Sleep(20);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Hilo principal: Me estoy ejecutando");
                Thread.Sleep(0);
            }

            Console.WriteLine("Hilo principal: Llamo a la función de unión 'Join()', para esperar al hilo secundario");
            t.Join();
            Console.WriteLine("Hilo principal: El hilo secundario se ha unido");
            Console.ReadLine();
        }
    }
}
