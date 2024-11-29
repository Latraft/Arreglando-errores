using System;

public class NodoListaSimple
{
    public int Dato;
    public NodoListaSimple Sig;
}

public class ListaSimple
{
    private NodoListaSimple cabeza = null;

   
    public void Agregar(int dato)
    {
        NodoListaSimple nuevo = new NodoListaSimple();
        nuevo.Dato = dato;
        nuevo.Sig = null;

        if (cabeza == null)
        {
            cabeza = nuevo; 
        }
        else
        {
            NodoListaSimple actual = cabeza;
            while (actual.Sig != null)
            {
                actual = actual.Sig; 
            }
            actual.Sig = nuevo; 
        }
        Console.WriteLine($"Se agregó el dato {dato} a la lista simple.");
    }

    
    public void Eliminar(int dato)
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        if (cabeza.Dato == dato) 
        {
            cabeza = cabeza.Sig; 
            Console.WriteLine($"Se eliminó el dato {dato} de la lista simple.");
            return;
        }

        NodoListaSimple actual = cabeza;
        while (actual.Sig != null && actual.Sig.Dato != dato)
        {
            actual = actual.Sig; 
        }

        if (actual.Sig == null)
        {
            Console.WriteLine($"El dato {dato} no se encontró en la lista.");
            return;
        }

        actual.Sig = actual.Sig.Sig; 
        Console.WriteLine($"Se eliminó el dato {dato} de la lista simple.");
    }

 
    public void Mostrar()
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        NodoListaSimple actual = cabeza;
        Console.WriteLine("Elementos de la lista:");
        while (actual != null)
        {
            Console.Write(actual.Dato + " -> ");
            actual = actual.Sig; 
        }
        Console.WriteLine("null");
    }
}