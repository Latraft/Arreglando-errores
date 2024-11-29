using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodos
{

    class Program
    {
        static nodo NodoInicial; 
        static nodo NodoFinal; 

        public class nodo
        {
            public int dato;
            public nodo sig;
        }


        static void Agregar(int dato)
        {
            
            nodo NodoNuevo = new nodo();
            NodoNuevo.dato = dato;
            NodoNuevo.sig = null;

            
            if (NodoInicial == null)
            { 
               
                NodoInicial = NodoNuevo;
                NodoFinal = NodoNuevo;
            } else {
               
                nodo NodoTmp = NodoFinal;

               
                NodoTmp.sig = NodoNuevo;

                
                NodoFinal = NodoNuevo;              
            }

        }
        static void Recorre()
        {
            nodo n1 = NodoInicial;
            while( n1 != null) {
                Console.WriteLine(n1.dato);
                n1 = n1.sig;
            }
        }
        static void Main(string[] args)
        {
            NodoInicial = null;
            NodoFinal = null;

            Console.WriteLine("Nodos");
            Agregar(5);
            Agregar(1);
            Agregar(6);
            Agregar(4);
            Agregar(10);

            Recorre();

            Console.WriteLine("\nPresiona <Enter> para salir");
            Console.ReadLine();

        }
    }
}

