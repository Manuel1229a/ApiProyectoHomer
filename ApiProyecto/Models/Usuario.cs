using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}