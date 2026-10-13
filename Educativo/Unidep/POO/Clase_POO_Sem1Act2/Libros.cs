using System;
using System.Collections.Generic;
using System.Text;

namespace Clase_POO_Sem1Act2
{
    internal class Libros
    {
        private string _isbn;
        private string _titulo;
        private string _autor;
        private int _ejemplaresTotales;
        private int _ejemplaresDisponibles;

        public Libros(string isbn, string titulo, string autor, int ejemplaresTotales)
        {
            _isbn = isbn;
            _titulo = titulo;
            _autor = autor;
            _ejemplaresTotales = ejemplaresTotales > 0 ? ejemplaresTotales : 1;
            _ejemplaresDisponibles = _ejemplaresTotales;
        }

        public string Isbn => _isbn;
        public string Titulo => _titulo;
        public string Autor => _autor;
        public int EjemplaresTotales => _ejemplaresTotales;
        public int EjemplaresDisponibles => _ejemplaresDisponibles;

        public bool PrestarEjemplar()
        {
            if (_ejemplaresDisponibles > 0)
            {
                _ejemplaresDisponibles--;
                Console.WriteLine($">> [ÉXITO]: Préstamo aprobado para '{_titulo}'. Ejemplares restantes en sala: {_ejemplaresDisponibles}.");
                return true;
            }
            Console.WriteLine($">> [DENEGADO]: No hay copias disponibles de '{_titulo}' en este momento.");
            return false;
        }

        public bool DevolverEjemplar()
        {
            if (_ejemplaresDisponibles < _ejemplaresTotales)
            {
                _ejemplaresDisponibles++;
                Console.WriteLine($">> [ÉXITO]: Libro '{_titulo}' devuelto al inventario. Ejemplares disponibles ahora: {_ejemplaresDisponibles}.");
                return true;
            }
            Console.WriteLine($">> [ALERTA]: Todas las copias de '{_titulo}' ya se encontraban en la biblioteca.");
            return false;
        }

        public void MostrarEstado()
        {
            Console.WriteLine($"-> [{_isbn}] '{_titulo}' de {_autor} | Stock: {_ejemplaresDisponibles} disponibles / {_ejemplaresTotales} totales");
        }
    }
}
