using Microsoft.Win32;

namespace Clase_POO_Sem1Act1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CLÍNICA MÉDICA UNIVERSITARIA - TRIAGE INICIAL (SEMANA 1 - ACT 1) ===");

            Console.WriteLine("[REGISTRO 1]: Creando paciente con datos válidos...");
            Paciente p1 = new Paciente("PAC-001", "Ana García", 22, 36.6);
            p1.MostrarFicha();

            Console.WriteLine("[REGISTRO 2]: Intentando registrar temperatura inválida(52.5°C)...");
            Paciente p2 = new Paciente("PAC-002", "Roberto Soto", 29, 52.5);
            p2.MostrarFicha();

            Console.WriteLine();
            ConsultaMedica c1 = new ConsultaMedica("MED-2026-01", p1, "Chequeo de rutina semestral");
            c1.ImprimirResumenConsulta();

            Console.WriteLine("=========================================================================");
        }
    }
}
/*
PROBLEMA DESCRIPCION:
📌 Título: Modelado de la Clase Paciente y Consulta Médica con Encapsulamiento en C#
Contexto y Planteamiento del Problema: Un centro de salud estudiantil requiere un módulo en consola para registrar el ingreso y triage de pacientes. Tu labor como desarrollador es modelar las entidades `Paciente` y `ConsultaMedica` en C# asegurando que la integridad de los datos esté blindada mediante encapsulamiento estricto.

Requerimientos Técnicos Paso a Paso: 
1. **Clase `Paciente`:** 
	- Atributos privados: `_idPaciente` (string), `_nombreCompleto` (string), `_edad` (int), `_temperatura` (double). - Constructor con parámetros para inicializar todos los campos. 
	- Propiedades públicas con validación: 
		- `Edad`: Debe ser mayor a 0 y menor a 125. Si no cumple, asignar 18 por defecto y mostrar advertencia. 
		- `Temperatura`: Debe encontrarse entre 34.0°C y 43.0°C. Si no cumple, asignar 36.5°C por defecto. 
	- Método `ObtenerDiagnosticoFiebre(): string` que devuelva "HIPOTERMIA" si temp < 36.0, "NORMAL" si entre 36.0 y 37.5, o "FIEBRE ALTA" si > 37.5. 
	- Método `MostrarFicha(): void` que imprima los datos del paciente formateados.
	
2. **Clase `ConsultaMedica`:** 
	- Atributos privados: `_folio` (string), `_paciente` (referencia de tipo `Paciente`), `_motivo` (string). 
	- Constructor que enlace el folio, el paciente y el motivo. 
	- Método `DeterminarPrioridad(): bool` que devuelva true si el paciente presenta fiebre alta o es mayor a 65 años. 
	- Método `ImprimirResumenConsulta(): void`.

3. **Programa Principal (`Program.cs`):** 
	- En el método `Main`, instanciar al menos 2 pacientes (uno con valores normales y otro provocando la validación defensiva). 
	- Instanciar una consulta médica vinculada a un paciente y mostrar los resultados en consola.
 */