using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDevT01.Models
{
    public class Ref
    {
        public Guid refID { get; set; }
        public DateTime refDate { get; set; }
        public string refNo { get; set; }
        public string refType { get; set; }
        public decimal total { get; set; }
        public string contactName { get; set; }
        public string reason { get; set; }

        //static List<Ref> _refs = new List<Ref>
        //{
        //    new Ref()
        //    {
        //        refID = Guid.NewGuid(),
        //        refDate = new DateTime(2019, 7, 20),
        //        refNo = "PT001",
        //        refType = "Phiếu thu tiền mặt",
        //        total = 2000000,
        //        contactName = "Vũ Đức Thắng",
        //        reason = "Thu nợ tiền áo sơ mi"
        //    },
        //    new Ref()
        //    {
        //        refID = Guid.NewGuid(),
        //        refDate = new DateTime(2019, 7, 20),
        //        refNo = "PT002",
        //        refType = "Phiếu thu tiền mặt",
        //        total = 2000000,
        //        contactName = "Vũ Đức Thắng",
        //        reason = "Thu nợ tiền áo sơ mi"
        //    },
        //    new Ref()
        //    {
        //        refID = Guid.NewGuid(),
        //        refDate = new DateTime(2019, 7, 20),
        //        refNo = "PT003",
        //        refType = "Phiếu thu tiền mặt",
        //        total = 2000000,
        //        contactName = "Vũ Đức Thắng",
        //        reason = "Thu nợ tiền áo sơ mi"
        //    },
        //    new Ref()
        //    {
        //        refID = Guid.NewGuid(),
        //        refDate = new DateTime(2019, 7, 20),
        //        refNo = "PT004",
        //        refType = "Phiếu thu tiền mặt",
        //        total = 2000000,
        //        contactName = "Vũ Đức Thắng",
        //        reason = "Thu nợ tiền áo sơ mi"
        //    },
        //    new Ref()
        //    {
        //        refID = Guid.NewGuid(),
        //        refDate = new DateTime(2019, 7, 20),
        //        refNo = "PT005",
        //        refType = "Phiếu thu tiền mặt",
        //        total = 2000000,
        //        contactName = "Vũ Đức Thắng",
        //        reason = "Thu nợ tiền áo sơ mi"
        //    },
        //    new Ref()
        //    {
        //        refID = Guid.NewGuid(),
        //        refDate = new DateTime(2019, 7, 20),
        //        refNo = "PT006",
        //        refType = "Phiếu thu tiền mặt",
        //        total = 2000000,
        //        contactName = "Vũ Đức Thắng",
        //        reason = "Thu nợ tiền áo sơ mi"
        //    },
        //};

        //public static List<Ref> Refs
        //{
        //    get
        //    {
        //        return _refs;
        //    }
        //    set
        //    {
        //        _refs = value;
        //    }
        //}
    }
}