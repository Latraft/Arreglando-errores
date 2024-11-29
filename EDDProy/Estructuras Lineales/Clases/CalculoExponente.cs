using System;

class CalculoExponente
{
    static void Main(string[] args)
    {
        Console.WriteLine("Cálculo de Exponentes");

        
        Console.Write("Introduce la base: ");
        double baseNumber = double.Parse(Console.ReadLine());

       
        Console.Write("Introduce el exponente: ");
        int exponent = int.Parse(Console.ReadLine());
        double result = Potencia(baseNumber, exponent);

       
        Console.WriteLine($"{baseNumber} elevado a {exponent} es {result}");
    }

    
    static double Potencia(double baseNumber, int exponent)
    {
        
        if (exponent == 0)
        {
            return 1;
        }
        
        if (exponent == 1)
        {
            return baseNumber;
        }

        return baseNumber * Potencia(baseNumber, exponent - 1);
    }
}
