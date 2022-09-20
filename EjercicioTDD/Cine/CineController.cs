using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine
{
    public class CineController
    {
        private const int MONTO_MINIMO_PELICULA = 100;

        private List<Pelicula> peliculas;

        public CineController()
        {
            this.peliculas = new List<Pelicula>();
        }

        public void AgregarPelicula(string nombrePelicula, int costo)
        {
            if (string.IsNullOrWhiteSpace(nombrePelicula) || costo < MONTO_MINIMO_PELICULA)
            {
                throw new PeliculaInvalidaException();
            }

            Pelicula peliculaAAgregar = new Pelicula { Costo = costo, Nombre = nombrePelicula };

            if (this.peliculas.Contains(peliculaAAgregar))
            {
                throw new PeliculaYaExisteException();
            }

            this.peliculas.Add(peliculaAAgregar);
        }

        public Ticket EfectuarCompra(string nombrePelicula, int cantidadDeEntradas)
        {
            if (cantidadDeEntradas < 1)
            {
                throw new CompraInvalidaException();
            }

            Pelicula pelicula = new Pelicula { Nombre = nombrePelicula };

            if (!this.peliculas.Contains(pelicula))
            {
                throw new LaPeliculaNoExisteException();
            }

            Pelicula peliculaAComprar = this.peliculas.FirstOrDefault(p => p.Nombre.Equals(nombrePelicula));

            return new Ticket { Monto = peliculaAComprar.Costo * cantidadDeEntradas };
        }

        public void AgregarAlimento(string nombre, int costo) { }

        public int CantidadDeAlimentos() => 1;

        public int CantidadDePeliculas()
        {
            return this.peliculas.Count;
        }
    }
}
