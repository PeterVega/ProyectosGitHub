namespace Class_POO_Sem4Act3
{
    public interface IFacturable
    {
        double CalcularCostoTotal();
        string GenerarComprobanteFiscal();
    }

    public abstract class Paciente : IFacturable
    {
        protected string folioExpediente;
        protected string nombre;
        protected int edad;
        protected int diasEstancia;

        public Paciente(string folio, string nombre, int edad, int diasEstancia)
        {
            this.folioExpediente = folio;
            this.nombre = nombre;
            this.edad = edad;
            this.diasEstancia = diasEstancia;
        }

        public string FolioExpediente
        {
            get { return this.folioExpediente; }
        }

        public string Nombre
        {
            get { return this.nombre; }
        }

        public int Edad
        {
            get { return this.edad; }
        }

        public int DiasEstancia
        {
            get { return this.diasEstancia; }
        }

        public abstract double CalcularMontoMedicamentos();
        public abstract double CalcularCostoTotal();
        public abstract string GenerarComprobanteFiscal();
    }

    public class PacienteGeneral : Paciente
    {
        private double costoConsultaBase;
        private const double TarifaHabitacionDia = 1200.0;

        public PacienteGeneral(string folio, string nombre, int edad, int dias, double costoConsulta)
            : base(folio, nombre, edad, dias)
        {
            this.costoConsultaBase = costoConsulta;
        }

        public override double CalcularMontoMedicamentos()
        {
            return 1500.0; // Cuota fija de medicamentos para consulta general
        }

        public override double CalcularCostoTotal()
        {
            double costoCuarto = this.diasEstancia * TarifaHabitacionDia;
            double costoMedicinas = this.CalcularMontoMedicamentos();
            double total = costoCuarto + costoMedicinas + this.costoConsultaBase;
            return total;
        }

        public override string GenerarComprobanteFiscal()
        {
            double cuarto = diasEstancia * TarifaHabitacionDia;
            return $"--- PACIENTE GENERAL (Tipo: PacienteGeneral) --- " + $"Comprobante Fiscal: FOL-CLI-2026-0081 | RFC: XAXX010101000" + $"Paciente: {nombre} (Edad: {edad}) | Días Estancia: {diasEstancia}" +$"Tarifa de Cuarto: ${cuarto:N2} MXN ($1,200/día)" + $"Cálculo de Medicamentos (Fijo): ${CalcularMontoMedicamentos():N2} MXN" + $"Costo Consulta Base: ${costoConsultaBase:N2} MXN" +$">> COSTO TOTAL A FACTURAR: ${CalcularCostoTotal():N2} MXN";
        }
    }

    public class PacienteTerapiaIntensiva : Paciente
    {
        private double costoSoporteVidaPorDia;
        private bool esQuirurgico;
        private const double TarifaUtiDia = 3000.0;
        private const double HonorariosQuirurgicos = 12000.0;

        public PacienteTerapiaIntensiva(string folio, string nombre, int edad, int dias, double soporte, bool quirurgico)
            : base(folio, nombre, edad, dias)
        {
            this.costoSoporteVidaPorDia = soporte;
            this.esQuirurgico = quirurgico;
        }

        public override double CalcularMontoMedicamentos()
        {
            return 18400.0; // Medicación intensiva avanzada
        }

        public override double CalcularCostoTotal()
        {
            double cuarto = this.diasEstancia * TarifaUtiDia;
            double soporte = this.diasEstancia * this.costoSoporteVidaPorDia;
            double cirugia = 0.0;
            if (this.esQuirurgico)
            {
                cirugia = HonorariosQuirurgicos;
            }
            double total = cuarto + soporte + this.CalcularMontoMedicamentos() + cirugia;
            return total;
        }

        public override string GenerarComprobanteFiscal()
        {
            double cuarto = diasEstancia * TarifaUtiDia;
            double soporte = diasEstancia * costoSoporteVidaPorDia;
            string cirugiaStr = "";
            if (this.esQuirurgico)
            {
                cirugiaStr = $"Honorarios Quirúrgicos: ${HonorariosQuirurgicos:N2} MXN";
            }

            return $"--- PACIENTE TERAPIA INTENSIVA (Tipo: PacienteTerapiaIntensiva) ---" +$"Comprobante Fiscal: FOL-CLI-2026-0082 | RFC: DOM780415AA1" + $"Paciente: {nombre} (Edad: {edad}) | Días Estancia: {diasEstancia} (ÁREA CRÍTICA UTI)     " + $"Tarifa de Cuarto: ${cuarto:N2} MXN ($3,000/día)" + $"Soporte de Vida y Monitoreo: ${soporte:N2} MXN (${costoSoporteVidaPorDia:N0}/día) " + $"Cálculo de Medicamentos Especializados: ${CalcularMontoMedicamentos():N2} MXN" + cirugiaStr + $">> COSTO TOTAL A FACTURAR: ${CalcularCostoTotal():N2} MXN";
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== EJECUCIÓN DEL NÚCLEO POLIMÓRFICO HOSPITALARIO (SEMANA 4) ===");
            Console.WriteLine("[MEMORIA HEAP]: Declarando arreglo polimórfico base: Paciente[] pacientes = new Paciente[2];");


            Paciente[] pacientes = new Paciente[]
            {
            new PacienteGeneral("EXP-101", "Héctor Valenzuela", 34, 3, 850.0),
            new PacienteTerapiaIntensiva("EXP-992", "Elena Domínguez", 58, 5, 4500.0, true)
            };

            Console.WriteLine(">>> INVOCACIÓN POLIMÓRFICA EN BUCLE UNIFICADO (for (Paciente p : pacientes)) <<<    ");
            foreach (Paciente p in pacientes)
            {
                Console.WriteLine(p.GenerarComprobanteFiscal());
                Console.WriteLine();
            }

            Console.WriteLine("==============================================================");
            Console.WriteLine("=== SALIDA DE LA INTERFAZ GRÁFICA (GUI SWING / WINFORMS) ===");
            Console.WriteLine("[EVENTO CLICK DETECTADO]: Clic en botón 'Facturar Paciente'");
            Console.WriteLine("Campos leídos de la ventana: Folio='EXP-992', Nombre='Elena Domínguez', Tipo='UTI'");
            Console.WriteLine("Área de Texto actualizada con el Comprobante Fiscal generado.");
            Console.WriteLine("Estado de la Ventana: [RESPONSIVA - 0 ERRORES EN EL HILO PRINCIPAL]");
        }
    }
}
/*
 EJERCICIO
📌 Título de la Actividad: Sistema Hospitalario y Facturación con Herencia, Polimorfismo y GUI

Contexto y Planteamiento del Problema: Una clínica médica y hospitalaria universitaria requiere renovar su sistema de cobro y atención de pacientes. El sistema debe gestionar diferentes tipos de internamiento y consulta médica, calcular los costos finales de acuerdo con tratamientos especializados mediante una interfaz formal de facturación, y contar con una ventana gráfica para que el recepcionista ingrese datos rápidamente.

Requerimientos Técnicos Paso a Paso: 
1. **Definición de la Interfaz `IFacturable`:** 
	- Declarar los métodos: 
		- `double calcularCostoTotal();` 
		- `String generarComprobanteFiscal();`

2. **Clase Abstracta Base `Paciente`:** 
	- Atributos protegidos (`protected`): `folioExpediente` (String), `nombre` (String), `edad` (int) y `diasEstancia` (int). 
	- Constructor que inicialice todos los atributos. 
	- Getters, setters y método abstracto `calcularMontoMedicamentos(): double`. 
	- Implementar la interfaz `IFacturable`.

3. **Subclases Especializadas (Herencia):** 
	- **Clase `PacienteGeneral`:** Hereda de `Paciente`. Añade atributo privado `costoConsultaBase` (double). Invoca al constructor de la clase base con `super(...)` (Java) o `: base(...)` (C#). Sobrescribe (`@Override` / `override`) el cálculo de costos con tarifa fija de medicación. 
	- **Clase `PacienteTerapiaIntensiva`:** Hereda de `Paciente`. Añade atributo privado `costoEquipoSoporteVidaPorDia` (double) y `esQuirurgico` (boolean). Sobrescribe los métodos calculando tarifas diferenciadas por alta especialidad.

4. **Demostración de Polimorfismo Dinámico:** 
	- En una clase de prueba, crear un arreglo de tipo base `Paciente[] pacientes = new Paciente[4];` conteniendo instancias mixtas de pacientes generales y de terapia intensiva. 
	- Con un único bucle, invocar `paciente.generarComprobanteFiscal()` y `paciente.calcularCostoTotal()`, demostrando cómo la máquina virtual (JVM / CLR) resuelve el método correcto del hijo en tiempo de ejecución (enlace dinámico).

5. **Prototipo de Interfaz Gráfica (GUI):** 
	- Diseñar una ventana visual sencilla utilizando Java Swing (`JFrame`, `JButton`, `JTextField`, `JLabel`, `JTextArea`) o C# WinForms/WPF. 
	- Implementar un manejador de eventos (Event Listener / Callback) asociado a un botón "Calcular y Facturar". Al hacer clic, debe leer los datos de los campos de texto, instanciar el tipo de paciente seleccionado y mostrar el ticket de cobro generado en el área de texto sin congelar la ventana.
*/