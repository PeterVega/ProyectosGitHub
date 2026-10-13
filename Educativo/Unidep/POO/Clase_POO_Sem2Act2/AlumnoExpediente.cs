using System;
using System.Collections.Generic;
using System.Text;

namespace Clase_POO_Sem2Act2
{
    internal class AlumnoExpediente
    {
        private string _matricula;
        private string _nombre;
        private string _carrera;
        private double _parcial1;
        private double _parcial2;
        private double _proyectoFinal;

        public AlumnoExpediente(string matricula, string nombre, string carrera, double p1, double p2, double proyecto)
        {
            this._matricula = matricula;
            this._nombre = nombre;
            this._carrera = carrera;
            this._parcial1 = ValidarNota(p1);
            this._parcial2 = ValidarNota(p2);
            this._proyectoFinal = ValidarNota(proyecto);
        }

        public AlumnoExpediente(string matricula, string nombre, string carrera)
            : this(matricula, nombre, carrera, 0.0, 0.0, 0.0)
        {
        }

        private double ValidarNota(double nota)
        {
            if (nota < 0.0) return 0.0;
            if (nota > 10.0) return 10.0;
            return nota;
        }

        public double CalcularPromedioPonderado()
        {
            return (_parcial1 * 0.30) + (_parcial2 * 0.30) + (_proyectoFinal * 0.40);
        }

        public string DeterminarEstatus()
        {
            double prom = CalcularPromedioPonderado();
            if (prom >= 9.5) return "APROBADO CON MENCIÓN DE HONOR";
            if (prom >= 7.0) return "APROBADO";
            return "REPROBADO (REQUIERE ASESORÍA)";
        }

        public int CalcularPorcentajeBeca()
        {
            double prom = CalcularPromedioPonderado();
            if (prom >= 9.5) return 50;
            if (prom >= 8.5) return 25;
            return 0;
        }

        public void ImprimirBoleta()
        {
            double prom = CalcularPromedioPonderado();
            int beca = CalcularPorcentajeBeca();

            Console.WriteLine($"-> Matrícula: [{_matricula}] {_nombre} | Carrera: {_carrera}");
            Console.WriteLine($"-> Calificaciones: P1: {_parcial1:F1} | P2: {_parcial2:F1} | Proyecto: {_proyectoFinal:F1}");
            Console.WriteLine($"-> Promedio Ponderado Final: {prom:F2} / 10.00");
            Console.WriteLine($"-> Estatus Académico: [{DeterminarEstatus()}]");
            Console.WriteLine($"-> Beneficio de Beca Asignado: {(beca > 0 ? $"BECA DE EXCELENCIA ({beca}% de descuento)" : "SIN BECA (Promedio mínimo 8.50 requerido)")}");
        }
    }
}
