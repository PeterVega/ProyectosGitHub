using System;
using System.Collections.Generic;
using System.Text;

namespace Class_POO_Sem4Act2
{
    internal class ProductoDigital : Producto
    {
        private double _tamanioMB;

        public ProductoDigital(string sku, string nombre, decimal precioBase, double tamanioMB)
            : base(sku, nombre, precioBase)
        {
            _tamanioMB = tamanioMB;
        }

        public override decimal CalcularPrecioFinal()
        {
            decimal iva = _precioBase * 0.16m; // 16% IVA digital
            return _precioBase + iva;
        }

        public override void ImprimirDetalle()
        {
            base.ImprimirDetalle();
            Console.WriteLine($"   Tipo: Digital ({_tamanioMB} MB) | Total con IVA (16%): {CalcularPrecioFinal():C}");
        }
    }
}
