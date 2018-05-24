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
using MisFeeApi.Models;

namespace MisFeeApi.Controllers
{
    public class FeeStructureApiController : ApiController
    {
        private MisFeesEntities db = new MisFeesEntities();

        // GET: api/FeeStructureApi
        public Array Gettbl_FeeStructure()
        {
            var selectResult = (from f in db.tbl_FeeStructure
                                select new
                                {
                                    f.FeeStructureId,
                                    f.ClassId,
                                    f.CategoryId,
                                    f.SubCategoryId,
                                    f.FeeStructureCost,
                                    f.tbl_Class.ClassName,
                                    f.tbl_Category.CategoryName,
                                    f.tbl_SubCategory.SubCategoryName
                                });
            return selectResult.ToArray();
            

        }
        // GET: api/FeeStructureApi/5
        [ResponseType(typeof(tbl_FeeStructure))]
        public IHttpActionResult Gettbl_FeeStructure(int id)
        {
            tbl_FeeStructure tbl_FeeStructure = db.tbl_FeeStructure.Find(id);
            if (tbl_FeeStructure == null)
            {
                return NotFound();
            }

            return Ok(tbl_FeeStructure);
        }

        // PUT: api/FeeStructureApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_FeeStructure(int id, tbl_FeeStructure tbl_FeeStructure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_FeeStructure.FeeStructureId)
            {
                return BadRequest();
            }

            db.Entry(tbl_FeeStructure).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_FeeStructureExists(id))
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

        // POST: api/FeeStructureApi
        [ResponseType(typeof(tbl_FeeStructure))]
        public IHttpActionResult Posttbl_FeeStructure(tbl_FeeStructure tbl_FeeStructure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_FeeStructure.Add(tbl_FeeStructure);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_FeeStructure.FeeStructureId }, tbl_FeeStructure);
        }

        // DELETE: api/FeeStructureApi/5
        [ResponseType(typeof(tbl_FeeStructure))]
        public IHttpActionResult Deletetbl_FeeStructure(int id)
        {
            tbl_FeeStructure tbl_FeeStructure = db.tbl_FeeStructure.Find(id);
            if (tbl_FeeStructure == null)
            {
                return NotFound();
            }

            db.tbl_FeeStructure.Remove(tbl_FeeStructure);
            db.SaveChanges();

            return Ok(tbl_FeeStructure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_FeeStructureExists(int id)
        {
            return db.tbl_FeeStructure.Count(e => e.FeeStructureId == id) > 0;
        }
    }
}