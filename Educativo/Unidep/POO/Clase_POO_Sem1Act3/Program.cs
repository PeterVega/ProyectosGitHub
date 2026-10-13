using Microsoft.Win32;

namespace Clase_POO_Sem1Act3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE TRANSPORTE Y CONTROL DE FLOTA UNIDEP (SEMANA 1) ===");

            Console.WriteLine("[INICIALIZACIÓN]: Creando catálogo de conductores certificados...");
            Conductor c1 = new Conductor("COND-101", "Carlos Morales", "Tipo B Federal", 8);
            Conductor c2 = new Conductor("COND-102", "Sofía Ruiz", "Tipo A Estatal", 4);
            c1.ImprimirPerfil();
            c2.ImprimirPerfil();

            Console.WriteLine("[INICIALIZACIÓN]: Instanciando parque vehicular en la memoria Heap...");
    
            Vehiculo v1 = new Vehiculo("3N1AB7AP7PL12001", "Nissan", "Versa", 2023);
            Vehiculo v2 = new Vehiculo("8AJBA3CD4RL90342", "Toyota", "Hilux", 2024);
            Vehiculo v3 = new Vehiculo("1FTBW2X83NKA5512", "Ford", "Transit", 2022);

            Console.WriteLine($"-> Unidad creada: {v1.Marca} {v1.Modelo} {v1.Anio} [VIN: {v1.Vin}]");
            Console.WriteLine($"-> Unidad creada: {v2.Marca} {v2.Modelo} {v2.Anio} [VIN: {v2.Vin}]");
            Console.WriteLine($"-> Unidad creada: {v3.Marca} {v3.Modelo} {v3.Anio} [VIN: {v3.Vin}]");

            Console.WriteLine("-- - ASIGNACIÓN DE OPERADORES Y REGISTRO DE VIAJES-- - ");
    
            v1.AsignarConductor(c1);
            v2.AsignarConductor(c2);

            Console.WriteLine("[OPERACIÓN]: Registrando viaje de ruta Hermosillo->Guaymas(+135.5 km) en Nissan Versa...");
    
            v1.RegistrarViaje(135.5);

            Console.WriteLine("[OPERACIÓN]: Registrando viaje local universitario(+24.0 km) en Toyota Hilux...");
    
            v2.RegistrarViaje(24.0);

            Console.WriteLine("[PRUEBA DE VALIDACIÓN DEFENSIVA]: Intentando ingresar kilometraje negativo(-50.0 km)...");
    
            v1.RegistrarViaje(-50.0);

            Console.WriteLine("================ FICHA TÉCNICA CONSOLIDADA ================");
        Console.WriteLine("UNIDAD #1:");
        v1.MostrarFichaTecnica();
        Console.WriteLine("UNIDAD #2:");
        v2.MostrarFichaTecnica();
        Console.WriteLine("UNIDAD #3:");
        v3.MostrarFichaTecnica();
        Console.WriteLine("===========================================================");
        }
    }
}
/*
EJERCICIO
📌 Título de la Actividad: Sistema de Control de Flota Vehicular y Conductores con Encapsulamiento
Contexto y Planteamiento del Problema: Una agencia de transporte universitario y logística estudiantil necesita un sistema en consola para administrar su parque 
vehicular y asignar conductores certificados a cada unidad. Debes construir el núcleo del dominio respetando estrictamente el encapsulamiento para evitar que 
cualquier agente externo corrompa los kilometrajes o asigne identificadores inválidos.

Requerimientos Técnicos Paso a Paso: 
1. **Creación de la Clase `Conductor`:** 
	- Atributos privados: `idConductor` (String), `nombreCompleto` (String), `licencia` (String) y `aniosExperiencia` (int). 
	- Constructor con todos los parámetros y constructor por defecto. 
	- Métodos Getters y Setters para cada atributo. El setter de `aniosExperiencia` debe rechazar valores negativos emitiendo una alerta o restableciendo a 0. 
	- Método `imprimirPerfil(): void` que formatee la información profesional del conductor.

2. **Creación de la Clase `Vehiculo`:** 
	- Atributos privados: `vin` (String), `marca` (String), `modelo` (String), `anio` (int), `kilometraje` (double) y `conductorAsignado` (referencia de tipo `Conductor`). 
	- Constructor parametrizado que reciba VIN, marca, modelo y año. El kilometraje inicial debe arrancar en 0.0 y el conductor en `null`. 
	- Método de negocio `asignarConductor(Conductor nuevoConductor): void` que enlace la unidad con el operador. 
	- Método de negocio `registrarViaje(double kmRecorridos): void` que sume los kilómetros al total existente únicamente si `kmRecorridos > 0`. Si el valor es negativo,
		debe rechazar la operación. 
	- Método `mostrarFichaTecnica(): void` que imprima el estado de la unidad, indicando si cuenta con conductor asignado o si se encuentra en espera.

3. **Clase Principal de Pruebas (`Main.java` o `Program.cs`):** 
	- En el método `main` / `Main`, instanciar al menos 2 objetos de tipo `Conductor` con datos distintos. 
	- Instanciar al menos 3 objetos de tipo `Vehiculo` independientes. 
	- Asignar conductores, registrar 3 viajes en diferentes unidades e imprimir la ficha técnica de cada una para constatar que cada objeto mantiene su propio estado de 
		memoria en el Heap sin interferir con los demás.
*/