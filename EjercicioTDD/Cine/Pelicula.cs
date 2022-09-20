using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine
{
    internal class Pelicula
    {
        public string Nombre { get; set; }
        public int Costo { get; set; }

        public override bool Equals(object obj)
        {
            Pelicula otra = obj as Pelicula;

            if (otra == null) return false;

            return this.Nombre.Equals(otra.Nombre);
        }
    }
}
