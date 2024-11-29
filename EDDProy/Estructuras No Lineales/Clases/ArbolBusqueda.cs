using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Estructuras_No_Lineales
{
    public class ArbolBusqueda
    {
        NodoBinario Raiz;
        public String strArbol;
        public String strRecorrido;

        public ArbolBusqueda()
        {
            Raiz = null;
            strArbol = "";
            strRecorrido = "";
        }

        public Boolean EstaVacio()
        {
            if (Raiz == null)
                return true;
            else
                return false;
        }
        public NodoBinario RegresaRaiz()
        {
            return Raiz;
        }

        public void InsertaNodo(int Dato, ref NodoBinario Nodo)
        {            
            if (Nodo == null)
            {
                Nodo = new NodoBinario(Dato);
              

                if (Raiz == null)
                    Raiz = Nodo;
            }
            else if (Dato < Nodo.Dato)
                InsertaNodo(Dato, ref Nodo.Izq);
            else if (Dato > Nodo.Dato)
                InsertaNodo(Dato, ref Nodo.Der);          
        }
        public void MuestraArbolAcostado(int nivel, NodoBinario nodo )
        {
            if (nodo == null)
                return;
            MuestraArbolAcostado(nivel + 1, nodo.Der);
            for(int i=0; i<nivel; i++)
            {
                strArbol = strArbol + "      ";
            }
            strArbol = strArbol + nodo.Dato.ToString() + "\r\n";
            MuestraArbolAcostado(nivel + 1, nodo.Izq);
        }

        public  String ToDot(NodoBinario nodo)
        {
            StringBuilder b = new StringBuilder();
            if (nodo.Izq != null)
            {
                b.AppendFormat("{0}->{1} [side=L] {2} ", nodo.Dato.ToString(), nodo.Izq.Dato.ToString(), Environment.NewLine);
                b.Append(ToDot(nodo.Izq));
            }

            if (nodo.Der != null)
            {
                b.AppendFormat("{0}->{1} [side=R] {2} ", nodo.Dato.ToString(), nodo.Der.Dato.ToString(), Environment.NewLine);
                b.Append(ToDot(nodo.Der));
            }
            return b.ToString();
        }

        public void PreOrden(NodoBinario nodo)
        {
            if (nodo == null)
                return;

            strRecorrido = strRecorrido + nodo.Dato + ", ";
            PreOrden(nodo.Izq);
            PreOrden(nodo.Der);
            
            return;
        }

        public void InOrden(NodoBinario nodo)
        {
            if (nodo == null)
                return;

            InOrden(nodo.Izq);
            strRecorrido = strRecorrido + nodo.Dato + ", ";
            InOrden(nodo.Der);

            return;
        }
        public void PostOrden(NodoBinario nodo )
        {
            if (nodo == null)
                return;

            PostOrden(nodo.Izq);
            PostOrden(nodo.Der);
            strRecorrido = strRecorrido + nodo.Dato + ", ";

            return;
         }


        public bool BuscarNodo(int Dato, NodoBinario nodo)
        {
            if (nodo == null) return false;

            if (nodo.Dato == Dato) return true;

           
            if (Dato < nodo.Dato)
                return BuscarNodo(Dato, nodo.Izq);
            else
                return BuscarNodo(Dato, nodo.Der);
        }
      
        public int ObtenerAltura()
        {
            return Altura(Raiz);
        }

        private int Altura(NodoBinario nodo)
        {
            if (nodo == null) return 0;
            int alturaIzq = Altura(nodo.Izq);
            int alturaDer = Altura(nodo.Der);
            return Math.Max(alturaIzq, alturaDer) + 1;
        }

        public int ContarNodos()
        {
            return ContarNodos(Raiz);
        }

        private int ContarNodos(NodoBinario nodo)
        {
            if (nodo == null) return 0;
            return 1 + ContarNodos(nodo.Izq) + ContarNodos(nodo.Der);
        }

        public int ContarHojas()
        {
            return ContarHojas(Raiz);
        }

        private int ContarHojas(NodoBinario nodo)
        {
            if (nodo == null) return 0;
            if (nodo.Izq == null && nodo.Der == null) return 1;
            return ContarHojas(nodo.Izq) + ContarHojas(nodo.Der);
        }

        public bool EsBinarioCompleto()
        {
            return EsCompleto(Raiz);
        }

        private bool EsCompleto(NodoBinario nodo)
        {
            if (nodo == null) return true;

            Queue<NodoBinario> cola = new Queue<NodoBinario>();
            cola.Enqueue(nodo);
            bool encontradoNodoIncompleto = false;

            while (cola.Count > 0)
            {
                NodoBinario actual = cola.Dequeue();

                if (actual.Izq != null)
                {
                    if (encontradoNodoIncompleto) return false;
                    cola.Enqueue(actual.Izq);
                }
                else
                {
                    encontradoNodoIncompleto = true;
                }

                if (actual.Der != null)
                {
                    if (encontradoNodoIncompleto) return false;
                    cola.Enqueue(actual.Der);
                }
                else
                {
                    encontradoNodoIncompleto = true;
                }
            }

            return true;
        }

        public bool EsBinarioLleno()
        {
            return EsLleno(Raiz, Altura(Raiz), 0);
        }

        private bool EsLleno(NodoBinario nodo, int altura, int nivel)
        {
            if (nodo == null) return true;

            if (nodo.Izq == null && nodo.Der == null)
                return altura == nivel + 1;

            if (nodo.Izq == null || nodo.Der == null)
                return false;

            return EsLleno(nodo.Izq, altura, nivel + 1) && EsLleno(nodo.Der, altura, nivel + 1);
        }
        public void Podar()
        {
            Raiz = null;
        }
        public void EliminarNodoConPredecesor(int dato)
        {
            Raiz = EliminarConPredecesor(Raiz, dato);
        }

        private NodoBinario EliminarConPredecesor(NodoBinario nodo, int dato)
        {
            if (nodo == null) return nodo;

            if (dato < nodo.Dato)
            {
                nodo.Izq = EliminarConPredecesor(nodo.Izq, dato);
            }
            else if (dato > nodo.Dato)
            {
                nodo.Der = EliminarConPredecesor(nodo.Der, dato);
            }
            else
            {
                if (nodo.Izq == null) return nodo.Der;
                if (nodo.Der == null) return nodo.Izq;

                NodoBinario predecesor = ObtenerPredecesor(nodo.Izq);
                nodo.Dato = predecesor.Dato;
                nodo.Izq = EliminarConPredecesor(nodo.Izq, predecesor.Dato);
            }
            return nodo;
        }

        private NodoBinario ObtenerPredecesor(NodoBinario nodo)
        {
            while (nodo.Der != null)
                nodo = nodo.Der;
            return nodo;
        }
        public void EliminarNodoConSucesor(int dato)
        {
            Raiz = EliminarConSucesor(Raiz, dato);
        }

        private NodoBinario EliminarConSucesor(NodoBinario nodo, int dato)
        {
            if (nodo == null) return nodo;

            if (dato < nodo.Dato)
            {
                nodo.Izq = EliminarConSucesor(nodo.Izq, dato);
            }
            else if (dato > nodo.Dato)
            {
                nodo.Der = EliminarConSucesor(nodo.Der, dato);
            }
            else
            {
                if (nodo.Izq == null) return nodo.Der;
                if (nodo.Der == null) return nodo.Izq;

                NodoBinario sucesor = ObtenerSucesor(nodo.Der);
                nodo.Dato = sucesor.Dato;
                nodo.Der = EliminarConSucesor(nodo.Der, sucesor.Dato);
            }
            return nodo;
        }

        private NodoBinario ObtenerSucesor(NodoBinario nodo)
        {
            while (nodo.Izq != null)
                nodo = nodo.Izq;
            return nodo;
        }
        public string RecorridoAmplitud()
        {
            if (Raiz == null) return "El árbol está vacío.";

            Queue<NodoBinario> cola = new Queue<NodoBinario>();
            StringBuilder resultado = new StringBuilder();
            cola.Enqueue(Raiz);

            while (cola.Count > 0)
            {
                NodoBinario actual = cola.Dequeue();
                resultado.Append(actual.Dato + " ");

                if (actual.Izq != null)
                    cola.Enqueue(actual.Izq);

                if (actual.Der != null)
                    cola.Enqueue(actual.Der);
            }

            return resultado.ToString();
        }

    }
}
