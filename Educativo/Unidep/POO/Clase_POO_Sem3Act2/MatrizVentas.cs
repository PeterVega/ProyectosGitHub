using System;
using System.Collections.Generic;
using System.Text;

namespace Clase_POO_Sem3Act2
{
    internal class MatrizVentas
    {
        private string[] _sucursales;
        private string[] _dias = { "Lun", "Mar", "Mié", "Jue", "Vie" };
        private double[,] _ventas;

        public MatrizVentas(string[] sucursales)
        {
            _sucursales = sucursales;
            _ventas = new double[sucursales.Length, _dias.Length];
        }

        public void RegistrarVenta(int sucursalIdx, int diaIdx, double monto)
        {
            if (sucursalIdx >= 0 && sucursalIdx < _ventas.GetLength(0) &&
                diaIdx >= 0 && diaIdx < _ventas.GetLength(1))
            {
                _ventas[sucursalIdx, diaIdx] = monto;
            }
        }

        public double TotalSucursal(int sucursalIdx)
        {
            double total = 0;
            for (int d = 0; d < _ventas.GetLength(1); d++) total += _ventas[sucursalIdx, d];
            return total;
        }

        public double TotalDia(int diaIdx)
        {
            double total = 0;
            for (int s = 0; s < _ventas.GetLength(0); s++) total += _ventas[s, diaIdx];
            return total;
        }

        public void ImprimirReporte()
        {
            Console.WriteLine("=== TABLERO DE VENTAS POR SUCURSAL Y DÍA (SEMANA 3 - ACT 2) ===");
            Console.WriteLine($"{"Sucursal / Día",-20} {"Lun",8} {"Mar",8} {"Mié",8} {"Jue",8} {"Vie",8} | {"TOTAL",12}");
            Console.WriteLine(new string('-', 80));

            double granTotal = 0;
            int mejorSucursal = 0;
            double maxVenta = 0;

            for (int s = 0; s < _ventas.GetLength(0); s++)
            {
                double totalSuc = TotalSucursal(s);
                granTotal += totalSuc;
                if (totalSuc > maxVenta)
                {
                    maxVenta = totalSuc;
                    mejorSucursal = s;
                }

                Console.Write($"{_sucursales[s],-20}");
                for (int d = 0; d < _ventas.GetLength(1); d++)
                {
                    Console.Write($"{_ventas[s, d],8:F0}");
                }
                Console.WriteLine($" | {totalSuc,12:C2}");
            }

            Console.WriteLine(new string('-', 80));
            Console.Write($"{"TOTAL POR DÍA:",-20}");
            for (int d = 0; d < _ventas.GetLength(1); d++)
            {
                Console.Write($"{TotalDia(d),8:F0}");
            }
            Console.WriteLine($" | {granTotal,12:C2}");

            Console.WriteLine($">> Sucursal con mayor venta: { _sucursales[mejorSucursal]}({ maxVenta: C2})");
            Console.WriteLine("===============================================================");
        }
    }
}
