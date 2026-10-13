using System;
using System.Collections.Generic;
using System.Text;

namespace Clase_POO_Sem4Act1
{
    internal class Vehiculo
    {
        protected string _placas;
        protected string _marca;
        protected string _modelo;

        public Vehiculo(string placas, string marca, string modelo)
        {
            _placas = placas;
            _marca = marca;
            _modelo = modelo;
        }

        public string Placas => _placas;

        public virtual double CalcularConsumoLitros(double kilometros)
        {
            return kilometros / 12.0; // Rendimiento estándar promedio
        }

        public virtual void MostrarFicha()
        {
            Console.WriteLine($"-> Unidad: {_marca} {_modelo} (Placas: {_placas})");
        }
    }
}
