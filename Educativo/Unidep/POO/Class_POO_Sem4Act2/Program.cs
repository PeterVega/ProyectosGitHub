namespace Class_POO_Sem4Act2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== COMERCIO ELECTRÓNICO - CHECKOUT POLIMÓRFICO (SEMANA 4 - ACT 2) ===");

            List<Producto> carrito = new List<Producto>
            {
                new ProductoFisico("SKU-FIS-01", "Libro Patrones GoF", 450.00m, 1.2),
                new ProductoDigital("SKU-DIG-02", "Licencia Visual Studio Pro", 1200.00m, 3500.0)
            };

            decimal totalOrden = 0;
            foreach (Producto p in carrito)
            {
                p.ImprimirDetalle();
                totalOrden += p.CalcularPrecioFinal();
                Console.WriteLine();
            }

            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($">> TOTAL CONSOLIDADO DE LA ORDEN: {totalOrden:C}");
            Console.WriteLine("======================================================================");
        }
    }
}
/*
 EJERICIO

📌 Título: Catálogo de Tienda Virtual con Productos Físicos y Digitales en C#
Contexto y Planteamiento del Problema: Una plataforma de comercio electrónico necesita liquidar el carrito de compras de los clientes. Los productos físicos incurren en costos de flete y embalaje según su peso, mientras que los productos digitales no pagan flete pero están sujetos a impuestos de servicios digitales.
Requerimientos Técnicos Paso a Paso: 

1. **Clase Abstracta `Producto`:** 
	- Atributos protegidos: `_sku` (string), `_nombre` (string), `_precioBase` (decimal). 
	- Constructor protegido. 
	- Método abstracto: `public abstract decimal CalcularPrecioFinal();` 
	- Método concreto: `public virtual void ImprimirDetalle()`.
	
2. **Clase `ProductoFisico`:** 
	- Atributo privado: `_pesoKg` (double). 
	- Costo de envío: `$50.00` fijos + `$25.00` por cada kg adicional después del primero. 
	- Implementa `CalcularPrecioFinal()`.

3. **Clase `ProductoDigital`:** 
	- Atributo privado: `_tamanioMB` (double). 
	- Impuesto digital: 16% sobre el precio base. 
	- Costo de envío: `$0.00`. 
	- Implementa `CalcularPrecioFinal()`.

4. **Programa Principal (`Program.cs`):** 
	- Crear una lista `List<Producto>`, agregar al menos un producto físico y uno digital, y totalizar polimórficamente la orden.
*/