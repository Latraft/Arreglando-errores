using System;

public class Fibonacci
{
   
    public static long Recursive(int n)
    {
       
        if (n <= 0) return 0;
        
        if (n == 1) return 1;

        
        return Recursive(n - 1) + Recursive(n - 2);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Cálculo de Fibonacci");

     
        Console.Write("Introduce el valor de n: ");
        int n = int.Parse(Console.ReadLine());

        
        long result = Recursive(n);

       
        Console.WriteLine($"El número de Fibonacci en la posición {n} es {result}");
    }
}


