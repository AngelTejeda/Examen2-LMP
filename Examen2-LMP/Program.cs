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
                str =>
                {
                    if(!int.TryParse(str, out int i))
                        throw new Exception("No puede ingresar caracteres que no sean numéricos.");
                    if (str.Length != 7)
                        throw new Exception("La longitud de la matrícula debe ser igual a 7.");
                    if (new AlumnoSC().GetAlumnoWithMatricula(int.Parse(str)) != null)
                        throw new Exception("Ya existe un alumno con esa matrícula.");

                    return true;
                }
                ) );

            alumno.nombre_alumno = Utilities.RequestField(
                "Ingrese el o los nombres del alumno: ",
                str =>
                {
                    if(str.Length == 0)
                        throw new Exception("Debe ingresar una cadena no vacía.");

                    return true;
                }
                );

            alumno.apellido_paterno_alumno = Utilities.RequestField(
                "Ingrese el apellido paterno del alumno: ",
                str =>
                {
                    if (str.Length == 0)
                        throw new Exception("Debe ingresar una cadena no vacía.");

                    return true;
                }
                );

            alumno.apellido_materno_alumno = Utilities.RequestField(
                "Ingrese el apellido materno del alumno: ",
                str =>
                {
                    if (str.Length == 0)
                        throw new Exception("Debe ingresar una cadena no vacía.");

                    return true;
                }
                );

            alumno.direccion_alumno = Utilities.RequestField(
                "Ingrese la dirección del alumno: ",
                str =>
                {
                    if (str.Length == 0)
                        throw new Exception("Debe ingresar una cadena no vacía.");

                    return true;
                }
                );

            alumno.telefono_alumno = Utilities.RequestField(
                "Ingrese el teléfono del alumno (10 dígitos): ",
                str =>
                {
                    if(!int.TryParse(str, out int i))
                        throw new Exception("No puede ingresar caracteres que no sean numéricos.");
                    if (str.Length != 10)
                        throw new Exception("Debe ingresar 10 dígitos.");

                    return true;
                }
                );

            alumno.correo_alumno = Utilities.RequestField(
                "Ingrese el correo del alumno (contiene @ y termina con '.com'): ",
                str =>
                {
                    if (!str.Contains("@"))
                        throw new Exception("El correo debe contener '@'.");
                    if (!str.EndsWith(".com"))
                        throw new Exception("El correo debe terminar con '.com'.");
                    if(new AlumnoSC().GetAllAlumnos().FirstOrDefault(a => a.correo_alumno == str) != null)
                        throw new Exception("El correo ingresado ya está registrado.");

                    return true;
                }
                );

            alumno.carrera = Utilities.RequestField(
                "Opciones de Carrera: LCC, LSTI, LM, LF, LMAD, LA\nIngrese la carrera del alumno: ",
                str =>
                {
                    string[] carrera = { "LCC", "LSTI", "LM", "LF", "LMAD", "LA" };

                    str = str.ToUpper();
                    if (!carrera.Contains(str))
                        throw new Exception("Ingresó una carrera no válida.");

                    return true;
                }
                );

            alumno.semestre_alumno = int.Parse( Utilities.RequestField(
                "Ingrese el semestre que está cursando el alumno (1-9): ",
                str =>
                {
                    int semestre;

                    if (!int.TryParse(str, out semestre))
                        throw new Exception("Debe ingresar un valor numérico.");
                    if (semestre < 1 || semestre > 9)
                        throw new Exception("Debe ingresar un número entre 1 y 9.");

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
