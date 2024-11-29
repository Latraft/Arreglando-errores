using Estructuras;
using System;
using System.Diagnostics;
using System.Numerics;

public class Program
{
    
    public static void Main(string[] args)


    {

        Pila pila = new Pila();
        Cola cola = new Cola();
        ListaSimple listaSimple = new ListaSimple();
        ListaDoblementeEnlazada listaDoble = new ListaDoblementeEnlazada();
        ListaCircularSimple listaCircular = new ListaCircularSimple();
        ListaCircularDoble listaCircularDoble = new ListaCircularDoble();
        while (true)
        {
            Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
            Console.WriteLine("1. Cálculo de Factorial.");
            Console.WriteLine("2. Calculo de Exponente.");
            Console.WriteLine("3. Sumar elementos de un arreglo.");
            Console.WriteLine("4. Algoritmo de la Torre de Hano..");
            Console.WriteLine("5. Búsqueda binaria.");
            Console.WriteLine("6. Secuencia de Fiboncci.");
            Console.WriteLine("7. Operaciones de Pila.");
            Console.WriteLine("8. Operaciones con Cola.");
            Console.WriteLine("9. Operaciones con Lista simple.");
            Console.WriteLine("10. Op. Listas doblemente enlazadas.");
            Console.WriteLine("11. Op. Lista circular simple.");
            Console.WriteLine("12. Op. Lista circular doble.");
            Console.WriteLine("13. Salir.");
            Console.Write("Elige una opción: ");

            int opcion = int.Parse(Console.ReadLine());
           

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Has seleccionado: Cálculo de Factorial");

                    Console.Write("Introduce un número entero: ");
                    int number = int.Parse(Console.ReadLine());

                    
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    
                    BigInteger factorialResult = CalculadoraFactorial.Factorial(number);

                    stopwatch.Stop();

                   
                    Console.WriteLine($"\nFactorial de {number}: {factorialResult}");
                    Console.WriteLine($"Tiempo de ejecución: {stopwatch.Elapsed.TotalMilliseconds} ms");

                    
                    Console.WriteLine("Complejidad temporal: O(n)");
                    break;

                case 2:
                    Console.WriteLine("Has seleccionado: Cálculo de Exponente");

                    // Leer la base
                    Console.Write("Introduce la base: ");
                    double baseNumber = double.Parse(Console.ReadLine());

                    // Leer el exponente
                    Console.Write("Introduce el exponente: ");
                    double exponent = double.Parse(Console.ReadLine());

                   
                    Stopwatch stopwath = new Stopwatch();
                    stopwath.Start();

                    
                    double result = Math.Pow(baseNumber, exponent);

                  
                    
                    stopwath.Stop();

                   
                    Console.WriteLine($"\n{baseNumber} elevado a {exponent}: {result}");
                    Console.WriteLine($"Tiempo de ejecución: {stopwath.Elapsed.TotalMilliseconds} ms");

                   
                    Console.WriteLine("Complejidad temporal: O(log n)");
                    break;

                case 3:
                
                    Console.WriteLine("Has seleccionado: Sumar los elementos de un arreglo");
                    Stopwatch stopwah = new Stopwatch();
                    stopwah.Start();

                    // Leer el tamaño del arreglo
                    Console.Write("Introduce el tamaño del arreglo: ");
                    int size = int.Parse(Console.ReadLine());

                    
                    int[] numbers = new int[size];

                   
                    for (int i = 0; i < size; i++)
                    {
                        Console.Write($"Introduce el elemento {i + 1}: ");
                        numbers[i] = int.Parse(Console.ReadLine());

                    }
                  

                    
                    int sum = SumarArreglos.SumArrayElements(numbers);

                 
                    Console.WriteLine($"\nLa suma de los elementos del arreglo es: {sum}");

                    stopwah.Stop();

                    Console.WriteLine("Complejidad temporal: O(log n)");

                    break;


                case 4:

                    Console.WriteLine("Has seleccionado: Resolver Torre de Hanoi");

                    Stopwatch stopwatchHanoi = new Stopwatch();
                    stopwatchHanoi.Start();

                    
                    Console.Write("Introduce el número de discos: ");
                    if (int.TryParse(Console.ReadLine(), out int numberOfDiscs) && numberOfDiscs > 0)
                    {
                        Console.WriteLine("\nSolución:");
                        TorreHano.Solve(numberOfDiscs, 'A', 'C', 'B');
                    }
                    else
                    {
                        Console.WriteLine("Número de discos no válido.");
                    }

                    stopwatchHanoi.Stop();

                    Console.WriteLine($"Tiempo de ejecución: {stopwatchHanoi.Elapsed.TotalMilliseconds} ms");
                    Console.WriteLine("Complejidad temporal: O(2^n)"); 

                    break;


                case 5:
                    Console.Write("Introduce el tamaño del arreglo: ");
                    if (int.TryParse(Console.ReadLine(), out int tamano) && tamano > 0)
                    {
                        int[] arregloBusqueda = new int[tamano];

                        for (int i = 0; i < tamano; i++)
                        {
                            Console.Write($"Elemento {i + 1}: ");
                            if (int.TryParse(Console.ReadLine(), out int elemento))
                            {
                                arregloBusqueda[i] = elemento;
                            }
                            else
                            {
                                Console.WriteLine("Entrada no válida. Se asignará 0 al elemento.");
                                arregloBusqueda[i] = 0; 
                            }
                        }

                        Array.Sort(arregloBusqueda);

                        Console.Write("Introduce el valor a buscar: ");
                        if (int.TryParse(Console.ReadLine(), out int valor))
                        {
                            Stopwatch stopwatchBusqueda = new Stopwatch();
                            stopwatchBusqueda.Start();

                            int indice = BusquedaBinaria.BuscarRecursivo(arregloBusqueda, 0, arregloBusqueda.Length - 1, valor);

                            stopwatchBusqueda.Stop();
                            if (indice != -1)
                            {
                                Console.WriteLine($"Valor {valor} encontrado en la posición {indice}.");
                            }
                            else
                            {
                                Console.WriteLine($"Valor {valor} no encontrado.");
                            }
                            Console.WriteLine($"Tiempo de ejecución: {stopwatchBusqueda.Elapsed.TotalMilliseconds} ms");
                            Console.WriteLine("Complejidad temporal: O(log n)");
                        }
                        else
                        {
                            Console.WriteLine("Valor de búsqueda no válido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tamaño de arreglo no válido.");
                    }
                    break;


                case 6:
                    Console.Write("Introduce el valor de n (número entero no negativo): ");
                    int nRec;
                    if (!int.TryParse(Console.ReadLine(), out nRec) || nRec < 0)
                    {
                        Console.WriteLine("El valor de n debe ser un número entero no negativo.");
                        continue;
                    }

                    Stopwatch stopwatchRec = new Stopwatch();
                    stopwatchRec.Start();

                    long resultRec = Fibonacci.Recursive(nRec);
                    Console.WriteLine($"Fibonacci Recursivo de {nRec}: {resultRec}");

                    stopwatchRec.Stop();
                    Console.WriteLine($"Tiempo de ejecución: {stopwatchRec.ElapsedMilliseconds} ms");
                    Console.WriteLine("Complejidad temporal: O(2^n)");

                    break;




                case 7:
                    Console.WriteLine("Has seleccionado: Operaciones con Pila.");
                    Console.WriteLine("1. Push (Agregar elemento a la pila).");
                    Console.WriteLine("2. Pop (Extraer elemento de la pila).");
                    Console.WriteLine("3. Mostrar elementos de la pila.");
                    Console.Write("Elige una opción: ");
                    int opcionPila = int.Parse(Console.ReadLine());

                    if (opcionPila == 1)
                    {
                        Console.Write("Introduce un número entero para agregar a la pila: ");
                        int datoPila = int.Parse(Console.ReadLine());
                        pila.Push(datoPila);
                    }
                    else if (opcionPila == 2)
                    {
                        pila.Pop();
                    }
                    else if (opcionPila == 3)
                    {
                        pila.Mostrar();
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida.");
                    }
                    break;



                case 9:

                    Console.WriteLine("Has seleccionado: Operaciones con Lista Simple.");
                    Console.WriteLine("1. Agregar elemento a la lista.");
                    Console.WriteLine("2. Eliminar elemento de la lista.");
                    Console.WriteLine("3. Mostrar los elementos de la lista.");
                    Console.Write("Elige una opción: ");
                    int opcionListaSimple = int.Parse(Console.ReadLine());

                    if (opcionListaSimple == 1)
                    {
                        Console.Write("Introduce un número entero para agregar a la lista simple: ");
                        int datoListaSimple = int.Parse(Console.ReadLine());
                        listaSimple.Agregar(datoListaSimple);
                    }
                    else if (opcionListaSimple == 2)
                    {
                        Console.Write("Introduce el número entero a eliminar de la lista simple: ");
                        int datoEliminar = int.Parse(Console.ReadLine());
                        listaSimple.Eliminar(datoEliminar);
                    }
                    else if (opcionListaSimple == 3)
                    {
                        listaSimple.Mostrar();
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida.");
                    }
                    break;
                case 10:

                    Console.WriteLine("Has seleccionado: Operaciones con Lista Doblemente Enlazada.");
                    Console.WriteLine("1. Agregar elemento a la lista.");
                    Console.WriteLine("2. Eliminar elemento de la lista.");
                    Console.WriteLine("3. Mostrar los elementos de la lista desde el inicio.");
                    Console.WriteLine("4. Mostrar los elementos de la lista desde el final.");
                    Console.Write("Elige una opción: ");
                    int opcionListaDoble = int.Parse(Console.ReadLine());

                    if (opcionListaDoble == 1)
                    {
                        Console.Write("Introduce un número entero para agregar a la lista doblemente enlazada: ");
                        int datoListaDoble = int.Parse(Console.ReadLine());
                        listaDoble.Agregar(datoListaDoble);
                    }
                    else if (opcionListaDoble == 2)
                    {
                        Console.Write("Introduce el número entero a eliminar de la lista doblemente enlazada: ");
                        int datoEliminar = int.Parse(Console.ReadLine());
                        listaDoble.Eliminar(datoEliminar);
                    }
                    else if (opcionListaDoble == 3)
                    {
                        listaDoble.MostrarDesdeInicio();
                    }
                    else if (opcionListaDoble == 4)
                    {
                        listaDoble.MostrarDesdeFinal();
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida.");
                    }
                    break;

                case 11:
                    Console.WriteLine("Has seleccionado: Operaciones con Lista Circular Simple.");
                    Console.WriteLine("1. Agregar elemento a la lista.");
                    Console.WriteLine("2. Eliminar elemento de la lista.");
                    Console.WriteLine("3. Mostrar los elementos de la lista.");
                    Console.Write("Elige una opción: ");
                    int opcionListaCircular = int.Parse(Console.ReadLine());

                    if (opcionListaCircular == 1)
                    {
                        Console.Write("Introduce un número entero para agregar a la lista circular: ");
                        int datoListaCircular = int.Parse(Console.ReadLine());
                        listaCircular.Agregar(datoListaCircular);
                    }
                    else if (opcionListaCircular == 2)
                    {
                        Console.Write("Introduce el número entero a eliminar de la lista circular: ");
                        int datoEliminar = int.Parse(Console.ReadLine());
                        listaCircular.Eliminar(datoEliminar);
                    }
                    else if (opcionListaCircular == 3)
                    {
                        listaCircular.Mostrar();
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida.");
                    }
                    break;

                case 12:
                    Console.WriteLine("Has seleccionado: Operaciones con Lista Circular Doblemente Encadenada.");
                    Console.WriteLine("1. Agregar elemento a la lista.");
                    Console.WriteLine("2. Eliminar elemento de la lista.");
                    Console.WriteLine("3. Mostrar los elementos de la lista.");
                    Console.Write("Elige una opción: ");
                    int opcionListaCircularDoble = int.Parse(Console.ReadLine());

                    if (opcionListaCircularDoble == 1)
                    {
                        Console.Write("Introduce un número entero para agregar a la lista circular doble: ");
                        int datoListaCircularDoble = int.Parse(Console.ReadLine());
                        listaCircularDoble.Agregar(datoListaCircularDoble);
                    }
                    else if (opcionListaCircularDoble == 2)
                    {
                        Console.Write("Introduce el número entero a eliminar de la lista circular doble: ");
                        int datoEliminar = int.Parse(Console.ReadLine());
                        listaCircularDoble.Eliminar(datoEliminar);
                    }
                    else if (opcionListaCircularDoble == 3)
                    {
                        listaCircularDoble.Mostrar();
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida.");
                    }
                    break;
                case 13:
                    Console.WriteLine("Saliendo del programa...");
                    return;

                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        }
    }
}
