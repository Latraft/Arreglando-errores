using System;

namespace Estructuras
{
    // Otras clases (Pila, Cola, ListaSimple, etc.)

    public class NodoListaCircular
    {
        public int Dato;
        public NodoListaCircular Sig;
    }

    public class ListaCircularSimple
    {
        private NodoListaCircular cabeza = null;

        public void Agregar(int dato)
        {
            NodoListaCircular nuevo = new NodoListaCircular { Dato = dato, Sig = null };
            if (cabeza == null)
            {
                cabeza = nuevo;
                cabeza.Sig = cabeza; 
            }
            else
            {
                NodoListaCircular actual = cabeza;
                while (actual.Sig != cabeza) 
                {
                    actual = actual.Sig;
                }
                actual.Sig = nuevo; 
                nuevo.Sig = cabeza; 
            }
            Console.WriteLine($"Se agregó el dato {dato} a la lista circular simple.");
        }

        public void Eliminar(int dato)
        {
            if (cabeza == null)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            NodoListaCircular actual = cabeza;
            NodoListaCircular anterior = null;

            
            do
            {
                if (actual.Dato == dato)
                {
                    if (anterior == null) 
                    {
                        if (cabeza.Sig == cabeza) 
                        {
                            cabeza = null; 
                        }
                        else
                        {
                            
                            NodoListaCircular temp = cabeza;
                            while (temp.Sig != cabeza)
                            {
                                temp = temp.Sig;
                            }
                            temp.Sig = cabeza.Sig;
                            cabeza = cabeza.Sig; 
                        }
                    }
                    else
                    {
                        anterior.Sig = actual.Sig; 
                    }
                    Console.WriteLine($"Se eliminó el dato {dato} de la lista circular simple.");
                    return;
                }
                anterior = actual;
                actual = actual.Sig;
            } while (actual != cabeza);

            Console.WriteLine($"El dato {dato} no se encontró en la lista.");
        }

        public void Mostrar()
        {
            if (cabeza == null)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            NodoListaCircular actual = cabeza;
            Console.WriteLine("Elementos de la lista circular:");
            do
            {
                Console.Write(actual.Dato + " -> ");
                actual = actual.Sig;
            } while (actual != cabeza);
            Console.WriteLine("(de vuelta a la cabeza)");
        }
    }
}