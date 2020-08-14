using System;

namespace Informatica.Negocio
{
    public class Comparador
    {
        public int ObtenerMenor(int primerElemento, int segundoElemento)
        {
            /*if (primerElemento > segundoElemento)
            {
                return segundoElemento;
            }
            else
            {
                return primerElemento;
            }*/

            // Refactorizacion del code

            return primerElemento < segundoElemento ? primerElemento : segundoElemento;
        }
    }
}