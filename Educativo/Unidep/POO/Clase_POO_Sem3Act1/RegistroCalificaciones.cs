using System;
using System.Collections.Generic;
using System.Text;

namespace Clase_POO_Sem3Act1
{
    internal class RegistroCalificaciones
    {
        private double[] _notas;
        private int _cantidad;

        public RegistroCalificaciones(int capacidadMaxima = 10)
        {
            _notas = new double[capacidadMaxima];
            _cantidad = 0;
        }

        public bool AgregarNota(double nota)
        {
            if (_cantidad >= _notas.Length)
            {
                Console.WriteLine(">> [ERROR]: El registro está lleno. No se pueden agregar más notas.");
                return false;
            }

            if (nota < 0.0 || nota > 10.0)
            {
                Console.WriteLine(">> [ERROR]: La calificación debe estar entre 0.0 y 10.0.");
                return false;
            }

            _notas[_cantidad] = nota;
            _cantidad++;
            Console.WriteLine($">> [OK]: Calificación {nota:F1} registrada exitosamente en posición [{_cantidad - 1}].");
            return true;
        }

        public void MostrarTodas()
        {
            if (_cantidad == 0)
            {
                Console.WriteLine(">> [INFO]: No hay calificaciones registradas aún.");
                return;
            }

            Console.WriteLine("--- LISTADO DE CALIFICACIONES ---");
            for (int i = 0; i < _cantidad; i++)
            {
                Console.WriteLine($"   Alumno [{i + 1}]: {_notas[i]:F1}");
            }
        }

        public double CalcularPromedio()
        {
            if (_cantidad == 0) return 0.0;
            double suma = 0.0;
            for (int i = 0; i < _cantidad; i++) suma += _notas[i];
            return suma / _cantidad;
        }

        public void ObtenerExtremos(out double max, out double min)
        {
            if (_cantidad == 0)
            {
                max = 0.0; min = 0.0;
                return;
            }

            max = _notas[0];
            min = _notas[0];
            for (int i = 1; i < _cantidad; i++)
            {
                if (_notas[i] > max) max = _notas[i];
                if (_notas[i] < min) min = _notas[i];
            }
        }
    }
}
