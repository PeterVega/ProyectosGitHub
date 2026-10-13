using System;
using System.Collections.Generic;
using System.Text;

namespace Clase_POO_Sem4Act1
{
    internal class CamionDeCarga : Vehiculo
    {
        private double _toneladasCarga;

        public CamionDeCarga(string placas, string marca, string modelo, double toneladas)
            : base(placas, marca, modelo)
        {
            _toneladasCarga = toneladas >= 0 ? toneladas : 0;
        }

        public override double CalcularConsumoLitros(double kilometros)
        {
            double litrosBase = kilometros / 3.0; // Camión rinde 3 km/L
            double litrosPorCarga = _toneladasCarga * 0.6; // +0.6 L por tonelada
            return litrosBase + litrosPorCarga;
        }

        public override void MostrarFicha()
        {
            base.MostrarFicha();
            Console.WriteLine($"Tipo: Camión Pesado | Carga: {_toneladasCarga:F1} Toneladas");
        }
    }
}
