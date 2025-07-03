using ApiProyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;

namespace ApiProyecto.Controllers
{
    public class TareasController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        // GET: Tareas
        public IEnumerable<Tarea> Get()
        {
            return db.Tareas.ToList();
        }

        // GET: Tareas/id
        public IHttpActionResult Get(int id)
        {
            var tarea = db.Tareas.Find(id);
            if (tarea == null)
            {
                return NotFound();
            }
            return Ok(tarea);
        }

        // POST: Tareas
        [HttpPost]
        public IHttpActionResult Post([FromBody] Tarea tarea)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            tarea.FechaCreacion = DateTime.Now;

            try
            {
                db.Tareas.Add(tarea);
                db.SaveChanges();
                return Ok(tarea);
            }
            catch (DbUpdateException dbEx)
            {
                return InternalServerError(dbEx.InnerException?.InnerException ?? dbEx);
            }
        }


        // PUT: Tareas
        public IHttpActionResult Put(int id, [FromBody] Tarea tarea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingTarea = db.Tareas.Find(id);
            if (existingTarea == null)
            {
                return NotFound();
            }
            existingTarea.Titulo = tarea.Titulo;
            existingTarea.Descripcion = tarea.Descripcion;
            existingTarea.FechaVencimiento = tarea.FechaVencimiento;
            existingTarea.Estado = tarea.Estado;
            db.SaveChanges();
            return Ok(existingTarea);
        }

        //DELETE: Tareas
        public IHttpActionResult Delete(int id)
        {
            {
                var tarea = db.Tareas.Find(id);
                if (tarea == null)
                {
                    return NotFound();
                }
                db.Tareas.Remove(tarea);
                db.SaveChanges();
                return Ok(tarea);
            }
        }
    }
}