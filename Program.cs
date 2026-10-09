
using System;

Console.WriteLine("EJERCICIO 10: DIAGNÓSTICO DE MOTORES");
Console.WriteLine();

char continuar = 's';

// Ciclo while para registrar una cantidad desconocida de motores
while (continuar == 's' || continuar == 'S')
{
    Motor motor = new Motor();

    Console.Write("Ingrese el identificador del motor: ");
    motor.Identificador = Console.ReadLine() ?? "Sin ID";

    Console.WriteLine("Ingrese las 4 mediciones de corriente:");
    for (int i = 0; i < 4; i++)
    {
        Console.Write($"Medición {i + 1} (A): ");
        motor.MedicionesCorriente[i] = Convert.ToDouble(Console.ReadLine());
    }

    // Mostrar información llamando al método del objeto
    motor.MostrarInformacion();

    Console.WriteLine();
    Console.Write("¿Desea registrar otro motor? (s/n): ");
    continuar = Convert.ToChar(Console.ReadLine());
    Console.WriteLine();
}

Console.WriteLine("Programa finalizado.");

// Definición de la clase Motor
class Motor
{
    // Propiedades
    public string Identificador { get; set; } = "";
    public double[] MedicionesCorriente { get; set; } = new double[4];

    // Calcular promedio usando un ciclo for
    public double CalcularPromedio()
    {
        double suma = 0;
        for (int i = 0; i < MedicionesCorriente.Length; i++)
        {
            suma += MedicionesCorriente[i];
        }
        return suma / MedicionesCorriente.Length;
    }

    // Obtener diagnóstico según el promedio
    public string ObtenerDiagnostico()
    {
        double promedio = CalcularPromedio();
        if (promedio <= 5.0)
        {
            return "NORMAL";
        }
        else
        {
            return "REQUIERE MANTENIMIENTO";
        }
    }

    // Mostrar datos del motor
    public void MostrarInformacion()
    {
        double promedio = CalcularPromedio();
        Console.WriteLine();
        Console.WriteLine("--- DATOS DEL DIAGNÓSTICO ---");
        Console.WriteLine($"Motor: {Identificador}");
        Console.WriteLine($"Promedio de corriente: {promedio:F2} A");
        Console.WriteLine($"Estado: {ObtenerDiagnostico()}");
    }
}