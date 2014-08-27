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
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using AdminKiosco.Entities;

namespace AdminKiosco.HTML5.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using AdminKiosco.Entities;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Kiosco>("Kiosco");
    builder.EntitySet<Cliente>("Cliente"); 
    builder.EntitySet<DistribuidorKiosco>("DistribuidorKiosco"); 
    builder.EntitySet<KioscoUsuario>("KioscoUsuario"); 
    builder.EntitySet<MovimientosDiarios>("MovimientosDiarios"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class KioscoController : ODataController
    {
        private PaperEntities db = new PaperEntities();

        // GET: odata/Kiosco
        [EnableQuery(PageSize=15)]
        public IQueryable<Kiosco> GetKiosco()
        {
            return db.Kiosco;
        }

        // GET: odata/Kiosco(5)
        [EnableQuery]
        public SingleResult<Kiosco> GetKiosco([FromODataUri] int key)
        {
            return SingleResult.Create(db.Kiosco.Where(kiosco => kiosco.Id == key));
        }

        // PUT: odata/Kiosco(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Kiosco> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Kiosco kiosco = db.Kiosco.Find(key);
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

        // POST: odata/Kiosco
        public IHttpActionResult Post(Kiosco kiosco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kiosco.Add(kiosco);
            db.SaveChanges();

            return Created(kiosco);
        }

        // PATCH: odata/Kiosco(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Kiosco> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Kiosco kiosco = db.Kiosco.Find(key);
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

        // DELETE: odata/Kiosco(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Kiosco kiosco = db.Kiosco.Find(key);
            if (kiosco == null)
            {
                return NotFound();
            }

            db.Kiosco.Remove(kiosco);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Kiosco(5)/Cliente
        [EnableQuery]
        public IQueryable<Cliente> GetCliente([FromODataUri] int key)
        {
            return db.Kiosco.Where(m => m.Id == key).SelectMany(m => m.Cliente);
        }

        // GET: odata/Kiosco(5)/DistribuidorKiosco
        [EnableQuery]
        public IQueryable<DistribuidorKiosco> GetDistribuidorKiosco([FromODataUri] int key)
        {
            return db.Kiosco.Where(m => m.Id == key).SelectMany(m => m.DistribuidorKiosco);
        }

        // GET: odata/Kiosco(5)/KioscoUsuario
        [EnableQuery]
        public IQueryable<KioscoUsuario> GetKioscoUsuario([FromODataUri] int key)
        {
            return db.Kiosco.Where(m => m.Id == key).SelectMany(m => m.KioscoUsuario);
        }

        // GET: odata/Kiosco(5)/MovimientosDiarios
        [EnableQuery]
        public IQueryable<MovimientosDiarios> GetMovimientosDiarios([FromODataUri] int key)
        {
            return db.Kiosco.Where(m => m.Id == key).SelectMany(m => m.MovimientosDiarios);
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
            return db.Kiosco.Count(e => e.Id == key) > 0;
        }
    }
}
