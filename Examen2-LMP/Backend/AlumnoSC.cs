using Examen2_LMP.DataAccess;
using System;
using System.Linq;
using Utilities;

namespace Examen2_LMP.Backend
{
    class AlumnoSC : BaseSC
    {
        /* Altas */
        /// <summary>
        /// Añade un registro de alumno a la base de datos. Si no se puede capturar al alumno se muestra un mensaje al usuario informando de esto.
        /// </summary>
        /// <param name="newAlumno">Objeto tipo Alumno, el cual contiene la información del nuevo alumno que se registrará.</param>
        /// <returns>Un booleano; true si se registró al alumno, false en caso contrario.</returns>
        public bool AddAlumno(Alumno newAlumno)
        {
            try
            {
                dbContext.Alumno.Add(newAlumno);
                dbContext.SaveChanges();
            }
            catch(Exception e)
            {
                Format.ShowMessage("Se ha producido un error. No se ha podido registrar al alumno.", "Error: " + e.Message);

                return false;
            }

            Format.ShowMessage("Se ha registrado al alumno con éxito.");
            return true;
        }

        /* Bajas */
        /// <summary>
        /// Elimina un registro de alumno de la base de datos. Si no se puede eliminar al alumno se muestra un mensaje al usuario informando de esto.
        /// </summary>
        /// <param name="alumno">Objeto tipo Alumno, el cual representa al alumno que se eliminará.</param>
        /// <returns>Un booleano; true si se elimina al alumno, false en caso contrario.</returns>
        public bool RemoveAlumno(Alumno alumno)
        {
            try
            {
                dbContext.Alumno.Attach(alumno);
                dbContext.Alumno.Remove(alumno);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Format.ShowMessage("Se ha producido un error. No se ha podido eliminar al alumno.", "Error: " + e.Message);

                return false;
            }

            Format.ShowMessage("Se ha eliminado al alumno con éxito.");
            return true;
        }

        /* Cambios */
        public bool UpdateAlumno(Alumno alumno)
        {
            try
            {
                Alumno alumnoInDB = GetAlumnoByMatricula(alumno.matricula_alumno);

                dbContext.Entry(alumnoInDB).CurrentValues.SetValues(alumno);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Format.ShowMessage("Se ha producido un error. No se ha podido actualizar al alumno.", "Error: " + e.Message);

                return false;
            }

            Format.ShowMessage("Se ha eliminado al alumno con éxito.");
            return true;
        }


        /* Consultas */
        /// <summary>
        /// Obtiene todos los alumnos de la base de datos.
        /// </summary>
        /// <returns>Un objeto IQueryable&lt;Alumno&gt; con los alumnos.</returns>
        public IQueryable<Alumno> GetAllAlumnos()
        {
            return dbContext.Alumno;
        }

        /// <summary>
        /// Obtiene al alumno con una matrícula en particular.
        /// </summary>
        /// <param name="matricula">Un string con la matrícula del alumno.</param>
        /// <returns>Un objeto Alumno que contiene la información del alumno con la matrícula especificada, o null si no existe.</returns>
        public Alumno GetAlumnoByMatricula(string matricula)
        {
            return GetAllAlumnos().FirstOrDefault(a => a.matricula_alumno == matricula);
        }

        /// <summary>
        /// Obtiene a todos los alumnos con los apellidos especificados.
        /// </summary>
        /// <param name="apellidos">Un string con los apellidos.</param>
        /// <returns>Un objeto IQueryable&lt;Alumno&gt; con los alumnos obtenidos de la consulta.</returns>
        public IQueryable<Alumno> GetAlumnosByApellido(string apellidos)
        {
            return GetAllAlumnos().Where(a => a.apellido_paterno_alumno.ToLower() + " " + a.apellido_materno_alumno.ToLower() == apellidos.ToLower());
        }

        /// <summary>
        /// Obtiene a todos los alumnos con el nombre completo especificado.
        /// </summary>
        /// <param name="fullName">Un string con el nombre completo.</param>
        /// <returns>Un objeto IQueryable&lt;Alumno&gt; con los alumnos obtenidos de la consulta.</returns>
        public IQueryable<Alumno> GetAlumnosByNombreCompleto(string fullName)
        {
            return GetAllAlumnos().Where(a => a.nombre_alumno.ToLower() + " " + a.apellido_paterno_alumno.ToLower() + " " + a.apellido_materno_alumno.ToLower() == fullName.ToLower());
        }

        /// <summary>
        /// Obtiene a todos los alumnos que estudien la carrera indicada.
        /// </summary>
        /// <param name="carrera">Un string con las iniciales de la carrera.</param>
        /// <returns>Un objeto IQueryable&lt;Alumno&gt; con los alumnos obtenidos de la consulta.</returns>
        public IQueryable<Alumno> GetAlumnosByCarrera(string carrera)
        {
            return GetAllAlumnos().Where(a => a.carrera == carrera);
        }

        /// <summary>
        /// Obtiene a todos los alumnos que cursan el semestre indicado.
        /// </summary>
        /// <param name="semestre">Un entero con el semestre deseado.</param>
        /// <returns>Un objeto IQueryable&lt;Alumno&gt; con los alumnos obtenidos de la consulta.</returns>
        public IQueryable<Alumno> GetAlumnosBySemestre(int semestre)
        {
            return GetAllAlumnos().Where(a => a.semestre_alumno == semestre);
        }

        //Otros
        public Alumno GenerateRandomAlumno()
        {
            string[] carreras = { "LCC", "LSTI", "LM", "LF", "LMAD", "LA" };
            Alumno alumno = new Alumno();

            do
            {
                alumno.matricula_alumno = Other.RandomNumber(7).ToString();

                if (new AlumnoSC().GetAlumnoByMatricula(alumno.matricula_alumno) == null)
                    break;
            } while (true);
            alumno.nombre_alumno = "Nombre" + Other.RandomNumber();
            alumno.apellido_paterno_alumno = "ApellidoPaterno" + Other.RandomNumber();
            alumno.apellido_materno_alumno = "ApellidoMaterno" + Other.RandomNumber();
            alumno.direccion_alumno = "Dirección" + Other.RandomNumber();
            alumno.telefono_alumno = Other.RandomNumber(10).ToString();
            do
            {
                string correo = "";
                correo += Other.RandomNumber();
                correo += "@";
                correo += Other.RandomNumber();
                correo += ".com";

                if (new AlumnoSC().GetAllAlumnos().FirstOrDefault(a => a.correo_alumno == correo) == null)
                {
                    alumno.correo_alumno = correo;
                    break;
                }
            } while (true);
            alumno.carrera = carreras[ new Random().Next(6) ];
            alumno.semestre_alumno = (int)Other.RandomNumber(1) + 1;

            return alumno;
        }
    }
}
