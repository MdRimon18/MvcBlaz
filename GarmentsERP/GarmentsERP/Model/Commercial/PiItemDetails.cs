using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial
{
    public class PiItemDetails
    {

        public int Id { get; set; }
        public int ItemGroupId { get; set; }
        public int ItemCategoryId { get; set; }
        public string ItemDescription { get; set; }
        public string BrandSuppRef { get; set; }
        public string GmtsColor { get; set; }
        public string GmtsSize { get; set; }
        public string ItemColor { get; set; }
        public string ItemSize { get; set; }
        public int UomId { get; set; }
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
