using Microsoft.EntityFrameworkCore;
using P2_AP1_Vismar_20190425.DAL;
using P2_AP1_Vismar_20190425.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Vismar_20190425.BLL
{
    public class ProyectosBLL
    {
        public static bool Guardar(Proyectos proyecto)
        {
            if (!Existe(proyecto.ProyectoId))
                return Insertar(proyecto);
            else
                return Modificar(proyecto);
        }

        private static bool Insertar(Proyectos proyecto)
        {
            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                contexto.Proyectos.Add(proyecto);

                foreach (var detalle in proyecto.Detalle)
                {
                    contexto.Entry(detalle).State = EntityState.Added;
                    contexto.Entry(detalle.TiposTareas).State = EntityState.Modified;
                    contexto.Entry(detalle.Proyecto).State = EntityState.Modified;
                    detalle.TiposTareas.TiempoAcumulado += detalle.Tiempo;
                    detalle.Proyecto.Total += detalle.Tiempo;
                }

                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;

        }

        private static bool Modificar(Proyectos proyecto)
        {
            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                var ProyectoAnterior = contexto.Proyectos
                    .Where(x => x.ProyectoId == proyecto.ProyectoId)
                    .Include(x => x.Detalle)
                    .ThenInclude(x => x.TiposTareas)
                    .AsNoTracking()
                    .SingleOrDefault();

                //foreach(var detalle in proyectoAnterior.Detalle)
                //{
                //    detalle.TiposTareas.TiempoAcumulado -= detalle.Tiempo;

                //    detalle.Proyecto.Total -= detalle.Tiempo;
                //}

                contexto.Database.ExecuteSqlRaw($"DeleteFROM ProyectosDetalle Where Id={proyecto.ProyectoId}");

                foreach (var item in proyecto.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;

                    contexto.Entry(item.TiposTareas).State = EntityState.Modified;

                    contexto.Entry(item.Proyecto).State = EntityState.Modified;

                    item.TiposTareas.TiempoAcumulado += item.Tiempo;

                    item.Proyecto.Total += item.Tiempo;
                }

                contexto.Entry(proyecto).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Proyectos Buscar(int id)
        {
            Proyectos proyecto = new Proyectos();

            Contexto contexto = new Contexto();

            try
            {
                proyecto = contexto.Proyectos.Include(x => x.Detalle)
                    .Where(x => x.ProyectoId == id)
                    .Include(x => x.Detalle)
                    .ThenInclude(x => x.TiposTareas)
                    .SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return proyecto;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                var proyecto = Buscar(id);

                if(proyecto != null)
                {
                    foreach(var item in proyecto.Detalle)
                    {
                        contexto.Entry(item.Proyecto).State = EntityState.Modified;

                        contexto.Entry(item.TiposTareas).State = EntityState.Modified;

                        item.TiposTareas.TiempoAcumulado -= item.Tiempo;

                        item.Proyecto.Total -= item.Tiempo;
                    }

                    contexto.Proyectos.Remove(proyecto);

                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static List<Proyectos> GetList(Expression<Func<Proyectos, bool>> criterio)
        {
            List<Proyectos> Lista = new List<Proyectos>();

            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Proyectos.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();

            bool encontrado = false;

            try
            {
                encontrado = contexto.Proyectos.Any(e => e.ProyectoId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

    }
}
