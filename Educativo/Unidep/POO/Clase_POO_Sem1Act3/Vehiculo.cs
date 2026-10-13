using System;
using System.Collections.Generic;
using System.Text;

namespace Clase_POO_Sem1Act3
{
    internal class Vehiculo
    {
        private string vin;
        private string marca;
        private string modelo;
        private int anio;
        private double kilometraje;
        private Conductor? conductorAsignado; // Composición: guarda la referencia al objeto Conductor

        public Vehiculo(string vin, string marca, string modelo, int anio)
        {
            this.vin = vin;
            this.marca = marca;
            this.modelo = modelo;
            this.anio = anio;
            this.kilometraje = 0.0;
            this.conductorAsignado = null;
        }

        // Métodos Get sencillos para principiantes
        public string Vin
        {
            get { return this.vin; }
        }

        public string Marca
        {
            get { return this.marca; }
        }

        public string Modelo
        {
            get { return this.modelo; }
        }

        public int Anio
        {
            get { return this.anio; }
        }

        public double Kilometraje
        {
            get { return this.kilometraje; }
        }

        public Conductor? ConductorAsignado
        {
            get { return this.conductorAsignado; }
        }

        public void AsignarConductor(Conductor nuevoConductor)
        {
            this.conductorAsignado = nuevoConductor;
            if (nuevoConductor != null)
            {
                Console.WriteLine($"[ASIGNACIÓN]: Conductor {nuevoConductor.IdConductor} asignado exitosamente a unidad {marca} {modelo}.");
            }
        }

        public bool RegistrarViaje(double kmRecorridos)
        {
            if (kmRecorridos > 0)
            {
                double kmAnterior = this.kilometraje;
                this.kilometraje += kmRecorridos;
                Console.WriteLine($">> OK: Kilometraje actualizado de {kmAnterior:F1} km a {this.kilometraje:F1} km.");
                return true;
            }
            else
            {
                Console.WriteLine($">> [ALERTA DE SEGURIDAD]: Rechazado kilometraje inválido: {kmRecorridos:F1} km. La distancia debe ser mayor a 0.");
                Console.WriteLine($">> Estado actual de la unidad protegido: Kilometraje permanece en {this.kilometraje:F1} km.");
                return false;
            }
        }

        public void MostrarFichaTecnica()
        {
            Console.WriteLine($"  - Marca / Modelo: {marca} {modelo} {anio} | VIN: {vin}");
            Console.WriteLine($"  - Kilometraje Total Acumulado: {kilometraje:F2} km");
            if (conductorAsignado != null)
            {
                Console.WriteLine($"  - Operador Titular: {conductorAsignado.NombreCompleto} (Licencia: {conductorAsignado.Licencia})");
                Console.WriteLine("  - Estatus Operativo: [EN SERVICIO ACTIVO]");
            }
            else
            {
                Console.WriteLine("  - Operador Titular: [SIN CONDUCTOR ASIGNADO - EN ESPERA]");
                Console.WriteLine("  - Estatus Operativo: [DISPONIBLE EN PATIO CENTRAL]");
            }
        }
    }
}
