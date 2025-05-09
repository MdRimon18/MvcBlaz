using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial
{
    public class YarnPurchaseOrderDetails
    {
        public int Id { get; set; }
        public int YarnPurchaseOrderId { get; set; }
        public int YarnCostId { get; set; }
        public int RequisitionId { get; set; }
        public int OrderAutoId { get; set; }
        public string BuyerPO { get; set; }
        public string Requisition { get; set; }
        public string Color { get; set; }
        public int YarnCountId { get; set; }
        public int CompositionId { get; set; }
        public int Percentage { get; set; }
        public int TypeId { get; set; }
        public int UomId { get; set; }
        public string JobNo { get; set; }
        public string BuyerName { get; set; }
        public string Style { get; set; }
        public double Quantity { get; set; }
        public double Rate { get; set; }
        public double Value { get; set; }
        public string SampleDelvStart { get; set; }
        public string BulkDelvStart { get; set; }
        public string BulkDelvEnd { get; set; }
        public double NoofLot { get; set; }
        public string Remarks { get; set; }
        public int? pfbMasterId { get; set; }
        public int? ProceessId { get; set; }
        public string ModifyiedDate { get; set; }
        public bool IsModifyied { get; set; }
        public string ModifyiedBy { get; set; }


        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
