using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebDevT01.Models;

namespace WebDevT01.Controllers
{
    public class RefsDemoController : ApiController
    {
        //[Route("refs")]
        //[HttpGet]
        //public List<Ref> Get()
        //{
        //    return Ref.Refs;
        //}

        //[Route("refs/{id}")]
        //[HttpGet]
        //public string Get(Guid id)
        //{
        //    return "value";
        //}

        //[Route("refs")]
        //[HttpPost]
        //public void Post([FromBody]Ref _ref)
        //{
        //    _ref.refID = Guid.NewGuid();
        //    Ref.Refs.Add(_ref);
        //}

        //[Route("refs")]
        //[HttpPut]
        //public int Put([FromBody]Ref _ref)
        //{
        //    var refFind = Ref.Refs.Where(n => n.refID == _ref.refID).SingleOrDefault();
        //    if (refFind == null)
        //    {
        //        return -1;
        //    }
        //    refFind.refNo = _ref.refNo;
        //    refFind.refType = _ref.refType;
        //    refFind.refDate = _ref.refDate;
        //    refFind.reason = _ref.reason;

        //    return 1;
        //}

        //[Route("refs/{id}")]
        //[HttpDelete]
        //public void Delete(Guid id)
        //{
        //    var refitem = Ref.Refs.Where(p => p.refID == id).FirstOrDefault();
        //    Ref.Refs.Remove(refitem);
        //}

        //[Route("refs")]
        //[HttpDelete]
        //public void DeleteMultiple([FromBody]List<Guid> ids)
        //{
        //    foreach(var id in ids)
        //    {
        //        var refitem = Ref.Refs.Where(p => p.refID == id).FirstOrDefault();
        //        Ref.Refs.Remove(refitem);
        //    }
        //}
    }
}
