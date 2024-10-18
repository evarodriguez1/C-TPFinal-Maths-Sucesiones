using System;

int opcion = 0, i = 0, cantidadTerminos = 0, quiereTodos = 0;
decimal numeroInicial = 0, razonOdiferencia = 0, resultado = 0;

// Muestra un menú para que el usuario elija el tipo de sucesión (aritmética, geométrica o conjunto).
opcion = (int)validarEntradaNumerica("Elija una opción presionando el número por teclado \n 1.Aritmética \n 2.Geométrica \n 3.Conjunto");

switch (opcion)
{
    // Sucesión aritmética
    case 1:
        numeroInicial = validarEntradaNumerica("Ingrese el primer término");
        razonOdiferencia = validarEntradaNumerica("Ingrese la diferencia");
        cantidadTerminos = (int)validarEntradaNumerica("¿Cuántos números desea?");

        // Verifica que el usuario haya solicitado al menos 3 términos (requerimiento)
        if (cantidadTerminos < 3)
        {
            Console.WriteLine("Error: Debe ingresar al menos 3 términos.");
            break;
        }

        // Elige si quiere mostrar solo el último término o todos los términos
        quiereTodos = (int)validarEntradaNumerica("Si desea solamente el término a" + cantidadTerminos + " ingrese 1. Si desea todos los términos de la sucesión, ingrese 2");

        switch (quiereTodos)
        {
            // Muestra solo el último término de la sucesión aritmética
            case 1:
                for (i = 0; i < cantidadTerminos; i++)
                {
                    resultado = numeroInicial + i * razonOdiferencia;
                }
                Console.WriteLine("a" + i + "=" + resultado);
                break;

            // Muestra todos los términos de la sucesión aritmética
            case 2:
                for (i = 0; i < cantidadTerminos; i++)
                {
                    resultado = numeroInicial + i * razonOdiferencia;
                    Console.WriteLine($"a{i + 1} = {resultado}");
                }
                break;

            default:
                Console.WriteLine("Ingrese un valor válido para las opciones presentadas");
                break;
        }

        // Determina si la sucesión aritmética es constante, creciente o decreciente 
        if (EsConstante(numeroInicial, razonOdiferencia))
            Console.WriteLine("La sucesión es constante.");
        else if (EsAritmeticaCreciente(razonOdiferencia))
            Console.WriteLine("La sucesión es aritmética creciente.");
        else if (EsAritmeticaDecreciente(razonOdiferencia))
            Console.WriteLine("La sucesión es aritmética decreciente.");

        break;

    // Sucesión geométrica
    case 2:
        numeroInicial = validarEntradaNumerica("Ingrese el primer término");
        razonOdiferencia = validarEntradaNumerica("Ingrese la razón");
        cantidadTerminos = (int)validarEntradaNumerica("¿Cuántos números desea?");

        // Verifica que el usuario haya solicitado al menos 3 términos 
        if (cantidadTerminos < 3)
        {
            Console.WriteLine("Error: Debe ingresar al menos 3 términos.");
            break;
        }

        // Elige si quiere mostrar solo el último término o todos los términos
        quiereTodos = (int)validarEntradaNumerica("Si desea solamente el término a" + cantidadTerminos + " ingrese 1. Si desea todos los términos de la sucesión, ingrese 2");

        switch (quiereTodos)
        {
            // Muestra solo el último término de la sucesión geométrica
            case 1:
                for (i = 0; i < cantidadTerminos; i++)
                {
                    resultado = numeroInicial *= razonOdiferencia;
                }
                Console.WriteLine("a" + i + "=" + resultado);
                break;

            // Muestra todos los términos de la sucesión geométrica
            case 2:
                for (i = 0; i < cantidadTerminos; i++)
                {
                    resultado = numeroInicial *= razonOdiferencia;
                    Console.WriteLine($"a{i + 1} = {resultado}");
                }
                break;

            default:
                Console.WriteLine("Ingrese un valor válido para las opciones presentadas");
                break;
        }

        // Determina si la sucesión geométrica es creciente o decreciente 
        if (EsGeometricaCreciente(numeroInicial, razonOdiferencia))
            Console.WriteLine("La sucesión es geométrica creciente.");
        else if (EsGeometricaDecreciente(numeroInicial, razonOdiferencia))
            Console.WriteLine("La sucesión es geométrica decreciente.");

        break;

    // Sucesión de conjunto de números
    case 3:
        cantidadTerminos = (int)validarEntradaNumerica("Ingrese qué cantidad de números escribirá del conjunto");

        // Verifica que el usuario haya solicitado al menos 3 términos 
        if (cantidadTerminos < 3)
        {
            Console.WriteLine("Error: Debe ingresar al menos 3 números en el conjunto.");
            break;
        }

        // Crea un vector para almacenar los números ingresados por el usuario
        decimal[] conjunto = new decimal[cantidadTerminos];

        // Llena el vector con los números proporcionados por el usuario
        for (i = 0; i < cantidadTerminos; i++)
        {
            conjunto[i] = validarEntradaNumerica($"Ingrese el número {i + 1}");
        }

        bool esAritmetica = true;
        bool esGeometrica = true;

        // Verifica si es una sucesión aritmética
        decimal diferenciaAritmetica = conjunto[1] - conjunto[0];
        for (i = 2; i < cantidadTerminos; i++)
        {
            if (conjunto[i] - conjunto[i - 1] != diferenciaAritmetica)
            {
                esAritmetica = false;
                break;
            }
        }

        // Verifica si es una sucesión geométrica
        decimal razonGeometrica = conjunto[1] / conjunto[0];
        for (i = 2; i < cantidadTerminos; i++)
        {
            if (conjunto[i] / conjunto[i - 1] != razonGeometrica)
            {
                esGeometrica = false;
                break;
            }
        }

        // Muestra si el conjunto es aritmético, geométrico o no es una sucesión
        if (esAritmetica)
        {
            Console.WriteLine("El conjunto es una sucesión aritmética.");
        }
        else if (esGeometrica)
        {
            Console.WriteLine("El conjunto es una sucesión geométrica.");
        }
        else
        {
            Console.WriteLine("El conjunto no es una sucesión.");
        }

        break;
}

// Mantener la consola abierta 
Console.WriteLine("Presione cualquier tecla para salir...");
Console.ReadKey();

// Función para validar que la entrada sea numérica
static decimal validarEntradaNumerica(string mensaje)
{
    decimal numero;
    string entrada;

    while (true)
    {
        Console.WriteLine(mensaje);
        entrada = Console.ReadLine();

        if (decimal.TryParse(entrada, out numero))
        {
            return numero;
        }
        else
        {
            Console.WriteLine("Error: Ingrese un número válido");
        }
    }
}

// Funciones adicionales para determinar si una sucesión es constante, creciente o decreciente
static bool EsConstante(decimal numeroInicial, decimal razonOdiferencia) =>
    razonOdiferencia == 0;

static bool EsAritmeticaCreciente(decimal razonOdiferencia) =>
    razonOdiferencia > 0;

static bool EsAritmeticaDecreciente(decimal razonOdiferencia) =>
    razonOdiferencia < 0;

static bool EsGeometricaCreciente(decimal numeroInicial, decimal razonOdiferencia) =>
    numeroInicial > 0 && razonOdiferencia > 1;

static bool EsGeometricaDecreciente(decimal numeroInicial, decimal razonOdiferencia) =>
    numeroInicial > 0 && razonOdiferencia > 0 && razonOdiferencia < 1;
