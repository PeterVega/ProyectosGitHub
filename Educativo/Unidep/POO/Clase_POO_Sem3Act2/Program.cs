namespace Clase_POO_Sem3Act2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sucursales = { "Sucursal Norte", "Sucursal Centro", "Sucursal Sur" };
            MatrizVentas tablero = new MatrizVentas(sucursales);

            // Carga de datos de prueba
            double[,] datos = {
                { 12500, 14200, 11800, 16500, 19000 },
                { 18900, 17500, 21000, 19800, 24500 },
                {  9800, 11200, 10500, 13000, 15400 }
            };

            for (int s = 0; s < 3; s++)
                for (int d = 0; d < 5; d++)
                    tablero.RegistrarVenta(s, d, datos[s, d]);

            tablero.ImprimirReporte();
        }
    }
}
/*
 EJERCICIO

📌 Título: Matriz Bidimensional de Ventas Semanales por Sucursal en C#
Contexto y Planteamiento del Problema: Una cadena comercial universitaria necesita consolidar en una matriz bidimensional el rendimiento financiero de sus 3 sucursales durante los 5 días hábiles de la semana para generar reportes tabulares y análisis gerencial.
Requerimientos Técnicos Paso a Paso: 
	1. **Clase `MatrizVentas`:** 
		- Atributos privados: `_nombresSucursales` (`string[]` de 3 elementos) y `_matrizVentas` (`double[,]` de 3 filas x 5 columnas). 
		- Constructor que reciba los nombres de las sucursales e inicialice la matriz. 
		- Métodos: 
			- `RegistrarVenta(int sucursal, int dia, double monto): void`: Valida coordenadas y asigna el monto. 
		- `ObtenerTotalSucursal(int sucursal): double`: Suma la fila correspondiente recorriendo las 5 columnas. 
		- `ObtenerTotalDia(int dia): double`: Suma la columna correspondiente recorriendo las 3 filas. 
		- `ObtenerGranTotal(): double`: Suma global de todas las celdas. 
		- `ImprimirMatrizConsolidada(): void`: Formatea en terminal la tabla con bordes y encabezados.
		
2. **Programa Principal (`Program.cs`):** 
	- Cargar datos de prueba representativos para las 3 sucursales en los 5 días e imprimir el reporte consolidado.
*/