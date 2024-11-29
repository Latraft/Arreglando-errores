using System;
using System.Numerics;

public class CalculadoraFactorial
{
   
    public static BigInteger Factorial(int n)
    {
        
        if (n == 0 || n == 1)
        {
            return 1;
        }
        else
        {
     
            return n * Factorial(n - 1);
        }
    }
}