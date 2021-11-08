using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Vismar_20190425.Entidades
{
    public class TiposTareas
    {
        [Key]
        public int TipoTareaId { get; set; }
        public string DescripcionTipoTarea { get; set; }
        public int TiempoAcumulado { get; set; }
    }
}
