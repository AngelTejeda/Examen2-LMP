using Examen2_LMP.Backend;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilities
{
    /// <summary>
    /// Contiene métodos para dar formato a la salida en consola.
    /// </summary>
    class Format
    {
        /// <summary>
        /// Equivalente a Console.WriteLine(), pero con espacios en blanco antes del texto.
        /// </summary>
        /// <param name="text">String que se imprime.</param>
        public static void WriteLine(string text)
        {
            Write(text + "\n");
        }

        /// <summary>
        /// Equivalente a Console.Write(), pero con espacios en blanco antes del texto.
        /// </summary>
        /// <param name="text">String que se imprime.</param>
        public static void Write(string text)
        {
            Console.Write("   " + text);
        }
        
        /// <summary>
        /// Imprime dentro de una caja los strings que recibe como parámetro.
        /// </summary>
        /// <param name="texts">Cada string representa una nueva línea.</param>
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

        /// <summary>
        /// Imprime un mensaje para el usuario dentro de una caja. El programa no continúa su ejecución hasta que se presione Enter.
        /// </summary>
        /// <param name="texts">Mensaje para el usuario. Cada string representa una nueva línea.</param>
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

    /// <summary>
    /// Contienen métodos para facilitar la solicitud de datos al usuario.
    /// </summary>
    class Requests
    {
        /// <summary>
        /// Pide confirmación al usuario. El usuario debe ingresar "S" o "N", mayúscula o minúscula.
        /// El programa no continúa con su ejecución hasta que se ingrese una de estas opciones.
        /// </summary>
        /// <param name="texts">Mensaje a mostrar para el usuario. Cada string representa una nueva línea.</param>
        /// <returns>Un string con la opción ingresada por el usuario, ya sea "S" o "N" en mayúscula.</returns>
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

        /// <summary>
        /// Pide un dato al usuario. Este dato se valida con una función lambda (si se requiere) y el programa no continúa con su ejecución hasta que el dato sea válido.
        /// </summary>
        /// <param name="requestMessages">Mensaje que se muestra al usuario al pedir el dato. Cada string es una nueva línea.</param>
        /// <param name="lambda">Parámetro opcional. Función lambda que recibe un string y devuelve un booleano.
        /// Evalúa el dato ingresado por el usuario, si alguna condicón no se cumple lanza una excepción con un mensaje para el usuario.
        /// Si cumple todas las condiciones devuelve true.</param>
        /// <param name="title">Parámetro opcional. Dibuja un título.</param>
        /// <returns>Un string con el valor ingresado por el usuario.</returns>
        public static string RequestField(Func<string, bool> lambda = null, string title = "", params string[] requestMessages)
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
                for(int i=0; i<requestMessages.Length - 1; i++) {
                    Format.WriteLine(requestMessages[i]);
                }
                if (requestMessages.Length != 0)
                    Format.Write(requestMessages[requestMessages.Length - 1]);
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

        /// <summary>
        /// Pide al usuario una matrícula que no esté registrada en la base de datos.
        /// </summary>
        /// <returns>Un string con la matrícula ingresada por el usuario.</returns>
        public static string RequestNewMatricula()
        {
            return RequestField(
                lambda: str =>
                {
                    Validations.ValidateStringStructure(str);
                    Validations.ValidateNumericString(str);
                    Validations.ValidateStringLength(str, 7);

                    //La cadena no representa una matrícula que ya existe en la base de datos.
                    if (new AlumnoSC().GetAlumnoByMatricula(str) != null)
                        throw new Exception("Ya existe un alumno con esa matrícula.");

                    return true;
                },
                title: "Matrícula",
                "Ingrese la matrícula (7 dígitos): "
                );
        }

        /// <summary>
        /// Pide al usuario una matrícula. Puede o no existir en la base de datos.
        /// </summary>
        /// <returns>Un string con la matrícula ingresada por el usuario.</returns>
        public static string RequestExistingMatricula()
        {
            return RequestField(
                lambda: str =>
                {
                    Validations.ValidateStringStructure(str);
                    Validations.ValidateNumericString(str);
                    Validations.ValidateStringLength(str, 7);

                    return true;
                },
                title: "Matrícula",
                "Ingrese la matrícula (7 dígitos): "
                );
        }

        /// <summary>
        /// Pide al usuario una cadena no vacía. La cadena no debe empezar ni terminar con espacios. Además no puede contener dos espacios contiguos.
        /// </summary>
        /// <param name="fieldName">Nombre del dato que se le pide al usuario.</param>
        /// <param name="title">Parámetro opcional. Si se utiliza imprime la cadena como un título.</param>
        /// <returns>Un string con la cadena ingresada por el usuario.</returns>
        public static string RequestNonEmptyAlphaString(string fieldName, string title = "")
        {
            return RequestField(
                lambda: str =>
                {
                    Validations.ValidateStringStructure(str);
                    Validations.ValidateNonConsecutiveSpaces(str);
                    Validations.ValidateAlphaString(str);

                    return true;
                },
                title,
                "Ingrese " + fieldName + ": "
                );
        }

        /// <summary>
        /// Pide al usuario un nombre. Utiliza la función RequestNonEmptyAlphaString() para validar la cadena.
        /// </summary>
        /// <returns>Un string con el nombre ingresado por el usuario.</returns>
        public static string RequestNombre()
        {
            return RequestNonEmptyAlphaString("el o los nombres del alumno", title: "Nombre");
        }

        /// <summary>
        /// Pide al usuario el apellido paterno. Utiliza la función RequestNonEmptyAlphaString() para validar la cadena.
        /// </summary>
        /// <returns>Un string con el apellido ingresado por el usuario.</returns>
        public static string RequestApellidoPaterno()
        {
            return RequestNonEmptyAlphaString("el apellido paterno del alumno", title: "Apellido Paterno");
        }

        /// <summary>
        /// Pide al usuario el apellido materno. Utiliza la función RequestNonEmptyAlphaString() para validar la cadena.
        /// </summary>
        /// <returns>Un string con el apellido ingresado por el usuario.</returns>
        public static string RequestApellidoMaterno()
        {
            return RequestNonEmptyAlphaString("el apellido materno del alumno", title: "Apellido Materno");
        }

        /// <summary>
        /// Pide al usuario una dirección. Utiliza la función RequestNonEmptyString() para validar la cadena.
        /// </summary>
        /// <returns>Un string con la dirección ingresada por el usuario.</returns>
        public static string RequestDireccion()
        {
            return RequestField(
                lambda: str =>
                {
                    Validations.ValidateStringStructure(str);
                    Validations.ValidateNonConsecutiveSpaces(str);

                    return true;
                }
                );
        }

        /// <summary>
        /// Pide al usuario un número telefónico de 10 dígitos.
        /// </summary>
        /// <returns>Un string con el teléfono ingresado por el usuario.</returns>
        public static string RequestTelefono()
        {
            return RequestField(
                lambda: str =>
                {
                    Validations.ValidateStringStructure(str);
                    Validations.ValidateNumericString(str);
                    Validations.ValidateStringLength(str, 10);

                    return true;
                },
                title: "Teléfono",
                "Ingrese el teléfono del alumno (10 dígitos): "
                );
        }

        /// <summary>
        /// Pide al usuario un correo. El correo debe contener '@' y debe terminar con '.com'.
        /// </summary>
        /// <returns>Un string con el correo ingresado por el usuario.</returns>
        public static string RequestCorreo()
        {
            return RequestField(
                lambda: str =>
                {
                    Validations.ValidateStringDoesNotContain(str, " ");
                    Validations.ValidateStringStructure(str);
                    Validations.ValidateStringContains(str, "@");
                    Validations.ValidateStringEndsWith(str, ".com");
                    
                    //La cadena ingresada no representa un correo que ya exista en la base de datos.
                    if (new AlumnoSC().GetAllAlumnos().FirstOrDefault(a => a.correo_alumno == str) != null)
                        throw new Exception("El correo ingresado ya está registrado.");

                    return true;
                },
                title: "Correo",
                "Ingrese el correo del alumno (contiene @ y termina con '.com'): "
                );
        }

        /// <summary>
        /// Pide al usuario las iniciales de una carrera.
        /// </summary>
        /// <returns>Un string con las iniciales en mayúscula de la carrera ingresada por el usuario.</returns>
        public static string RequestCarrera()
        {
            return RequestField(
                lambda: str =>
                {
                    string[] carrera = { "LCC", "LSTI", "LM", "LF", "LMAD", "LA" };

                    //La cadena es alguna de las carreras válidas.
                    str = str.ToUpper();
                    if (!carrera.Contains(str))
                        throw new Exception("Ingresó una carrera no válida.");

                    return true;
                },
                title: "Carrera",
                "Opciones de Carrera: LCC, LSTI, LM, LF, LMAD, LA",
                "Ingrese la carrera del alumno: "
                ).ToUpper();
        }

        /// <summary>
        /// Pide al usuario un número que representa el semestre del alumno. El semestre debe ser un número entre 1 y 9.
        /// </summary>
        /// <returns>Un entero con el semestre ingresado por el usuario.</returns>
        public static int RequestSemestre()
        {
            return int.Parse( RequestField(
                lambda: str =>
                {
                    Validations.ValidateStringStructure(str);
                    Validations.ValidateNumericString(str);
                    Validations.ValidateNumberBetween(str, 1, 9);

                    return true;
                },
                title: "Semestre",
                "Ingrese el semestre que está cursando el alumno (1-9): "
                ));
        }

        /// <summary>
        /// Pide al usuario ambos apellidos. Utiliza las funciones RequestApellidoPaterno() y RequestApellidoMaterno().
        /// </summary>
        /// <returns></returns>
        public static string RequestApellidos()
        {
            string apellidos = "";
            apellidos += RequestApellidoPaterno();
            apellidos += " " + RequestApellidoMaterno();

            return apellidos;
        }

        /// <summary>
        /// Pide al usuario un nombre completo.  Utiliza la funciones RequestNombe(), RequestApellidoPaterno() y RequestApellidoMaterno().
        /// </summary>
        /// <returns>Un string con el nombre ingresado por el usuario.</returns>
        public static string RequestNombreCompleto()
        {
            string nombreCompleto = "";

            nombreCompleto += RequestNombre();
            nombreCompleto += " " + RequestApellidos();

            return nombreCompleto;
        }
    }

    /// <summary>
    /// Clase que contiene métodos para validar distintos aspectos de una cadena dada.
    /// </summary>
    class Validations
    {
        /// <summary>
        /// Valida que la cadena sea numérica.
        /// </summary>
        /// <param name="str">Cadena a validar.</param>
        public static void ValidateNumericString(string str)
        {
            if (!long.TryParse(str, out long i))
                throw new Exception("No puede ingresar caracteres que no sean numéricos.");
        }

        /// <summary>
        /// Valida que la cadena ingresada tenga la longitud especificada.
        /// </summary>
        /// <param name="str">Cadena a validar.</param>
        /// <param name="length">Longitud de la cadena.</param>
        public static void ValidateStringLength(string str, int length)
        {
            if (str.Length != length)
                throw new Exception("La longitud de la matrícula debe ser igual a " + length + ".");
        }

        /// <summary>
        /// Valida la estructura básica de una cadena (no empieza ni termina con espacios, no está vacía.
        /// </summary>
        /// <param name="str">Cadena a validar.</param>
        public static void ValidateStringStructure(string str)
        {
            //La cadena no está vacía.
            if (str.Equals(""))
                throw new Exception("No puede ingresar una cadena vacía.");
            //La cadena no empieza con espacios en blanco.
            if (!str.TrimStart().Equals(str))
                throw new Exception("La cadena no debe empezar con espacios en blanco.");
            //La cadena no termina con espacios en blanco.
            if (!str.TrimEnd().Equals(str))
                throw new Exception("La cadena no debe terminar con espacios en blanco.");
        }

        /// <summary>
        /// Valida que la cadena no tenga espacios consecutivos.
        /// </summary>
        /// <param name="str">Cadena a validar.</param>
        public static void ValidateNonConsecutiveSpaces(string str)
        {
            //La cadena no contiene espacios consecutivos.
            int cont = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (cont > 1)
                    throw new Exception("La cadena no debe contener más de un espacio contiguo.");
                if (str[i] == ' ')
                    cont++;
                else
                    cont = 0;
            }
        }

        /// <summary>
        /// Valida que la cadena contenga únicamente letras.
        /// </summary>
        /// <param name="str">Cadena a validar.</param>
        internal static void ValidateAlphaString(string str)
        {
            //La cadena únicamente contiene letras.
            for (int i = 0; i < str.Length; i++)
            {
                if (!Char.IsLetter(str[i]))
                    throw new Exception("No puede ingresar caracteres que no sean letras.");
            }
        }

        /// <summary>
        /// Valida que la cadena sea un número dentro del rango indicado.
        /// </summary>
        /// <param name="str">Cadena a validar.</param>
        /// <param name="start">Valor mínimo que puede tomar.</param>
        /// <param name="end">Vaor máximo que puede tomar.</param>
        internal static void ValidateNumberBetween(string str, int start, int end)
        {
            //La cadena es numérica.
            if(int.TryParse(str, out int number))
                throw new Exception("No puede ingresar caracteres que no sean numéricos.");
            //El número está en el rango indicado.
            if (number < start || number > end)
                throw new Exception("Debe ingresar un número entre " + start + " y " + end + ".");
        }

        /// <summary>
        /// Valida que la cadena contenga la subcadena indicada.
        /// </summary>
        /// <param name="str">Cadena a validar.</param>
        /// <param name="substring">Subcadena que debe estar contenida en la cadena.</param>
        internal static void ValidateStringContains(string str, string substring)
        {
            //La cadena contiene el string especificado.
            if (!str.Contains(substring))
                throw new Exception("El correo debe contener '" + substring + "'.");
        }

        /// <summary>
        /// Valida que la cadena termine con una subcadena indicada.
        /// </summary>
        /// <param name="str">Cadena a validar.</param>
        /// <param name="substring">Subcadena con la que debe terminar la cadena.</param>
        internal static void ValidateStringEndsWith(string str, string substring)
        {
            //La cadena termina con el string indicado.
            if (!str.EndsWith(substring))
                throw new Exception("El correo debe terminar con '" + substring + "'.");
        }

        /// <summary>
        /// Valida que la cadena no contenga la subcadena indicada.
        /// </summary>
        /// <param name="str">Cadena a validar.</param>
        /// <param name="substring">Subcadena que no debe contener la cadena.</param>
        internal static void ValidateStringDoesNotContain(string str, string substring)
        {
            string label = substring;

            if (label == " ")
                label = "espacios";

            //La cadena no contiene el string indicado.
            if (str.Contains(substring))
                throw new Exception("El correo no debe contener " + label + " .");
        }
    }

    class Other
    {
        /// <summary>
        /// Regresa un número aleatorio de entre 1 y 10 dígitos.
        /// </summary>
        /// <param name="digits">Parámetro opcional que indica cuántos dígitos debe tener el número generado. Si el parámetro no se define el número de dígitos es aleatorio.</param>
        /// <returns>Un entero long con el número generado.</returns>
        public static long RandomNumber(int digits = 0)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            string number = "";

            if(digits == 0)
                digits = rand.Next(1, 11);

            for(int i=0; i<digits; i++)
                number += rand.Next(0, 10);

            return long.Parse(number);
        }
    }
}
