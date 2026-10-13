using System;
using System.Collections.Generic;
using System.Text;

namespace Clase_POO_Sem2Act3
{
    internal class SolicitudCredito
    {
        private string folioSolicitud;
        private string nombreEstudiante;
        private double ingresoMensual;
        private double montoSolicitado;
        private int plazoMeses;
        private bool tieneHistorialMoroso;
        private double tasaInteresAnual;

        public SolicitudCredito(string folioSolicitud, string nombreEstudiante, double ingresoMensual,
                                double montoSolicitado, int plazoMeses, bool tieneHistorialMoroso,
                                double tasaInteresAnual)
        {
            this.folioSolicitud = folioSolicitud;
            this.nombreEstudiante = nombreEstudiante;
            this.ingresoMensual = ingresoMensual;
            this.montoSolicitado = montoSolicitado;
            this.plazoMeses = plazoMeses;
            this.tieneHistorialMoroso = tieneHistorialMoroso;
            this.tasaInteresAnual = tasaInteresAnual;
        }

        // Propiedades explícitas con get y set estándar para alumnos principiantes
        public string FolioSolicitud
        {
            get { return this.folioSolicitud; }
            set { this.folioSolicitud = value; }
        }

        public string NombreEstudiante
        {
            get { return this.nombreEstudiante; }
            set { this.nombreEstudiante = value; }
        }

        public double IngresoMensual
        {
            get { return this.ingresoMensual; }
            set { this.ingresoMensual = value; }
        }

        public double MontoSolicitado
        {
            get { return this.montoSolicitado; }
            set { this.montoSolicitado = value; }
        }

        public int PlazoMeses
        {
            get { return this.plazoMeses; }
            set { this.plazoMeses = value; }
        }

        public bool TieneHistorialMoroso
        {
            get { return this.tieneHistorialMoroso; }
            set { this.tieneHistorialMoroso = value; }
        }

        public double TasaInteresAnual
        {
            get { return this.tasaInteresAnual; }
            set { this.tasaInteresAnual = value; }
        }

        public double CalcularCuotaMensual()
        {
            // Paso 1: Convertir tasa anual a tasa mensual decimal
            double tasaMensual = (this.tasaInteresAnual / 100.0) / 12.0;

            // Paso 2: Calcular el factor de potencia (1 + i)^n
            double factorPotencia = Math.Pow(1.0 + tasaMensual, this.plazoMeses);

            // Paso 3: Calcular numerador y denominador paso a paso
            double numerador = this.montoSolicitado * (tasaMensual * factorPotencia);
            double denominador = factorPotencia - 1.0;

            // Paso 4: Cuota fija mensual
            double cuota = numerador / denominador;
            return cuota;
        }

        public bool EvaluarAprobacion()
        {
            double cuota = this.CalcularCuotaMensual();
            double limiteCapacidad = this.ingresoMensual * 0.35; // 35% del sueldo del estudiante

            // Evaluamos cada regla por separado de forma sencilla y clara:
            bool noEsMoroso = (this.tieneHistorialMoroso == false);
            bool cuotaPermitida = (cuota <= limiteCapacidad);
            bool plazoValido = (this.plazoMeses >= 6 && this.plazoMeses <= 36);
            bool montoValido = (this.montoSolicitado >= 2000.0 && this.montoSolicitado <= 80000.0);

            bool aprobada = noEsMoroso && cuotaPermitida && plazoValido && montoValido;
            return aprobada;
        }

        public void ImprimirDictamen()
        {
            double cuota = this.CalcularCuotaMensual();
            double razonCuotaIngreso = (cuota / this.ingresoMensual) * 100.0;
            double tasaMensual = (this.tasaInteresAnual / 100.0) / 12.0;
            bool aprobada = this.EvaluarAprobacion();

            Console.WriteLine($"  - Folio: {this.folioSolicitud} | Estudiante: {this.nombreEstudiante}");
            Console.WriteLine($"  - Ingreso Mensual Comprobado: ${this.ingresoMensual:N2} MXN");
            Console.WriteLine($"  - Monto Solicitado: ${this.montoSolicitado:N2} MXN | Plazo: {this.plazoMeses} meses | Tasa Anual: {this.tasaInteresAnual:F2}%");
            Console.WriteLine($"  - Tasa Mensual Efectiva (i): {tasaMensual * 100:F4}%");
            Console.WriteLine($"  - Cuota Fija Mensual Calculada: ${cuota:N2} MXN");
            Console.WriteLine($"  - Razón Cuota / Ingreso: {razonCuotaIngreso:F2}% (Máximo Permitido: 35.00%)");
            Console.WriteLine($"  - Historial Moroso Registrado: {(this.tieneHistorialMoroso ? "SÍ (true)" : "NO (false)")}");

            if (aprobada)
            {
                Console.WriteLine("  >> EVALUACIÓN BOOLEANA (!moroso && cuota<=limite && plazoValido && montoValido): TRUE");
                Console.WriteLine("  >> DICTAMEN FINAL: ★ CRÉDITO EDUCATIVO PRE-APROBADO ★");
            }
            else
            {
                Console.Write("  >> DICTAMEN FINAL: ✖ RECHAZADO: ");
                if (this.tieneHistorialMoroso)
                {
                    Console.WriteLine("Reporte negativo en Buró de Crédito.");
                }
                else if (cuota > this.ingresoMensual * 0.35)
                {
                    Console.WriteLine($"Capacidad de endeudamiento excedida ({razonCuotaIngreso:F2}% > 35%).");
                }
                else if (this.plazoMeses < 6 || this.plazoMeses > 36)
                {
                    Console.WriteLine("Plazo crediticio no admitido por políticas (Rango permitido: 6 a 36 meses).");
                }
                else
                {
                    Console.WriteLine("Monto solicitado fuera de límites.");
                }
            }
        }
    }
}
