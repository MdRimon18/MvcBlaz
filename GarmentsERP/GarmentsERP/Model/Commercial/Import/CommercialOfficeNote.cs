using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Import
{
    public class CommercialOfficeNote
    {
        public int Id { get; set; }
        public string SystemID { get; set; }
        public int ImporterId { get; set; }
        public string OfficeNoteDate { get; set; }
        public string LCType { get; set; }
        public string ProFormaInvoice { get; set; }
        public string ReadyToApprove { get; set; }
        public string Remarks { get; set; }


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
