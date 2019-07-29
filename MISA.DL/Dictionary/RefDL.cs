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
            _ref.refID = Guid.NewGuid();
            db.Refs.Add(_ref);
            db.SaveChanges();
        }

        //Hàm thực hiện xóa dữ liệu phiếu thu
        //Người tạo: VDThang 29/07/2019
        public void DeleteRef(List<Guid> ids)
        {
            foreach (var id in ids)
            {
                var refitem = db.Refs.Where(p => p.refID == id).FirstOrDefault();
                db.Refs.Remove(refitem);
            }
            db.SaveChanges();
        }

        //Hàm thực hiện cập nhật dữ liệu phiếu thu
        //Người tạo: VDThang 29/07/2019
        public void UpdateRef(Ref _ref)
        {
            var refFind = db.Refs.Where(n => n.refID == _ref.refID).SingleOrDefault();
            refFind.refNo = _ref.refNo;
            refFind.refType = _ref.refType;
            refFind.refDate = _ref.refDate;
            refFind.reason = _ref.reason;
            refFind.total = _ref.total;
            refFind.contactName = _ref.contactName;
            db.SaveChanges();
        }

    }
}
