using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Shared
{
    public class PageObjectCreatorMaster
    {
        public int Id { get; set; }
        
        public string ClassName { get; set; }
        public string ServiceName { get; set; }
        public string SinglePageOrMultiline { get; set; }
        public string PageTitleName { get; set; }
        public string ModuleName { get; set; }

        public string Status { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }

        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }

        public string ModifyiedDate { get; set; }
        public bool IsModifyied { get; set; }
        public string ModifyiedBy { get; set; }


    }
}
