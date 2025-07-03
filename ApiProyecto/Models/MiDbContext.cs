using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; 

namespace ApiProyecto.Models
{
    public class MiDbContext : DbContext
    {
        public MiDbContext() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;

            Database.SetInitializer<MiDbContext>(null);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

    }
}