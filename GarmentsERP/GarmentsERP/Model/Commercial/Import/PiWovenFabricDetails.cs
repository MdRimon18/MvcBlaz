using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Import
{
    public class PiWovenFabricDetails
    {
        public int Id { get; set; }
        public int PiMasterId { get; set; }
        public int ItemCategoryId { get; set; }
        public int WoId { get; set; }
        public string Wo { get; set; }
        public string RdNo { get; set; }
        public string FabDescription { get; set; }
        public int FabDescId { get; set; }
        public string Color { get; set; }
        public string Weight { get; set; }
        public string WeightType { get; set; }
        public double DiaOrWidth { get; set; }
        public double Width { get; set; }
        public double CutableWidth { get; set; }
        public string Uom { get; set; }
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
