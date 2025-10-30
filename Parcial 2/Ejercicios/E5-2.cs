using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaColaDinamica
{
    class ClaseNodo<Tipo>
    {
        private Tipo _objetoConDatos;

        public Tipo ObjetoConDatos
        {
            get { return _objetoConDatos; }
            set { _objetoConDatos = value; }
        }

        private ClaseNodo<Tipo> _siguiente;

        public ClaseNodo<Tipo> Siguiente
        {
            get { return _siguiente; }
            set { _siguiente = value; }
        }

        ~ClaseNodo()
        {
            ObjetoConDatos = default(Tipo);
        }
    }
}
