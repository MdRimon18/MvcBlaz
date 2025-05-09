using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class GatePassEntry
    {
        public int Id { get; set; }
        public string GatePassID { get; set; }
        public int CompanyId { get; set; }
        public string Basis { get; set; }
        public string SystemIDChallanNo { get; set; }
        public int FromLocation { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string WithinGroup { get; set; }
        public string SentTo { get; set; }
        public string ToLocation { get; set; }
        public string OutDate { get; set; }
        public string OutTimeHoure { get; set; }
        public string OutTimeMin { get; set; }
        public string Attention { get; set; }
        public string Returnable { get; set; }
        public string EstReturnDate { get; set; }
        public string DeliveryAs { get; set; }
        public string Purpose { get; set; }
        public string Carriedby { get; set; }
        public string SentBy { get; set; }
        public string VhicleNumber { get; set; }
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
