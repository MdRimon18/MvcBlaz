using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Inventory
{
    public class PurchaseRequisition
    {
        public int Id { get; set; }
        public string RequisitionNo { get; set; }
        public int CompanyId { get; set; }
        public int LocationId { get; set; }
        public string ForDivision { get; set; }
        public string ForDepartment { get; set; }
        public string ForSection { get; set; }
        public string ReqDate { get; set; }
        public string StoreName { get; set; }
        public string PayMode { get; set; }
        public string Source { get; set; }
        public int CurrencyId { get; set; }
        public string DeliveryDate { get; set; }
        public string ReqBy { get; set; }
        public string ManualReqNo { get; set; }
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


