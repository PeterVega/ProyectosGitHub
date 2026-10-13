using System;
using System.Collections.Generic;
using System.Text;

namespace Clase_POO_Sem2Act1
{
    internal class TarjetaPrepago
    {
        private string _numeroTarjeta;
        private string _titular;
        private decimal _saldo;

        // Constructor 1: Maestro / Completo
        public TarjetaPrepago(string numeroTarjeta, string titular, decimal saldoInicial)
        {
            this._numeroTarjeta = string.IsNullOrWhiteSpace(numeroTarjeta) ? "TP-999" : numeroTarjeta.Trim();
            this._titular = string.IsNullOrWhiteSpace(titular) ? "Anónimo" : titular.Trim();
            this._saldo = saldoInicial >= 0 ? saldoInicial : 0m;
        }

        // Constructor 2: Nominativo con saldo estándar ($50)
        public TarjetaPrepago(string numeroTarjeta, string titular)
            : this(numeroTarjeta, titular, 50.00m)
        {
        }

        // Constructor 3: Por defecto para tarjeta básica de bienvenida ($20)
        public TarjetaPrepago()
            : this("TP-000", "Portador Anónimo", 20.00m)
        {
        }

        public string NumeroTarjeta => _numeroTarjeta;
        public string Titular => _titular;
        public decimal Saldo => _saldo;

        public void Recargar(decimal monto)
        {
            if (monto > 0)
            {
                _saldo += monto;
                Console.WriteLine($">> [ÉXITO]: Recarga de {monto:C} aprobada. Saldo actualizado: {_saldo:C}");
            }
            else
            {
                Console.WriteLine(">> [ALERTA]: El monto de recarga debe ser positivo.");
            }
        }

        public bool Pagar(decimal monto)
        {
            if (monto <= 0)
            {
                Console.WriteLine(">> [ALERTA]: El monto de cobro debe ser mayor a cero.");
                return false;
            }

            if (_saldo >= monto)
            {
                _saldo -= monto;
                Console.WriteLine($">> [APROBADO]: Cobro de {monto:C} realizado. Saldo restante: {_saldo:C}");
                return true;
            }

            Console.WriteLine($">> [RECHAZADO]: Saldo insuficiente ({_saldo:C} disponible para cobrar {monto:C}).");
            return false;
        }

        public void MostrarEstado()
        {
            Console.WriteLine($"-> Tarjeta [{_numeroTarjeta}] ({_titular}) | Saldo: {_saldo:C}");
        }
    }
}
