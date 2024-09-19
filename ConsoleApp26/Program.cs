using System;

namespace CalculadoraSalarios
{
    // Clase base Empleado
    public abstract class Empleado
    {
        public string Nombre { get; set; }
        public bool AlcanzóMeta { get; set; }

        public Empleado(string nombre, bool alcanzóMeta)
        {
            Nombre = nombre;
            AlcanzóMeta = alcanzóMeta;
        }

        public abstract decimal CalcularSalario();
    }

    // Clase DocentePorHora
    public class DocentePorHora : Empleado
    {
        public int HorasTrabajadas { get; set; }
        private const decimal TarifaPorHora = 800;

        public DocentePorHora(string nombre, bool alcanzóMeta, int horasTrabajadas)
            : base(nombre, alcanzóMeta)
        {
            HorasTrabajadas = horasTrabajadas;
        }

        public override decimal CalcularSalario()
        {
            return HorasTrabajadas * TarifaPorHora;
        }
    }

    // Clase DocenteContratoFijo
    public class DocenteContratoFijo : Empleado
    {
        private const decimal SalarioBase = 50000;

        public DocenteContratoFijo(string nombre, bool alcanzóMeta)
            : base(nombre, alcanzóMeta)
        {
        }

        public override decimal CalcularSalario()
        {
            return AlcanzóMeta ? SalarioBase : SalarioBase / 2;
        }
    }

    // Clase EmpleadoAdministrativo
    public class EmpleadoAdministrativo : Empleado
    {
        private const decimal SalarioBase = 40000;

        public EmpleadoAdministrativo(string nombre, bool alcanzóMeta)
            : base(nombre, alcanzóMeta)
        {
        }

        public override decimal CalcularSalario()
        {
            return AlcanzóMeta ? SalarioBase : SalarioBase / 2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Empleado[] empleados = new Empleado[]
            {
                new DocentePorHora("Juan", true, 160),
                new DocenteContratoFijo("Ana", false),
                new EmpleadoAdministrativo("Carlos", true)
            };

            foreach (var empleado in empleados)
            {
                Console.WriteLine($"Empleado: {empleado.Nombre}, Salario: {empleado.CalcularSalario()}");
            }
        }
    }
}

