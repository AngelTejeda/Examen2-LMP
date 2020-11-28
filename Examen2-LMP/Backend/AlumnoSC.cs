using Examen2_LMP.DataAccess;
using System;
using System.Linq;
using Utilities;

namespace Examen2_LMP.Backend
{
    class AlumnoSC : BaseSC
    {
        //Altas
        public bool AddAlumno(Alumno newAlumno)
        {
            try
            {
                dbContext.Alumno.Add(newAlumno);
                dbContext.SaveChanges();
            }
            catch(Exception)
            {
                Format.ShowMessage("Se ha producido un error. No se ha podido registrar al alumno.");

                return false;
            }

            Format.ShowMessage("Se ha registrado al alumno con éxito.");
            return true;
        }
        //Bajas
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

        //Cambios

        //Consultas
        public IQueryable<Alumno> GetAllAlumnos()
        {
            return dbContext.Alumno;
        }

        public Alumno GetAlumnoByMatricula(string matricula)
        {
            return GetAllAlumnos().FirstOrDefault(a => a.matricula_alumno == matricula);
        }

        public IQueryable<Alumno> GetAlumnosByApellido(string apellidos)
        {
            return GetAllAlumnos().Where(a => a.apellido_paterno_alumno.ToLower() + " " + a.apellido_materno_alumno.ToLower() == apellidos.ToLower());
        }

        public IQueryable<Alumno> GetAlumnosByNombreCompleto(string fullName)
        {
            return GetAllAlumnos().Where(a => a.nombre_alumno.ToLower() + " " + a.apellido_paterno_alumno.ToLower() + " " + a.apellido_materno_alumno.ToLower() == fullName.ToLower());
        }

        public IQueryable<Alumno> GetAlumnosByCarrera(string carrera)
        {
            return GetAllAlumnos().Where(a => a.carrera == carrera);
        }

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
