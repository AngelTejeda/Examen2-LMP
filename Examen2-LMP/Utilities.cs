using Examen2_LMP.Backend;
using System;
using System.Linq;

namespace Utilities
{
    class Format
    {
        public static void WriteLine(string text)
        {
            Write(text + "\n");
        }

        public static void Write(string text)
        {
            Console.Write("   " + text);
        }

        public static void DrawBox(params string[] texts)
        {
            int maxLength = texts.Max(t => t.Length);

            Console.Write("        ");
            for (int i = 0; i < maxLength + 4; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            foreach(string text in texts) { 
                Console.Write("        ");
                Console.Write("| " + text);
                for (int i = 0; i < maxLength - text.Length; i++)
                    Console.Write(" ");
                Console.WriteLine(" |");
            }

            Console.Write("        ");
            for (int i = 0; i < maxLength + 4; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        public static void ShowMessage(string message)
        {
            DrawBox(
                message,
                "Presione Enter para continuar..."
                );
            Console.ReadLine();
        }
    }

    class Requests
    {
        public static string RequestField(string requestMessage, Func<string, bool> lambda)
        {
            string field;
            do
            {
                Console.Clear();
                Format.Write(requestMessage);
                field = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    if (lambda == null)
                        break;
                    else if (lambda(field))
                        break;
                }
                catch (Exception e)
                {
                    Format.ShowMessage(e.Message);
                }
                
            } while (true);
            
            return field;
        }

        public static int RequestMatricula()
        {
            return int.Parse( RequestField(
                "Ingrese la matrícula (7 dígitos): ",
                str =>
                {
                    if (!int.TryParse(str, out int i))
                        throw new Exception("No puede ingresar caracteres que no sean numéricos.");
                    if (str.Length != 7)
                        throw new Exception("La longitud de la matrícula debe ser igual a 7.");
                    if (new AlumnoSC().GetAlumnoWithMatricula(int.Parse(str)) != null)
                        throw new Exception("Ya existe un alumno con esa matrícula.");

                    return true;
                }
                ));
        }

        public static string RequestNonEmptyString(string fieldName)
        {
            return RequestField(
                "Ingrese " + fieldName + ": ",
                str =>
                {
                    if (str.Length == 0)
                        throw new Exception("Debe ingresar una cadena no vacía.");

                    return true;
                }
                );
        }

        public static string RequestNombre()
        {
            return RequestNonEmptyString("el o los nombres del alumno");
        }

        public static string RequestApellidoPaterno()
        {
            return RequestNonEmptyString("el apellido paterno del alumno");
        }

        public static string RequestApellidoMaterno()
        {
            return RequestNonEmptyString("el apellido materno del alumno");
        }

        public static string RequestDireccion()
        {
            return RequestNonEmptyString("la dirección del alumno");
        }

        public static string RequestTelefono()
        {
            return RequestField(
                "Ingrese el teléfono del alumno (10 dígitos): ",
                str =>
                {
                    if (!long.TryParse(str, out long i))
                        throw new Exception("No puede ingresar caracteres que no sean numéricos.");
                    if (str.Length != 10)
                        throw new Exception("Debe ingresar 10 dígitos.");

                    return true;
                }
                );
        }

        public static string RequestCorreo()
        {
            return RequestField(
                "Ingrese el correo del alumno (contiene @ y termina con '.com'): ",
                str =>
                {
                    if (!str.Contains("@"))
                        throw new Exception("El correo debe contener '@'.");
                    if (!str.EndsWith(".com"))
                        throw new Exception("El correo debe terminar con '.com'.");
                    if (new AlumnoSC().GetAllAlumnos().FirstOrDefault(a => a.correo_alumno == str) != null)
                        throw new Exception("El correo ingresado ya está registrado.");

                    return true;
                }
                );
        }

        public static string RequestCarrera()
        {
            return RequestField(
                "Opciones de Carrera: LCC, LSTI, LM, LF, LMAD, LA\nIngrese la carrera del alumno (en mayúsculas): ",
                str =>
                {
                    string[] carrera = { "LCC", "LSTI", "LM", "LF", "LMAD", "LA" };

                    if (!carrera.Contains(str))
                        throw new Exception("Ingresó una carrera no válida.");

                    return true;
                }
                );
        }

        public static int RequestSemestre()
        {
            return int.Parse( RequestField(
                "Ingrese el semestre que está cursando el alumno (1-9): ",
                str =>
                {
                    if (!int.TryParse(str, out int semestre))
                        throw new Exception("Debe ingresar un valor numérico.");
                    if (semestre < 1 || semestre > 9)
                        throw new Exception("Debe ingresar un número entre 1 y 9.");

                    return true;
                }
                ));
        }
    }
}
