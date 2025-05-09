using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarmentsERP.Model.Commercial.Export
{
    public class ExportLCAmendmentRecord
    {
        public int Id { get; set; }
        public int ExportLcMasterId { get; set; }
        public string AmendmentNo { get; set; }
        public string AmendmentDate { get; set; }
        public double AmendmentValue { get; set; }
        public string ValueChangedBy { get; set; }
        public string LastShipDatee { get; set; }
        public string ExpiryDatee { get; set; }
        public int ShippingModeId { get; set; }
        public string IncoTerm { get; set; }
        public string IncoTermPlace { get; set; }
        public string PortofEntry { get; set; }
        public string PortofLoading { get; set; }
        public string PortofDischarge { get; set; }
        public string PayTerm { get; set; }
        public double Tenor { get; set; }
        public double ClaimAdjust { get; set; }
        public string ClaimAdjustBy { get; set; }
        public string DiscountClauses { get; set; }
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
