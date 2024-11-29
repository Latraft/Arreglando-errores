using System;

public static class BusquedaBinaria
{
    
    public static int BuscarRecursivo(int[] arreglo, int izquierda, int derecha, int valor)
    {
        
        if (izquierda > derecha)
            return -1;

       
        int medio = izquierda + (derecha - izquierda) / 2;

       
        if (arreglo[medio] == valor)
            return medio;

       
        if (arreglo[medio] > valor)
            return BuscarRecursivo(arreglo, izquierda, medio - 1, valor);
        else
            return BuscarRecursivo(arreglo, medio + 1, derecha, valor);
    }

    public static void Main(string[] args)
    {
      
        Console.WriteLine("Búsqueda Binaria Recursiva");

        
        int[] arreglo = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };

       
        Console.Write("Introduce el valor a buscar: ");
        int valor;
        if (int.TryParse(Console.ReadLine(), out valor))
        {
         
            int resultado = BuscarRecursivo(arreglo, 0, arreglo.Length - 1, valor);

           
            if (resultado != -1)
                Console.WriteLine($"Valor encontrado en el índice {resultado}");
            else
                Console.WriteLine("Valor no encontrado en el arreglo");
        }
        else
        {
            Console.WriteLine("Por favor, introduce un número entero válido.");
        }
    }
}
