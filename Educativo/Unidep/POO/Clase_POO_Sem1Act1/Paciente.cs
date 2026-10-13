using System;
using System.Collections.Generic;
using System.Text;

namespace Clase_POO_Sem1Act1
{
    internal class Paciente
    {
        private string _idPaciente;
        private string _nombreCompleto;
        private int _edad;
        private double _temperatura;

        public Paciente(string id, string nombre, int edad, double temperatura)
        {
            _idPaciente = string.IsNullOrWhiteSpace(id) ? "PAC-DEF" : id.Trim();
            _nombreCompleto = string.IsNullOrWhiteSpace(nombre) ? "Anónimo" : nombre.Trim();
            Edad = edad;                 // Delega en la propiedad para validar
            Temperatura = temperatura;   // Delega en la propiedad para validar
        }

        public string IdPaciente => _idPaciente;
        public string NombreCompleto => _nombreCompleto;

        public int Edad
        {
            get => _edad;
            set
            {
                if (value > 0 && value < 125)
                {
                    _edad = value;
                }
                else
                {
                    Console.WriteLine($"[ALERTA DE SEGURIDAD]: Edad {value} inválida. Se asigna 18 por defecto.");
                    _edad = 18;
                }
            }
        }

        public double Temperatura
        {
            get => _temperatura;
            set
            {
                if (value >= 34.0 && value <= 43.0)
                {
                    _temperatura = value;
                }
                else
                {
                    Console.WriteLine($"[ALERTA DE SEGURIDAD]: Temperatura {value}°C fuera de rango fisiológico (34°C - 43°C). Se asigna 36.5°C por defecto.");
                    _temperatura = 36.5;
                }
            }
        }

        public string ObtenerDiagnosticoFiebre()
        {
            if (_temperatura < 36.0) return "HIPOTERMIA LEVE";
            if (_temperatura <= 37.5) return "NORMAL";
            return "FIEBRE ALTA (ATENCIÓN REQUERIDA)";
        }

        public void MostrarFicha()
        {
            Console.WriteLine($"-> Paciente: [{_idPaciente}] {_nombreCompleto} | Edad: {_edad} años | Temp: {_temperatura:F1}°C | Estado: {ObtenerDiagnosticoFiebre()}");
        }
    }
}
