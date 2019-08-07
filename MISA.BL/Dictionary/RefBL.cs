using MISA.DL;
using MISA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL
{
    public class RefBL
    {
        private RefDL _refDL = new RefDL();
        public IEnumerable<Ref> SearchRef(string _refType, string _refValue)
        {
            IEnumerable<Ref> _refs = _refDL.GetAllData();
            switch (_refType)
            {
                case "2":
                    _refs = _refs.Where(p => p.RefNo.Contains(_refValue));
                    break;
                case "3":
                    _refs = _refs.Where(p => p.RefType == _refValue);
                    break;
            }
            return _refs;
        }
    }
}
