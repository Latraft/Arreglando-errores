using System;

public class TorreHano
{
    
    public static void Solve(int numberOfDiscs, char fromRod, char toRod, char auxRod)
    {
        if (numberOfDiscs == 1)
        {
            Console.WriteLine($"Mueve disco 1 de {fromRod} a {toRod}");
            return;
        }

       
        Solve(numberOfDiscs - 1, fromRod, auxRod, toRod);

        
        Console.WriteLine($"Mueve disco {numberOfDiscs} de {fromRod} a {toRod}");

        
        Solve(numberOfDiscs - 1, auxRod, toRod, fromRod);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Resolución del problema de Torre de Hanoi");

      
        Console.Write("Introduce el número de discos: ");
        int numberOfDiscs;
        if (int.TryParse(Console.ReadLine(), out numberOfDiscs) && numberOfDiscs > 0)
        {
           
            Solve(numberOfDiscs, 'A', 'C', 'B');
        }
        else
        {
            Console.WriteLine("Por favor, introduce un número entero positivo.");
        }
    }
}

