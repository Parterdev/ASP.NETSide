using Microsoft.VisualStudio.TestTools.UnitTesting;
using Informatica.Negocio;

namespace Informatica.Logica.Test
{
    [TestClass]
     public class ComparadorTest
    {
        [TestMethod]
      
            public void ObtenerMenor()
            {
                // AAA = Arrange Act Assert

                // Organizar los datos -- Arrange
                var primerElemento = 57;
                var segundoElemento = 20;
                var esperado = 20;

                //Ejecutar -- Act
                Comparador comparador = new Comparador();
                int actual = comparador.ObtenerMenor(primerElemento, segundoElemento);

                //Comprobar -- Assert

                Assert.AreEqual(esperado, actual);



            }
        
    }
}
