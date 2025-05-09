using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class ScrapOutEntry
    {
        public int Id { get; set; }
        public string SystemChallanNo { get; set; }
        public int CompanyId { get; set; }
        public int ItemCategory { get; set; }
        public string SellingDate { get; set; }
        public string PayTerm { get; set; }
        public string Customer { get; set; }
        public int CurrencyId { get; set; }
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
