using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Import
{
    public class PiKnitFinishFabric
    {
        public int Id { get; set; }
        
        public int PiMasterId { get; set; }
        public int ItemCategoryId { get; set; }
        public int WoId { get; set; }
        public string Wo { get; set; }
        public string HsCode { get; set; }
        public int FabDescId { get; set; }
        public string FabDescription { get; set; }
        public string Construction { get; set; }
        public string Composition { get; set; }
        public string Color { get; set; }
        public double GSM { get; set; }
        public double DiaOrWidth { get; set; }
        public string UOM { get; set; }
        public double Quantity { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public double Upcharge { get; set; }
        public double Discount { get; set; }


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
