using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Import
{
    public class PiYarnDyeing
    {
        public int Id { get; set; }
        public double Upcharge { get; set; }
        public double Discount { get; set; }
        public int PiMasterId { get; set; }
        public int ItemCategoryId { get; set; }
        public string Wo { get; set; }
        public string Lot { get; set; }
        public string Count { get; set; }
        public string YarnDescription { get; set; }
        public string YarnColor { get; set; }
        public string ColorRange { get; set; }
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
