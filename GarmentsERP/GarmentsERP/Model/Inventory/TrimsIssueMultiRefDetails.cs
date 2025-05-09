using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class TrimsIssueMultiRefDetails
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string OrderNo { get; set; }
        public int ItemGroup { get; set; }
        public int ItemDescription { get; set; }
        public string BrandBySupRef { get; set; }
        public int ItemColor { get; set; }
        public string ItemSize { get; set; }
        public int Uom { get; set; }
        public double IssueQnty { get; set; }
        public double RecvQty { get; set; }
        public string CumulIssued { get; set; }
        public string YettoIssue { get; set; }
        public int Floor { get; set; }
        public int SewingLineNo { get; set; }
        public double StockQty { get; set; }


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
