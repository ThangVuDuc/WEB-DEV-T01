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
using WebDevT01.Models;

namespace WebDevT01.Controllers
{
    public class RefsController : ApiController
    {
        private WebDevT01Context db = new WebDevT01Context();

        [Route("refs")]
        [HttpGet]
        public IEnumerable<Ref> GetRefs()
        {
            return db.Refs;
        }

        // GET: api/Refs/5
        [ResponseType(typeof(Ref))]
        public IHttpActionResult GetRef(Guid id)
        {
            Ref @ref = db.Refs.Find(id);
            if (@ref == null)
            {
                return NotFound();
            }

            return Ok(@ref);
        }

        [Route("refs")]
        [HttpPut]
        public int Put([FromBody]Ref _ref)
        {
            var refFind = db.Refs.Where(n => n.refID == _ref.refID).SingleOrDefault();
            if (refFind == null)
            {
                return -1;
            }
            refFind.refNo = _ref.refNo;
            refFind.refType = _ref.refType;
            refFind.refDate = _ref.refDate;
            refFind.reason = _ref.reason;
            db.SaveChanges();
            return 1;
        }


        [Route("refs")]
        [HttpPost]
        public void Post([FromBody]Ref _ref)
        {
            _ref.refID = Guid.NewGuid();
            db.Refs.Add(_ref);
            db.SaveChanges();
        }

        [Route("refs")]
        [HttpDelete]
        public void DeleteMultiple([FromBody]List<Guid> ids)
        {
            foreach (var id in ids)
            {
                var refitem = db.Refs.Where(p => p.refID == id).FirstOrDefault();
                db.Refs.Remove(refitem);
            }
            db.SaveChanges();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RefExists(Guid id)
        {
            return db.Refs.Count(e => e.refID == id) > 0;
        }
    }
}