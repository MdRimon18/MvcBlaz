using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Shared
{
    public class Search
    {
        public string FilterValue { get; set; }

        public string buyerName { get; set; }
        public string entryDate { get; set; }
        public string jobNo { get; set; }
        public string prodCatName { get; set; }
        public string prodDeptName { get; set; }
        public string style_Ref { get; set; }

        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
   
}
