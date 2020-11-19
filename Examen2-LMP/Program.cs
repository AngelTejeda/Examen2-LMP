using Examen2_LMP.Backend;
using Examen2_LMP.DataAccess;
using System;
using System.Linq;

namespace Examen2_LMP
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu();

        }

        public static void Menu()
        {
            string option;
            do
            {
                Console.Clear();
                Console.WriteLine("Menú");
                Console.WriteLine("1. Alta");
                Console.WriteLine("2. Baja");
                Console.WriteLine("3. Cambios");
                Console.WriteLine("4. Consultas");
                Console.WriteLine("5. Salir");

                Console.Write("Ingrese una opción: ");
                option = Console.ReadLine();
                
                switch(option)
                {
                    case "1": MenuAlta(); break;
                    case "2": MenuBaja(); break;
                    case "3": MenuCambios(); break;
                    case "4": MenuConsultas(); break;
                    case "5": break;
                    default: Utilities.ShowMessage("Opción Inválida"); break;
                }
            } while (option != "5");
        }

        public static void MenuAlta()
        {
            Alumno alumno = new Alumno();

            Func<string, bool> lambda = str => str.Equals("");

            alumno.matricula_alumno = int.Parse( Utilities.RequestField(
                "Ingrese la matrícula (7 dígitos): ",
                "La matrícula ingresada es inválida.",
                str => str.Length == 7 && int.TryParse(str, out int i)
                ) );

            alumno.nombre_alumno = Utilities.RequestField(
                "Ingrese el o los nombres del alumno: ",
                "Debe ingresar una cadena no vacía",
                str => str.Length != 0
                );

            alumno.apellido_paterno_alumno = Utilities.RequestField(
                "Ingrese el apellido paterno del alumno: ",
                "Debe ingresar una cadena no vacía",
                str => str.Length != 0
                );

            alumno.apellido_materno_alumno = Utilities.RequestField(
                "Ingrese el apellido materno del alumno: ",
                "Debe ingresar una cadena no vacía",
                str => str.Length != 0
                );

            alumno.direccion_alumno = Utilities.RequestField(
                "Ingrese la dirección del alumno: ",
                "Debe ingresar una cadena no vacía",
                str => str.Length != 0
                );

            alumno.telefono_alumno = Utilities.RequestField(
                "Ingrese el teléfono del alumno (10 dígitos): ",
                "El teléfono ingresado no es válido.",
                str => str.Length == 10 && int.TryParse(str, out int i)
                );

            alumno.correo_alumno = Utilities.RequestField(
                "Ingrese el correo del alumno (contiene @ y termina con '.com'): ",
                "El correo ingresado no es válido.",
                str =>
                {
                    if (!str.Contains("@"))
                        return false;
                    if (!str.EndsWith(".com"))
                        return false;

                    return true;
                }
                );

            alumno.carrera = Utilities.RequestField(
                "Ingrese la carrera del alumno (sólo las iniciales): ",
                "La carrera ingresada no es válida.",
                str =>
                {
                    string[] carrera = { "LCC", "LSTI", "LM", "LF", "LMAD", "LA" };

                    if (carrera.Contains(str.ToUpper()))
                        return true;
                    else
                        return false;
                }
                );

            alumno.semestre_alumno = int.Parse( Utilities.RequestField(
                "Ingrese el semestre que está cursando el alumno (1-9): ",
                "El semestre ingresado no es válido.",
                str =>
                {
                    int semestre;

                    if (!int.TryParse(str, out semestre))
                        return false;

                    if (semestre < 1 || semestre > 9)
                        return false;

                    return true;
                }
                ));

            new AlumnoSC().addAlumno(alumno);
        }

        public static void MenuBaja()
        {
            string option;
            do
            {
                Console.Clear();
                Console.WriteLine("Menú de Baja");
                Console.WriteLine("1. Salir");

                Console.Write("Ingrese una opción: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1": break;
                    default: Utilities.ShowMessage("Opción Inválida"); break;
                }
            } while (option != "1");
        }

        public static void MenuCambios()
        {
            string option;
            do
            {
                Console.Clear();
                Console.WriteLine("Menú de Cambios");
                Console.WriteLine("1. Salir");

                Console.Write("Ingrese una opción: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1": break;
                    default: Utilities.ShowMessage("Opción Inválida"); break;
                }
            } while (option != "1");
        }

        public static void MenuConsultas()
        {
            string option;
            do
            {
                Console.Clear();
                Console.WriteLine("Menú de Consultas");
                Console.WriteLine("1. Salir");

                Console.Write("Ingrese una opción: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1": break;
                    default: Utilities.ShowMessage("Opción Inválida"); break;
                }
            } while (option != "1");
        }
    }
}
