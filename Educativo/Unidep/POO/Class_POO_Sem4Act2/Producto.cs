using System;
using System.Collections.Generic;
using System.Text;

namespace Class_POO_Sem4Act2
{
    internal abstract  class Producto
    {
        protected string _sku;
        protected string _nombre;
        protected decimal _precioBase;

        public Producto(string sku, string nombre, decimal precioBase)
        {
            _sku = sku;
            _nombre = nombre;
            _precioBase = precioBase >= 0 ? precioBase : 0m;
        }

        public string Nombre => _nombre;
        public decimal PrecioBase => _precioBase;

        public abstract decimal CalcularPrecioFinal();

        public virtual void ImprimirDetalle()
        {
            Console.WriteLine($"[{_sku}] {_nombre} | Precio Base: {_precioBase:C}");
        }
    }
}
