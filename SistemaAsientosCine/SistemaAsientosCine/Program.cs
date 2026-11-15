using System;

class Program
{
    static void Main(string[] args)
    {
        int filas = 5;
        int columnas = 5;
        char[,] matriz = new char[filas, columnas];

        // Inicializar asientos con 'L' (Libre)
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                matriz[i, j] = 'L';
            }
        }

        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE ASIENTOS DE CINE ===");
            Console.WriteLine("1. Mostrar asientos");
            Console.WriteLine("2. Reservar asiento");
            Console.WriteLine("3. Cancelar reserva");
            Console.WriteLine("4. Reporte de ventas");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("\n--- ESTADO DE LOS ASIENTOS ---");
                    for (int i = 0; i < filas; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            Console.Write(matriz[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Write("\nIngrese la fila (0 al 4): ");
                    int fReserva = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese la columna (0 al 4): ");
                    int cReserva = int.Parse(Console.ReadLine());

                    if (fReserva >= 0 && fReserva < filas && cReserva >= 0 && cReserva < columnas)
                    {
                        if (matriz[fReserva, cReserva] == 'L')
                        {
                            matriz[fReserva, cReserva] = 'O'; // 'O' de Ocupado
                            Console.WriteLine("¡Asiento reservado con éxito!");
                        }
                        else
                        {
                            Console.WriteLine("El asiento ya está ocupado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Fila o columna fuera de rango.");
                    }
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "3":
                    Console.Write("\nIngrese la fila de la reserva a cancelar (0 al 4): ");
                    int fCancel = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese la columna de la reserva a cancelar (0 al 4): ");
                    int cCancel = int.Parse(Console.ReadLine());

                    if (fCancel >= 0 && fCancel < filas && cCancel >= 0 && cCancel < columnas)
                    {
                        if (matriz[fCancel, cCancel] == 'O')
                        {
                            matriz[fCancel, cCancel] = 'L';
                            Console.WriteLine("¡Reserva cancelada con éxito! El asiento vuelve a estar libre.");
                        }
                        else
                        {
                            Console.WriteLine("El asiento no estaba reservado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Fila o columna fuera de rango.");
                    }
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "4":
                    int ocupados = 0;
                    int libres = 0;
                    for (int i = 0; i < filas; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            if (matriz[i, j] == 'O') ocupados++;
                            else libres++;
                        }
                    }
                    Console.WriteLine("\n--- REPORTE DE VENTAS ---");
                    Console.WriteLine($"Asientos reservados: {ocupados}");
                    Console.WriteLine($"Asientos libres: {libres}");
                    Console.WriteLine("-------------------------");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "5":
                    salir = true;
                    Console.WriteLine("\nSaliendo del sistema... ¡Hasta luego!");
                    break;

                default:
                    Console.WriteLine("\nOpción no válida. Intente de nuevo.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}