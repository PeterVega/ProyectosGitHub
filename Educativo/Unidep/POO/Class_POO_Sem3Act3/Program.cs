namespace Class_POO_Sem3Act3
{
    internal class Program
    {
        private static readonly string[] Alumnos = {
        "García, Ana", "Mendoza, Carlos", "Paredes, Lucía", "Torres, Miguel", "Vega, Daniela"
    };

        private static readonly string[] Evaluaciones = {
        "PARCIAL 1", "PARCIAL 2", "TAREAS", "PROYECTO"
    };

        private static double[,] notas = {
        { 95.0, 88.0, 100.0, 92.0 },
        { 70.0, 65.0,  80.0, 75.0 },
        { 60.0, 55.0,  65.0, 58.0 },
        { 85.0, 90.0,  92.0, 89.0 },
        { 100.0, 96.0, 98.0, 99.0 }
    };

        public static void Main(string[] args)
        {
            int opcion = 0;

            do
            {
                Console.WriteLine("===============================================================");
            Console.WriteLine("   SISTEMA DE CONTROL ESCOLAR Y CALIFICACIONES UNIDEP");
            Console.WriteLine("===============================================================");
            Console.WriteLine("1. Cargar / Restablecer matriz de calificaciones del grupo");
            Console.WriteLine("2. Mostrar matriz bidimensional completa (Alumnos vs Evaluaciones)");
            Console.WriteLine("3. Calcular promedio general por alumno y estatus (Aprobado/Reprobado)");
            Console.WriteLine("4. Calcular promedio grupal por cada evaluación parcial");
            Console.WriteLine("5. Identificar al alumno con mayor y menor rendimiento");
            Console.WriteLine("6. Buscar registro de calificaciones por nombre de alumno");
            Console.WriteLine("7. Salir del sistema");
            Console.WriteLine("---------------------------------------------------------------");
            Console.Write("Seleccione una opción [1-7]: ");

            string? entrada = Console.ReadLine();
            if (!int.TryParse(entrada, out opcion))
            {
                Console.WriteLine(">> [ERROR]: Digite un número entre 1 y 7.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.WriteLine(">> Matriz de calificaciones reinicializada con 5 registros base.");
                    break;
                case 2:
                    MostrarMatriz();
                    break;
                case 3:
                    CalcularPromediosAlumnos();
                    break;
                case 4:
                    CalcularPromediosEvaluaciones();
                    break;
                case 5:
                    IdentificarExtremos();
                    break;
                case 6:
                    Console.Write("Ingrese el nombre del estudiante a consultar: ");
                    string? termino = Console.ReadLine();
                    BuscarAlumno(termino ?? "");
                    break;
                case 7:
                    Console.WriteLine("Saliendo de la sesión escolar... ¡Datos procesados exitosamente!");
                    break;
                default:
                    Console.WriteLine(">> Opción no válida.");
                    break;
            }
        } while (opcion != 7);
    }

    private static void MostrarMatriz()
    {
        Console.WriteLine("MATRIZ DE CALIFICACIONES [5 Alumnos x 4 Evaluaciones]:");
        Console.WriteLine("========================================================================");
        Console.WriteLine($"{"ALUMNO",-23} | {Evaluaciones[0],-9} | {Evaluaciones[1],-9} | {Evaluaciones[2],-6} | {Evaluaciones[3],-8}");
        Console.WriteLine("------------------------------------------------------------------------");

        for (int i = 0; i < Alumnos.Length; i++)
        {
            Console.Write($"[{i}] {Alumnos[i],-19} | ");
            for (int j = 0; j < Evaluaciones.Length; j++)
            {
                Console.Write($"{notas[i, j],7:F1}  |");
            }
            Console.WriteLine();
        }
        Console.WriteLine("========================================================================");
    }

    private static void CalcularPromediosAlumnos()
    {
        Console.WriteLine("CALCULANDO PROMEDIOS INDIVIDUALES (Ponderación 25% por columna):");
        for (int i = 0; i < Alumnos.Length; i++)
        {
            double suma = 0.0;
            for (int j = 0; j < Evaluaciones.Length; j++)
            {
                suma += notas[i, j];
            }
            double prom = suma / Evaluaciones.Length;
            
            // Decisión sencilla con if-else para principiantes
            string estatus;
            if (prom >= 70.0)
            {
                estatus = "[APROBADO ★]";
            }
            else
            {
                estatus = "[REPROBADO ✖]";
            }
            Console.WriteLine($"- {Alumnos[i],-20} -> Promedio: {prom,5:F2} {estatus}");
        }
    }

    private static void CalcularPromediosEvaluaciones()
    {
        Console.WriteLine("PROMEDIO GRUPAL POR CADA EVALUACIÓN:");
        for (int j = 0; j < Evaluaciones.Length; j++)
        {
            double suma = 0.0;
            for (int i = 0; i < Alumnos.Length; i++)
            {
                suma += notas[i, j];
            }
            double prom = suma / Alumnos.Length;
            Console.WriteLine($"- {Evaluaciones[j],-12}: Promedio grupal = {prom,5:F2} pts");
        }
    }

    private static void IdentificarExtremos()
    {
        Console.WriteLine("ESTADÍSTICAS DEL GRUPO:");
        double mayor = -1.0;
        double menor = 999.0;
        string mejor = "";
        string peor = "";

        for (int i = 0; i < Alumnos.Length; i++)
        {
            double suma = 0.0;
            for (int j = 0; j < Evaluaciones.Length; j++)
            {
                suma += notas[i, j];
            }
            double prom = suma / Evaluaciones.Length;

            if (prom > mayor)
            {
                mayor = prom;
                mejor = Alumnos[i];
            }

            if (prom < menor)
            {
                menor = prom;
                peor = Alumnos[i];
            }
        }

        Console.WriteLine($"★ Alumno con Mayor Promedio: {mejor} ({mayor:F2} pts)");
        Console.WriteLine($"✖ Alumno en Riesgo Académico: {peor} ({menor:F2} pts)");
    }

    private static void BuscarAlumno(string termino)
    {
        bool hallado = false;
        string t = termino.ToLower();

        for (int i = 0; i < Alumnos.Length; i++)
        {
            if (Alumnos[i].ToLower().Contains(t))
            {
                double suma = 0.0;
                for (int j = 0; j < Evaluaciones.Length; j++) suma += notas[i, j];
                double prom = suma / Evaluaciones.Length;

                Console.WriteLine($">> [BÚSQUEDA EXITOSA]: Estudiante encontrado en índice [{i}].");
                Console.WriteLine($"   Notas: P1: {notas[i, 0]:F1} | P2: {notas[i, 1]:F1} | Tareas: {notas[i, 2]:F1} | Proyecto: {notas[i, 3]:F1} -> Promedio: {prom:F2}");
                hallado = true;
                break;
            }
        }

        if (!hallado)
        {
            Console.WriteLine($">> [SIN RESULTADOS]: No se encontró a '{termino}'.");
        }
    }
    }
}
/*
 EJERCICIO

📌 Título de la Actividad: Sistema Escolar de Calificaciones con Matrices y Menú Interactivo
Contexto y Planteamiento del Problema: El Departamento de Servicios Escolares de UNIDEP solicita un software de consola para capturar, procesar y analizar las 
calificaciones de los alumnos de un grupo en las distintas evaluaciones del cuatrimestre. El sistema debe permitir la navegación interactiva a través de un menú 
profesional que no se cierre hasta que el usuario elija expresamente salir.

Requerimientos Técnicos Paso a Paso: 
	1. **Control de Flujo con Menú Interactivo (`do-while` + `switch-case`):** 
		- El sistema debe presentar de forma continua el siguiente menú: 
			- `1. Capturar / Inicializar calificaciones del grupo` 
			- `2. Mostrar matriz completa de calificaciones (Alumnos vs Evaluaciones)` 
			- `3. Calcular y mostrar promedio general de cada alumno` 
			- `4. Calcular promedio grupal por cada evaluación / parcial` 
			- `5. Identificar al alumno con mayor y menor promedio` 
			- `6. Buscar calificaciones de un alumno por nombre o índice` 
			- `7. Salir del sistema` 
			- La navegación del menú debe ejecutarse dentro de un bucle `do-while` y despacharse con `switch-case` (incluyendo bloque `default` para opciones inválidas).
			
2. **Estructuras de Datos Matriciales:** 
	- Definir un arreglo unidimensional `String[] nombresAlumnos` para los nombres de $N$ estudiantes (ej. 5 alumnos). 
	- Definir una matriz bidimensional `double[][] notas` de dimensiones $N \times M$ (ej. 5 alumnos $\times$ 4 evaluaciones: Tarea 1, Tarea 2, Examen, Proyecto). 
	- Permitir precargar datos de muestra para agilizar las pruebas o capturarlos vía teclado mediante `Scanner` (Java) o `Console.ReadLine()` (C#).

3. **Algoritmos con Bucles Anidados (`for` y `for-each` / `foreach`):** 
	- En la opción 2, imprimir la matriz con formato tabular usando dos bucles `for` anidados. 
	- En la opción 3, calcular el promedio de cada fila y categorizar con `if-else`: Aprobado ($\ge 70$) o Reprobado ($< 70$). 
	- En la opción 4, recorrer la matriz por columnas para obtener la estadística de cada evaluación. 
	- En la opción 5, implementar un algoritmo de búsqueda de máximos y mínimos comparando los promedios obtenidos. 
	- En la opción 6, implementar búsqueda secuencial con salida anticipada mediante sentencia `break`.

4. **Validación de Límites de Arreglos:** 
	- Todo acceso a las celdas debe protegerse validando que los índices pertenezcan estrictamente al rango $[0, \text{longitud} - 1]$, documentando la prevención de excepciones de desbordamiento.
*/