using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Vismar_20190425.Entidades
{
    public class ProyectosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int MyProperty { get; set; }
        public int ProyectoId { get; set; }
        public int TipoTareaId { get; set; }
        public string Requerimiento { get; set; }
        public int Tiempo { get; set; }

        [ForeignKey("TipoTareaId")]

        public TiposTareas TiposTareas { get; set; }

        public Proyectos Proyecto { get; set; }

        public ProyectosDetalle()
        {
            Id = 0;

            ProyectoId = 0;

            TipoTareaId = 0;

            Requerimiento = string.Empty;

            Tiempo = 0;

            TiposTareas = null;

            Proyecto = null;
        }

        public ProyectosDetalle(int proyecto, int tipo, string requerimiento, int tiempo, TiposTareas tt, Proyectos proyectos)
        {
            Id = 0;

            ProyectoId = proyecto;

            TipoTareaId = tipo;

            Requerimiento = requerimiento;

            Tiempo = tiempo;

            TiposTareas = tt;

            Proyecto = proyectos;
        }
    }
}
