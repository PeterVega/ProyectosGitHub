namespace Clase_POO_Sem4Act1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== JERARQUÍA VEHICULAR Y CÁLCULO POLIMÓRFICO (SEMANA 4 - ACT 1) ===");

            List<Vehiculo> flota = new List<Vehiculo>
            {
                new Automovil("ABC-123", "Toyota", "Corolla", 4),
                new CamionDeCarga("TRK-999", "Kenworth", "T680", 12.5)
            };

            double kmViaje = 200.0;

            foreach (Vehiculo v in flota)
            {
                v.MostrarFicha();
                double consumo = v.CalcularConsumoLitros(kmViaje);
                Console.WriteLine($"   Consumo en {kmViaje} km: {consumo:F2} Litros");
            }

            Console.WriteLine("===================================================================");
        }
    }
}

/*
EJERCICIO

📌 Título: Herencia y Sobrescritura Virtual en Jerarquía Vehicular en C#
Contexto y Planteamiento del Problema: Una empresa de logística requiere calcular el consumo estimado de combustible de sus unidades para planificar sus costos de ruta. Se debe modelar una jerarquía orientada a objetos con una clase base y clases derivadas especializadas.
Requerimientos Técnicos Paso a Paso: 
1. **Clase Base `Vehiculo`:** 
	- Atributos protegidos (`protected`): `_placas` (string), `_marca` (string), `_modelo` (string). 
	- Constructor parametrizado. 
	- Método virtual: `public virtual double CalcularConsumoLitros(double kilometros)`: Retorna `kilometros / 12.0` como estimación base. 
	- Método `MostrarFicha(): void`.
	
2. **Clase Derivada `Automovil` (hereda de `Vehiculo`):** 
	- Atributo privado: `_pasajeros` (int). 
	- Constructor que invoque a `: base(placas, marca, modelo)`. 
	- `override CalcularConsumoLitros(double km)`: Añade un 5% de combustible extra por cada pasajero adicional.

3. **Clase Derivada `CamionDeCarga` (hereda de `Vehiculo`):** 
	- Atributo privado: `_toneladasCarga` (double). 
	- Constructor que invoque a `: base(placas, marca, modelo)`. 
	- `override CalcularConsumoLitros(double km)`: Base de 3.0 km/L más 0.2 litros extra por cada tonelada transportada.

4. **Programa Principal (`Program.cs`):** 
	- Crear un automóvil y un camión. 
	- Agruparlos en una lista `List<Vehiculo>` e invocar el cálculo polimórficamente.

*/