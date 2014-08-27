using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.OData;
using AdminKiosco.HTML5.Model;

namespace AdminKiosco.HTML5.Controllers
{
    public class FeriadosController : ODataController
    {
        private Entities db = new Entities();

        // GET: odata/Feriados
        [EnableQuery(PageSize = 10)]
        public IQueryable<Feriado> GetFeriados()
        {
            return db.Feriados;
        }

        // GET: odata/Feriados(5)
        [EnableQuery]
        public SingleResult<Feriado> GetFeriado([FromODataUri] int key)
        {
            return SingleResult.Create(db.Feriados.Where(Feriado => Feriado.Id == key));
        }

        // PUT: odata/Feriados(5)
        public IHttpActionResult Put([FromODataUri] int key, Feriado Feriado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != Feriado.Id)
            {
                return BadRequest();
            }

            db.Entry(Feriado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeriadoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(Feriado);
        }

        // POST: odata/Feriados
        public IHttpActionResult Post(Feriado Feriado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Feriados.Add(Feriado);
            db.SaveChanges();

            return Created(Feriado);
        }

        // PATCH: odata/Feriados(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Feriado> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Feriado Feriado = db.Feriados.Find(key);
            if (Feriado == null)
            {
                return NotFound();
            }

            patch.Patch(Feriado);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeriadoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(Feriado);
        }

        // DELETE: odata/Feriados(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Feriado Feriado = db.Feriados.Find(key);
            if (Feriado == null)
            {
                return NotFound();
            }

            db.Feriados.Remove(Feriado);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeriadoExists(int key)
        {
            return db.Feriados.Count(e => e.Id == key) > 0;
        }
    }
}
