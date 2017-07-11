using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiCobro.DAL;
using ApiCobro.Models;
using System.Web.Http.Cors;

namespace ApiCobro.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CobrosController : ApiController
    {
        private CobrosDb db = new CobrosDb();

        // GET: api/Cobros
        public IQueryable<Cobros> GetCobros()
        {
            return db.Cobros;
        }

        // GET: api/Cobros/5
        [ResponseType(typeof(Cobros))]
        public IHttpActionResult GetCobros(int id)
        {
            Cobros cobros = db.Cobros.Find(id);
            if (cobros == null)
            {
                return NotFound();
            }

            return Ok(cobros);
        }

        // PUT: api/Cobros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCobros(int id, Cobros cobros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cobros.IdCobro)
            {
                return BadRequest();
            }

            db.Entry(cobros).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CobrosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cobros
        [ResponseType(typeof(Cobros))]
        public IHttpActionResult PostCobros(Cobros cobros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cobros.Add(cobros);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cobros.IdCobro }, cobros);
        }

        // DELETE: api/Cobros/5
        [ResponseType(typeof(Cobros))]
        public IHttpActionResult DeleteCobros(int id)
        {
            Cobros cobros = db.Cobros.Find(id);
            if (cobros == null)
            {
                return NotFound();
            }

            db.Cobros.Remove(cobros);
            db.SaveChanges();

            return Ok(cobros);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CobrosExists(int id)
        {
            return db.Cobros.Count(e => e.IdCobro == id) > 0;
        }
    }
}