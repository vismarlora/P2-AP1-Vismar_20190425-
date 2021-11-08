using P2_AP1_Vismar_20190425.DAL;
using P2_AP1_Vismar_20190425.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Vismar_20190425.BLL
{
    public class TiposTareasBLL
    {
        public static TiposTareas Buscar(int id)
        {
            TiposTareas tarea;

            Contexto contexto = new Contexto();

            try
            {
                tarea = contexto.TiposTareas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return tarea;
        }
        public static List<TiposTareas> GetTiposTarea()
        {
            List<TiposTareas> lista = new List<TiposTareas>();

            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.TiposTareas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        public static List<TiposTareas> GetList(Expression<Func<TiposTareas, bool>> criterio)
        {
            List<TiposTareas> Lista = new List<TiposTareas>();

            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.TiposTareas.Where(criterio).ToList();
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
    }
}
