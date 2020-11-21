using Examen2_LMP.Backend;
using Examen2_LMP.DataAccess;
using System;
using System.Linq;
using Utilities;

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
                Console.WriteLine();
                Format.DrawBox("Menú");
                Console.WriteLine();
                Format.WriteLine("1. Alta");
                Format.WriteLine("2. Baja");
                Format.WriteLine("3. Cambios");
                Format.WriteLine("4. Consultas");
                Format.WriteLine("5. Salir");
                Console.WriteLine();

                Format.Write("Ingrese una opción: ");
                option = Console.ReadLine();
                Console.WriteLine();
                
                switch(option)
                {
                    case "1": MenuAlta(); break;
                    case "2": MenuBaja(); break;
                    case "3": MenuCambios(); break;
                    case "4": MenuConsultas(); break;
                    case "5": break;
                    default: Format.ShowMessage("Opción Inválida"); break;
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
                Console.WriteLine();
                Format.DrawBox("Datos del Nuevo Alumno");
                Console.WriteLine();
                Format.WriteLine("1. Matricula: " + (alumno.matricula_alumno == 0 ? "----" : alumno.matricula_alumno.ToString()));
                Format.WriteLine("2. Nombre: " + (alumno.nombre_alumno == "" ? "----" : alumno.nombre_alumno.ToString()));
                Format.WriteLine("3. Apellido Paterno: " + (alumno.apellido_paterno_alumno == "" ? "----" : alumno.apellido_paterno_alumno.ToString()));
                Format.WriteLine("4. Apellido Materno: " + (alumno.apellido_materno_alumno == "" ? "----" : alumno.apellido_materno_alumno.ToString()));
                Format.WriteLine("5. Dirección: " + (alumno.direccion_alumno == "" ? "----" : alumno.direccion_alumno.ToString()));
                Format.WriteLine("6. Teléfono: " + (alumno.telefono_alumno == "" ? "----" : alumno.telefono_alumno.ToString()));
                Format.WriteLine("7. Correo: " + (alumno.correo_alumno == "" ? "----" : alumno.correo_alumno.ToString()));
                Format.WriteLine("8. Carrera: " + (alumno.carrera == "" ? "----" : alumno.carrera.ToString()));
                Format.WriteLine("9. Semestre: " + (alumno.semestre_alumno == 0 ? "----" : alumno.semestre_alumno.ToString()));
                Format.WriteLine("---------------------");
                Format.WriteLine("T. Insertar Datos de Prueba");
                Format.WriteLine("R. Registrar Alumno");
                Format.WriteLine("S. Salir");
                Console.WriteLine();

                Format.Write("Ingrese una opción: ");
                option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        alumno.matricula_alumno = Requests.RequestMatricula();
                        fields[0] = true;
                        break;
                    case "2":
                        alumno.nombre_alumno = Requests.RequestNombre();
                        fields[1] = true;
                        break;
                    case "3":
                        alumno.apellido_paterno_alumno = Requests.RequestApellidoPaterno();
                        fields[2] = true;
                        break;
                    case "4":
                        alumno.apellido_materno_alumno = Requests.RequestApellidoMaterno();
                        fields[3] = true;
                        break;
                    case "5":
                        alumno.direccion_alumno = Requests.RequestDireccion();
                        fields[4] = true;
                        break;
                    case "6":
                        alumno.telefono_alumno = Requests.RequestTelefono();
                        fields[5] = true;
                        break;
                    case "7":
                        alumno.correo_alumno = Requests.RequestCorreo();
                        fields[6] = true;
                        break;
                    case "8":
                        alumno.carrera = Requests.RequestCarrera();
                        fields[7] = true;
                        break;
                    case "9":
                        alumno.semestre_alumno = Requests.RequestSemestre();
                        fields[8] = true;
                        break;
                    case "t":
                    case "T":
                        alumno = new AlumnoSC().GenerateRandomAlumno();

                        for(int i=0; i<9; i++)
                        {
                            fields[i] = true;
                        }

                        break;
                    case "r":
                    case "R":
                        Console.Clear();
                        Console.WriteLine();
                        if (fields.Contains(false))
                            Format.ShowMessage("Debe ingresar todos los campos primero.");
                        else
                        {
                            string confirm = Requests.AskForConfirmation(
                                "---Datos del Alumno---",
                                "",
                                "Matrícula: " + alumno.matricula_alumno,
                                "Nombre: " + alumno.nombre_alumno + " " + alumno.apellido_paterno_alumno + " " + alumno.apellido_materno_alumno,
                                "Dirección: " + alumno.direccion_alumno,
                                "Teléfono: " + alumno.telefono_alumno,
                                "Correo: " + alumno.correo_alumno,
                                "Carrera: " + alumno.carrera,
                                "Semestre: " + alumno.semestre_alumno,
                                "",
                                "¿Desea registrar a este alumno?"
                                );

                            if(confirm == "S") {
                                Console.WriteLine();
                                if(new AlumnoSC().AddAlumno(alumno))
                                    option = "S";
                            }
                        }
                        break;
                    case "s":
                    case "S":
                        if (fields.Contains(true))
                        {
                            string exit = Requests.AskForConfirmation("Se perderán los datos ingresados.", "¿Desea Salir?");

                            if (exit == "N")
                                option = "Don't Break";
                            else
                                option = "S";
                        }
                        else
                            option = "S";
                        break;
                    default: Format.ShowMessage("Opción Inválida"); break;
                }
            } while (option != "S");
        }

        public static void MenuBaja()
        {
            string option;
            do
            {
                Console.Clear();
                Console.WriteLine();
                Format.DrawBox("Menú de Baja");
                Console.WriteLine();
                Format.WriteLine("1. Salir");

                Console.WriteLine();
                Format.Write("Ingrese una opción: ");
                option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1": break;
                    default: Format.ShowMessage("Opción Inválida"); break;
                }
            } while (option != "1");
        }

        public static void MenuCambios()
        {
            string option;
            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Format.DrawBox("Menú de Cambios");
                Format.WriteLine("1. Salir");

                Console.WriteLine();
                Format.Write("Ingrese una opción: ");
                option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1": break;
                    default: Format.ShowMessage("Opción Inválida"); break;
                }
            } while (option != "1");
        }

        public static void MenuConsultas()
        {
            string option;
            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Format.DrawBox("Menú de Consultas");
                Format.WriteLine("1. Salir");

                Console.WriteLine();
                Format.Write("Ingrese una opción: ");
                option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1": break;
                    default: Format.ShowMessage("Opción Inválida"); break;
                }
            } while (option != "1");
        }
    }
}
