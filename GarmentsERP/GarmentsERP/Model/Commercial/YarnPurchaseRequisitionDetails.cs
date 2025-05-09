using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial
{
    public class YarnPurchaseRequisitionDetails
    {

        public int Id { get; set; }
        public int YarnPurchaseRequisitionId { get; set; }
        public string JobNo { get; set; }
        public string FabBooking { get; set; }
        public int BuyerProfileId { get; set; }
        public string Style { get; set; }
        public string YarnColor { get; set; }
        public int YarnCountId { get; set; }
        public int CompositionId { get; set; }
        public int Percentage { get; set; }
        public int YarnTypeId { get; set; }
        public int UomId { get; set; }
        public double RequisitionQty { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public string YarnInhouseDate { get; set; }
        public string Remarks { get; set; }

        public string EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
