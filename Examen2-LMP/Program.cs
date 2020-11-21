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
                Console.WriteLine();
                
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
            string option;
            bool[] fields = new bool[9];

            alumno.nombre_alumno = "";
            alumno.apellido_paterno_alumno = "";
            alumno.apellido_materno_alumno = "";
            alumno.direccion_alumno = "";
            alumno.telefono_alumno = "";
            alumno.correo_alumno = "";
            alumno.carrera = "";

            do
            {
                Console.Clear();
                Console.WriteLine("Datos del Nuevo Alumno");
                Console.WriteLine("1. Matricula: " + (alumno.matricula_alumno == 0 ? "----" : alumno.matricula_alumno.ToString()));
                Console.WriteLine("2. Nombre: " + (alumno.nombre_alumno == "" ? "----" : alumno.nombre_alumno.ToString()));
                Console.WriteLine("3. Apellido Paterno: " + (alumno.apellido_paterno_alumno == "" ? "----" : alumno.apellido_paterno_alumno.ToString()));
                Console.WriteLine("4. Apellido Materno: " + (alumno.apellido_materno_alumno == "" ? "----" : alumno.apellido_materno_alumno.ToString()));
                Console.WriteLine("5. Dirección: " + (alumno.direccion_alumno == "" ? "----" : alumno.direccion_alumno.ToString()));
                Console.WriteLine("6. Teléfono: " + (alumno.telefono_alumno == "" ? "----" : alumno.telefono_alumno.ToString()));
                Console.WriteLine("7. Correo: " + (alumno.correo_alumno == "" ? "----" : alumno.correo_alumno.ToString()));
                Console.WriteLine("8. Carrera: " + (alumno.carrera == "" ? "----" : alumno.carrera.ToString()));
                Console.WriteLine("9. Semestre: " + (alumno.semestre_alumno == 0 ? "----" : alumno.semestre_alumno.ToString()));
                Console.WriteLine("10. Registrar Alumno");
                Console.WriteLine("11. Salir");

                Console.Write("Ingrese una opción: ");
                option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        {
                            alumno.matricula_alumno = Utilities.RequestMatricula();
                            fields[0] = true;
                            break;
                        }
                    case "2":
                        {
                            alumno.nombre_alumno = Utilities.RequestNombre();
                            fields[1] = true;
                            break;
                        }
                    case "3":
                        {
                            alumno.apellido_paterno_alumno = Utilities.RequestApellidoPaterno();
                            fields[2] = true;
                            break;
                        }
                    case "4":
                        {
                            alumno.apellido_materno_alumno = Utilities.RequestApellidoMaterno();
                            fields[3] = true;
                            break;
                        }
                    case "5":
                        {
                            alumno.direccion_alumno = Utilities.RequestDireccion();
                            fields[4] = true;
                            break;
                        }
                    case "6":
                        {
                            alumno.telefono_alumno = Utilities.RequestTelefono();
                            fields[5] = true;
                            break;
                        }
                    case "7":
                        {
                            alumno.correo_alumno = Utilities.RequestCorreo();
                            fields[6] = true;
                            break;
                        }
                    case "8":
                        {
                            alumno.carrera = Utilities.RequestCarrera();
                            fields[7] = true;
                            break;
                        }
                    case "9":
                        {
                            alumno.semestre_alumno = Utilities.RequestSemestre();
                            fields[8] = true;
                            break;
                        }
                    case "10":
                        {
                            Console.Clear();
                            if (fields.Contains(false))
                                Utilities.ShowMessage("Debe ingresar todos los campos primero.");
                            else
                            {
                                if(new AlumnoSC().AddAlumno(alumno))
                                    option = "11";
                            }
                            break;
                        }
                    case "11": break;
                    default: Utilities.ShowMessage("Opción Inválida"); break;
                }
            } while (option != "11");
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
