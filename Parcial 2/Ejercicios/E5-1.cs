using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaColaDinamica
{
    class ClaseColaDinamica<Tipo>
    {
        private ClaseNodo<Tipo> _frente;

        private ClaseNodo<Tipo> Frente
        {
            get { return _frente; }
            set { _frente = value; }
        }

        private ClaseNodo<Tipo> _final;

        private ClaseNodo<Tipo> Final
        {
            get { return _final; }
            set { _final = value; }
        }

        public ClaseColaDinamica()
        {
            Frente = Final = null;
        }

        ~ClaseColaDinamica()
        {
            Vaciar();
        }

        public bool Vacia
        {
            get
            {
                return (Frente == null && Final == null) ? true : false;
            }
        }

        public void InsertarNodo(Tipo objeto)
        {
            if (Vacia)
            {
                ClaseNodo<Tipo> nodoNuevo = new ClaseNodo<Tipo>();
                nodoNuevo.ObjetoConDatos = objeto;
                nodoNuevo.Siguiente = null;
                Frente = nodoNuevo;
                Final = nodoNuevo;
            }
            else
            {
                ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
                ClaseNodo<Tipo> nodoPrevio = new ClaseNodo<Tipo>();
                nodoActual = Frente;

                do
                {
                    if (objeto.Equals(nodoActual.ObjetoConDatos))
                    {
                        throw new Exception("No se permiten duplicados");
                    }
                    else
                    {
                        nodoPrevio = nodoActual;
                        nodoActual = nodoActual.Siguiente;
                    }
                }
                while (nodoActual != null);
                {
                    ClaseNodo<Tipo> NodoNuevo = new ClaseNodo<Tipo>();
                    NodoNuevo.ObjetoConDatos = objeto;
                    NodoNuevo.Siguiente = null;
                    nodoPrevio.Siguiente = NodoNuevo;
                    Final = NodoNuevo;
                    return;
                }
            }
        }

        public Tipo Buscar(Tipo objeto)
        {
            if (Vacia)
            {
                throw new Exception("La lista esta vacia");
            }
            else
            {
                ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
                nodoActual = Frente;
                Tipo Auxiliar;
                do
                {
                    if (objeto.Equals(nodoActual.ObjetoConDatos))
                    {
                        Auxiliar = nodoActual.ObjetoConDatos;
                        return (Auxiliar);
                    }
                    else
                    {
                        nodoActual = nodoActual.Siguiente;
                    }
                }
                while (nodoActual != null);
                {
                    throw new Exception("No existe");
                }
            }
        }

        public void Vaciar()
        {
            if (Vacia)
            {
                return;
            }
            else
            {
                ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
                ClaseNodo<Tipo> nodoPrevio = new ClaseNodo<Tipo>();
                nodoActual = Frente;

                do
                {
                    nodoPrevio = nodoActual;
                    nodoActual = nodoActual.Siguiente;
                    nodoPrevio = null;

                }
                while (nodoActual != null);
                {
                    Frente = null;
                    Final = null;
                }
                return;
            }
        }

        public Tipo EliminarNodo()
        {
            if (Vacia)
            {
                throw new Exception("La lista esta vacia");
            }
            else
            {
                Tipo Eliminado;
                ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
                if (Frente == Final)
                {
                    Eliminado = Frente.ObjetoConDatos;
                    Frente = Final = null;
                    return Eliminado;
                }
                else
                {
                    nodoActual = Frente;
                    Eliminado = nodoActual.ObjetoConDatos;
                    Frente = Frente.Siguiente;
                    nodoActual = null;
                    return Eliminado;
                }
            }
        }
        public Tipo EliminarNodo(Tipo objeto)
        {
            if (Vacia)
            {
                throw new Exception("La lista esta vacia");
            }
            else
            {
                ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
                ClaseNodo<Tipo> nodoPrevio = new ClaseNodo<Tipo>();
                Tipo Eliminado = default(Tipo);
                nodoActual = Frente;
                do
                {
                    if (objeto.Equals(nodoActual.ObjetoConDatos))
                    {
                        if (nodoActual == Frente)
                        {
                            if (nodoActual == Final)
                            {
                                Eliminado = nodoActual.ObjetoConDatos;
                                Frente = Final = null;
                                return Eliminado;
                            }
                            else
                            {
                                Frente = Frente.Siguiente;
                                Eliminado = nodoActual.ObjetoConDatos;
                                nodoActual = null;
                                return Eliminado;
                            }
                        }
                        else if (nodoActual == Final)
                        {
                            nodoPrevio.Siguiente = null;
                            Eliminado = nodoActual.ObjetoConDatos;
                            nodoActual = null;
                            Final = nodoPrevio;
                            return Eliminado;
                        }
                        else
                        {
                            nodoPrevio.Siguiente = nodoActual.Siguiente;
                            Eliminado = nodoActual.ObjetoConDatos;
                            nodoActual = null;
                            return Eliminado;
                        }
                    }
                    else
                    {
                        nodoPrevio = nodoActual;
                        nodoActual = nodoActual.Siguiente;
                    }
                } while (nodoActual != null);
                throw new Exception("No existe");
            }

        }

        public IEnumerator<Tipo> GetEnumerator()
        {
            if (Vacia)
            {
                yield break;
            }
            else
            {
                ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
                nodoActual = Frente;
                do
                {
                    yield return (nodoActual.ObjetoConDatos);
                    nodoActual = nodoActual.Siguiente;
                }
                while (nodoActual != null);
                yield break;
            }
        }
    }
}
