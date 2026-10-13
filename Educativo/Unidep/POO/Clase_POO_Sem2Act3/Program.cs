namespace Clase_POO_Sem2Act3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SIMULADOR FINANCIERO Y CALIFICADOR CREDITICIO UNIDEP (SEMANA 2) ===");
            Console.WriteLine("[CASO DE PRUEBA 1]: Evaluación de Solicitud Exitosa");
            SolicitudCredito s1 = new SolicitudCredito("SOL-2026-001", "Laura Gómez", 12500.0, 25000.0, 18, false, 14.50);
            s1.ImprimirDictamen();

            Console.WriteLine("----------------------------------------------------------------------");    
            Console.WriteLine("[CASO DE PRUEBA 2]: Rechazo por Exceso de Capacidad de Pago");
            SolicitudCredito s2 = new SolicitudCredito("SOL-2026-002", "Roberto Vega", 8000.0, 60000.0, 12, false, 16.00);
            s2.ImprimirDictamen();

            Console.WriteLine("----------------------------------------------------------------------");    
            Console.WriteLine("[CASO DE PRUEBA 3]: Rechazo por Historial Crediticio Moroso");
            SolicitudCredito s3 = new SolicitudCredito("SOL-2026-003", "Andrea Morales", 22000.0, 30000.0, 24, true, 15.00);
            s3.ImprimirDictamen();

            Console.WriteLine("----------------------------------------------------------------------");    
            Console.WriteLine("[CASO DE PRUEBA 4]: Rechazo por Plazo Fuera de Rango Institucional");
            SolicitudCredito s4 = new SolicitudCredito("SOL-2026-004", "Fernando Castillo", 18000.0, 35000.0, 48, false, 14.00);
            s4.ImprimirDictamen();
        }
    }
}
/*
EJERCICIO

📌 Título de la Actividad: Simulador Financiero y Calificador de Créditos con Referencia this
Contexto y Planteamiento del Problema: Una financiera digital universitaria requiere implementar un módulo automatizado para evaluar la viabilidad de créditos 
educativos y calcular la cuota mensual amortizada. El sistema debe validar que los solicitantes cumplan con rigurosos criterios de endeudamiento y estabilidad 
antes de preaprobar cualquier fondo.
Requerimientos Técnicos Paso a Paso: 

1. **Diseño de la Clase `SolicitudCredito`:** 
	- Atributos privados: `folioSolicitud` (String), `nombreEstudiante` (String), `ingresoMensual` (double), `montoSolicitado` (double), `plazoMeses` (int), 
		`tieneHistorialMoroso` (boolean) y `tasaInteresAnual` (double). 
	- Constructor con argumentos que utilice la palabra reservada `this` en cada asignación para desambiguar los parámetros que llevan el mismo identificador 
		que los atributos (ej. `this.ingresoMensual = ingresoMensual;`). 
	- Getters y Setters completos empleando la referencia `this`.

2. **Cálculo de Cuota y Fórmulas Aritméticas:** 
	- Implementar el método `calcularCuotaMensual(): double` aplicando la fórmula de anualidad: $$\text{Cuota} = P \times \frac{i(1 + i)^n}{(1 + i)^n - 1}$$ 
		Donde $P$ es el monto solicitado, $i$ es la tasa mensual ($(\text{tasaInteresAnual} / 100) / 12$) y $n$ es el plazo en meses. 
	- Demostrar el uso correcto de precedencia de operadores matemáticos utilizando `Math.pow()` tanto en Java como en C#.

3. **Motor de Calificación con Expresiones Lógicas Compuestas:** 
	- Implementar el método `evaluarAprobacion(): boolean` que evalúe en una sola expresión lógica compuesta (usando `&&`, `||`, `!`): 
	- Que el solicitante **no** tenga historial moroso (`!this.tieneHistorialMoroso`). 
	- Que la cuota mensual calculada sea menor o igual al 35% de su ingreso mensual (`cuota <= this.ingresoMensual * 0.35`). 
	- Que el plazo de meses esté en el rango de 6 a 36 meses inclusive (`this.plazoMeses >= 6 && this.plazoMeses <= 36`). 
	- Que el monto solicitado sea al menos de $2,000 MXN y máximo $80,000 MXN.

4. **Clase de Prueba y Casos de Estudio en Consola:** 
	- Probar 4 casos de prueba distintos: 
		1. Solicitante que cumple todas las condiciones (Aprobado). 
		2. Solicitante rechazado por exceso de capacidad de pago (cuota > 35% de ingresos). 
		3. Solicitante rechazado por historial moroso. 
		4. Solicitante rechazado por plazo fuera de norma (ej. 48 meses). 
		- Imprimir el desglose financiero de cada caso con formato de dos decimales.  
*/