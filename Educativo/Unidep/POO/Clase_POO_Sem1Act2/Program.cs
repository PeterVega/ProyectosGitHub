namespace Clase_POO_Sem1Act2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BIBLIOTECA CENTRAL UNIDEP - CONTROL DE PRÉSTAMOS (SEMANA 1 - ACT 2) ===");
            Libros l1 = new Libros("ISBN-978-01", "Clean Code", "Robert Martin", 3);
            Libros l2 = new Libros("ISBN-978-02", "C# 12 in a Nutshell", "Joseph Albahari", 1);

            Console.WriteLine("[CATÁLOGO INICIAL]:");
            l1.MostrarEstado();
            l2.MostrarEstado();

            UsuarioLector u1 = new UsuarioLector("LECT-101", "María López");
            UsuarioLector u2 = new UsuarioLector("LECT-102", "Juan Pérez");
            UsuarioLector u3 = new UsuarioLector("LECT-103", "Diana Vega");

            Console.WriteLine("-- - SIMULACIÓN DE PRÉSTAMOS-- - ");
            Console.WriteLine($"[OPERACIÓN 1]: {u1.Nombre} solicita '{l1.Titulo}'...");
            l1.PrestarEjemplar();

            Console.WriteLine($"[OPERACIÓN 2]: { u2.Nombre} solicita '{l2.Titulo}'...");
            l2.PrestarEjemplar();

            Console.WriteLine($"[OPERACIÓN 3]: { u3.Nombre} solicita '{l2.Titulo}'...");
            l2.PrestarEjemplar(); // Intento cuando el stock es 0

            Console.WriteLine("-- - DEVOLUCIÓN DE MATERIAL-- - ");
            Console.WriteLine($"[OPERACIÓN 4]: Devolución de '{l2.Titulo}' por {u2.Nombre}...");
            l2.DevolverEjemplar();

            Console.WriteLine("==========================================================================");
        }
    }
}
/*
 EJERCICIO
 📌 Título: Catálogo de Biblioteca y Control de Préstamos con Múltiples Instancias en C#

Contexto y Planteamiento del Problema: La biblioteca universitaria requiere un módulo de software orientado a objetos para controlar el préstamo y la devolución de libros físicos. Cada libro cuenta con un total de ejemplares adquiridos y una cantidad dinámica de copias disponibles en estantería.

Requerimientos Técnicos Paso a Paso: 
1. **Clase `Libro`:** 
	- Atributos privados: `_isbn` (string), `_titulo` (string), `_autor` (string), `_ejemplaresTotales` (int), `_ejemplaresDisponibles` (int). 
	- Constructor con parámetros que reciba ISBN, título, autor y total de ejemplares. Al iniciar, los ejemplares disponibles deben ser iguales a los totales. 
	- Propiedades de solo lectura (`get`) para ISBN, Título, Autor y Totales. 
	- Método `PrestarEjemplar(): bool`: Si `_ejemplaresDisponibles > 0`, decrementa en 1 y devuelve `true`. De lo contrario, imprime mensaje de agotado y devuelve `false`. 
	- Método `DevolverEjemplar(): bool`: Si `_ejemplaresDisponibles < _ejemplaresTotales`, incrementa en 1 y devuelve `true`. Si ya estaban todas las copias, rechaza la operación. 
	- Método `MostrarEstado(): void`.

2. **Clase `UsuarioLector`:** 
	- Atributos privados: `_idMatricula` (string), `_nombre` (string), `_carrera` (string). 
	- Constructor y propiedades accesibles.

3. **Clase de Pruebas (`Program.cs`):** 
	- Instanciar al menos 2 libros y 3 usuarios. 
	- Ejecutar una secuencia de préstamos exitosos, un intento de préstamo cuando el stock sea 0 (validando la denegación), y una devolución exitosa.
 */