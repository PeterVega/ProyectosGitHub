using System;
using System.Collections.Generic;
using System.Text;

namespace Clase_POO_Sem1Act3
{
    internal class Conductor
    {
        // Atributos privados
        private string idConductor;
        private string nombreCompleto;
        private string licencia;
        private int aniosExperiencia;

        // Constructor por defecto
        public Conductor()
        {
            this.idConductor = "SIN_ID";
            this.nombreCompleto = "Sin Asignar";
            this.licencia = "N/A";
            this.aniosExperiencia = 0;
        }

        // Constructor parametrizado
        public Conductor(string idConductor, string nombreCompleto, string licencia, int aniosExperiencia)
        {
            this.idConductor = idConductor;
            this.nombreCompleto = nombreCompleto;
            this.licencia = licencia;
            this.AniosExperiencia = aniosExperiencia; // Usa la propiedad con validación
        }

        // Propiedades con validación sencilla para alumnos principiantes
        public string IdConductor
        {
            get
            {
                return this.idConductor;
            }
            set
            {
                if (value != null && value.Trim() != "")
                {
                    this.idConductor = value.Trim();
                }
            }
        }

        public string NombreCompleto
        {
            get
            {
                return this.nombreCompleto;
            }
            set
            {
                if (value != null && value.Trim() != "")
                {
                    this.nombreCompleto = value.Trim();
                }
            }
        }

        public string Licencia
        {
            get
            {
                return this.licencia;
            }
            set
            {
                this.licencia = value;
            }
        }

        public int AniosExperiencia
        {
            get
            {
                return this.aniosExperiencia;
            }
            set
            {
                // Validamos que los años no sean negativos usando un if sencillo
                if (value >= 0)
                {
                    this.aniosExperiencia = value;
                }
                else
                {
                    Console.WriteLine($">> [ALERTA]: Años de experiencia negativos ({value}). Ajustado a 0.");
                    this.aniosExperiencia = 0;
                }
            }
        }

        public void ImprimirPerfil()
        {
            Console.WriteLine($"-> Conductor registrado: [ID: {idConductor}] {nombreCompleto} (Licencia: {licencia} | Exp: {aniosExperiencia} años)");
        }
    }
}
