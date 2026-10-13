using System;
using System.Collections.Generic;
using System.Text;

namespace Clase_POO_Sem4Act1
{
    internal class Automovil : Vehiculo
    {
        private int _pasajeros;

        public Automovil(string placas, string marca, string modelo, int pasajeros)
            : base(placas, marca, modelo)
        {
            _pasajeros = pasajeros > 0 ? pasajeros : 1;
        }

        public override double CalcularConsumoLitros(double kilometros)
        {
            double baseLitros = kilometros / 16.0; // Sedán más eficiente
            double factorPasajeros = 1.0 + (_pasajeros * 0.03); // +3% por pasajero
            return baseLitros * factorPasajeros;
        }

        public override void MostrarFicha()
        {
            base.MostrarFicha();
            Console.WriteLine($"Tipo: Sedán Particular | Pasajeros: {_pasajeros}");
        }
    }
}
