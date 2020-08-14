using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.IO;


namespace RaceCarGame.App
{
    class Race
    {
        //Metodo inicial para posicionar elementos en pantalla
        public static void PantallaElementos(char[,] pantalla) {
            //Establecemos el curso en la posicion 0 y 0
            Console.SetCursorPosition(0, 0);

            //Buffer para almacenar los datos de manera temporal
            string bufferConsola = "";

            for (int columna = 4; columna < Juego.alturaPantalla - 4; columna++)
            {
                for (int fila = 0; fila < Juego.anchuraPantalla; fila++)
                {
                    bufferConsola += pantalla[columna, fila];
                }
                bufferConsola += "\n";   
            }

            Console.Write(bufferConsola);

        }

        //Metodo para agregar una matriz pequeña a una matriz de pantall
        public static void EnPantalla(char[,] pantalla, char[,] array, int posicionX, int posicionY) {
            for (int columna = posicionY; columna < array.GetLength(0) + posicionY; columna++) {
                for (int fila = posicionX; fila < array.GetLength(1) + posicionX; fila++) {
                    if (pantalla[columna, fila] != Juego.simbolo) {
                        //Restamos para acceder a la matriz en [0][0]
                        pantalla[columna, fila] = array[columna - posicionY, fila - posicionX];
                    }
                }
            }
        }
    }

    //Clase de logica de juego
    class Juego {
        //Simbolo para carro normal
        public const char simbolo = '*';
        //Simbolo para carro enemigo
        public const char simbolo1 = 'O';
        //Simbolo para paredes
        public const char simbolo2 = '║';

        /**Los otros carros aparecerán lentamente
         * 1.- Van a aparecer en las primeras 5 filas
         * 2.- Van a desaparecer en las ultimas 5 fulas**/

        public const int alturaPantalla = 4 + 20 + 4;
        public const int anchuraPantalla = 10;

        //Diseño del carro del jugador principal (vector de caracteres)
        static readonly char[,] carroJugador = new char[4, 3] {{'\0'  , simbolo, '\0'  },
                                                              { simbolo, simbolo, simbolo },
                                                              { '\0' , simbolo, '\0'  },
                                                              { simbolo, '\0' , simbolo }};


        //Diseño del carro del enemigo (vector de caracteres)
        static readonly char[,] carroEnemigo = new char[4, 3] {{'\0'  , simbolo1, '\0'  },
                                                              { simbolo1, simbolo1, simbolo1 },
                                                              { '\0' , simbolo1, '\0'  },
                                                              { simbolo1, '\0' , simbolo1 }};


        //Matriz de pantalla de juego (mapa de bits)
        static char[,] pantalla = new char[alturaPantalla, anchuraPantalla];
        //Paredes
        static char[,] paredes = new char[20, 10];
        //Puntaje
        private static int puntaje = 0;
        //Ruta para almacenar el mejor puntaje
        private static readonly string mejorPuntajeRuta = Path.Combine(Directory.GetCurrentDirectory(), "Mejor_Puntaje");
        //Lo leemos 
        private static int mejorPuntaje = LeerPuntaje();

        //Metodo principal
        public static void Main() {

            //Todo lo impreso sera aceptado con caracteres especiales
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            //Ocultamos el cursor
            Console.CursorVisible = false;

            /** Empieza el juego... **/
            empezar:

            //Puntaje inicial
            puntaje = 0;

            //Posicion inicial del carro
            int posicionCarroEnX = 2;
            int posicionCarroEnY = 16;

            //Velocidad en bloques por segundo
            int velocidad = 30;

            //Posicion del carro enemigo
            int posicionCarroEnemigoEnX = 0;
            int posicionCarroEnemigoEnY = 0;

            //Valor aleatorio para el desplazamiento
            posicionCarroEnemigoEnX = PosicionAleatoria();

            //Cuenta regresiva para el jugador
            HiloCentral(paredes, pantalla, carroJugador, posicionCarroEnX, posicionCarroEnY);

            //Loop
            while (true) {
                //Renderizado del marco principals
                paredes = CrearParedes();

                Race.EnPantalla(pantalla, paredes, 0, 4); 
                Race.EnPantalla(pantalla, carroJugador, posicionCarroEnX, posicionCarroEnY + 4); 
                Race.EnPantalla(pantalla, carroEnemigo, posicionCarroEnemigoEnX, posicionCarroEnemigoEnY);
                Race.PantallaElementos(pantalla);

                //Mostramos el puntaje fuera de la pantalla
                puntaje++;
                MostrarPuntaje(puntaje);
                //MuestraAlMejor(puntaje);

                if (EnemigoGolpeado(posicionCarroEnX, posicionCarroEnY, posicionCarroEnemigoEnX, posicionCarroEnemigoEnY) == true)
                {
                    break;
                }

                //La diversion empieza
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (posicionCarroEnX > 3)
                            {
                                posicionCarroEnX -= 3;
                                Array.Clear(pantalla, 0, pantalla.Length);
                                Race.EnPantalla(pantalla, carroJugador, posicionCarroEnX, posicionCarroEnY + 4);
                                Race.EnPantalla(pantalla, carroEnemigo, posicionCarroEnemigoEnX, posicionCarroEnemigoEnY);
                                Race.EnPantalla(pantalla, paredes, 0, 4);
                                Thread.Sleep(10); //Eliminamos los parpadeos de consola
                                Race.PantallaElementos(pantalla);
                                MostrarPuntaje(puntaje);
                            }
                            break;

                        case ConsoleKey.RightArrow:
                            if (posicionCarroEnX <= 3)
                            {
                                posicionCarroEnX += 3;
                                Array.Clear(pantalla, 0, pantalla.Length);
                                Race.EnPantalla(pantalla, carroJugador, posicionCarroEnX, posicionCarroEnY + 4);
                                Race.EnPantalla(pantalla, carroEnemigo, posicionCarroEnemigoEnX, posicionCarroEnemigoEnY);
                                Race.EnPantalla(pantalla, paredes, 0, 4);
                                Thread.Sleep(10); //Eliminamos los parpadeos de consola
                                Race.PantallaElementos(pantalla);
                                MostrarPuntaje(puntaje);
                            }
                            break;

                        default:
                            break;
                    }
                }

                //Cuando el carro enemigo llega al fondo y se genera uno nuevo
                posicionCarroEnemigoEnY++;
                if (posicionCarroEnemigoEnY == pantalla.GetLength(0) - 1 - 4)
                {
                    posicionCarroEnemigoEnY = 0;
                    posicionCarroEnemigoEnX = PosicionAleatoria();
                }

                Array.Clear(pantalla, 0, pantalla.Length);
                Thread.Sleep(1000 / velocidad);
            }

            //Si pierde
            JugadorHaPerdido(pantalla);
            goto empezar;


        }

        //Geramos paredes
        public static int count = 0;

        //Metodo para la generacion de paredes
        static char[,] CrearParedes() {
            //Inicializamos la pared unidim para despues transformarla en bidim
            char[] paredUno = new char[20] { simbolo2, simbolo2, simbolo2, simbolo2, ' ', simbolo2, simbolo2, simbolo2, simbolo2, ' ', simbolo2, simbolo2, simbolo2, simbolo2, ' ', simbolo2, simbolo2, simbolo2, simbolo2, ' ' };
            char[,] resultado = new char[20, 10];

            /** Nivel de cambio para las paredes
             * 1.- No es una varible interna
             * 2.- Almacenamos el nivel de cambio en la memoria RAM de forma continua**/
            Juego.count++;
            if (Juego.count > 5) {
                Juego.count = 1;
            }

            //Desplazamos la matriz a la derecha 
            for (int i = 1; i <= Juego.count; i++) {

                char aux = paredUno[paredUno.Length - 1];

                //Desplazamos matriz a una posicion a la derecha
                for (int j = paredUno.Length - 1; j > 0; j--) {
                    paredUno[j] = paredUno[j - 1];
                }
                paredUno[0] = aux;
            }

            //Matriz bidimensional
            for (int columna = 0; columna < paredUno.Length; columna++) {
                resultado[columna, 0] = paredUno[columna];
            }
            for (int columna = 0; columna < paredUno.Length; columna++) {
                resultado[columna, 9] = paredUno[columna];
            }

            return resultado;    
        }

        //Metodo para generar posicones aleatorias
        static int PosicionAleatoria() {
            Random rand = new Random();
            int valorRandom = rand.Next(2);
            int posicionX;

            switch (valorRandom) {
                case 0:
                    posicionX = 2;
                    break;

                case 1:
                    posicionX = 5;
                    break;

                default:
                    posicionX = 2;
                    break;
            }
            //Retornamos el valor de desplazamiento en X
            return posicionX;
        }

        //Metodo para choche con otros carros
        static bool EnemigoGolpeado(int posicionCarroEnX, int posicionCarroEnY, int posicionCarroEnemigoEnX, int posicionCarroEnemigoEnY) {
            bool golpeado = false;

            for (int fila = posicionCarroEnY; fila < posicionCarroEnY + 4; fila++) {
                for (int columna = posicionCarroEnX; columna < posicionCarroEnX + 3; columna++) {
                    if ((columna >= posicionCarroEnemigoEnX && columna < posicionCarroEnemigoEnX + 3) && (fila >= posicionCarroEnemigoEnY - 4 && fila < posicionCarroEnemigoEnY)) {
                        //Si chocan
                        golpeado = true;
                        break;
                    }
                }
            }
            return golpeado;
        }

        //Metodo para corregir error de espacio en memoria Buffer
        //Cuando el readkey se lee en el bufer (consola)
        static void BufferLimpio() {
            while (Console.KeyAvailable)
                Console.ReadKey(false);
        }

        //Metodo para mostrar el puntaje
        static void MostrarPuntaje(int puntaje) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(12, 0);
            Console.WriteLine($"Puntaje: {puntaje}", Console.ForegroundColor);
        }

        //Metodo para obtener el mejor puntaje
        static int LeerPuntaje() {
            int elMejorPuntaje;

            //Validamos si el archivo Mejor_Puntaje existe
            if (File.Exists(mejorPuntajeRuta))
            {
                elMejorPuntaje = Convert.ToInt32(File.ReadAllText(mejorPuntajeRuta));
            }
            else {
                elMejorPuntaje = 0;
            }
            return elMejorPuntaje;
        }

        //Metodo para mostrar al mejor
        static void MuestraAlMejor(int puntaje) {
            if (puntaje > mejorPuntaje) {
                mejorPuntaje = puntaje;
            }
            Console.SetCursorPosition(12, 1);
            Console.Write($"El mejor hasta ahora: {mejorPuntaje}");
        }

        //Metodo para guardar el mejor puntaje
        static void EscribeElMejorPuntaje(int elMejor) {
            //Eescribimos en el archivo Mejor_Puntaje 
            using (StreamWriter archivoDeSalida = new StreamWriter(mejorPuntajeRuta)) {
                archivoDeSalida.WriteLine(elMejor);
            }
        }

        //Hilo principal
        static void HiloCentral(char[,] paredes, char[,] pantalla, char[,] carroJugador, int posicionCarroEnX, int posicionCarroEnY) {
            paredes = CrearParedes();

            //Ciclo para iterar el cronometro de segundos antes del juego
            for (int i = 5; i >= 1; i--)
            {
                Race.EnPantalla(pantalla, paredes, 0, 4);
                Race.EnPantalla(pantalla, carroJugador, posicionCarroEnX, posicionCarroEnY + 4);
                Race.PantallaElementos(pantalla);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(50, 10);
                Console.WriteLine($"¿Listo? {i}", Console.ForegroundColor);
                MostrarPuntaje(puntaje);
                //MuestraAlMejor(puntaje);
                Thread.Sleep(1000);
                BufferLimpio();
                Console.Clear();
            }
            Race.EnPantalla(pantalla, paredes, 0, 4); 
            Race.EnPantalla(pantalla, carroJugador, posicionCarroEnX, posicionCarroEnY + 4);
            Race.PantallaElementos(pantalla);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(50, 10);
            Console.WriteLine("Vamos", Console.ForegroundColor);
            MostrarPuntaje(puntaje);
            //MuestraAlMejor(puntaje);
            Thread.Sleep(1000);
            BufferLimpio();
            Console.Clear();
        }

        //Metodo para mostrar datos cuando el jugador pierde
        static void JugadorHaPerdido(char[,] pantalla)
        {
            Console.SetCursorPosition(50, 10);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Opss! Has perdido...");
            Console.WriteLine("Presiona una tecla para reiniciar el juego");
            EscribeElMejorPuntaje(mejorPuntaje);
            Thread.Sleep(300);
            BufferLimpio();
            Console.ReadKey();
            Array.Clear(pantalla, 0, pantalla.Length);
            Console.Clear();
        }
    }

    
}
