namespace Clase_POO_Sem2Act1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE TARJETAS DE PREPAGO UNIDEP (SEMANA 2 - ACT 1) ===");

            TarjetaPrepago t1 = new TarjetaPrepago();
            TarjetaPrepago t2 = new TarjetaPrepago("TP-101", "Carlos Vera");
            TarjetaPrepago t3 = new TarjetaPrepago("TP-102", "Elena Rico", 220.00m);

            t1.MostrarEstado();
            t2.MostrarEstado();
            t3.MostrarEstado();

            Console.WriteLine("-- - OPERACIONES DE CONSUMO Y RECARGA-- - ");
            Console.WriteLine("[MOVIMIENTO 1]: Cobro de $15.50 en Tarjeta TP-101...");
            t2.Pagar(15.50m);

            Console.WriteLine("[MOVIMIENTO 2]: Intento de cobro de $60.00 en Tarjeta TP - 101...");
            t2.Pagar(60.00m); // Saldo insuficiente

            Console.WriteLine("[MOVIMIENTO 3]: Recarga de $100.00 en Tarjeta TP - 101...");
            t2.Recargar(100.00m);

            Console.WriteLine("================================================================");
        }
        }
    }
/*
 EJERCICIO
 
 📌 Título: Tarjeta de Prepago Estudiantil con Sobrecarga de Constructores y `this` en C#
Contexto y Planteamiento del Problema: La cafetería universitaria implementará terminales de cobro mediante tarjetas de prepago recargables. Para facilitar la emisión de plásticos en diversos escenarios (tarjeta anónima básica, tarjeta nominativa con saldo regular o tarjeta corporativa con bono), se requiere una clase `TarjetaPrepago` con múltiples constructores encadenados.

Requerimientos Técnicos Paso a Paso: 
1. **Clase `TarjetaPrepago`:** - Atributos privados: `_numeroTarjeta` (string), `_titular` (string), `_saldo` (decimal). 
	- **Constructor 1 (Completo):** Recibe número, titular y saldo inicial. Valida que el saldo no sea negativo y asigna usando `this`. 
	- **Constructor 2 (Rápido):** Recibe número y titular. Invoca al Constructor 1 usando `: this(numero, titular, 50.00m)`. 
	- **Constructor 3 (Por defecto):** Sin parámetros. Invoca al Constructor 1 usando `: this("TP-000", "Portador Anónimo", 20.00m)`. 
	- Métodos: 
		- `Recargar(decimal monto): void`: Solo acepta montos > 0. 
		- `Pagar(decimal monto): bool`: Si el saldo es suficiente, descuenta y devuelve true. Si no, rechaza y devuelve false. 
		- `MostrarEstado(): void`.

2. **Programa Principal (`Program.cs`):** 
	- Instanciar tres tarjetas utilizando cada uno de los 3 constructores para demostrar la sobrecarga. 
	- Realizar cobros válidos e inválidos y una recarga para verificar el comportamiento.
 */