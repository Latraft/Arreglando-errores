using System;

public class SumarArreglos
{
  
    public static int SumArrayElements(int[] array)
    {
        return SumArrayElementsRecursive(array, 0);
    }

    
    private static int SumArrayElementsRecursive(int[] array, int index)
    {
        
        if (index >= array.Length)
        {
            return 0;
        }

    
        return array[index] + SumArrayElementsRecursive(array, index + 1);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Suma de elementos de un arreglo");

        int size;
        while (true)
        {
            
            Console.Write("Introduce el tamaño del arreglo: ");
            if (int.TryParse(Console.ReadLine(), out size) && size > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Por favor, introduce un tamaño válido (número entero positivo).");
            }
        }

      
        int[] array = new int[size];

        
        for (int i = 0; i < size; i++)
        {
            while (true)
            {
                Console.Write($"Introduce el elemento en la posición {i}: ");
                if (int.TryParse(Console.ReadLine(), out int element))
                {
                    array[i] = element;
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, introduce un valor entero válido.");
                }
            }
        }

       
        int result = SumArrayElements(array);

     
        Console.WriteLine($"La suma de los elementos del arreglo es {result}");
    }
}