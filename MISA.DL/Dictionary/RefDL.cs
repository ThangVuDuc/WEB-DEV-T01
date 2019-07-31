using MISA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL
{
    public class RefDL
    {
        private WebDevT01Context db = new WebDevT01Context();
        //Hàm thực hiện lấy dữ liệu data các phiếu thu
        //Người tạo: VDThang 29/07/2019
        public IEnumerable<Ref> GetData()
        {
            return db.Refs;
        }

        //Hàm thực hiện thêm mới dữ liệu data các phiếu thu
        //Người tạo: VDThang 29/07/2019
        public void AddRef(Ref _ref)
        {
            _ref.RefID = Guid.NewGuid();
            db.Refs.Add(_ref);
            db.SaveChanges();
        }

        //Hàm thực hiện xóa dữ liệu phiếu thu
        //Người tạo: VDThang 29/07/2019
        public void DeleteRef(List<Guid> ids)
        {
            foreach (var id in ids)
            {
                var refitem = db.Refs.Where(p => p.RefID == id).FirstOrDefault();
                db.Refs.Remove(refitem);
            }
            db.SaveChanges();
        }

        //Hàm thực hiện cập nhật dữ liệu phiếu thu
        //Người tạo: VDThang 29/07/2019
        public void UpdateRef(Ref _ref)
        {
            var refFind = db.Refs.Where(n => n.RefID == _ref.RefID).SingleOrDefault();
            refFind.RefNo = _ref.RefNo;
            refFind.RefType = _ref.RefType;
            refFind.RefDate = _ref.RefDate;
            refFind.Reason = _ref.Reason;
            refFind.Total = _ref.Total;
            refFind.ContactName = _ref.ContactName;
            db.SaveChanges();
        }

        //Hàm thực hiện lấy các bản ghi chi tiết cho phiếu thu tương ứng
        //Người tạo: VDThang 31/07/2019
        public IEnumerable<RefDetail> GetRefDetail(Guid _refID)
        {
            var _listRef = db.RefDetails.Where(p => p.RefID == _refID).ToList();
            return _listRef;
        }

    }
}
