namespace Clase_POO_Sem2Act2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CONTROL ESCOLAR Y PROGRAMA DE BECAS UNIDEP (SEMANA 2 - ACT 2) ===");

            Console.WriteLine("[EXPEDIENTE 1]: Estudiante de Excelencia");
            AlumnoExpediente a1 = new AlumnoExpediente("ALU-2026-01", "Valeria Mendoza", "Ing. Software", 9.8, 9.5, 10.0);
            a1.ImprimirBoleta();

            Console.WriteLine("[EXPEDIENTE 2]: Estudiante Regular");
            AlumnoExpediente a2 = new AlumnoExpediente("ALU-2026-02", "Jorge Medina", "Ing. Industrial", 7.0, 6.5, 8.0);
            a2.ImprimirBoleta();

            Console.WriteLine("=====================================================================");
        }
    }
}
/*
 EJERCICIO

📌 Título: Expediente Académico y Beca con Cálculo de Promedio Ponderado en C#
Contexto y Planteamiento del Problema: El departamento de Servicios Escolares de UNIDEP requiere un módulo que calcule el promedio ponderado de los estudiantes y determine automáticamente el otorgamiento de becas de colegiatura con base en su rendimiento semestral.
Requerimientos Técnicos Paso a Paso: 
	1. **Clase `AlumnoExpediente`:** 
		- Atributos privados: `_matricula` (string), `_nombre` (string), `_carrera` (string), `_parcial1` (double), `_parcial2` (double), `_proyectoFinal` (double), `_porcentajeBeca` (int). 
		- Constructor completo que reciba matrícula, nombre, carrera y las 3 calificaciones. 
		- Constructor alternativo que reciba solo matrícula, nombre y carrera (inicializando notas en 0.0). 
		- Métodos: 
			- `CalcularPromedioPonderado(): double`: Fórmula: `(Parcial1 * 0.30) + (Parcial2 * 0.30) + (Proyecto * 0.40)`. 
		- `DeterminarEstatus(): string`: "REPROBADO" si promedio < 7.0, "APROBADO" si >= 7.0, "EXCELENCIA" si >= 9.5. 
		- `CalcularBeca(): int`: Devuelve 50 si promedio >= 9.5; 25 si promedio >= 8.5 y < 9.5; 0 en cualquier otro caso. 
		- `ImprimirBoleta(): void`.

	2. **Programa Principal (`Program.cs`):** 
		- Instanciar al menos 2 expedientes con distintos rendimientos e imprimir sus boletas en consola.
*/