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

        public Alumno GetAlumnoByMatricula(int matricula)
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
            Alumno alumno = new Alumno();
            Random rand = new Random();

            do
            {
                string matricula = "";
                for (int i = 0; i < 7; i++)
                {
                    matricula += rand.Next(10);
                }

                if (new AlumnoSC().GetAlumnoByMatricula(int.Parse(matricula)) == null)
                {
                    alumno.matricula_alumno = int.Parse(matricula);
                    break;
                }
            } while (true);
            alumno.nombre_alumno = "Nombre" + rand.Next(10000);
            alumno.apellido_paterno_alumno = "ApellidoPaterno" + rand.Next(10000);
            alumno.apellido_materno_alumno = "ApellidoMaterno" + rand.Next(10000);
            alumno.direccion_alumno = "Dirección" + rand.Next(10000);
            string telefono = "";
            for (int i = 0; i < 10; i++)
            {
                telefono += rand.Next(10);
            }
            alumno.telefono_alumno = telefono;
            do
            {
                string correo = "";
                for (int i = 0; i < rand.Next(10); i++)
                {
                    correo += rand.Next(10);
                }
                correo += "@";
                for (int i = 0; i < rand.Next(10); i++)
                {
                    correo += rand.Next(10);
                }
                correo += ".com";

                if (new AlumnoSC().GetAllAlumnos().FirstOrDefault(a => a.correo_alumno == correo) == null)
                {
                    alumno.correo_alumno = correo;
                    break;
                }

            } while (true);
            string[] carreras = { "LCC", "LSTI", "LM", "LF", "LMAD", "LA" };

            alumno.carrera = carreras[rand.Next(6)];
            alumno.semestre_alumno = rand.Next(9) + 1;

            return alumno;
        }
    }
}
