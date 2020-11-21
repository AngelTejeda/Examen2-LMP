using Examen2_LMP.DataAccess;
using System;
using System.Linq;

namespace Examen2_LMP.Backend
{
    class AlumnoSC : BaseSC
    {
        public IQueryable<Alumno> GetAllAlumnos()
        {
            return dbContext.Alumno;
        }

        public Alumno GetAlumnoWithMatricula(int matricula)
        {
            return GetAllAlumnos().FirstOrDefault(a => a.matricula_alumno == matricula);
        }

        //Altas
        public bool addAlumno(Alumno newAlumno)
        {
            try
            {
                dbContext.Alumno.Add(newAlumno);
                dbContext.SaveChanges();
            }
            catch(Exception)
            {
                Utilities.ShowMessage("No se ha podido registrar al alumno.");

                return false;
            }

            Utilities.ShowMessage("Se ha registrado al alumno con éxito.");
            return true;
        }
        //Bajas

        //Cambios

        //Consultas
    }
}
