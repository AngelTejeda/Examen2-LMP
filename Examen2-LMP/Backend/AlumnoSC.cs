using Examen2_LMP.DataAccess;
using System;
using System.Linq;

namespace Examen2_LMP.Backend
{
    class AlumnoSC : BaseSC
    {
        public IQueryable<Alumno> getAllAlumnos()
        {
            return dbContext.Alumno;
        }

        //Altas
        public bool addAlumno(Alumno newAlumno)
        {
            try
            {
                dbContext.Alumno.Add(newAlumno);
                dbContext.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
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
