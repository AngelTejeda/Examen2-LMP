using Examen2_LMP.Backend;
using Examen2_LMP.DataAccess;
using Examen2_LMP.Models;
using System;
using System.Collections.Generic;
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
            string option;  //Opción que ingresa el usuario
            do
            {
                //Impresion del Menú
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

                //Solicitud de Opción
                Format.Write("Ingrese una opción: ");
                option = Console.ReadLine();
                Console.WriteLine();
                
                //Opciones del Menú
                switch(option)
                {
                    case "1": MenuAlta(); break;
                    case "2": MenuBaja(); break;
                    case "3": MenuCambios(); break;
                    case "4": MenuConsultas(); break;
                    case "5":
                        string confirm = Requests.AskForConfirmation("¿Desea salir del programa?");
                        if (confirm == "S")
                        {
                            Console.WriteLine();
                            Format.ShowMessage("El programa va a terminar su ejecucion.");
                        }
                        else
                        {
                            option = "0";
                        }
                        break;
                    default: Format.ShowMessage("Opción Inválida"); break;
                }
            } while (option != "5");
        }

        public static void MenuAlta()
        {
            Alumno alumno = new Alumno();   //Nuevo alumno 
            bool[] fields = new bool[9];    //Campos que ya fueron registrados
            string option;                  //Opción ingresada por el usuario

            //Inicialización de los campos del alumno.
            alumno.matricula_alumno = "";
            alumno.nombre_alumno = "";
            alumno.apellido_paterno_alumno = "";
            alumno.apellido_materno_alumno = "";
            alumno.direccion_alumno = "";
            alumno.telefono_alumno = "";
            alumno.correo_alumno = "";
            alumno.carrera = "";

            do
            {
                //Impresión del Menú
                Console.Clear();
                Console.WriteLine();
                Format.DrawBox("Datos del Nuevo Alumno");
                Console.WriteLine();
                Format.WriteLine("1. Matricula: " + (alumno.matricula_alumno == "" ? "----" : alumno.matricula_alumno));
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

                //Solicitud de Opción
                Format.Write("Ingrese una opción: ");
                option = Console.ReadLine();
                Console.WriteLine();

                //Si la opción ingresada es numérica
                if (int.TryParse(option, out int field))
                {
                    //Y el número está dentro del rango permitido
                    if (field >= 1 && field <= 9)
                        fields[field - 1] = true;   //El campo se marca como registrado
                }
                //Si la opción ingresada no es numérica
                else
                    option = option.ToUpper();

                //Opciones del Menú
                switch (option)
                {
                    case "1":
                        alumno.matricula_alumno = Requests.RequestNewMatricula(); break;
                    case "2":
                        alumno.nombre_alumno = Requests.RequestNombre(); break;
                    case "3":
                        alumno.apellido_paterno_alumno = Requests.RequestApellidoPaterno(); break;
                    case "4":
                        alumno.apellido_materno_alumno = Requests.RequestApellidoMaterno(); break;
                    case "5":
                        alumno.direccion_alumno = Requests.RequestDireccion(); break;
                    case "6":
                        alumno.telefono_alumno = Requests.RequestTelefono(); break;
                    case "7":
                        alumno.correo_alumno = Requests.RequestCorreo(); break;
                    case "8":
                        alumno.carrera = Requests.RequestCarrera(); break;
                    case "9":
                        alumno.semestre_alumno = Requests.RequestSemestre(); break;
                    case "T":
                        alumno = new AlumnoSC().GenerateRandomAlumno();

                        for(int i=0; i<9; i++)
                            fields[i] = true;

                        break;
                    case "R":
                        Console.Clear();
                        Console.WriteLine();

                        //Si no se han ingresado todos los campos
                        if (fields.Contains(false))
                            Format.ShowMessage("Debe ingresar todos los campos primero.");
                        //Si ya se ingresaron todos los campos
                        else
                        {
                            //Se pide confirmación del registro.
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

                            //Si confirma el registro
                            if(confirm == "S") {
                                Console.Clear();
                                Console.WriteLine();
                                //Si el alumno se registra con éxito
                                if(new AlumnoSC().AddAlumno(alumno))
                                    option = "S";   //Se rompe el ciclo.
                            }
                        }
                        break;
                    case "S":
                        //Si ya se han ingresado campos.
                        if (fields.Contains(true))
                        {
                            //Se pide confirmación para salir.
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
            Alumno alumno = SelectAlumno();

            if (alumno == null)
                return;

            string option;
            do
            {
                string alumno_nombreCompleto = alumno.nombre_alumno + " " + alumno.apellido_paterno_alumno + " " + alumno.apellido_materno_alumno;

                option = Requests.AskForConfirmation("Se dara de baja al alumno: ",
                    "",
                    "Matrícula: " + alumno.matricula_alumno,
                    "Nombre: " + alumno_nombreCompleto,
                    "Dirección: " + alumno.direccion_alumno,
                    "Teléfono: " + alumno.telefono_alumno,
                    "Correo: " + alumno.correo_alumno,
                    "Carrera: " + alumno.carrera,
                    "Semestre: " + alumno.semestre_alumno,
                    "",
                    "¿Desea continuar con la baja del alumno?");

                if (option == "S")
                {
                    Console.Clear();
                    Console.WriteLine();
                    if (new AlumnoSC().RemoveAlumno(alumno))
                        option = "N";
                }
                else
                    Format.ShowMessage("Se canceló la baja del alumno.");
            } while (option != "N");
        }

        public static void MenuCambios()
        {
            Alumno alumno = SelectAlumno();

            if (alumno == null)
                return;

            string option;
            bool cambios = false;
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine();
                    Format.DrawBox("Menú de Cambios");
                    Console.WriteLine();

                    Format.WriteLine("Datos del Alumno: ");
                    Console.WriteLine();
                    Format.WriteLine("Matricula: " + alumno.matricula_alumno);
                    Format.WriteLine("1. Nombre: " + alumno.nombre_alumno);
                    Format.WriteLine("2. Apellido Paterno: " + alumno.apellido_paterno_alumno);
                    Format.WriteLine("3. Apellido Materno: " + alumno.apellido_materno_alumno);
                    Format.WriteLine("4. Dirección: " + alumno.direccion_alumno);
                    Format.WriteLine("5. Teléfono: " + alumno.telefono_alumno);
                    Format.WriteLine("6. Correo: " + alumno.correo_alumno);
                    Format.WriteLine("7. Carrera: " + alumno.carrera);
                    Format.WriteLine("8. Semestre: " + alumno.semestre_alumno);
                    Format.WriteLine("9.  Guardar Cambios");
                    Format.WriteLine("10.  Salir");

                    Console.WriteLine();
                    Format.Write("Ingrese una opción a cambiar: ");
                    option = Console.ReadLine();
                    Console.WriteLine();

                    Console.Clear();

                    if (int.TryParse(option, out int i))
                    {
                        if (i >= 1 && i <= 8)
                            cambios = true;
                    }

                    switch (option)
                    {
                        case "1":
                            alumno.nombre_alumno = Requests.RequestNombre(); break;
                        case "2":
                            alumno.apellido_paterno_alumno = Requests.RequestApellidoPaterno(); break;
                        case "3":
                            alumno.apellido_materno_alumno = Requests.RequestApellidoMaterno(); break;
                        case "4":
                            alumno.direccion_alumno = Requests.RequestDireccion(); break;
                        case "5":
                            alumno.telefono_alumno = Requests.RequestTelefono(); break;
                        case "6":
                            alumno.correo_alumno = Requests.RequestCorreo(); break;
                        case "7":
                            alumno.carrera = Requests.RequestCarrera(); break;
                        case "8":
                            alumno.semestre_alumno = Requests.RequestSemestre(); break;
                        case "9": break;
                        case "10":
                            if (cambios)
                            {
                                string exit = Requests.AskForConfirmation("Se perderán los cambios.", "¿Desea continuar?");

                                if (exit == "S")
                                    return;
                            }
                            else
                                return;

                            break;
                        default: Format.ShowMessage("Opción Inválida"); break;
                    }
                } while (option != "9");

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
                    "¿Desea sobreescribir estos datos?"
                    );

                if(confirm == "S")
                {
                    Console.Clear();
                    Console.WriteLine();
                    if (new AlumnoSC().UpdateAlumno(alumno))
                        break;
                }
                else
                    Format.ShowMessage("No se guardarán los cambios.");

            } while (true);
        }

        public static void MenuConsultas()
        {
            string option;
            do
            {
                List<Alumno> students = new List<Alumno>();

                Console.Clear();
                Console.WriteLine();
                Format.DrawBox("Menú de Consultas");
                Console.WriteLine();
                Format.WriteLine("1. Matricula");
                Format.WriteLine("2. Apellidos");
                Format.WriteLine("3. Nombre Completo");
                Format.WriteLine("4. Carrera");
                Format.WriteLine("5. Semestre");
                Format.WriteLine("6. Consultar todos los Registros");
                Format.WriteLine("7. Salir");

                Console.WriteLine();
                Format.Write("Ingrese el tipo de consulta a realizar: ");
                option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        string matricula = Requests.RequestExistingMatricula();
                        Alumno alumno = new AlumnoSC().GetAlumnoByMatricula(matricula);

                        if (alumno != null)
                            students.Add(alumno);

                        break;
                    case "2":
                        string apellidos = Requests.RequestApellidos();

                        students = new AlumnoSC().GetAlumnosByApellido(apellidos).ToList();

                        break;
                    case "3":
                        string nombreCompleto = Requests.RequestNombreCompleto();

                        students = new AlumnoSC().GetAlumnosByNombreCompleto(nombreCompleto).ToList();

                        break;
                    case "4":
                        string carrera = Requests.RequestCarrera();

                        students = new AlumnoSC().GetAlumnosByCarrera(carrera).ToList();

                        break;
                    case "5":
                        int semestre = Requests.RequestSemestre();

                        students = new AlumnoSC().GetAlumnosBySemestre(semestre).ToList();

                        break;
                    case "6":
                        students = new AlumnoSC().GetAllAlumnos().OrderBy(a => a.nombre_alumno).ToList();

                        break;
                    case "7": return;
                    default:
                        Format.ShowMessage("Opción Inválida");
                        students = null;
                        break;
                }

                if(students != null)
                {
                    if (students.Count != 0)
                    {
                        Alumno alumno = SelectAlumnoFromList(students);

                        if (alumno != null)
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Format.ShowMessage(
                                "---Datos del Alumno---",
                                "",
                                "Matrícula: " + alumno.matricula_alumno,
                                "Nombre: " + alumno.nombre_alumno + " " + alumno.apellido_paterno_alumno + " " + alumno.apellido_materno_alumno,
                                "Dirección: " + alumno.direccion_alumno,
                                "Teléfono: " + alumno.telefono_alumno,
                                "Correo: " + alumno.correo_alumno,
                                "Carrera: " + alumno.carrera,
                                "Semestre: " + alumno.semestre_alumno
                                );
                        }
                    }
                    else
                    {
                        string confirm = Requests.AskForConfirmation(
                        "No se han encontrado alumnos.",
                        "¿Desea realizar otra consulta?"
                        );

                        if (confirm.Equals("N"))
                            return;
                    }
                }
            } while (true);
        }

        /// <summary>
        /// Obtiene una lista de alumnos que coincidan con el nombre o la matrícula indicado por el usuario.
        /// </summary>
        /// <returns>Un objeto List&lt;Alumno&gt; con los alumnos que coincidan con los parámetros de búsqueda o null si se selecciona la opción "Salir".</returns>
        public static List<Alumno> GetListOfAlumnos()
        {
            List<Alumno> alumnos;
            string option;

            do
            {
                //Impresión del Menú
                Console.Clear();
                Console.WriteLine();
                Format.DrawBox("Seleccionar Alumno");
                Console.WriteLine();
                Format.WriteLine("1. Buscar por Nombre");
                Format.WriteLine("2. Buscar por Matrícula");
                Format.WriteLine("3. Salir");
                Console.WriteLine();

                //Solicitud de opción
                Format.Write("Ingrese una opción: ");
                option = Console.ReadLine();
                Console.WriteLine();

                //Opciones del menú
                switch (option)
                {
                    case "1":
                        string nombreCompleto = Requests.RequestNombreCompleto();

                        //Lista de alumnos con el nombre ingresado.
                        alumnos = new AlumnoSC()
                            .GetAlumnosByNombreCompleto(nombreCompleto)
                            .OrderBy(a => a.nombre_alumno)
                            .ToList();

                        return alumnos;
                    case "2":
                        string matricula = Requests.RequestExistingMatricula();

                        //Lista de alumnos con un solo registro del alumno con la matrícula ingresada.
                        Alumno alumno = new AlumnoSC().GetAlumnoByMatricula(matricula);
                        alumnos = new List<Alumno>();

                        if(alumno != null)
                            alumnos.Add(alumno);

                        return alumnos;
                    case "3":
                        return null;
                    default: Format.ShowMessage("Opción Inválida"); break;
                }
            } while (true);
        }

        /// <summary>
        /// Dada una lista de alumnos, muestra los alumnos de la lista por páginas y perimte que el usuario seleccionar alguno o que navegue entre las páginas.
        /// </summary>
        /// <param name="alumnos">Lista tipo List&lt;Alumno&gt; que contiene a los alumnos que se mostrarán.</param>
        /// <returns>El alumno seleccionado, o null si se selecciona la opción de regresar.</returns>
        public static Alumno SelectAlumnoFromList(List<Alumno> alumnos)
        {
            int alumnosPorPagina = 10;
            int pos = 0;

            do
            {
                string option;

                //Impresión del Menú
                Console.Clear();
                Console.WriteLine();
                Format.DrawBox("Seleccionar Alumno");
                Console.WriteLine();

                //Página actual
                Format.WriteLine("Página " + Math.Ceiling((float)pos/alumnosPorPagina + 1) + " de " + Math.Ceiling((float)alumnos.Count / alumnosPorPagina));
                Console.WriteLine();

                //Alumnos en la página
                for (int i = 0; i < alumnosPorPagina; i++)
                {
                    if (pos + i < alumnos.Count)
                    {
                        AlumnoDTO alumno = new AlumnoDTO()
                        {
                            Matricula = alumnos[pos + i].matricula_alumno,
                            Nombre = alumnos[pos + i].nombre_alumno,
                            ApellidoPaterno = alumnos[pos + i].apellido_paterno_alumno,
                            ApellidoMaterno = alumnos[pos + i].apellido_materno_alumno
                        };

                        Format.WriteLine((i + 1) + ": " + alumno.GetNombreCompleto() + " - " + alumno.Matricula);
                    }
                    else
                        break;
                }

                //Opciones de Navegación
                Format.WriteLine("----------");
                if (pos > 0)
                    Format.WriteLine("A: Anterior Página");
                if (pos + alumnosPorPagina < alumnos.Count)
                    Format.WriteLine("S: Siguiente Página");
                Format.WriteLine("R: Regresar");
                Console.WriteLine();

                //Solicitud de Opción
                Format.Write("Seleccione un alumno o una opción: ");
                option = Console.ReadLine();
                Console.WriteLine();

                //Opciones del Menú

                //Si la opción es numérica y está en el rango de alumnos que se pueden seleccionar
                if (int.TryParse(option, out int number) && pos + number <= alumnos.Count && number >= 1 && number <= alumnosPorPagina)
                    return alumnos[pos + number - 1];   //El método regresa al alumno seleccionado
                
                //Opciones de Navegación
                else if (option.ToUpper().Equals("A") && pos > 0)
                    pos -= alumnosPorPagina;    //Regresar página
                else if (option.ToUpper().Equals("S") && pos + alumnosPorPagina < alumnos.Count)
                    pos += alumnosPorPagina;    //Avanzar Página
                else if (option.ToUpper().Equals("R"))
                    return null;
                
                else
                    Format.ShowMessage("Opción Inválida");

            } while (true);
        }

        public static Alumno SelectAlumno()
        {
            List<Alumno> alumnos;

            do
            {
                alumnos = GetListOfAlumnos();

                if (alumnos != null)
                    if (alumnos.Count > 0)
                        break;
                    else
                    {
                        string confirm = Requests.AskForConfirmation(
                        "No se han encontrado alumnos.",
                        "¿Desea realizar otra búsqueda?"
                        );

                        if (confirm.Equals("N"))
                            return null;
                    }
                else
                    return null;
            } while (true);

            do
            {
                Alumno selectedAlumno = SelectAlumnoFromList(alumnos);

                if (selectedAlumno == null)
                    return null;

                string confirm = Requests.AskForConfirmation(
                        "---Datos del Alumno---",
                        "",
                        "Nombre: " + selectedAlumno.nombre_alumno + " " + selectedAlumno.apellido_paterno_alumno + " " + selectedAlumno.apellido_materno_alumno,
                        "Matrícula: " + selectedAlumno.matricula_alumno,
                        "Carrera: " + selectedAlumno.carrera,
                        "Semestre: " + selectedAlumno.semestre_alumno,
                        "",
                        "¿Desea seleccionar este alumno?"
                        );

                if (confirm.Equals("S"))
                    return selectedAlumno;
            } while (true);
        }
    }
}
