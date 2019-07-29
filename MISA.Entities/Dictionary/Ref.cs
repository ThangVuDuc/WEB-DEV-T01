using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA.Entities
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
    }
}