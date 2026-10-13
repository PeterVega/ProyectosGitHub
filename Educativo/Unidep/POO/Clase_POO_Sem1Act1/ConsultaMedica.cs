using System;
using System.Collections.Generic;
using System.Text;

namespace Clase_POO_Sem1Act1
{
    internal class ConsultaMedica
    {
        private string _folio;
        private Paciente _paciente;
        private string _motivo;

        public ConsultaMedica(string folio, Paciente paciente, string motivo)
        {
            _folio = folio;
            _paciente = paciente ?? throw new ArgumentNullException(nameof(paciente));
            _motivo = motivo;
        }

        public bool DeterminarPrioridad()
        {
            return _paciente.Temperatura > 37.5 || _paciente.Edad >= 65;
        }

        public void ImprimirResumenConsulta()
        {
            Console.WriteLine("[TRIAGE DE CONSULTA]:");
            Console.WriteLine($"-> Folio Consulta: {_folio}");
            Console.WriteLine($"-> Paciente atendido: {_paciente.NombreCompleto} ({_paciente.Edad} años)");
            Console.WriteLine($"-> Motivo: {_motivo}");
            Console.WriteLine($"-> Requiere Atención Urgente: {(DeterminarPrioridad() ? "SÍ (PRIORIDAD ALTA)" : "NO (Signos vitales estables)")}");
        }
    }
}
