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
                dbContext.Alumno.Remove(alumno);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                Format.ShowMessage("Se ha producido un error. No se ha podido eliminar al alumno.");

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

        public Alumno GetAlumnoWithMatricula(int matricula)
        {
            return GetAllAlumnos().FirstOrDefault(a => a.matricula_alumno == matricula);
        }

        public IQueryable<Alumno> GetAlumnosByFullName(string fullName)
        {
            return GetAllAlumnos().Where(a => a.nombre_alumno + " " + a.apellido_paterno_alumno + " " + a.apellido_materno_alumno == fullName);
        }

        public IQueryable<Alumno> GetAlumnosByCarrera(string carrera)
        {
            return GetAllAlumnos().Where(a => a.carrera == carrera);
        }

        public IQueryable<Alumno> GetAlumnosBySemestre(int semestre)
        {
            return GetAllAlumnos().Where(a => a.semestre_alumno == semestre);
        }
    }
}
