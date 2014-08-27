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

    public class KioscosController : ODataController
    {
        private Entities db = new Entities();

        // GET: odata/Kioscos
        [EnableQuery(PageSize = 10)]
        public IQueryable<Kiosco> GetKioscos()
        {
            return db.Kioscos;
        }

        // GET: odata/Kioscos(5)
        [EnableQuery]
        public SingleResult<Kiosco> GetKiosco([FromODataUri] int key)
        {
            return SingleResult.Create(db.Kioscos.Where(kiosco => kiosco.Id == key));
        }

        // PUT: odata/Kioscos(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Kiosco> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Kiosco kiosco = db.Kioscos.Find(key);
            if (kiosco == null)
            {
                return NotFound();
            }

            patch.Put(kiosco);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KioscoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(kiosco);
        }

        // POST: odata/Kioscos
        public IHttpActionResult Post(Kiosco kiosco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kioscos.Add(kiosco);
            db.SaveChanges();

            return Created(kiosco);
        }

        // PATCH: odata/Kioscos(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Kiosco> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Kiosco kiosco = db.Kioscos.Find(key);
            if (kiosco == null)
            {
                return NotFound();
            }

            patch.Patch(kiosco);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KioscoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(kiosco);
        }

        // DELETE: odata/Kioscos(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Kiosco kiosco = db.Kioscos.Find(key);
            if (kiosco == null)
            {
                return NotFound();
            }

            db.Kioscos.Remove(kiosco);
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

        private bool KioscoExists(int key)
        {
            return db.Kioscos.Count(e => e.Id == key) > 0;
        }
    }
}
