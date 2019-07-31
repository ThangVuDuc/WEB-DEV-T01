using MISA.DL;
using MISA.Entities;
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
using WebDevT01.Properties;

namespace WebDevT01.Controllers
{
    public class RefsController : ApiController
    {
        private RefDL _refDL = new RefDL();
        /// <summary>
        /// Service thực hiện lấy dữ liệu bảng phiếu thu
        /// Người tạo VDThang 29/07/2019
        /// </summary>
        /// <returns>Dữ liệu bảng phiếu thu</returns>
        [Route("refs")]
        [HttpGet]
        public AjaxResult GetRefs()
        {
            var ajaxResult = new AjaxResult();
            try
            {
                ajaxResult.Data = _refDL.GetData();
            }catch(Exception ex)
            {
                ajaxResult.Data = ex;
                ajaxResult.Success = false;
                ajaxResult.Message = Resources.MessageVN;
            }
            return ajaxResult;
        }

        /// <summary>
        /// Service thực hiện thêm mới dữ liệu phiếu thu
        /// Người tạo VDThang 29/07/2019
        /// </summary>
        /// <param name="_ref"></param>
        [Route("refs")]
        [HttpPost]
        public AjaxResult Post([FromBody]Ref _ref)
        {
            var ajaxResult = new AjaxResult();
            try
            {
                _refDL.AddRef(_ref);
            }
            catch (Exception ex)
            {
                ajaxResult.Data = ex;
                ajaxResult.Success = false;
                ajaxResult.Message = Resources.MessageVN;
            }
            return ajaxResult;
        }

        /// <summary>
        /// Hàm thực hiện xóa phiếu thu
        /// Người tạo VDThang 29/07/2019
        /// </summary>
        /// <param name="ids"></param>
        [Route("refs")]
        [HttpDelete]
        public AjaxResult DeleteMultiple([FromBody]List<Guid> ids)
        {
            var ajaxResult = new AjaxResult();
            try
            {
                _refDL.DeleteRef(ids);
            }
            catch (Exception ex)
            {
                ajaxResult.Data = ex;
                ajaxResult.Success = false;
                ajaxResult.Message = Resources.MessageVN;
            }
            return ajaxResult;
        }
        /// <summary>
        /// Hàm thực hiện lấy phiếu thu theo trường id
        /// Người tạo VDThang 29/07/2019
        /// </summary>
        /// <param name="id">Phiếu thu có id tương ứng</param>
        /// <returns></returns>
        //[Route("refs/{id}")]
        //[HttpGet]
        //public Ref GetRefs(Guid id)
        //{
        //    var refitem = db.Refs.Where(p => p.refID == id).FirstOrDefault();
        //    return refitem;
        //}

        ///// <summary>
        ///// Hàm thực hiện sửa phiếu thu
        ///// Người tạo VDThang 29/07/2019
        ///// </summary>
        ///// <param name="_ref"></param>
        ///// <returns></returns>
        [Route("refs")]
        [HttpPut]
        public AjaxResult Put([FromBody]Ref _ref)
        {
            var ajaxResult = new AjaxResult();
            try
            {
                _refDL.UpdateRef(_ref);
            }
            catch (Exception ex)
            {
                ajaxResult.Data = ex;
                ajaxResult.Success = false;
                ajaxResult.Message = Resources.MessageVN;
            }
            return ajaxResult;
        }
    }
}