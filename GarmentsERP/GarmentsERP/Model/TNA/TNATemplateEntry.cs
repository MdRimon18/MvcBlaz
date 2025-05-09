using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.TNA
{
    public class TNATemplateEntry
    {
        public int Id { get; set; }
        public string SystemID { get; set; }
        public int Buyer { get; set; }
        public double LeadTime { get; set; }
        public string MaterialSource { get; set; }
        public int Type { get; set; }
        public int TotalTask { get; set; }


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
