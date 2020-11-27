using Examen2_LMP.Backend;
using System;
using System.Collections.Generic;
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

        public static void ShowMessage(params string[] texts)
        {
            List<string> temp = texts.ToList();
            temp.Add("");
            temp.Add("Presione Enter para continuar...");
            texts = temp.ToArray();

            DrawBox(texts);
            Console.ReadLine();
        }
    }

    class Requests
    {
        public static string AskForConfirmation(params string[] texts)
        {
            string option;

            do
            {
                Console.Clear();
                Console.WriteLine();
                Format.DrawBox(texts);
                Console.WriteLine();

                Format.Write("(S/N): ");
                option = Console.ReadLine();

                option = option.ToUpper();
            } while (option != "S" && option!= "N");

            return option;
        }
        
        public static string RequestField(string requestMessage, Func<string, bool> lambda, string title = "")
        {
            string field;

            do
            {
                Console.Clear();
                Console.WriteLine();
                if (!title.Equals("")) {
                    Format.DrawBox(title);
                    Console.WriteLine();
                }
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

        public static string RequestNewMatricula()
        {
            return RequestField(
                "Ingrese la matrícula (7 dígitos): ",
                str =>
                {
                    if (!int.TryParse(str, out int i))
                        throw new Exception("No puede ingresar caracteres que no sean numéricos.");
                    if (str.Length != 7)
                        throw new Exception("La longitud de la matrícula debe ser igual a 7.");
                    if (new AlumnoSC().GetAlumnoByMatricula(str) != null)
                        throw new Exception("Ya existe un alumno con esa matrícula.");

                    return true;
                },
                title: "Matrícula"
                );
        }

        public static string RequestExistingMatricula()
        {
            return RequestField(
                "Ingrese la matrícula (7 dígitos): ",
                str =>
                {
                    if (!int.TryParse(str, out int i))
                        throw new Exception("No puede ingresar caracteres que no sean numéricos.");
                    if (str.Length != 7)
                        throw new Exception("La longitud de la matrícula debe ser igual a 7.");

                    return true;
                },
                title: "Matrícula"
                );
        }

        public static string RequestNonEmptyString(string fieldName, string title = "")
        {
            return RequestField(
                "Ingrese " + fieldName + ": ",
                str =>
                {
                    if(str.Equals(""))
                        throw new Exception("La cadena no debe estar vacía.");
                    if (!str.TrimStart().Equals(str))
                        throw new Exception("La cadena no debe empezar con espacios en blanco.");
                    if (!str.TrimEnd().Equals(str))
                        throw new Exception("La cadena no debe terminar con espacios en blanco.");

                    int cont = 0;
                    for(int i=0; i<str.Length; i++)
                    {
                        if(cont > 1)
                            throw new Exception("La cadena no debe contener más de un espacio contiguo.");
                        if (str[i] == ' ')
                            cont++;
                        else
                            cont = 0;
                    }

                    return true;
                },
                title
                );
        }

        public static string RequestNombre()
        {
            return RequestNonEmptyString("el o los nombres del alumno", title: "Nombre");
        }

        public static string RequestApellidoPaterno()
        {
            return RequestNonEmptyString("el apellido paterno del alumno", title: "Apellido Paterno");
        }

        public static string RequestApellidoMaterno()
        {
            return RequestNonEmptyString("el apellido materno del alumno", title: "Apellido Materno");
        }

        public static string RequestDireccion()
        {
            return RequestNonEmptyString("la dirección del alumno", title: "Dirección");
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
                },
                title: "Teléfono"
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
                },
                title: "Correo"
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
                },
                title: "Carrera"
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
                },
                title: "Semestre"
                ));
        }
        
        public static string RequestNombreCompleto()
        {
            return RequestNonEmptyString("el nombre completo del alumno", "Nombre Completo");
        }
    }
}
