using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3
{
    class ClasePilaDinamica<Tipo> where Tipo : IEquatable<Tipo>
    {
        private ClaseNodo<Tipo> _Top;
        public ClasePilaDinamica()
        {
            Top = null;
        }
        private ClaseNodo<Tipo> Top
        {
            get { return _Top; }
            set { _Top = value; }
        }
        public bool Vacia
        {
            get
            {
                if (Top == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void Push(Tipo objeto)
        {
            if (Vacia)
            {
                ClaseNodo<Tipo> nodoNuevo = new ClaseNodo<Tipo>();
                nodoNuevo.ObjetoConDatos = objeto;
                nodoNuevo.Siguiente = null;
                Top = nodoNuevo;
            }
            else
            {
                ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
                ClaseNodo<Tipo> nodoPrevio = new ClaseNodo<Tipo>();
                nodoActual = Top;
                do
                {
                    if (objeto.Equals(nodoActual.ObjetoConDatos))
                    {
                        throw new Exception("No se permiten datos duplicados");
                    }
                    else
                    {
                        nodoPrevio = nodoActual;
                        nodoActual = nodoActual.Siguiente;
                    }
                } while (nodoActual != null);

                ClaseNodo<Tipo> nodoNuevo = new ClaseNodo<Tipo>();
                nodoNuevo.ObjetoConDatos = objeto;
                nodoNuevo.Siguiente = Top;
                Top = nodoNuevo;
            }
        }
        public Tipo Pop(Tipo objeto)
        {
            if (Vacia)
            {
                throw new Exception("La lista se encuentra vacia");
            }
            else
            {
                ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
                ClaseNodo<Tipo> nodoPrevio = new ClaseNodo<Tipo>();
                Tipo Auxiliar;
                nodoActual = Top;
                nodoPrevio = Top;
                do
                {
                    if (objeto.Equals(Top.ObjetoConDatos))
                    {
                        Auxiliar = nodoActual.ObjetoConDatos;
                        Top = nodoActual.Siguiente;
                        nodoActual = null;
                        return Auxiliar;
                    }
                    if (objeto.Equals(nodoActual.ObjetoConDatos))
                    {
                        nodoPrevio.Siguiente = nodoActual.Siguiente;
                        Auxiliar = nodoActual.ObjetoConDatos;
                        nodoActual = null;
                        return Auxiliar;
                    }
                    else
                    {
                        nodoPrevio = nodoActual;
                        nodoActual = nodoActual.Siguiente;
                    }
                } while (nodoActual != null);

                throw new Exception("No existe en la lista");

            }
        }
        public Tipo Pop()
        {
            if (Vacia)
            {
                throw new Exception("La Pila esta Vacia");
            }
            else
            {
                ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
                nodoActual = Top;
                Tipo Auxiliar;
                Auxiliar = nodoActual.ObjetoConDatos;
                Top = nodoActual.Siguiente;
                nodoActual = null;
                return Auxiliar;
            }
        }
        public Tipo BuscarNodo(Tipo objeto)
        {
            if (Vacia)
            {
                throw new Exception("La lista se enceuntra vacia");
            }
            else
            {
                ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
                ClaseNodo<Tipo> nodoPrevio = new ClaseNodo<Tipo>();
                Tipo Auxiliar;
                nodoActual = Top;
                nodoPrevio = Top;
                do
                {
                    if (objeto.Equals(Top.ObjetoConDatos))
                    {
                        Auxiliar = nodoActual.ObjetoConDatos;
                        return Auxiliar;
                    }
                    if (objeto.Equals(nodoActual.ObjetoConDatos))
                    {
                        Auxiliar = nodoActual.ObjetoConDatos;
                        return Auxiliar;
                    }
                    else
                    {
                        nodoPrevio = nodoActual;
                        nodoActual = nodoActual.Siguiente;
                    }
                } while (nodoActual != null);
                throw new Exception("No existe en la lista");
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
                nodoActual = Top;
                do
                {
                    yield return (nodoActual.ObjetoConDatos);
                    nodoActual = nodoActual.Siguiente;
                } while (nodoActual != null);

                yield break;
            }
        }
        public void Vaciar()
        {
            if (Vacia)
            {
                throw new Exception("La lista esta vacia");
            }
            else
            {
                ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
                ClaseNodo<Tipo> nodoPrevio = new ClaseNodo<Tipo>();
                nodoActual = Top;

                do
                {
                    nodoPrevio = nodoActual;
                    nodoActual = nodoActual.Siguiente;
                    nodoPrevio = null;
                } while (nodoActual != null);
                Top = null;
            }
        }
        ~ClasePilaDinamica()
        {
            Vaciar();
        }
    }
}
