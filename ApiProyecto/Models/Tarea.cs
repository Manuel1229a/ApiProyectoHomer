using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace ApiProyecto.Models
{
    public class Tarea
    {
        public int TareaId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Estado { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; } // Relación con Usuario
    }
}