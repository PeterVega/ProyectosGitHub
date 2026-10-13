namespace Clase_POO_Sem3Act1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RegistroCalificaciones gestor = new RegistroCalificaciones(10);
            bool salir = false;

            // Simulación guiada para verificar
            Console.WriteLine("=== GESTOR DE CALIFICACIONES EN CONSOLA (SEMANA 3 - ACT 1) ===");
            gestor.AgregarNota(8.5);
            gestor.AgregarNota(9.8);
            gestor.AgregarNota(7.2);

            gestor.MostrarTodas();
            Console.WriteLine($">> [ESTADÍSTICA]: Promedio del grupo: {gestor.CalcularPromedio():F2} / 10.0");

            gestor.ObtenerExtremos(out double maxima, out double minima);
            Console.WriteLine($">> [EXTREMOS]: Nota más alta: {maxima:F1} | Nota más baja: {minima:F1}");
            Console.WriteLine("==============================================================");
        }
    }
}
/*
EJERICIO

📌 Título: Registro de Calificaciones en Arreglo con Menú de Consola en C#
Contexto y Planteamiento del Problema: Un profesor necesita una herramienta ligera en consola para registrar las calificaciones de sus estudiantes durante la clase, consultar el listado y obtener estadísticas rápidas de promedio, nota mínima y nota máxima sin usar colecciones dinámicas complejas, afianzando el uso de arreglos nativos (`double[]`).

Requerimientos Técnicos Paso a Paso: 
	1. **Clase `RegistroCalificaciones`:** 
		- Atributos privados: `_notas` (arreglo `double[]` de tamaño 10) y `_cantidadRegistrada` (int). 
		- Constructor que inicialice el arreglo y ponga el contador en 0. 
		- Métodos: 
			- `AgregarNota(double nota): bool`: Si hay espacio y la nota está entre 0.0 y 10.0, la guarda y retorna true. 
		- `MostrarTodas(): void`: Recorre el arreglo imprimiendo solo los elementos guardados. 
		- `CalcularPromedio(): double`: Suma los elementos y divide entre `_cantidadRegistrada`. 
		- `ObtenerExtremos(out double max, out double min): void`: Algoritmo clásico de recorrido para hallar mayor y menor.
		
2. **Clase `Program.cs` con Menú Interactivo:** 
	- Bucle `do-while` que despliegue el menú. 
	- Estructura `switch-case` para atender las opciones 1 a 5. 
	- Lectura segura con `double.TryParse` para evitar que el programa se caiga si el usuario escribe texto.
*/