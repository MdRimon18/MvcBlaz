using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.PIBreakDown
{
    public class ProFormaInvoiceYarnChild
    {
        public int Id { get; set; }
        public int Wo { get; set; }
        public int PiMasterId { get; set; }
        public string Color { get; set; }
        public int CountId { get; set; }
        public int CompFirst { get; set; }
        public string CompSecnd { get; set; }
        public int YarnTypeId { get; set; }
        public string Uom { get; set; }
        public double Quantity { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }


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
