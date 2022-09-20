using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Cine;

namespace CineTest
{
    [TestClass]
    public class CineControllerTest
    {
        [TestMethod]
        public void AltaDePelicula()
        {
            CineController cineController = new CineController();
            cineController.AgregarPelicula("Thor", 100);

            Assert.AreEqual(1, cineController.CantidadDePeliculas());
        }

        [TestMethod]
        [ExpectedException(typeof(PeliculaInvalidaException))]
        [DataRow(null)]
        [DataRow("   ")]
        [DataRow("")]
        public void NoSeAgregaUnaPeliculaConNombreVacio(string nombrePelicula)
        {
            CineController cineController = new CineController();
            cineController.AgregarPelicula(nombrePelicula, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(PeliculaInvalidaException))]
        public void ElCostoDeUnaPeliculaEsMinimoCien()
        {
            CineController cineController = new CineController();
            cineController.AgregarPelicula("Thor", 99);
        }

        [TestMethod]
        [ExpectedException(typeof(PeliculaYaExisteException))]
        public void ElNombreDeLaPeliculaEsUnico()
        {
            CineController cineController = new CineController();
            cineController.AgregarPelicula("Thor", 100);
            cineController.AgregarPelicula("Thor", 100);
        }

        [TestMethod]
        public void UnUsuarioCompraEntradas()
        {
            // setup
            CineController cineController = new CineController();
            cineController.AgregarPelicula("Thor", 100);

            // exercise
            Ticket ticket = cineController.EfectuarCompra("Thor", 3);

            // verify
            Assert.AreEqual(300, ticket.Monto);
        }

        [TestMethod]
        [ExpectedException(typeof(LaPeliculaNoExisteException))]
        public void UnUsuarioNoPuedeComprarEntradasDeUnaPeliculaQueNoExiste()
        {
            CineController cineController = new CineController();

            cineController.EfectuarCompra("Thor", 3);
        }

        [TestMethod]
        [ExpectedException(typeof(CompraInvalidaException))]
        public void UnaCompraNoPuedeContenerCeroEntradas()
        {
            CineController cineController = new CineController();
            cineController.AgregarPelicula("Thor", 100);

            cineController.EfectuarCompra("Thor", 0);
        }

        [TestMethod]
        public void SeDaDeAltaUnAlimento()
        {
            CineController cineController = new CineController();
            cineController.AgregarAlimento("Pop", 150);

            int cantidadDeAlimentos = cineController.CantidadDeAlimentos();

            Assert.AreEqual(1, cantidadDeAlimentos);
        }
    }
}
