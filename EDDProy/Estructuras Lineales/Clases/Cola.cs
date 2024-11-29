using System;

public class NodoCola
{
    public int Dato;
    public NodoCola Sig;
}

public class Cola
{
    private NodoCola Frente = null;
    private NodoCola Final = null;

    public void Enqueue(int dato)
    {
        NodoCola nuevo = new NodoCola();
        nuevo.Dato = dato;
        nuevo.Sig = null;

        if (Final == null)
        {
            Frente = nuevo;
            Final = nuevo;
        }
        else
        {
            Final.Sig = nuevo;
            Final = nuevo;
        }
        Console.WriteLine($"Se agregó el dato {dato} a la cola.");
    }

    public int? Dequeue()
    {
        if (Frente == null)
        {
            Console.WriteLine("Cola vacía.");
            return null;
        }
        else
        {  
            NodoCola aux = Frente;
            Frente = Frente.Sig;
            if (Frente == null) 
            {
                Final = null;
            }
            int dato = aux.Dato;
            aux = null; 
            Console.WriteLine($"Se extrajo el dato {dato} de la cola.");
            return dato;
        }
    }

    public bool EstaVacia()
    {
        return Frente == null;
    }
}