using System;
using System.Collections.Generic;
using System.Text;

namespace Class_POO_Sem4Act2
{
    internal class ProductoFisico : Producto
    {
        private double _pesoKg;

        public ProductoFisico(string sku, string nombre, decimal precioBase, double pesoKg)
            : base(sku, nombre, precioBase)
        {
            _pesoKg = pesoKg > 0 ? pesoKg : 0.5;
        }

        public override decimal CalcularPrecioFinal()
        {
            decimal costoEnvio = 50.00m + (decimal)Math.Max(0, _pesoKg - 1.0) * 25.00m;
            decimal seguro = _precioBase * 0.05m;
            return _precioBase + costoEnvio + seguro;
        }

        public override void ImprimirDetalle()
        {
            base.ImprimirDetalle();
            Console.WriteLine($"   Tipo: Físico ({_pesoKg:F2} kg) | Total con flete y seguro: {CalcularPrecioFinal():C}");
        }
    }
}
