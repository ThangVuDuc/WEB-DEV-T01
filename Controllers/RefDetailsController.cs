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
using MISA.DL;
using MISA.Entities;
using WebDevT01.Properties;

namespace WebDevT01.Controllers
{
    public class RefDetailsController : ApiController
    {
        private RefDL _refDL = new RefDL();

        /// <summary>
        /// Service thực hiện lấy phiếu chi tiết cho phiếu thu
        /// Ngươi tạo: VDThang 31/07/2019
        /// </summary>
        /// <param name="refid"></param>
        /// <returns></returns>
        [Route("refdetails/{refid}")]
        [HttpGet]
        public AjaxResult GetDataByRefID(Guid refid)
        {
            var _ajaxResult = new AjaxResult();
            try
            {
                _ajaxResult.Data = _refDL.GetRefDetail(refid);
            }catch(Exception ex)
            {
                _ajaxResult.Data = ex;
                _ajaxResult.Success = false;
                _ajaxResult.Message = Resources.MessageVN;
            }
            return _ajaxResult;
        }
    }
}