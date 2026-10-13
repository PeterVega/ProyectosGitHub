using System;
using System.Collections.Generic;
using System.Text;

namespace Clase_POO_Sem1Act2
{
    internal class UsuarioLector
    {
        public string IdMatricula { get; }
        public string Nombre { get; }

        public UsuarioLector(string id, string nombre)
        {
            IdMatricula = id;
            Nombre = nombre;
        }
    }
}
